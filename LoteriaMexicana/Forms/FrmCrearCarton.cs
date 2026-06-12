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