using LoteriaMexicana.Forms;
using System;
using System.Windows.Forms;

namespace LoteriaMexicana
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            // Abrir FrmJuego directamente (1 cartón y opciones por defecto)
            FrmJuego frmJuego = new FrmJuego(1, null);
            frmJuego.Show();
            this.Hide();
        }

        private void btnInstrucciones_Click(object sender, EventArgs e)
        {
            FrmInstrucciones frmInstrucciones = new FrmInstrucciones();
            frmInstrucciones.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FrmInicio_Load(object sender, EventArgs e)
        {
        }
    }

}