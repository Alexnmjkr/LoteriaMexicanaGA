namespace LoteriaMexicana
{
    partial class FrmInstrucciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstrucciones));
            this.lblTexto = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.BackColor = System.Drawing.Color.Transparent;
            this.lblTexto.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTexto.Location = new System.Drawing.Point(268, 76);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(528, 400);
            this.lblTexto.TabIndex = 0;
            this.lblTexto.Text = resources.GetString("lblTexto.Text");
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.Location = new System.Drawing.Point(479, 469);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRegresar.Size = new System.Drawing.Size(106, 31);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FrmInstrucciones
            // 
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.instrucciones;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1011, 557);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblTexto);
            this.Name = "FrmInstrucciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrucciones";
            this.Load += new System.EventHandler(this.FrmInstrucciones_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Button btnRegresar;
    }
}