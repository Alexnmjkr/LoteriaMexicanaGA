using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoteriaMexicana.Forms
{
    public partial class FrmPersonalizarVictoria : Form
    {
        private Button[,] _botonesCasillas =
            new Button[5, 5];

        private bool[,] _casillasSeleccionadas =
            new bool[5, 5];

        public bool[,] PatronSeleccionado { get; private set; }

        public FrmPersonalizarVictoria()
        {
            InitializeComponent();
            CrearControlesSeleccion();
        }

        public FrmPersonalizarVictoria(bool[,] patronActual)
        {
            InitializeComponent();
            CargarPatronActual(patronActual);
            CrearControlesSeleccion();
        }

        private void CargarPatronActual(bool[,] patronActual)
        {
            if (patronActual == null)
                return;

            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    _casillasSeleccionadas[fila, columna] =
                        patronActual[fila, columna];
                }
            }
        }

        private void CrearControlesSeleccion()
        {
            int tamanoCasilla = 55;
            int margen = 8;
            int inicioX = 70;
            int inicioY = 70;

            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    Button botonCasilla = new Button();

                    botonCasilla.Name = "btnCasilla_" + fila + "_" + columna;
                    botonCasilla.Size = new Size(tamanoCasilla, tamanoCasilla);
                    botonCasilla.Location = new Point(
                        inicioX + columna * (tamanoCasilla + margen),
                        inicioY + fila * (tamanoCasilla + margen));
                    botonCasilla.Tag = fila + "," + columna;
                    botonCasilla.Text = (fila + 1) + "," + (columna + 1);
                    botonCasilla.FlatStyle = FlatStyle.Flat;
                    botonCasilla.Click += new EventHandler(btnCasilla_Click);

                    Controls.Add(botonCasilla);
                    _botonesCasillas[fila, columna] = botonCasilla;

                    ActualizarAparienciaCasilla(fila, columna);
                }
            }

            Button btnAceptar = new Button();
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Text = "Aceptar";
            btnAceptar.Size = new Size(100, 35);
            btnAceptar.Location = new Point(120, 410);
            btnAceptar.Click += new EventHandler(btnAceptar_Click);
            Controls.Add(btnAceptar);

            Button btnCancelar = new Button();
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.Location = new Point(250, 410);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            Controls.Add(btnCancelar);
        }

        private void btnCasilla_Click(object sender, EventArgs e)
        {
            Button botonCasilla = (Button)sender;
            string[] partes = botonCasilla.Tag.ToString().Split(',');

            int fila = int.Parse(partes[0]);
            int columna = int.Parse(partes[1]);

            _casillasSeleccionadas[fila, columna] =
                !_casillasSeleccionadas[fila, columna];

            ActualizarAparienciaCasilla(fila, columna);
        }

        private void ActualizarAparienciaCasilla(int fila, int columna)
        {
            Button botonCasilla = _botonesCasillas[fila, columna];

            if (botonCasilla == null)
                return;

            if (_casillasSeleccionadas[fila, columna])
            {
                botonCasilla.BackColor = Color.Gold;
                botonCasilla.FlatAppearance.BorderColor = Color.DarkRed;
                botonCasilla.FlatAppearance.BorderSize = 3;
            }
            else
            {
                botonCasilla.BackColor = SystemColors.Control;
                botonCasilla.FlatAppearance.BorderColor = Color.Gray;
                botonCasilla.FlatAppearance.BorderSize = 1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!TieneCasillasSeleccionadas())
            {
                MessageBox.Show(
                    "Selecciona al menos una casilla para el patrón personalizado.",
                    "Patrón personalizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            PatronSeleccionado = CopiarCasillasSeleccionadas();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool TieneCasillasSeleccionadas()
        {
            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    if (_casillasSeleccionadas[fila, columna])
                        return true;
                }
            }

            return false;
        }

        private bool[,] CopiarCasillasSeleccionadas()
        {
            bool[,] patronCopia = new bool[5, 5];

            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    patronCopia[fila, columna] =
                        _casillasSeleccionadas[fila, columna];
                }
            }

            return patronCopia;
        }
    }
}
