using LoteriaMexicana.Models;
using System;
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
            chkPersonalizado.CheckedChanged += new EventHandler(chkPersonalizado_CheckedChanged);
            ConfigurarValoresIniciales();
        }

        private void ConfigurarValoresIniciales()
        {
            nudCantidadCartones.Minimum = 1;
            nudCantidadCartones.Maximum = 10;
            nudCantidadCartones.Value = 1;

            chkHorizontal.Checked = true;
            chkVertical.Checked = true;
            chkDiagonal.Checked = true;
            chkLleno.Checked = true;
        }

        private void chkPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPersonalizado.Checked)
            {
                _patronVictoriaPersonalizado = null;
                return;
            }

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
                chkPersonalizado.Checked = false;
            }
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!chkHorizontal.Checked &&
                !chkVertical.Checked &&
                !chkDiagonal.Checked &&
                !chkLleno.Checked &&
                !chkPersonalizado.Checked)
            {
                MessageBox.Show(
                    "Debes seleccionar al menos una forma de ganar.",
                    "Modo de victoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CantidadCartones = (int)nudCantidadCartones.Value;

            OpcionesVictoria = new OpcionesVictoria
            {
                Horizontal = chkHorizontal.Checked,
                Vertical = chkVertical.Checked,
                Diagonal = chkDiagonal.Checked,
                Lleno = chkLleno.Checked,
                Personalizado = chkPersonalizado.Checked,
                PatronPersonalizado = CopiarPatronPersonalizado(_patronVictoriaPersonalizado)
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
