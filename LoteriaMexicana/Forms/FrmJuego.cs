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

namespace LoteriaMexicana.Forms
{
    public partial class FrmJuego : Form
    {
        private Baraja _baraja;
        private CartonJugador _carton;

        private bool _modoAuto = false;
        private bool _jugando = false;

        private PictureBox[,] _picsCarton =
            new PictureBox[CartonJugador.FILAS, CartonJugador.COLUMNAS];

        private Image _imagenFicha;

        private const int PUERTO = 5000;

        private ServidorLoteria _servidor;
        private ClienteLoteria _cliente;

        private bool _soyServidor = false;
        private bool _soyCliente = false;
        private string _nombreJugador = "Jugador";

        public FrmJuego()
        {
            InitializeComponent();

            timerAuto.Interval = 3000;

            InicializarOpciones();
            InicializarJuego();

            _jugando = true;
        }

        private void InicializarOpciones()
        {
            chkHorizontal.Checked = true;
            chkVertical.Checked = true;
            chkDiagonal.Checked = true;
            chkLleno.Checked = true;

            nudVelocidad.Minimum = 1;
            nudVelocidad.Maximum = 10;
            nudVelocidad.Value = 3;
        }

        private void InicializarJuego()
        {
            CargarImagenFicha();

            _baraja = new Baraja();
            _carton = new CartonJugador(ObtenerTodasLasCartas());

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
                    pic.Image = _carton.Cartas[f, c].Imagen;
                    pic.Tag = $"{f},{c}";
                    pic.Cursor = Cursors.Hand;
                    pic.BackColor = Color.Transparent;
                    pic.Click += PicCarton_Click;

                    panelCarton.Controls.Add(pic);
                    _picsCarton[f, c] = pic;
                }
            }

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

            nudVelocidad.Enabled = true;

            AplicarModoRed();
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

            Carta cartaCelda = _carton.Cartas[fila, col];

            bool fueCantada = _baraja.CartasCantadas.Exists(
                c => c.Id == cartaCelda.Id);

            if (!fueCantada)
            {
                MessageBox.Show("Esa carta aún no ha sido cantada.", "Espera",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_carton.Marcadas[fila, col])
                return;

            _carton.MarcarCarta(fila, col);

            MarcarVisualmente(pic);

            VerificarVictoria();
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
            bool gano = false;

            if (chkHorizontal.Checked && _carton.TieneLineaHorizontal())
                gano = true;

            if (chkVertical.Checked && _carton.TieneLineaVertical())
                gano = true;

            if (chkDiagonal.Checked && _carton.TieneDiagonal())
                gano = true;

            if (chkLleno.Checked && _carton.TieneCartonLleno())
                gano = true;

            if (!gano)
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

            MessageBox.Show("¡¡¡BUENAS!!!\n\n¡Felicidades, ganaste!",
                "¡Ganaste!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (_baraja != null && _baraja.CartasCantadas.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Ya hay cartas cantadas. Si creas una tabla nueva, la partida se reiniciará.\n\n¿Quieres continuar?",
                    "Crear tabla",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                _baraja = new Baraja();
                picCartaActual.Image = null;
                lblContador.Text = "Cartas: 0 / 54";
                LimpiarHistorial();
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
            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    _picsCarton[f, c].Image = _carton.Cartas[f, c].Imagen;
                    _picsCarton[f, c].BackColor = Color.Transparent;
                }
            }
        }

        private void TerminarJuego()
        {
            _jugando = false;
            _modoAuto = false;

            timerAuto.Stop();

            btnSacarCarta.Enabled = false;
            btnAuto.Enabled = false;
            btnAuto.Text = "Auto: OFF";

            btnCrearCarton.Enabled = !_soyCliente;
            nudVelocidad.Enabled = true;
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
                nudVelocidad.Enabled = true;
            }
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
    }
}