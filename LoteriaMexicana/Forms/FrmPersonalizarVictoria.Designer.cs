namespace LoteriaMexicana.Forms
{
    partial class FrmPersonalizarVictoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonalizarVictoria));
            this.lblSeleccioneLasCasillas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSeleccioneLasCasillas
            // 
            this.lblSeleccioneLasCasillas.AutoSize = true;
            this.lblSeleccioneLasCasillas.BackColor = System.Drawing.Color.Transparent;
            this.lblSeleccioneLasCasillas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccioneLasCasillas.Location = new System.Drawing.Point(22, 27);
            this.lblSeleccioneLasCasillas.Name = "lblSeleccioneLasCasillas";
            this.lblSeleccioneLasCasillas.Size = new System.Drawing.Size(179, 23);
            this.lblSeleccioneLasCasillas.TabIndex = 0;
            this.lblSeleccioneLasCasillas.Text = "Seleccione las casillas";
            // 
            // FrmPersonalizarVictoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(616, 606);
            this.Controls.Add(this.lblSeleccioneLasCasillas);
            this.Name = "FrmPersonalizarVictoria";
            this.Text = "Personalizar Victoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSeleccioneLasCasillas;
    }
}