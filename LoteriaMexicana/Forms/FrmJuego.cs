using LoteriaMexicana.Models;
using LoteriaMexicana.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WMPLib;

namespace LoteriaMexicana.Forms
{
    public partial class FrmJuego : Form
    {
        private Baraja _baraja;
        private CartonJugador _carton;

        private List<CartonJugador> _cartonesJugador = new List<CartonJugador>();
        private List<int> _indicesCartonesEnDesempate = new List<int>();
        private int _indiceCartonActual = 0;
        private int _cantidadCartones = 1;
        private OpcionesVictoria _opcionesVictoria;
        private string _nombreGanadorActual = "";
        // --- AÑADIDO: panel lateral config ---
        private bool[,] _patronVictoriaPersonalizado_Lateral;
        // --- FIN AÑADIDO ---

        private Button btnCartonAnterior;
        private Button btnCartonSiguiente;
        private Label lblCartonActual;

        private bool _modoAuto = false;
        private bool _jugando = false;

        private PictureBox[,] _picsCarton =
            new PictureBox[CartonJugador.FILAS, CartonJugador.COLUMNAS];
        private List<PictureBox[,]> _picsCartones =
            new List<PictureBox[,]>();
        private Timer timerAuto;
        private Label lblEstadoRed;
        private bool _ajustandoLayout = false;

        private Image _imagenFicha;
        private WindowsMediaPlayer _playerCarta;

        private const int PUERTO = 5000;

        private ServidorLoteria _servidor;
        private ClienteLoteria _cliente;

        private bool _soyServidor = false;
        private bool _soyCliente = false;
        private string _nombreJugador = "Jugador";

        List<string> cartonesUsados = new List<string>();

        public FrmJuego(int cantidadCartones, OpcionesVictoria opcionesVictoria)
        {
            InitializeComponent();
            InicializarControlesFaltantes();
            // --- AÑADIDO: panel lateral config ---
            ConfigurarValoresIniciales_Lateral();
            CargarPatrones_Lateral();
            // --- FIN AÑADIDO ---

            _cantidadCartones = cantidadCartones;
            _opcionesVictoria = opcionesVictoria ?? new OpcionesVictoria
            {
                Horizontal = true,
                Vertical = true,
                Diagonal = true,
                Lleno = true
            };
            // --- AÑADIDO: panel lateral config ---
            SincronizarOpcionesVictoria_Lateral();
            // --- FIN AÑADIDO ---

            timerAuto.Interval = 3000;

            InicializarOpciones();
            CrearControlesCartones();
            InicializarJuego();
            AjustarLayoutPantallaGrande();

            _jugando = true;
        }

        public FrmJuego() : this(1, null)
        {
        }

        private void InicializarControlesFaltantes()
        {
            if (components == null)
                components = new System.ComponentModel.Container();

            if (timerAuto == null)
            {
                timerAuto = new Timer(components);
                timerAuto.Tick += timerAuto_Tick;
            }

            if (lblEstadoRed == null)
            {
                lblEstadoRed = new Label();
                lblEstadoRed.AutoSize = true;
                lblEstadoRed.BackColor = Color.DarkRed;
                lblEstadoRed.ForeColor = Color.White;
                lblEstadoRed.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                lblEstadoRed.Location = new Point(52, 345);
                lblEstadoRed.Text = "Red Local: Sin conexión";

                if (pnlConfigLateral != null)
                {
                    pnlConfigLateral.Controls.Add(lblEstadoRed);
                    lblEstadoRed.BringToFront();
                }
                else
                {
                    Controls.Add(lblEstadoRed);
                }
            }

            lstHistorial.DrawMode = DrawMode.OwnerDrawFixed;
            lstHistorial.ItemHeight = 58;
            lstHistorial.DrawItem -= lstHistorial_DrawItem;
            lstHistorial.DrawItem += lstHistorial_DrawItem;

            panelCarton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlConfigLateral.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Resize -= FrmJuego_Resize;
            Resize += FrmJuego_Resize;
        }

        private void FrmJuego_Resize(object sender, EventArgs e)
        {
            AjustarLayoutPantallaGrande();
        }

        private void AjustarLayoutPantallaGrande()
        {
            if (_ajustandoLayout || panelCarton == null || pnlConfigLateral == null)
                return;

            _ajustandoLayout = true;

            int margen = 12;
            int izquierda = pictureBox1 != null ? pictureBox1.Right + margen : 219;
            int derecha = pnlConfigLateral.Left - margen;
            int arriba = Math.Max(24, panelCarton.Top);
            int abajo = ClientSize.Height - margen;

            if (pictureBox1 != null)
                pictureBox1.Height = ClientSize.Height;

            if (derecha > izquierda + 100 && abajo > arriba + 100)
            {
                panelCarton.Location = new Point(izquierda, arriba);
                panelCarton.Size = new Size(derecha - izquierda, abajo - arriba - 40);

                if (btnCartonAnterior != null)
                {
                    int yNavegacion = panelCarton.Bottom + 8;
                    btnCartonAnterior.Location = new Point(panelCarton.Left, yNavegacion);
                    btnCartonSiguiente.Location = new Point(panelCarton.Left + panelCarton.Width - btnCartonSiguiente.Width, yNavegacion);
                    lblCartonActual.Location = new Point(
                        panelCarton.Left + (panelCarton.Width - lblCartonActual.Width) / 2,
                        yNavegacion + 5);
                }

                if (_cartonesJugador != null && _cartonesJugador.Count > 0)
                {
                    DibujarTodosLosCartones();
                    ActualizarGridCarton();
                }
            }

            _ajustandoLayout = false;
        }

        private void InicializarOpciones()
        {
            nudVelocidad.Minimum = 1;
            nudVelocidad.Maximum = 10;
            nudVelocidad.Value = 3;
        }

        // --- AÑADIDO: panel lateral config ---
        private void ConfigurarValoresIniciales_Lateral()
        {
            nudCantidadCartones_Lateral.Minimum = 1;
            nudCantidadCartones_Lateral.Maximum = int.MaxValue;
            nudCantidadCartones_Lateral.Value = 1;
        }

