namespace LoteriaMexicana.Forms
{
    partial class FrmConfiguracionPartida
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidadCartones = new System.Windows.Forms.NumericUpDown();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkdFormaVictoria = new System.Windows.Forms.CheckedListBox();
            this.grpNumeroCartones = new System.Windows.Forms.GroupBox();
            this.grpFormaDeVictoria = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevaFormaDeGanar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCartones)).BeginInit();
            this.grpNumeroCartones.SuspendLayout();
            this.grpFormaDeVictoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(358, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(373, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuración de partida";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(9, 23);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(191, 25);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "Número de cartones:";
            // 
            // nudCantidadCartones
            // 
            this.nudCantidadCartones.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudCantidadCartones.Location = new System.Drawing.Point(234, 21);
            this.nudCantidadCartones.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCantidadCartones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadCartones.Name = "nudCantidadCartones";
            this.nudCantidadCartones.Size = new System.Drawing.Size(120, 32);
            this.nudCantidadCartones.TabIndex = 2;
            this.nudCantidadCartones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIniciarPartida.Location = new System.Drawing.Point(391, 360);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(150, 42);
            this.btnIniciarPartida.TabIndex = 4;
            this.btnIniciarPartida.Text = "Iniciar partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(569, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 42);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkdFormaVictoria
            // 
            this.chkdFormaVictoria.FormattingEnabled = true;
            this.chkdFormaVictoria.Items.AddRange(new object[] {
            "Línea horizontal",
            "Línea vertical",
            "Diagonal",
            "Cartón lleno"});
            this.chkdFormaVictoria.Location = new System.Drawing.Point(26, 52);
            this.chkdFormaVictoria.Name = "chkdFormaVictoria";
            this.chkdFormaVictoria.Size = new System.Drawing.Size(150, 89);
            this.chkdFormaVictoria.TabIndex = 6;
            // 
            // grpNumeroCartones
            // 
            this.grpNumeroCartones.BackColor = System.Drawing.Color.Transparent;
            this.grpNumeroCartones.Controls.Add(this.lblCantidad);
            this.grpNumeroCartones.Controls.Add(this.nudCantidadCartones);
            this.grpNumeroCartones.Location = new System.Drawing.Point(365, 112);
            this.grpNumeroCartones.Name = "grpNumeroCartones";
            this.grpNumeroCartones.Size = new System.Drawing.Size(366, 79);
            this.grpNumeroCartones.TabIndex = 7;
            this.grpNumeroCartones.TabStop = false;
            // 
            // grpFormaDeVictoria
            // 
            this.grpFormaDeVictoria.BackColor = System.Drawing.Color.Transparent;
            this.grpFormaDeVictoria.Controls.Add(this.label1);
            this.grpFormaDeVictoria.Controls.Add(this.btnNuevaFormaDeGanar);
            this.grpFormaDeVictoria.Controls.Add(this.chkdFormaVictoria);
            this.grpFormaDeVictoria.Location = new System.Drawing.Point(365, 197);
            this.grpFormaDeVictoria.Name = "grpFormaDeVictoria";
            this.grpFormaDeVictoria.Size = new System.Drawing.Size(366, 157);
            this.grpFormaDeVictoria.TabIndex = 8;
            this.grpFormaDeVictoria.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Forma de Victoria:";
            // 
            // btnNuevaFormaDeGanar
            // 
            this.btnNuevaFormaDeGanar.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFormaDeGanar.Location = new System.Drawing.Point(204, 90);
            this.btnNuevaFormaDeGanar.Name = "btnNuevaFormaDeGanar";
            this.btnNuevaFormaDeGanar.Size = new System.Drawing.Size(149, 51);
            this.btnNuevaFormaDeGanar.TabIndex = 7;
            this.btnNuevaFormaDeGanar.Text = "Crear nueva forma";
            this.btnNuevaFormaDeGanar.UseVisualStyleBackColor = true;
            this.btnNuevaFormaDeGanar.Click += new System.EventHandler(this.btnNuevaFormaDeGanar_Click);
            // 
            // FrmConfiguracionPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.configuracion;
            this.ClientSize = new System.Drawing.Size(1084, 480);
            this.Controls.Add(this.grpFormaDeVictoria);
            this.Controls.Add(this.grpNumeroCartones);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIniciarPartida);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmConfiguracionPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de partida";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCartones)).EndInit();
            this.grpNumeroCartones.ResumeLayout(false);
            this.grpNumeroCartones.PerformLayout();
            this.grpFormaDeVictoria.ResumeLayout(false);
            this.grpFormaDeVictoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidadCartones;
        private System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckedListBox chkdFormaVictoria;
        private System.Windows.Forms.GroupBox grpNumeroCartones;
        private System.Windows.Forms.GroupBox grpFormaDeVictoria;
        private System.Windows.Forms.Button btnNuevaFormaDeGanar;
        private System.Windows.Forms.Label label1;
    }
}