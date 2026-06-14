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
            FrmConfiguracionPartida frmConfig = new FrmConfiguracionPartida();

            if (frmConfig.ShowDialog() == DialogResult.OK)
            {
                FrmJuego frmJuego = new FrmJuego(
                    frmConfig.CantidadCartones,
                    frmConfig.OpcionesVictoria);

                frmJuego.Show();
                this.Hide();
            }
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