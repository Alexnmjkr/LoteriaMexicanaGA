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

        private Button btnCartonAnterior;
        private Button btnCartonSiguiente;
        private Label lblCartonActual;

        private bool _modoAuto = false;
        private bool _jugando = false;

        private PictureBox[,] _picsCarton =
            new PictureBox[CartonJugador.FILAS, CartonJugador.COLUMNAS];

        private Image _imagenFicha;
        private WindowsMediaPlayer _playerCarta;

        private const int PUERTO = 5000;

        private ServidorLoteria _servidor;
        private ClienteLoteria _cliente;

        private bool _soyServidor = false;
        private bool _soyCliente = false;
        private string _nombreJugador = "Jugador";

        public FrmJuego(int cantidadCartones, OpcionesVictoria opcionesVictoria)
        {
            InitializeComponent();

            _cantidadCartones = cantidadCartones;
            _opcionesVictoria = opcionesVictoria ?? new OpcionesVictoria
            {
                Horizontal = true,
                Vertical = true,
                Diagonal = true,
                Lleno = true
            };

            timerAuto.Interval = 3000;

            InicializarOpciones();
            CrearControlesCartones();
            InicializarJuego();

            _jugando = true;
        }

        private void InicializarOpciones()
        {
            nudVelocidad.Minimum = 1;
            nudVelocidad.Maximum = 10;
            nudVelocidad.Value = 3;

            if (chkHorizontal != null) chkHorizontal.Checked = _opcionesVictoria.Horizontal;
            if (chkVertical != null) chkVertical.Checked = _opcionesVictoria.Vertical;
            if (chkDiagonal != null) chkDiagonal.Checked = _opcionesVictoria.Diagonal;
            if (chkLleno != null) chkLleno.Checked = _opcionesVictoria.Lleno;
        }

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

            panelCarton.Controls.Clear();

            int size = 80;
            int margen = 5;

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    PictureBox pic = new PictureBox();

                    pic.Name = $"pic_{f}_{c}";
                    pic.Size = new Size(size, size);
                    pic.Location = new Point(c * (size + margen), f * (size + margen));
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Tag = $"{f},{c}";
                    pic.Cursor = Cursors.Hand;
                    pic.BackColor = Color.Transparent;
                    pic.Click += PicCarton_Click;

                    panelCarton.Controls.Add(pic);
                    _picsCarton[f, c] = pic;
                }
            }

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

            string texto = $"{lstHistorial.Items.Count + 1}. {carta.Nombre}";
            lstHistorial.Items.Insert(0, texto);
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

            int fila = int.Parse(partes[0]);
            int col = int.Parse(partes[1]);

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

                    bool fueCantada = _baraja.CartasCantadas.Exists(
                        carta => carta.Id == idCarta);

                    if (!fueCantada)
                        return false;
                }
            }

            return true;
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

                if (_imagenFicha != null)
                {
                    int margen = (int)(pic.Width * 0.18);

                    Rectangle rect = new Rectangle(
                        margen,
                        margen,
                        pic.Width - margen * 2,
                        pic.Height - margen * 2);

                    g.DrawImage(_imagenFicha, rect);
                }
                else
                {
                    using (SolidBrush brush =
                        new SolidBrush(Color.FromArgb(160, Color.Crimson)))
                    {
                        int margen = (int)(pic.Width * 0.1);

                        g.FillEllipse(
                            brush,
                            margen,
                            margen,
                            pic.Width - margen * 2,
                            pic.Height - margen * 2);
                    }
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

        private void btnGuardarCarton_Click(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            GuardarCartonEnArchivo();
        }

        private void btnCargarCarton_Click(object sender, EventArgs e)
        {
            if (_soyCliente)
                return;

            try
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    Filter = "Cartón de Lotería (*.loteria)|*.loteria"
                };

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string[] lineas = File.ReadAllLines(dlg.FileName);

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

                _carton.CargarCartas(cartasCargadas);
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

        private void btnCrearCarton_Click(object sender, EventArgs e)
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

                _carton.CargarCartas(frm.CartasSeleccionadas);
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

        private void ActualizarGridCarton()
        {
            if (_carton == null)
                return;

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    _picsCarton[f, c].Image = _carton.Cartas[f, c].Imagen;
                    _picsCarton[f, c].BackColor = Color.Transparent;

                    if (_carton.Marcadas[f, c])
                        MarcarVisualmente(_picsCarton[f, c]);
                }
            }

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
                    lblEstadoRed.Text = "Cliente conectado: " + ip);

                _servidor.MensajeRecibido += ProcesarMensajeRed;

                _servidor.Error += msg => EjecutarEnPantalla(() =>
                    MessageBox.Show("Error de servidor: " + msg));

                _servidor.Iniciar(PUERTO);

                _soyServidor = true;
                _soyCliente = false;

                lblEstadoRed.Text = "Servidor activo. IP: " + ObtenerIpLocal();

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

                _soyServidor = false;
                _soyCliente = true;

                lblEstadoRed.Text = "Conectado al servidor: " + ip;

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

            _baraja.RegistrarCartaCantada(id);
            picCartaActual.Image = carta.Imagen;
            lblContador.Text = $"Cartas: {_baraja.CartasCantadas.Count} / 54";
            AgregarAlHistorial(carta);
            ReproducirAudioCarta(carta);
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
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    ipLocal = ip.ToString();
            }

            return ipLocal;
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
        }

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

            if (existeVictoriaConCartasNoCantadas)
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
    }
}