        private void SincronizarOpcionesVictoria_Lateral()
        {
            if (nudCantidadCartones_Lateral != null)
                nudCantidadCartones_Lateral.Value = _cantidadCartones;

            if (chkdFormaVictoria_Lateral == null)
                return;

            for (int i = 0; i < chkdFormaVictoria_Lateral.Items.Count; i++)
                chkdFormaVictoria_Lateral.SetItemChecked(i, false);

            MarcarFormaVictoria_Lateral("Línea horizontal", _opcionesVictoria.Horizontal);
            MarcarFormaVictoria_Lateral("Línea vertical", _opcionesVictoria.Vertical);
            MarcarFormaVictoria_Lateral("Diagonal", _opcionesVictoria.Diagonal);
            MarcarFormaVictoria_Lateral("Cartón lleno", _opcionesVictoria.Lleno);
        }

        private void MarcarFormaVictoria_Lateral(string texto, bool marcado)
        {
            int indice = chkdFormaVictoria_Lateral.Items.IndexOf(texto);

            if (indice >= 0)
                chkdFormaVictoria_Lateral.SetItemChecked(indice, marcado);
        }

        private bool[,] CopiarPatronPersonalizado_Lateral(bool[,] patronOriginal)
        {
            if (patronOriginal == null)
                return null;

            bool[,] patronCopia = new bool[5, 5];

            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    patronCopia[fila, columna] = patronOriginal[fila, columna];
                }
            }

