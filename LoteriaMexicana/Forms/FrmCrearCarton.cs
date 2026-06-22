using LoteriaMexicana.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LoteriaMexicana.Forms
{
    public partial class FrmCrearCarton : Form
    {
        private List<Carta> _todasLasCartas;
        private Carta[,] _cartasElegidas;
        private PictureBox[,] _casillas;

        public Carta[,] CartasSeleccionadas { get; private set; }

        public FrmCrearCarton(List<Carta> todasLasCartas)
        {
            InitializeComponent();

            _todasLasCartas = todasLasCartas;
            _cartasElegidas = new Carta[CartonJugador.FILAS, CartonJugador.COLUMNAS];

            PrepararCasillas();
            CargarListaCartas();
        }

        private void FrmCrearCarton_Load(object sender, EventArgs e)
        {
        }

        private void PrepararCasillas()
        {
            _casillas = new PictureBox[CartonJugador.FILAS, CartonJugador.COLUMNAS];

            for (int fila = 0; fila < CartonJugador.FILAS; fila++)
            {
                for (int col = 0; col < CartonJugador.COLUMNAS; col++)
                {
                    string nombre = $"pic{fila}{col}";
                    PictureBox pic = ObtenerPictureBox(nombre);

                    if (pic == null)
                    {
                        MessageBox.Show("Falta la casilla " + nombre + " en el formulario.");
                        Close();
                        return;
                    }

                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.BorderStyle = BorderStyle.FixedSingle;
                    pic.BackColor = Color.White;
                    pic.Cursor = Cursors.Hand;

                    _casillas[fila, col] = pic;
                }
            }
        }

        private PictureBox ObtenerPictureBox(string nombre)
        {
            Control[] controles = Controls.Find(nombre, true);

            if (controles.Length == 0)
                return null;

            return controles[0] as PictureBox;
        }

        private void CargarListaCartas()
        {
            lstCartas.DataSource = null;
            lstCartas.DataSource = _todasLasCartas;
            lstCartas.DisplayMember = "Nombre";
            lstCartas.ValueMember = "Id";
        }

        private void lstCartas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carta carta = lstCartas.SelectedItem as Carta;

            if (carta == null)
            {
                picPreviewCarta.Image = null;
                return;
            }

            picPreviewCarta.Image = carta.Imagen;
        }

        private void picCasilla_Click(object sender, EventArgs e)
        {
            Carta carta = lstCartas.SelectedItem as Carta;

            if (carta == null)
            {
                MessageBox.Show("Selecciona una carta primero.");
                return;
            }

            int fila;
            int col;

            if (!ObtenerPosicionCasilla((PictureBox)sender, out fila, out col))
                return;

            if (!chkPermitirDobles.Checked && CartaYaExiste(carta.Id, fila, col))
            {
                MessageBox.Show("Esa carta ya está en tu tabla. Activa la opción de repetidas si quieres usar dobles.");
                return;
            }

            string errorDobles;
            if (chkPermitirDobles.Checked && !PuedeColocarCartaRepetida(carta, fila, col, out errorDobles))
            {
                MessageBox.Show(errorDobles);
                return;
            }

            _cartasElegidas[fila, col] = carta;
            _casillas[fila, col].Image = carta.Imagen;
        }

        private bool ObtenerPosicionCasilla(PictureBox pic, out int fila, out int col)
        {
            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (_casillas[f, c] == pic)
                    {
                        fila = f;
                        col = c;
                        return true;
                    }
                }
            }

            fila = -1;
            col = -1;
            return false;
        }

        private bool CartaYaExiste(int id, int filaActual, int colActual)
        {
            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (f == filaActual && c == colActual)
                        continue;

                    if (_cartasElegidas[f, c] != null && _cartasElegidas[f, c].Id == id)
                        return true;
                }
            }

            return false;
        }

        private bool TieneDobles()
        {
            List<int> ids = new List<int>();

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (_cartasElegidas[f, c] == null)
                        continue;

                    if (ids.Contains(_cartasElegidas[f, c].Id))
                        return true;

                    ids.Add(_cartasElegidas[f, c].Id);
                }
            }

            return false;
        }

        private int ContarCarta(int id, int filaIgnorada, int colIgnorada)
        {
            int cantidad = 0;

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (f == filaIgnorada && c == colIgnorada)
                        continue;

                    if (_cartasElegidas[f, c] != null && _cartasElegidas[f, c].Id == id)
                        cantidad++;
                }
            }

            return cantidad;
        }

        private int ObtenerCartaDoble(int filaIgnorada, int colIgnorada)
        {
            Dictionary<int, int> conteos = new Dictionary<int, int>();

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (f == filaIgnorada && c == colIgnorada)
                        continue;

                    Carta carta = _cartasElegidas[f, c];

                    if (carta == null)
                        continue;

                    if (!conteos.ContainsKey(carta.Id))
                        conteos[carta.Id] = 0;

                    conteos[carta.Id]++;
                }
            }

            foreach (KeyValuePair<int, int> conteo in conteos)
            {
                if (conteo.Value >= 2)
                    return conteo.Key;
            }

            return -1;
        }

        private bool PuedeColocarCartaRepetida(Carta carta, int fila, int col, out string mensaje)
        {
            int vecesActuales = ContarCarta(carta.Id, fila, col);

            if (vecesActuales >= 2)
            {
                mensaje = "Solo puedes poner la misma carta 2 veces.";
                return false;
            }

            if (vecesActuales == 1)
            {
                int idCartaDoble = ObtenerCartaDoble(fila, col);

                if (idCartaDoble != -1 && idCartaDoble != carta.Id)
                {
                    mensaje = "Ya tienes una carta repetida. No puedes repetir otra carta.";
                    return false;
                }
            }

            mensaje = null;
            return true;
        }

        private bool DoblesValidosDespuesDeColocar(Carta cartaNueva, int filaNueva, int colNueva, out string mensaje)
        {
            Dictionary<int, int> conteos = new Dictionary<int, int>();

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    Carta carta = (f == filaNueva && c == colNueva) ? cartaNueva : _cartasElegidas[f, c];

                    if (carta == null)
                        continue;

                    if (!conteos.ContainsKey(carta.Id))
                        conteos[carta.Id] = 0;

                    conteos[carta.Id]++;
                }
            }

            int cartasRepetidas = 0;

            foreach (int cantidad in conteos.Values)
            {
                if (cantidad > 2)
                {
                    mensaje = "Solo puedes poner la misma carta 2 veces.";
                    return false;
                }

                if (cantidad == 2)
                    cartasRepetidas++;
            }

            if (cartasRepetidas > 1)
            {
                mensaje = "Ya tienes una carta repetida. No puedes repetir otra carta.";
                return false;
            }

            mensaje = null;
            return true;
        }

        private bool DoblesValidos()
        {
            string mensaje;
            return DoblesValidosDespuesDeColocar(null, -1, -1, out mensaje);
        }

        private bool CartonCompleto()
        {
            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    if (_cartasElegidas[f, c] == null)
                        return false;
                }
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!CartonCompleto())
            {
                MessageBox.Show("Debes llenar las 25 casillas de la tabla.");
                return;
            }

            if (!chkPermitirDobles.Checked && TieneDobles())
            {
                MessageBox.Show("El cartón no puede tener cartas repetidas si la opción de repetidas está desactivada.");
                return;
            }

            if (chkPermitirDobles.Checked && !DoblesValidos())
            {
                MessageBox.Show("Solo puedes repetir una carta y máximo 2 veces.");
                return;
            }

            CartasSeleccionadas = new Carta[CartonJugador.FILAS, CartonJugador.COLUMNAS];

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    CartasSeleccionadas[f, c] = _cartasElegidas[f, c];
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _cartasElegidas = new Carta[CartonJugador.FILAS, CartonJugador.COLUMNAS];

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    _casillas[f, c].Image = null;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkPermitirDobles_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPermitirDobles.Checked && TieneDobles())
            {
                MessageBox.Show("Tu tabla ya tiene cartas repetidas. Limpia la tabla antes de desactivar esta opción.");
                chkPermitirDobles.Checked = true;
            }
        }
    }
}
