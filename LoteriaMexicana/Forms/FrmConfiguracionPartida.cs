using LoteriaMexicana.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace LoteriaMexicana.Forms
{
    public partial class FrmConfiguracionPartida : Form
    {
        public int CantidadCartones { get; private set; }
        public OpcionesVictoria OpcionesVictoria { get; private set; }

        private bool[,] _patronVictoriaPersonalizado;

        public FrmConfiguracionPartida()
        {
            InitializeComponent();
            ConfigurarValoresIniciales();
        }

        private void ConfigurarValoresIniciales()
        {
            nudCantidadCartones.Minimum = 1;
            nudCantidadCartones.Maximum = 100;
            nudCantidadCartones.Value = 1;

        }

        private void FrmConfiguracionPartida_Load(object sender, EventArgs e)
        {
            // ... tu código existente ...

            CargarPatrones(); // línea nueva
        }

        private bool[,] CopiarPatronPersonalizado(bool[,] patronOriginal)
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

        private void btnIniciarPartida_Click(object sender, EventArgs e)
        {
            if (chkdFormaVictoria.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Debes seleccionar al menos una forma de ganar.",
                    "Modo de victoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CantidadCartones = (int)nudCantidadCartones.Value;

            bool horizontalSeleccionado = false;
            bool verticalSeleccionado = false;
            bool diagonalSeleccionado = false;
            bool llenaSeleccionado = false;
            bool personalizadoSeleccionado = false;
            string nombrePatron = "";

            for (int i = 0; i < chkdFormaVictoria.CheckedItems.Count; i++)
            {
                string item = chkdFormaVictoria.CheckedItems[i].ToString();

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

            OpcionesVictoria = new OpcionesVictoria
            {
                Horizontal = horizontalSeleccionado,
                Vertical = verticalSeleccionado,
                Diagonal = diagonalSeleccionado,
                Lleno = llenaSeleccionado,
                Personalizado = personalizadoSeleccionado,
                PatronPersonalizado = CopiarPatronPersonalizado(_patronVictoriaPersonalizado)
            };

            if (personalizadoSeleccionado)
            {
                bool[,] patron = LeerPatron(nombrePatron);
                OpcionesVictoria.PatronPersonalizado = patron;
            }

            DialogResult = DialogResult.OK;
            Close();
        }    

        private void CargarPatrones()
        {
            string carpeta = Application.StartupPath + "\\MisFormasDeVictoria";

            string[] archivos = Directory.GetFiles(carpeta, "*.txt");

            for (int i = 0; i < archivos.Length; i++)
            {
                string[] lineas = File.ReadAllLines(archivos[i]);
                if (lineas.Length >= 2)
                {
                    chkdFormaVictoria.Items.Add(lineas[0]); 
                }
            }
        }

        private bool[,] LeerPatron(string nombre)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnNuevaFormaDeGanar_Click(object sender, EventArgs e)
        {
            FrmPersonalizarVictoria frmPersonalizar =
            new FrmPersonalizarVictoria(_patronVictoriaPersonalizado);

            if (frmPersonalizar.ShowDialog(this) == DialogResult.OK)
            {
                _patronVictoriaPersonalizado =
                CopiarPatronPersonalizado(frmPersonalizar.PatronSeleccionado);
            }
            else
            {
                _patronVictoriaPersonalizado = null;
                chkdFormaVictoria.SetItemChecked(chkdFormaVictoria.Items.Count - 1, false);
            }

            CargarPatrones();
        }
    }
}