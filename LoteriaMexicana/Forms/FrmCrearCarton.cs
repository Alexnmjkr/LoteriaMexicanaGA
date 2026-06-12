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

        private void PrepararCasillas()
        {
            _casillas = new PictureBox[CartonJugador.FILAS, CartonJugador.COLUMNAS];

            _casillas[0, 0] = pic00;
            _casillas[0, 1] = pic01;
            _casillas[0, 2] = pic02;
            _casillas[0, 3] = pic03;
            _casillas[0, 4] = pic04;

            _casillas[1, 0] = pic10;
            _casillas[1, 1] = pic11;
            _casillas[1, 2] = pic12;
            _casillas[1, 3] = pic13;
            _casillas[1, 4] = pic14;

            _casillas[2, 0] = pic20;
            _casillas[2, 1] = pic21;
            _casillas[2, 2] = pic22;
            _casillas[2, 3] = pic23;
            _casillas[2, 4] = pic24;

            _casillas[3, 0] = pic30;
            _casillas[3, 1] = pic31;
            _casillas[3, 2] = pic32;
            _casillas[3, 3] = pic33;
            _casillas[3, 4] = pic34;

            for (int f = 0; f < CartonJugador.FILAS; f++)
            {
                for (int c = 0; c < CartonJugador.COLUMNAS; c++)
                {
                    _casillas[f, c].SizeMode = PictureBoxSizeMode.StretchImage;
                    _casillas[f, c].BorderStyle = BorderStyle.FixedSingle;
                    _casillas[f, c].BackColor = Color.White;
                    _casillas[f, c].Cursor = Cursors.Hand;
                }
            }
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
                MessageBox.Show("Debes llenar las 20 casillas de la tabla.");
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