            return patronCopia;
        }
        // --- FIN AÑADIDO ---

        private void InicializarJuego()
        {
            CargarImagenFicha();

            _baraja = new Baraja();
            _cartonesJugador.Clear();
            _indicesCartonesEnDesempate.Clear();

            for (int i = 0; i < _cantidadCartones; i++)
            {
                _cartonesJugador.Add(new CartonJugador(ObtenerTodasLasCartas()));
            }

            _indiceCartonActual = 0;
            _carton = _cartonesJugador[_indiceCartonActual];

            DibujarTodosLosCartones();
            ActualizarGridCarton();
            ActualizarEtiquetaCarton();

            picCartaActual.SizeMode = PictureBoxSizeMode.StretchImage;
            picCartaActual.Image = null;

            lblContador.Text = "Cartas: 0 / 54";
            LimpiarHistorial();

            _jugando = true;
            _modoAuto = false;

            timerAuto.Stop();

            btnAuto.Text = "Auto: OFF";
            btnAuto.Enabled = true;
            btnSacarCarta.Enabled = true;
            btnGuardarCarton.Enabled = true;
            btnCargarCarton.Enabled = true;
            btnCrearCarton.Enabled = true;
            btnBuenas.Enabled = true;
            nudVelocidad.Enabled = true;

            AplicarModoRed();
        }

        private void CrearControlesCartones()
        {
            if (btnCartonAnterior != null)
                return;

            lblCartonActual = new Label();
            lblCartonActual.AutoSize = true;
            lblCartonActual.BackColor = Color.Transparent;
            lblCartonActual.ForeColor = Color.White;
            lblCartonActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCartonActual.Location = new Point(panelCarton.Left + 135, panelCarton.Bottom + 6);
            lblCartonActual.Text = "Cartón 1 de 1";

            btnCartonAnterior = new Button();
            btnCartonAnterior.Text = "Anterior";
            btnCartonAnterior.Size = new Size(90, 30);
            btnCartonAnterior.Location = new Point(panelCarton.Left, panelCarton.Bottom + 2);
            btnCartonAnterior.Click += btnCartonAnterior_Click;

            btnCartonSiguiente = new Button();
            btnCartonSiguiente.Text = "Siguiente";
            btnCartonSiguiente.Size = new Size(90, 30);
            btnCartonSiguiente.Location = new Point(panelCarton.Left + 280, panelCarton.Bottom + 2);
            btnCartonSiguiente.Click += btnCartonSiguiente_Click;

            Controls.Add(lblCartonActual);
            Controls.Add(btnCartonAnterior);
            Controls.Add(btnCartonSiguiente);

            lblCartonActual.BringToFront();
            btnCartonAnterior.BringToFront();
            btnCartonSiguiente.BringToFront();
        }

        private void DibujarTodosLosCartones()
        {
            panelCarton.SuspendLayout();
            panelCarton.Controls.Clear();
            _picsCartones.Clear();

            if (_cartonesJugador == null || _cartonesJugador.Count == 0)
            {
                panelCarton.ResumeLayout();
                return;
            }

            int total = _cartonesJugador.Count;
            int anchoPanel = Math.Max(1, panelCarton.ClientSize.Width);
            int altoPanel = Math.Max(1, panelCarton.ClientSize.Height);
            int mejorColumnas = 1;
            int mejorFilas = total;
            int mejorCelda = 1;

            for (int columnas = 1; columnas <= total; columnas++)
            {
                int filas = (int)Math.Ceiling(total / (double)columnas);
                int anchoDisponible = (anchoPanel - 12 - (columnas - 1) * 10) / columnas;
                int altoDisponible = (altoPanel - 12 - (filas - 1) * 12) / filas;
                int celdaPorAncho = (anchoDisponible - 8) / CartonJugador.COLUMNAS;
                int celdaPorAlto = (altoDisponible - 22) / CartonJugador.FILAS;
                int celda = Math.Min(celdaPorAncho, celdaPorAlto);

                if (celda > mejorCelda)
                {
                    mejorCelda = celda;
                    mejorColumnas = columnas;
                    mejorFilas = filas;
                }
            }

            int margenCelda = mejorCelda >= 18 ? 3 : 1;
            int celdaFinal = Math.Max(1, mejorCelda);
            int anchoCarton = CartonJugador.COLUMNAS * celdaFinal + (CartonJugador.COLUMNAS - 1) * margenCelda;
            int altoCarton = CartonJugador.FILAS * celdaFinal + (CartonJugador.FILAS - 1) * margenCelda;
            int anchoBloque = Math.Max(1, (anchoPanel - 12 - (mejorColumnas - 1) * 10) / mejorColumnas);
            int altoBloque = Math.Max(1, (altoPanel - 12 - (mejorFilas - 1) * 12) / mejorFilas);

            for (int indiceCarton = 0; indiceCarton < total; indiceCarton++)
            {
                int filaBloque = indiceCarton / mejorColumnas;
                int columnaBloque = indiceCarton % mejorColumnas;
                int baseX = 6 + columnaBloque * (anchoBloque + 10);
                int baseY = 6 + filaBloque * (altoBloque + 12);
                int gridX = baseX + Math.Max(0, (anchoBloque - anchoCarton) / 2);
                int gridY = baseY + 18;

                Label lblTabla = new Label();
                lblTabla.AutoSize = false;
                lblTabla.BackColor = Color.Transparent;
                lblTabla.ForeColor = Color.Maroon;
                lblTabla.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
                lblTabla.Location = new Point(baseX, baseY);
                lblTabla.Size = new Size(anchoBloque, 16);
                lblTabla.Text = "Tabla " + (indiceCarton + 1);
                panelCarton.Controls.Add(lblTabla);

                PictureBox[,] pics = new PictureBox[CartonJugador.FILAS, CartonJugador.COLUMNAS];

                for (int f = 0; f < CartonJugador.FILAS; f++)
                {
                    for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                    {
                        PictureBox pic = new PictureBox();
                        pic.Name = $"pic_{indiceCarton}_{f}_{c}";
                        pic.Size = new Size(celdaFinal, celdaFinal);
                        pic.Location = new Point(
                            gridX + c * (celdaFinal + margenCelda),
                            gridY + f * (celdaFinal + margenCelda));
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Tag = $"{indiceCarton},{f},{c}";
                        pic.Cursor = Cursors.Hand;
                        pic.BackColor = Color.Transparent;
                        pic.BorderStyle = BorderStyle.FixedSingle;
                        pic.Click += PicCarton_Click;

                        panelCarton.Controls.Add(pic);
                        pics[f, c] = pic;

                        if (indiceCarton == _indiceCartonActual)
                            _picsCarton[f, c] = pic;
                    }
                }

                _picsCartones.Add(pics);
            }

            panelCarton.ResumeLayout();
        }

        private void ActualizarEtiquetaCarton()
        {
            if (lblCartonActual == null)
                return;

            lblCartonActual.Text = $"Cartón {_indiceCartonActual + 1} de {_cartonesJugador.Count}";

            bool hayMasDeUno = _cartonesJugador.Count > 1;

            btnCartonAnterior.Enabled = hayMasDeUno && _jugando;
            btnCartonSiguiente.Enabled = hayMasDeUno && _jugando;
        }

        private void MostrarCarton(int indice)
        {
            if (_cartonesJugador == null || _cartonesJugador.Count == 0)
                return;

            if (indice < 0)
                indice = _cartonesJugador.Count - 1;

            if (indice >= _cartonesJugador.Count)
                indice = 0;

            _indiceCartonActual = indice;
            _carton = _cartonesJugador[_indiceCartonActual];

            if (_indiceCartonActual < _picsCartones.Count)
                _picsCarton = _picsCartones[_indiceCartonActual];

            ActualizarGridCarton();
            ActualizarEtiquetaCarton();
        }

        private void btnCartonAnterior_Click(object sender, EventArgs e)
        {
            MostrarCarton(_indiceCartonActual - 1);
        }

        private void btnCartonSiguiente_Click(object sender, EventArgs e)
        {
            MostrarCarton(_indiceCartonActual + 1);
        }

        private void CargarImagenFicha()
        {
            try
            {
                string ruta = Path.Combine(
                    Application.StartupPath, "Resources", "Images", "ficha.png");

                if (!File.Exists(ruta))
                {
                    MessageBox.Show("No se encontró la ficha en:\n" + ruta);
                    return;
                }

                byte[] bytes = File.ReadAllBytes(ruta);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (Image img = Image.FromStream(ms))
                    {
                        _imagenFicha = new Bitmap(img);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ficha:\n" + ex.Message);
            }
        }

        private void AgregarMensajeChat(string mensaje)
        {
            if (lstChat == null)
                return;

            lstChat.Items.Add(mensaje);
            lstChat.TopIndex = lstChat.Items.Count - 1;
        }

        private void ReproducirAudioCarta(Carta carta)
        {
            if (carta == null)
                return;

            try
            {
                string ruta = Path.Combine(
                    Application.StartupPath,
                    "Resources",
                    "Sounds",
                    $"carta_{carta.Id}.mpeg");

                if (!File.Exists(ruta))
                    return;

                if (_playerCarta == null)
                    _playerCarta = new WindowsMediaPlayer();

                _playerCarta.controls.stop();
                _playerCarta.URL = ruta;
                _playerCarta.controls.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reproducir audio:\n" + ex.Message);
            }
        }

        private List<Carta> ObtenerTodasLasCartas()
        {
            Baraja temp = new Baraja();
            List<Carta> lista = new List<Carta>();

            Carta c;

            while ((c = temp.SiguienteCarta()) != null)
            {
                lista.Add(c);
            }

            return lista;
        }

        private Carta BuscarCartaPorId(int id)
        {
            Baraja temp = new Baraja();
            return temp.ObtenerCartaPorId(id);
        }

        private void AgregarAlHistorial(Carta carta)
        {
            if (carta == null)
                return;

            lstHistorial.Items.Insert(0, carta);
        }

        private void lstHistorial_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0 || e.Index >= lstHistorial.Items.Count)
                return;

            Carta carta = lstHistorial.Items[e.Index] as Carta;

            if (carta == null)
                return;

            Rectangle rectImagen = new Rectangle(
                e.Bounds.Left + (e.Bounds.Width - 42) / 2,
                e.Bounds.Top + 4,
                42,
                e.Bounds.Height - 8);

            if (carta.Imagen != null)
                e.Graphics.DrawImage(carta.Imagen, rectImagen);

            e.DrawFocusRectangle();
        }

        private void LimpiarHistorial()
        {
            if (lstHistorial != null)
                lstHistorial.Items.Clear();
        }

        private void btnSacarCarta_Click(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            SacarSiguienteCarta();
        }

        private void timerAuto_Tick(object sender, EventArgs e)
        {
            if (_modoAuto && _jugando)
            {
                SacarSiguienteCarta();
            }
        }

        private void SacarSiguienteCarta()
        {
            if (!_jugando)
                return;

            if (_baraja == null)
            {
                MessageBox.Show("La baraja no está inicializada.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_baraja.HayCartasRestantes())
            {
                timerAuto.Stop();
                _modoAuto = false;

                MessageBox.Show("¡Se acabaron todas las cartas!", "Fin",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                TerminarJuego();
                return;
            }

            Carta carta = _baraja.SiguienteCarta();

            if (carta == null)
            {
                timerAuto.Stop();
                _modoAuto = false;

                MessageBox.Show("No se pudo sacar otra carta.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            picCartaActual.Image = carta.Imagen;
            lblContador.Text = $"Cartas: {_baraja.CartasCantadas.Count} / 54";
            AgregarAlHistorial(carta);
            ReproducirAudioCarta(carta);

            if (_soyServidor && _servidor != null)
                _servidor.Transmitir($"CARTA|{carta.Id}");
        }

        private void PicCarton_Click(object sender, EventArgs e)
        {
            if (!_jugando)
                return;

            PictureBox pic = (PictureBox)sender;

            string[] partes = pic.Tag.ToString().Split(',');

            int indiceCarton = partes.Length == 3 ? int.Parse(partes[0]) : _indiceCartonActual;
            int fila = int.Parse(partes[partes.Length - 2]);
            int col = int.Parse(partes[partes.Length - 1]);

            if (indiceCarton < 0 || indiceCarton >= _cartonesJugador.Count)
                return;

            _indiceCartonActual = indiceCarton;
            _carton = _cartonesJugador[_indiceCartonActual];

            if (_indiceCartonActual < _picsCartones.Count)
                _picsCarton = _picsCartones[_indiceCartonActual];

            if (_carton.Marcadas[fila, col])
            {
                _carton.Marcadas[fila, col] = false;
                pic.Image = _carton.Cartas[fila, col].Imagen;
                pic.BackColor = Color.Transparent;
                return;
            }

            _carton.MarcarCarta(fila, col);
            MarcarVisualmente(pic);
        }

        private bool TodasLasMarcadasFueronCantadas(CartonJugador carton)
        {
            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (!carton.Marcadas[f, c])
                        continue;

                    int idCarta = carton.Cartas[f, c].Id;

                    if (!CartaFueCantada(idCarta))
                        return false;
                }
            }

            return true;
        }

        private bool CartaFueCantada(int idCarta)
        {
            return _baraja != null &&
                _baraja.CartasCantadas.Exists(carta => carta.Id == idCarta);
        }

        private bool ResaltarCartasMarcadasNoCantadas()
        {
            if (_cartonesJugador == null)
                return false;

            ActualizarGridCarton();
            bool hayCartasNoCantadas = false;

            for (int indiceCarton = 0; indiceCarton < _cartonesJugador.Count; indiceCarton++)
            {
                if (indiceCarton >= _picsCartones.Count)
                    continue;

                CartonJugador carton = _cartonesJugador[indiceCarton];
                PictureBox[,] pics = _picsCartones[indiceCarton];

                for (int f = 0; f < CartonJugador.FILAS; f++)
                {
                    for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                    {
                        if (!carton.Marcadas[f, c])
                            continue;

                        if (!CartaFueCantada(carton.Cartas[f, c].Id))
                        {
                            MarcarVisualmente(pics[f, c], Color.DarkRed, 190);
                            hayCartasNoCantadas = true;
                        }
                    }
                }
            }

            return hayCartasNoCantadas;
        }

        private bool CumpleModoVictoria(CartonJugador carton)
        {
            if (_opcionesVictoria.Personalizado)
                return CumplePatronPersonalizado(carton);

            if (_opcionesVictoria.Horizontal && carton.TieneLineaHorizontal())
                return true;

            if (_opcionesVictoria.Vertical && carton.TieneLineaVertical())
                return true;

            if (_opcionesVictoria.Diagonal && carton.TieneDiagonal())
                return true;

            if (_opcionesVictoria.Lleno && carton.TieneCartonLleno())
                return true;

            return false;
        }

        private bool CumplePatronPersonalizado(CartonJugador carton)
        {
            if (_opcionesVictoria.PatronPersonalizado == null)
                return false;

            bool tieneCasillasEnPatron = false;

            for (int fila = 0; fila < CartonJugador.FILAS; fila++)
            {
                for (int columna = 0; columna < CartonJugador.COLUMNAS; columna++)
                {
                    if (_opcionesVictoria.PatronPersonalizado[fila, columna])
                    {
                        tieneCasillasEnPatron = true;

                        if (!carton.Marcadas[fila, columna])
                            return false;
                    }
                }
            }

            return tieneCasillasEnPatron;
        }

        private int BuscarCartonGanadorValido(out bool existeVictoriaConCartasNoCantadas)
        {
            existeVictoriaConCartasNoCantadas = false;

            for (int i = 0; i < _cartonesJugador.Count; i++)
            {
                CartonJugador carton = _cartonesJugador[i];

                if (!CumpleModoVictoria(carton))
                    continue;

                if (TodasLasMarcadasFueronCantadas(carton))
                    return i;

                existeVictoriaConCartasNoCantadas = true;
            }

            return -1;
        }

        private List<int> BuscarCartonesGanadoresValidos(out bool existeVictoriaConCartasNoCantadas)
        {
            List<int> indicesGanadores = new List<int>();

            existeVictoriaConCartasNoCantadas = false;

            if (_indicesCartonesEnDesempate.Count > 0)
            {
                for (int i = 0; i < _indicesCartonesEnDesempate.Count; i++)
                {
                    int indiceCarton = _indicesCartonesEnDesempate[i];

                    RevisarCartonParaGanadores(
                        indiceCarton,
                        indicesGanadores,
                        ref existeVictoriaConCartasNoCantadas);
                }
            }
            else
            {
                for (int i = 0; i < _cartonesJugador.Count; i++)
                {
                    RevisarCartonParaGanadores(
                        i,
                        indicesGanadores,
                        ref existeVictoriaConCartasNoCantadas);
                }
            }

            return indicesGanadores;
        }

        private void RevisarCartonParaGanadores(
            int indiceCarton,
            List<int> indicesGanadores,
            ref bool existeVictoriaConCartasNoCantadas)
        {
            if (indiceCarton < 0 || indiceCarton >= _cartonesJugador.Count)
                return;

            CartonJugador carton = _cartonesJugador[indiceCarton];

            if (!CumpleModoVictoria(carton))
                return;

            if (TodasLasMarcadasFueronCantadas(carton))
            {
                indicesGanadores.Add(indiceCarton);
                return;
            }

            existeVictoriaConCartasNoCantadas = true;
        }

        private void ProcesarEmpate(List<int> indicesGanadores)
        {
            MessageBox.Show(
                "Hay empate entre: " + ObtenerNombresCartones(indicesGanadores) +
                "\n\nSe iniciara una ronda de desempate.",
                "Desempate",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _indicesCartonesEnDesempate.Clear();

            for (int i = 0; i < indicesGanadores.Count; i++)
            {
                _indicesCartonesEnDesempate.Add(indicesGanadores[i]);
            }

            ReiniciarCartonesEnDesempate();
            ReiniciarEstadoRondaDesempate();

            if (_indicesCartonesEnDesempate.Count > 0)
                MostrarCarton(_indicesCartonesEnDesempate[0]);
        }

        private void ReiniciarCartonesEnDesempate()
        {
            List<Carta> todasLasCartas = ObtenerTodasLasCartas();

            for (int i = 0; i < _indicesCartonesEnDesempate.Count; i++)
            {
                int indiceCarton = _indicesCartonesEnDesempate[i];

                if (indiceCarton >= 0 && indiceCarton < _cartonesJugador.Count)
                    _cartonesJugador[indiceCarton].CrearNuevoCarton(todasLasCartas, false);
            }
        }

        private void ReiniciarEstadoRondaDesempate()
        {
            _baraja = new Baraja();
            _jugando = true;
            _modoAuto = false;

            timerAuto.Stop();

            picCartaActual.Image = null;
            lblContador.Text = "Cartas: 0 / 54";
            LimpiarHistorial();

            btnAuto.Text = "Auto: OFF";
            btnAuto.Enabled = true;
            btnSacarCarta.Enabled = true;
            btnBuenas.Enabled = true;
            nudVelocidad.Enabled = true;

            AplicarModoRed();
        }

        private string ObtenerNombreCarton(int indiceCarton)
        {
            return "Carton " + (indiceCarton + 1);
        }

        private string ObtenerNombresCartones(List<int> indicesCartones)
        {
            string nombres = "";

            for (int i = 0; i < indicesCartones.Count; i++)
            {
                if (i > 0)
                    nombres += ", ";

                nombres += ObtenerNombreCarton(indicesCartones[i]);
            }

            return nombres;
        }

        private void MarcarVisualmente(PictureBox pic)
        {
            MarcarVisualmente(pic, Color.FromArgb(120, 62, 45), 185);
        }

        private void MarcarVisualmente(PictureBox pic, Color colorMarca, int alpha)
        {
            if (pic.Image == null)
                return;

            Image original = pic.Image is Bitmap bmpOrig
                ? new Bitmap(bmpOrig)
                : new Bitmap(pic.Image);

            Bitmap bmp = new Bitmap(pic.Width, pic.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(original, 0, 0, pic.Width, pic.Height);

                using (SolidBrush brush =
                    new SolidBrush(Color.FromArgb(alpha, colorMarca)))
                {
                    g.FillRectangle(brush, 0, 0, pic.Width, pic.Height);
                }
            }

            original.Dispose();

            pic.Image = bmp;
        }



        private void VerificarVictoria()
        {
            if (!CumpleModoVictoria(_carton))
                return;

            _jugando = false;
            _modoAuto = false;
            timerAuto.Stop();

            try
            {
                string ruta = Path.Combine(
                    Application.StartupPath, "Resources", "Sounds", "victoria.wav");

                if (File.Exists(ruta))
                {
                    SoundPlayer player = new SoundPlayer(ruta);
                    player.Play();
                }
            }
            catch
            {
            }

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (_carton.Marcadas[f, c])
                    {
                        _picsCarton[f, c].BackColor = Color.FromArgb(255, 200, 0);
                    }
                }
            }

            if (_soyCliente && _cliente != null)
                _cliente.Enviar($"GANADOR|{_nombreJugador}");

            if (_soyServidor && _servidor != null)
                _servidor.Transmitir($"GANADOR|{_nombreJugador}");

            if (_nombreGanadorActual == "")
                _nombreGanadorActual = ObtenerNombreCarton(_indiceCartonActual);

            MessageBox.Show("¡¡¡BUENAS!!!\n\nGanador: " + _nombreGanadorActual,
                "¡Ganaste!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _indicesCartonesEnDesempate.Clear();
            _nombreGanadorActual = "";

            TerminarJuego();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            if (!_jugando)
            {
                MessageBox.Show("El juego no está activo. Presiona Reiniciar para comenzar de nuevo.",
                    "Juego detenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _modoAuto = !_modoAuto;

            if (_modoAuto)
            {
                timerAuto.Interval = (int)(nudVelocidad.Value * 1000);
                timerAuto.Start();

                btnAuto.Text = "Pausar";
                btnSacarCarta.Enabled = false;
                nudVelocidad.Enabled = false;

                SacarSiguienteCarta();
            }
            else
            {
                timerAuto.Stop();

                btnAuto.Text = "Auto: OFF";
                btnSacarCarta.Enabled = true;
                nudVelocidad.Enabled = true;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            timerAuto.Stop();
            InicializarJuego();

            if (_soyServidor && _servidor != null)
                _servidor.Transmitir("REINICIAR");
        }

        private void btnReiniciar_Click_1(object sender, EventArgs e)
        {
            btnReiniciar_Click(sender, e);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerAuto.Stop();

            FrmInicio inicio = new FrmInicio();
            inicio.Show();

            this.Close();
        }

        private void GuardarCartonEnArchivo()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog
                {
                    Filter = "Cartón de Lotería (*.loteria)|*.loteria",
                    FileName = "mi_carton"
                };

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                List<string> lineas = new List<string>();

                for (int f = 0; f < CartonJugador.FILAS; f++)
                {
                    for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                    {
                        lineas.Add(_carton.Cartas[f, c].Id.ToString());
                    }
                }

                File.WriteAllLines(dlg.FileName, lineas);

                MessageBox.Show(
                    "Cartón guardado correctamente.",
                    "Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void ActualizarGridCarton()
        {
            if (_cartonesJugador == null || _cartonesJugador.Count == 0)
                return;

            for (int indiceCarton = 0; indiceCarton < _cartonesJugador.Count; indiceCarton++)
            {
                if (indiceCarton >= _picsCartones.Count)
                    continue;

                CartonJugador carton = _cartonesJugador[indiceCarton];
                PictureBox[,] pics = _picsCartones[indiceCarton];

                for (int f = 0; f < CartonJugador.FILAS; f++)
                {
                    for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                    {
                        pics[f, c].Image = carton.Cartas[f, c].Imagen;
                        pics[f, c].BackColor = Color.Transparent;

                        if (carton.Marcadas[f, c])
                            MarcarVisualmente(pics[f, c]);
                    }
                }
            }

            if (_indiceCartonActual >= 0 && _indiceCartonActual < _picsCartones.Count)
                _picsCarton = _picsCartones[_indiceCartonActual];

            ActualizarEtiquetaCarton();
        }

        private void TerminarJuego()
        {
            _jugando = false;
            _modoAuto = false;

            timerAuto.Stop();

            btnSacarCarta.Enabled = false;
            btnAuto.Enabled = false;
            btnBuenas.Enabled = false;
            btnAuto.Text = "Auto: OFF";

            btnCrearCarton.Enabled = !_soyCliente;
            nudVelocidad.Enabled = true;

            ActualizarEtiquetaCarton();
        }

        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            try
            {
                _nombreJugador = PedirTexto("Crear partida", "Nombre del jugador:", "Servidor");

                if (string.IsNullOrWhiteSpace(_nombreJugador))
                    return;

                _servidor = new ServidorLoteria();

                _servidor.ClienteConectado += ip => EjecutarEnPantalla(() =>
                {
                    lblEstadoRed.Text = "Cliente conectado:\n " + ip;
                    EnviarEstadoActualRed();
                });

                _servidor.MensajeRecibido += ProcesarMensajeRed;

                _servidor.Error += msg => EjecutarEnPantalla(() =>
                    MessageBox.Show("Error de servidor: " + msg));

                _servidor.Iniciar(PUERTO);

                _soyServidor = true;
                _soyCliente = false;

                lblEstadoRed.Text = "Servidor activo. IP:\n " + ObtenerIpLocal();

                AplicarModoRed();

                MessageBox.Show(
                    "Partida creada. Los clientes deben conectarse a esta IP:\n" + ObtenerIpLocal(),
                    "Servidor activo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear la partida: " + ex.Message);
            }
        }

        private void btnUnirsePartida_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = PedirTexto("Unirse a partida", "IP del servidor:", "192.168.1.1");

                if (string.IsNullOrWhiteSpace(ip))
                    return;

                _nombreJugador = PedirTexto("Unirse a partida", "Nombre del jugador:", "Jugador");

                if (string.IsNullOrWhiteSpace(_nombreJugador))
                    return;

                _cliente = new ClienteLoteria();

                _cliente.MensajeRecibido += ProcesarMensajeRed;

                _cliente.Desconectado += () => EjecutarEnPantalla(() =>
                    lblEstadoRed.Text = "Red local: desconectado");

                _cliente.Error += msg => EjecutarEnPantalla(() =>
                    MessageBox.Show("Error de cliente: " + msg));

                _cliente.Conectar(ip, PUERTO);
                _cliente.Enviar($"JOIN|{_nombreJugador}");

                _soyServidor = false;
                _soyCliente = true;

                lblEstadoRed.Text = "Conectado al servidor:\n " + ip;

                AplicarModoRed();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar: " + ex.Message);
            }
        }

        private void btnDesconectarRed_Click(object sender, EventArgs e)
        {
            DesconectarRed();
        }

        private void ProcesarMensajeRed(string mensaje)
        {
            EjecutarEnPantalla(() =>
            {
                if (mensaje.StartsWith("CARTA|"))
                {
                    int id;

                    if (int.TryParse(mensaje.Substring(6), out id))
                        MostrarCartaRecibida(id);
                }
                else if (mensaje == "REINICIAR")
                {
                    InicializarJuego();
                }
                else if (mensaje.StartsWith("SYNC|"))
                {
                    SincronizarCartasCantadas(mensaje.Substring(5));
                }
                else if (mensaje.StartsWith("JOIN|"))
                {
                    string jugador = mensaje.Substring(5);

                    if (!string.IsNullOrWhiteSpace(jugador))
                        AgregarMensajeChat(jugador + " se unió a la partida.");
                }
                else if (mensaje.StartsWith("GANADOR|"))
                {
                    string ganador = mensaje.Substring(8);

                    _jugando = false;
                    timerAuto.Stop();

                    MessageBox.Show(ganador + " cantó lotería.", "Partida terminada");

                    TerminarJuego();
                }
                else if (mensaje.StartsWith("CHAT|"))
                {
                    string contenido = mensaje.Substring(5);
                    int separador = contenido.IndexOf('|');

                    if (separador >= 0)
                    {
                        string nombre = contenido.Substring(0, separador);
                        string texto = contenido.Substring(separador + 1);

                        AgregarMensajeChat($"{nombre}: {texto}");
                    }
                }
            });
        }

        private void MostrarCartaRecibida(int id)
        {
            Carta carta = BuscarCartaPorId(id);

            if (carta == null)
                return;

            bool yaEstabaCantada = _baraja.CartasCantadas.Exists(c => c.Id == id);

            _baraja.RegistrarCartaCantada(id);
            picCartaActual.Image = carta.Imagen;
            lblContador.Text = $"Cartas: {_baraja.CartasCantadas.Count} / 54";

            if (!yaEstabaCantada)
                AgregarAlHistorial(carta);

            ReproducirAudioCarta(carta);
        }

        private void SincronizarCartasCantadas(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
                return;

            string[] partes = ids.Split(',');

            foreach (string parte in partes)
            {
                int id;

                if (int.TryParse(parte, out id))
                    MostrarCartaRecibida(id);
            }

            AplicarModoRed();
        }

        private void EnviarEstadoActualRed()
        {
            if (!_soyServidor || _servidor == null || _baraja == null)
                return;

            string ids = "";

            for (int i = 0; i < _baraja.CartasCantadas.Count; i++)
            {
                if (i > 0)
                    ids += ",";

                ids += _baraja.CartasCantadas[i].Id.ToString();
            }

            _servidor.Transmitir("SYNC|" + ids);
        }

        private void AplicarModoRed()
        {
            btnCrearPartida.Enabled = !_soyServidor && !_soyCliente;
            btnUnirsePartida.Enabled = !_soyServidor && !_soyCliente;
            btnDesconectarRed.Enabled = _soyServidor || _soyCliente;

            if (_soyCliente)
            {
                btnSacarCarta.Enabled = false;
                btnAuto.Enabled = false;
                btnReiniciar.Enabled = false;
                btnGuardarCarton.Enabled = false;
                btnCargarCarton.Enabled = false;
                btnCrearCarton.Enabled = false;
                btnBuenas.Enabled = _jugando;
                nudVelocidad.Enabled = false;
            }
            else if (_jugando)
            {
                btnSacarCarta.Enabled = true;
                btnAuto.Enabled = true;
                btnReiniciar.Enabled = true;
                btnGuardarCarton.Enabled = true;
                btnCargarCarton.Enabled = true;
                btnCrearCarton.Enabled = true;
                btnBuenas.Enabled = true;
                nudVelocidad.Enabled = true;
            }

            ActualizarEtiquetaCarton();
        }

        private void DesconectarRed()
        {
            timerAuto.Stop();

            if (_servidor != null)
                _servidor.Detener();

            if (_cliente != null)
                _cliente.Desconectar();

            _servidor = null;
            _cliente = null;

            _soyServidor = false;
            _soyCliente = false;

            if (lblEstadoRed != null)
                lblEstadoRed.Text = "Red local: sin conexión";

            AplicarModoRed();
        }

        private void EjecutarEnPantalla(Action accion)
        {
            if (InvokeRequired)
                BeginInvoke(accion);
            else
                accion();
        }

        private string ObtenerIpLocal()
        {
            string ipLocal = "127.0.0.1";

            foreach (IPAddress ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily != AddressFamily.InterNetwork)
                    continue;

                string texto = ip.ToString();

                if (texto.StartsWith("192.168.") ||
                    texto.StartsWith("10.") ||
                    EsIpPrivada172(texto))
                    return texto;

                if (ipLocal == "127.0.0.1" && texto != "127.0.0.1")
                    ipLocal = texto;
            }

            return ipLocal;
        }

        private bool EsIpPrivada172(string ip)
        {
            string[] partes = ip.Split('.');

            if (partes.Length < 2 || partes[0] != "172")
                return false;

            int segundo;

            if (!int.TryParse(partes[1], out segundo))
                return false;

            return segundo >= 16 && segundo <= 31;
        }

        private string PedirTexto(string titulo, string mensaje, string valorInicial)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button btnAceptar = new Button();
            Button btnCancelar = new Button();

            form.Text = titulo;
            form.Size = new Size(360, 160);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            label.Text = mensaje;
            label.Location = new Point(15, 15);
            label.Size = new Size(310, 25);

            textBox.Text = valorInicial;
            textBox.Location = new Point(15, 45);
            textBox.Size = new Size(310, 25);

            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new Point(160, 80);
            btnAceptar.DialogResult = DialogResult.OK;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(250, 80);
            btnCancelar.DialogResult = DialogResult.Cancel;

            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(btnAceptar);
            form.Controls.Add(btnCancelar);

            form.AcceptButton = btnAceptar;
            form.CancelButton = btnCancelar;

            return form.ShowDialog(this) == DialogResult.OK ? textBox.Text.Trim() : "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DesconectarRed();
            base.OnFormClosing(e);
        }

        private void FrmJuego_Load(object sender, EventArgs e)
        {
            AjustarLayoutPantallaGrande();
        }

        // --- AÑADIDO: panel lateral config ---
        private void btnIniciarPartida_Lateral_Click(object sender, EventArgs e)
        {
            if (chkdFormaVictoria_Lateral.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Debes seleccionar al menos una forma de ganar.",
                    "Modo de victoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _cantidadCartones = (int)nudCantidadCartones_Lateral.Value;

            bool horizontalSeleccionado = false;
            bool verticalSeleccionado = false;
            bool diagonalSeleccionado = false;
            bool llenaSeleccionado = false;
            bool personalizadoSeleccionado = false;
            string nombrePatron = "";

            for (int i = 0; i < chkdFormaVictoria_Lateral.CheckedItems.Count; i++)
            {
                string item = chkdFormaVictoria_Lateral.CheckedItems[i].ToString();

                if (item == "Línea horizontal") horizontalSeleccionado = true;
                else if (item == "Línea vertical") verticalSeleccionado = true;
                else if (item == "Diagonal") diagonalSeleccionado = true;
                else if (item == "Cartón lleno") llenaSeleccionado = true;
                else
                {
                    personalizadoSeleccionado = true;
                    nombrePatron = item;
                }
            }

            _opcionesVictoria = new OpcionesVictoria
            {
                Horizontal = horizontalSeleccionado,
                Vertical = verticalSeleccionado,
                Diagonal = diagonalSeleccionado,
                Lleno = llenaSeleccionado,
                Personalizado = personalizadoSeleccionado,
                PatronPersonalizado = CopiarPatronPersonalizado_Lateral(_patronVictoriaPersonalizado_Lateral)
            };

            if (personalizadoSeleccionado)
            {
                bool[,] patron = LeerPatron_Lateral(nombrePatron);
                _opcionesVictoria.PatronPersonalizado = patron;
            }

            InicializarOpciones();
            InicializarJuego();
        }

        private void CargarPatrones_Lateral()
        {
            string carpeta = Application.StartupPath + "\\MisFormasDeVictoria";

            if (!Directory.Exists(carpeta))
                return;

            string[] archivos = Directory.GetFiles(carpeta, "*.txt");

            for (int i = 0; i < archivos.Length; i++)
            {
                string[] lineas = File.ReadAllLines(archivos[i]);
                if (lineas.Length >= 2)
                {
                    chkdFormaVictoria_Lateral.Items.Add(lineas[0]);
                }
            }
        }

        private bool[,] LeerPatron_Lateral(string nombre)
        {
            string ruta = Application.StartupPath + "\\MisFormasDeVictoria\\" + nombre + ".txt";
            string[] lineas = File.ReadAllLines(ruta);
            string[] valores = lineas[1].Split(',');

            bool[,] patron = new bool[5, 5];
            int indice = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    patron[i, j] = valores[indice] == "1";
                    indice++;
                }
            }
            return patron;
        }

        private void btnCancelar_Lateral_Click(object sender, EventArgs e)
        {
            pnlConfigLateral.Visible = false;
        }

        private void btnNuevaFormaDeGanar_Lateral_Click(object sender, EventArgs e)
        {
            FrmPersonalizarVictoria frmPersonalizar =
            new FrmPersonalizarVictoria(_patronVictoriaPersonalizado_Lateral);

            if (frmPersonalizar.ShowDialog(this) == DialogResult.OK)
            {
                _patronVictoriaPersonalizado_Lateral =
                CopiarPatronPersonalizado_Lateral(frmPersonalizar.PatronSeleccionado);
            }
            else
            {
                _patronVictoriaPersonalizado_Lateral = null;
                chkdFormaVictoria_Lateral.SetItemChecked(chkdFormaVictoria_Lateral.Items.Count - 1, false);
            }

            CargarPatrones_Lateral();
        }
        // --- FIN AÑADIDO ---

        private void nudVelocidad_ValueChanged(object sender, EventArgs e)
        {
            if (_modoAuto)
            {
                timerAuto.Interval = (int)(nudVelocidad.Value * 1000);
            }
        }

        private void btnEnviarChat_Click(object sender, EventArgs e)
        {
            string texto = txtMensajeChat.Text.Trim();

            if (texto == "")
                return;

            string mensajeRed = $"CHAT|{_nombreJugador}|{texto}";

            AgregarMensajeChat($"{_nombreJugador}: {texto}");
            txtMensajeChat.Clear();

            if (_soyServidor && _servidor != null)
                _servidor.Transmitir(mensajeRed);

            if (_soyCliente && _cliente != null)
                _cliente.Enviar(mensajeRed);
        }

        private void btnBuenas_Click(object sender, EventArgs e)
        {
            if (!_jugando)
                return;

            bool existeVictoriaConCartasNoCantadas;
            List<int> indicesGanadores =
                BuscarCartonesGanadoresValidos(out existeVictoriaConCartasNoCantadas);
            bool hayCartasMarcadasNoCantadas = ResaltarCartasMarcadasNoCantadas();

            if (indicesGanadores.Count == 1)
            {
                MostrarCarton(indicesGanadores[0]);
                _nombreGanadorActual = ObtenerNombreCarton(indicesGanadores[0]);
                VerificarVictoria();
                return;
            }

            if (indicesGanadores.Count > 1)
            {
                ProcesarEmpate(indicesGanadores);
                return;
            }

            if (existeVictoriaConCartasNoCantadas || hayCartasMarcadasNoCantadas)
            {
                MessageBox.Show(
                    "Buenas inválidas.\n\nEl cartón tiene forma de ganar, pero hay cartas marcadas que aún no han sido cantadas.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Aún no cumples ninguna forma de ganar en tus cartones.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnGuardarCarton_Click_1(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            GuardarCartonEnArchivo();
        }

        private void btnCargarCarton_Click_1(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Cartón de Lotería (*.loteria)|*.loteria";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string nombreCarton = Path.GetFileNameWithoutExtension(dialogo.FileName);

                if (cartonesUsados.Contains(nombreCarton))
                {
                    MessageBox.Show(
                        "Este cartón ya fue cargado. Elige uno diferente.",
                        "Cartón duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                cartonesUsados.Add(nombreCarton);

                try
                {
                    string[] lineas = File.ReadAllLines(dialogo.FileName);

                    if (lineas.Length != CartonJugador.TOTAL)
                    {
                        MessageBox.Show("El archivo no es un cartón válido.");
                        return;
                    }

                    int i = 0;
                    Carta[,] cartasCargadas = new Carta[CartonJugador.FILAS, CartonJugador.COLUMNAS];

                    for (int f = 0; f < CartonJugador.FILAS; f++)
                    {
                        for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                        {
                            int id = int.Parse(lineas[i++]);

                            Carta carta = BuscarCartaPorId(id);

                            if (carta == null)
                            {
                                MessageBox.Show("No se encontró una carta con ID: " + id);
                                return;
                            }

                            cartasCargadas[f, c] = carta;
                        }
                    }

                    CartonJugador cartonCargado = new CartonJugador(ObtenerTodasLasCartas());
                    cartonCargado.CargarCartas(cartasCargadas);
                    _cartonesJugador.Add(cartonCargado);
                    _cantidadCartones = _cartonesJugador.Count;
                    _indiceCartonActual = _cartonesJugador.Count - 1;
                    _carton = cartonCargado;
                    DibujarTodosLosCartones();
                    ActualizarGridCarton();

                    picCartaActual.Image = null;
                    lblContador.Text = "Cartas: 0 / 54";
                    LimpiarHistorial();

                    _baraja = new Baraja();
                    _jugando = true;
                    _modoAuto = false;

                    btnAuto.Text = "Auto: OFF";
                    btnAuto.Enabled = true;
                    btnSacarCarta.Enabled = true;
                    btnCrearCarton.Enabled = true;
                    btnBuenas.Enabled = true;
                    nudVelocidad.Enabled = true;

                    AplicarModoRed();

                    MessageBox.Show(
                        "Cartón cargado correctamente.",
                        "Cargado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar: " + ex.Message);
                }
            }
        }   

        private void btnCrearCarton_Click_1(object sender, EventArgs e)
        {
            if (_soyCliente)
            {
                MessageBox.Show(
                    "Los clientes no pueden crear una tabla nueva durante una partida en red.",
                    "Acción no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (FrmCrearCarton frm = new FrmCrearCarton(ObtenerTodasLasCartas()))
            {
                if (frm.ShowDialog(this) != DialogResult.OK)
                    return;

                CartonJugador cartonNuevo = new CartonJugador(ObtenerTodasLasCartas());
                cartonNuevo.CargarCartas(frm.CartasSeleccionadas);
                _cartonesJugador.Add(cartonNuevo);
                _cantidadCartones = _cartonesJugador.Count;
                _indiceCartonActual = _cartonesJugador.Count - 1;
                _carton = cartonNuevo;
                DibujarTodosLosCartones();
                ActualizarGridCarton();

                _jugando = true;
                _modoAuto = false;

                btnAuto.Text = "Auto: OFF";
                btnSacarCarta.Enabled = true;
                btnAuto.Enabled = true;
                btnReiniciar.Enabled = true;
                btnGuardarCarton.Enabled = true;
                btnCargarCarton.Enabled = true;
                btnCrearCarton.Enabled = true;
                btnBuenas.Enabled = true;
                nudVelocidad.Enabled = true;

                AplicarModoRed();

                DialogResult guardar = MessageBox.Show(
                    "Tabla creada correctamente.\n\n¿Quieres guardarla ahora?",
                    "Tabla lista",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (guardar == DialogResult.Yes)
                    GuardarCartonEnArchivo();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtMensajeChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
