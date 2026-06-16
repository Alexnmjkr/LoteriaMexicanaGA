using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        int[,] patronVictoria = new int[5, 5]; 

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
        private void GuardarPatron(string nombre, bool[,] patron)
        {
            string carpeta = Application.StartupPath + "\\MisFormasDeVictoria";
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string ruta = carpeta + "\\" + nombre + ".txt";

            string valoresPlanos = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (valoresPlanos != "")
                        valoresPlanos += ",";
                    valoresPlanos += patron[i, j] ? "1" : "0";
                }
            }

            string[] lineas = new string[2];
            lineas[0] = nombre;
            lineas[1] = valoresPlanos;
            File.WriteAllLines(ruta, lineas);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
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
            GuardarPatron(txtbNombreNuevaVictoria.Text, PatronSeleccionado);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
