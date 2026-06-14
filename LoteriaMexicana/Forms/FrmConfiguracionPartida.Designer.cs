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
            this.grpModoVictoria = new System.Windows.Forms.GroupBox();
            this.chkPersonalizado = new System.Windows.Forms.CheckBox();
            this.chkHorizontal = new System.Windows.Forms.CheckBox();
            this.chkVertical = new System.Windows.Forms.CheckBox();
            this.chkDiagonal = new System.Windows.Forms.CheckBox();
            this.chkLleno = new System.Windows.Forms.CheckBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCartones)).BeginInit();
            this.grpModoVictoria.SuspendLayout();
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
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCantidad.Location = new System.Drawing.Point(296, 115);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(188, 25);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "Número de cartones:";
            // 
            // nudCantidadCartones
            // 
            this.nudCantidadCartones.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudCantidadCartones.Location = new System.Drawing.Point(683, 114);
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
            // grpModoVictoria
            // 
            this.grpModoVictoria.BackColor = System.Drawing.Color.Transparent;
            this.grpModoVictoria.Controls.Add(this.chkPersonalizado);
            this.grpModoVictoria.Controls.Add(this.chkHorizontal);
            this.grpModoVictoria.Controls.Add(this.chkVertical);
            this.grpModoVictoria.Controls.Add(this.chkDiagonal);
            this.grpModoVictoria.Controls.Add(this.chkLleno);
            this.grpModoVictoria.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpModoVictoria.Location = new System.Drawing.Point(349, 187);
            this.grpModoVictoria.Name = "grpModoVictoria";
            this.grpModoVictoria.Size = new System.Drawing.Size(430, 180);
            this.grpModoVictoria.TabIndex = 3;
            this.grpModoVictoria.TabStop = false;
            this.grpModoVictoria.Text = "Modo de victoria";
            // 
            // chkPersonalizado
            // 
            this.chkPersonalizado.AutoSize = true;
            this.chkPersonalizado.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPersonalizado.Location = new System.Drawing.Point(35, 134);
            this.chkPersonalizado.Name = "chkPersonalizado";
            this.chkPersonalizado.Size = new System.Drawing.Size(143, 29);
            this.chkPersonalizado.TabIndex = 6;
            this.chkPersonalizado.Text = "Personalizado";
            this.chkPersonalizado.UseVisualStyleBackColor = true;
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkHorizontal.Location = new System.Drawing.Point(35, 45);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(154, 27);
            this.chkHorizontal.TabIndex = 0;
            this.chkHorizontal.Text = "Línea horizontal";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // chkVertical
            // 
            this.chkVertical.AutoSize = true;
            this.chkVertical.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkVertical.Location = new System.Drawing.Point(35, 90);
            this.chkVertical.Name = "chkVertical";
            this.chkVertical.Size = new System.Drawing.Size(131, 27);
            this.chkVertical.TabIndex = 1;
            this.chkVertical.Text = "Línea vertical";
            this.chkVertical.UseVisualStyleBackColor = true;
            // 
            // chkDiagonal
            // 
            this.chkDiagonal.AutoSize = true;
            this.chkDiagonal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkDiagonal.Location = new System.Drawing.Point(235, 45);
            this.chkDiagonal.Name = "chkDiagonal";
            this.chkDiagonal.Size = new System.Drawing.Size(100, 27);
            this.chkDiagonal.TabIndex = 2;
            this.chkDiagonal.Text = "Diagonal";
            this.chkDiagonal.UseVisualStyleBackColor = true;
            // 
            // chkLleno
            // 
            this.chkLleno.AutoSize = true;
            this.chkLleno.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkLleno.Location = new System.Drawing.Point(235, 90);
            this.chkLleno.Name = "chkLleno";
            this.chkLleno.Size = new System.Drawing.Size(126, 27);
            this.chkLleno.TabIndex = 3;
            this.chkLleno.Text = "Cartón lleno";
            this.chkLleno.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.Location = new System.Drawing.Point(384, 396);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(150, 42);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar partida";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(584, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 42);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmConfiguracionPartida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.configuracion;
            this.ClientSize = new System.Drawing.Size(1084, 480);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.grpModoVictoria);
            this.Controls.Add(this.nudCantidadCartones);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmConfiguracionPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de partida";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCartones)).EndInit();
            this.grpModoVictoria.ResumeLayout(false);
            this.grpModoVictoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidadCartones;
        private System.Windows.Forms.GroupBox grpModoVictoria;
        private System.Windows.Forms.CheckBox chkHorizontal;
        private System.Windows.Forms.CheckBox chkVertical;
        private System.Windows.Forms.CheckBox chkDiagonal;
        private System.Windows.Forms.CheckBox chkLleno;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkPersonalizado;
    }
}