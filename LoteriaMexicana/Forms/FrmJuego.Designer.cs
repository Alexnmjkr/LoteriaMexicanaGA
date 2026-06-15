namespace LoteriaMexicana.Forms
{
    partial class FrmJuego
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
            this.components = new System.ComponentModel.Container();
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            this.picCartaActual = new System.Windows.Forms.PictureBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.panelCarton = new System.Windows.Forms.Panel();
            this.btnSacarCarta = new System.Windows.Forms.Button();
            this.btnBuenas = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblCartaActual = new System.Windows.Forms.Label();
            this.grpModoVictoria = new System.Windows.Forms.GroupBox();
            this.chkHorizontal = new System.Windows.Forms.CheckBox();
            this.chkVertical = new System.Windows.Forms.CheckBox();
            this.chkDiagonal = new System.Windows.Forms.CheckBox();
            this.chkLleno = new System.Windows.Forms.CheckBox();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.nudVelocidad = new System.Windows.Forms.NumericUpDown();
            this.btnCrearCarton = new System.Windows.Forms.Button();
            this.btnCargarCarton = new System.Windows.Forms.Button();
            this.btnGuardarCarton = new System.Windows.Forms.Button();
            this.lblEstadoRed = new System.Windows.Forms.Label();
            this.btnCrearPartida = new System.Windows.Forms.Button();
            this.btnUnirsePartida = new System.Windows.Forms.Button();
            this.btnDesconectarRed = new System.Windows.Forms.Button();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.txtMensajeChat = new System.Windows.Forms.TextBox();
            this.btnEnviarChat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaActual)).BeginInit();
            this.grpModoVictoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // timerAuto
            // 
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // picCartaActual
            // 
            this.picCartaActual.Location = new System.Drawing.Point(62, 100);
            this.picCartaActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picCartaActual.Name = "picCartaActual";
            this.picCartaActual.Size = new System.Drawing.Size(202, 238);
            this.picCartaActual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCartaActual.TabIndex = 0;
            this.picCartaActual.TabStop = false;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.BackColor = System.Drawing.Color.Transparent;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblContador.ForeColor = System.Drawing.Color.White;
            this.lblContador.Location = new System.Drawing.Point(101, 344);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(79, 21);
            this.lblContador.TabIndex = 2;
            this.lblContador.Text = "Contador";
            // 
            // panelCarton
            // 
            this.panelCarton.BackColor = System.Drawing.Color.Transparent;
            this.panelCarton.Location = new System.Drawing.Point(326, 56);
            this.panelCarton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCarton.Name = "panelCarton";
            this.panelCarton.Size = new System.Drawing.Size(922, 625);
            this.panelCarton.TabIndex = 3;
            // 
            // btnSacarCarta
            // 
            this.btnSacarCarta.Location = new System.Drawing.Point(79, 400);
            this.btnSacarCarta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSacarCarta.Name = "btnSacarCarta";
            this.btnSacarCarta.Size = new System.Drawing.Size(146, 44);
            this.btnSacarCarta.TabIndex = 4;
            this.btnSacarCarta.Text = "Sacar Carta";
            this.btnSacarCarta.UseVisualStyleBackColor = true;
            this.btnSacarCarta.Click += new System.EventHandler(this.btnSacarCarta_Click);
            // 
            // btnBuenas
            // 
            this.btnBuenas.Location = new System.Drawing.Point(79, 456);
            this.btnBuenas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuenas.Name = "btnBuenas";
            this.btnBuenas.Size = new System.Drawing.Size(146, 44);
            this.btnBuenas.TabIndex = 5;
            this.btnBuenas.Text = "¡Buenas!";
            this.btnBuenas.UseVisualStyleBackColor = true;
            this.btnBuenas.Click += new System.EventHandler(this.btnBuenas_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(79, 569);
            this.btnAuto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(146, 44);
            this.btnAuto.TabIndex = 7;
            this.btnAuto.Text = "Auto: OFF";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(79, 512);
            this.btnReiniciar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(146, 44);
            this.btnReiniciar.TabIndex = 6;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(79, 625);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(146, 44);
            this.btnMenu.TabIndex = 8;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblCartaActual
            // 
            this.lblCartaActual.AutoSize = true;
            this.lblCartaActual.BackColor = System.Drawing.Color.Transparent;
            this.lblCartaActual.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.lblCartaActual.ForeColor = System.Drawing.Color.White;
            this.lblCartaActual.Location = new System.Drawing.Point(90, 56);
            this.lblCartaActual.Name = "lblCartaActual";
            this.lblCartaActual.Size = new System.Drawing.Size(125, 27);
            this.lblCartaActual.TabIndex = 1;
            this.lblCartaActual.Text = "Carta Actual";
            // 
            // grpModoVictoria
            // 
            this.grpModoVictoria.Controls.Add(this.chkHorizontal);
            this.grpModoVictoria.Controls.Add(this.chkVertical);
            this.grpModoVictoria.Controls.Add(this.chkDiagonal);
            this.grpModoVictoria.Controls.Add(this.chkLleno);
            this.grpModoVictoria.Location = new System.Drawing.Point(1294, 750);
            this.grpModoVictoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpModoVictoria.Name = "grpModoVictoria";
            this.grpModoVictoria.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpModoVictoria.Size = new System.Drawing.Size(11, 12);
            this.grpModoVictoria.TabIndex = 11;
            this.grpModoVictoria.TabStop = false;
            this.grpModoVictoria.Text = "Modo de victoria";
            this.grpModoVictoria.Visible = false;
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Location = new System.Drawing.Point(11, 25);
            this.chkHorizontal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(147, 24);
            this.chkHorizontal.TabIndex = 0;
            this.chkHorizontal.Text = "Línea horizontal";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // chkVertical
            // 
            this.chkVertical.AutoSize = true;
            this.chkVertical.Location = new System.Drawing.Point(11, 56);
            this.chkVertical.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkVertical.Name = "chkVertical";
            this.chkVertical.Size = new System.Drawing.Size(127, 24);
            this.chkVertical.TabIndex = 1;
            this.chkVertical.Text = "Línea vertical";
            this.chkVertical.UseVisualStyleBackColor = true;
            // 
            // chkDiagonal
            // 
            this.chkDiagonal.AutoSize = true;
            this.chkDiagonal.Location = new System.Drawing.Point(11, 88);
            this.chkDiagonal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDiagonal.Name = "chkDiagonal";
            this.chkDiagonal.Size = new System.Drawing.Size(98, 24);
            this.chkDiagonal.TabIndex = 2;
            this.chkDiagonal.Text = "Diagonal";
            this.chkDiagonal.UseVisualStyleBackColor = true;
            // 
            // chkLleno
            // 
            this.chkLleno.AutoSize = true;
            this.chkLleno.Location = new System.Drawing.Point(11, 119);
            this.chkLleno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkLleno.Name = "chkLleno";
            this.chkLleno.Size = new System.Drawing.Size(120, 24);
            this.chkLleno.TabIndex = 3;
            this.chkLleno.Text = "Cartón lleno";
            this.chkLleno.UseVisualStyleBackColor = true;
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.lblVelocidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVelocidad.ForeColor = System.Drawing.Color.White;
            this.lblVelocidad.Location = new System.Drawing.Point(1318, 68);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(134, 25);
            this.lblVelocidad.TabIndex = 9;
            this.lblVelocidad.Text = "Velocidad seg:";
            this.lblVelocidad.Click += new System.EventHandler(this.lblVelocidad_Click);
            // 
            // nudVelocidad
            // 
            this.nudVelocidad.Location = new System.Drawing.Point(1323, 100);
            this.nudVelocidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudVelocidad.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudVelocidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVelocidad.Name = "nudVelocidad";
            this.nudVelocidad.Size = new System.Drawing.Size(135, 26);
            this.nudVelocidad.TabIndex = 10;
            this.nudVelocidad.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudVelocidad.ValueChanged += new System.EventHandler(this.nudVelocidad_ValueChanged);
            // 
            // btnCrearCarton
            // 
            this.btnCrearCarton.Location = new System.Drawing.Point(1271, 167);
            this.btnCrearCarton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCrearCarton.Name = "btnCrearCarton";
            this.btnCrearCarton.Size = new System.Drawing.Size(146, 44);
            this.btnCrearCarton.TabIndex = 12;
            this.btnCrearCarton.Text = "Crear cartón";
            this.btnCrearCarton.UseVisualStyleBackColor = true;
            this.btnCrearCarton.Visible = false;
            this.btnCrearCarton.Click += new System.EventHandler(this.btnCrearCarton_Click);
            // 
            // btnCargarCarton
            // 
            this.btnCargarCarton.Location = new System.Drawing.Point(1271, 219);
            this.btnCargarCarton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCargarCarton.Name = "btnCargarCarton";
            this.btnCargarCarton.Size = new System.Drawing.Size(146, 44);
            this.btnCargarCarton.TabIndex = 13;
            this.btnCargarCarton.Text = "Cargar cartón";
            this.btnCargarCarton.UseVisualStyleBackColor = true;
            this.btnCargarCarton.Visible = false;
            this.btnCargarCarton.Click += new System.EventHandler(this.btnCargarCarton_Click);
            // 
            // btnGuardarCarton
            // 
            this.btnGuardarCarton.Location = new System.Drawing.Point(1271, 275);
            this.btnGuardarCarton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarCarton.Name = "btnGuardarCarton";
            this.btnGuardarCarton.Size = new System.Drawing.Size(146, 44);
            this.btnGuardarCarton.TabIndex = 14;
            this.btnGuardarCarton.Text = "Guardar cartón";
            this.btnGuardarCarton.UseVisualStyleBackColor = true;
            this.btnGuardarCarton.Visible = false;
            this.btnGuardarCarton.Click += new System.EventHandler(this.btnGuardarCarton_Click);
            // 
            // lblEstadoRed
            // 
            this.lblEstadoRed.AutoSize = true;
            this.lblEstadoRed.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoRed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoRed.ForeColor = System.Drawing.Color.White;
            this.lblEstadoRed.Location = new System.Drawing.Point(1266, 350);
            this.lblEstadoRed.Name = "lblEstadoRed";
            this.lblEstadoRed.Size = new System.Drawing.Size(213, 25);
            this.lblEstadoRed.TabIndex = 15;
            this.lblEstadoRed.Text = "Red Local: Sin conexión";
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.Location = new System.Drawing.Point(1271, 400);
            this.btnCrearPartida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(146, 44);
            this.btnCrearPartida.TabIndex = 16;
            this.btnCrearPartida.Text = "Crear Partida";
            this.btnCrearPartida.UseVisualStyleBackColor = true;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // btnUnirsePartida
            // 
            this.btnUnirsePartida.Location = new System.Drawing.Point(1429, 400);
            this.btnUnirsePartida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnirsePartida.Name = "btnUnirsePartida";
            this.btnUnirsePartida.Size = new System.Drawing.Size(146, 44);
            this.btnUnirsePartida.TabIndex = 17;
            this.btnUnirsePartida.Text = "Unirse";
            this.btnUnirsePartida.UseVisualStyleBackColor = true;
            this.btnUnirsePartida.Click += new System.EventHandler(this.btnUnirsePartida_Click);
            // 
            // btnDesconectarRed
            // 
            this.btnDesconectarRed.Enabled = false;
            this.btnDesconectarRed.Location = new System.Drawing.Point(1344, 456);
            this.btnDesconectarRed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDesconectarRed.Name = "btnDesconectarRed";
            this.btnDesconectarRed.Size = new System.Drawing.Size(180, 44);
            this.btnDesconectarRed.TabIndex = 18;
            this.btnDesconectarRed.Text = "Desconectar Red";
            this.btnDesconectarRed.UseVisualStyleBackColor = true;
            this.btnDesconectarRed.Click += new System.EventHandler(this.btnDesconectarRed_Click);
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.AutoSize = true;
            this.lblTituloHistorial.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.White;
            this.lblTituloHistorial.Location = new System.Drawing.Point(326, 700);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(101, 30);
            this.lblTituloHistorial.TabIndex = 19;
            this.lblTituloHistorial.Text = "Historial";
            // 
            // lstHistorial
            // 
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.ItemHeight = 20;
            this.lstHistorial.Location = new System.Drawing.Point(326, 738);
            this.lstHistorial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(618, 124);
            this.lstHistorial.TabIndex = 20;
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 20;
            this.lstChat.Location = new System.Drawing.Point(1012, 738);
            this.lstChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(483, 124);
            this.lstChat.TabIndex = 21;
            // 
            // txtMensajeChat
            // 
            this.txtMensajeChat.Location = new System.Drawing.Point(1012, 881);
            this.txtMensajeChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMensajeChat.Name = "txtMensajeChat";
            this.txtMensajeChat.Size = new System.Drawing.Size(371, 26);
            this.txtMensajeChat.TabIndex = 22;
            // 
            // btnEnviarChat
            // 
            this.btnEnviarChat.Location = new System.Drawing.Point(1395, 875);
            this.btnEnviarChat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnviarChat.Name = "btnEnviarChat";
            this.btnEnviarChat.Size = new System.Drawing.Size(101, 44);
            this.btnEnviarChat.TabIndex = 23;
            this.btnEnviarChat.Text = "Enviar";
            this.btnEnviarChat.UseVisualStyleBackColor = true;
            this.btnEnviarChat.Click += new System.EventHandler(this.btnEnviarChat_Click);
            // 
            // FrmJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.juego;
            this.ClientSize = new System.Drawing.Size(1609, 950);
            this.Controls.Add(this.btnEnviarChat);
            this.Controls.Add(this.txtMensajeChat);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.lstHistorial);
            this.Controls.Add(this.lblTituloHistorial);
            this.Controls.Add(this.btnDesconectarRed);
            this.Controls.Add(this.btnUnirsePartida);
            this.Controls.Add(this.btnCrearPartida);
            this.Controls.Add(this.lblEstadoRed);
            this.Controls.Add(this.btnGuardarCarton);
            this.Controls.Add(this.btnCargarCarton);
            this.Controls.Add(this.btnCrearCarton);
            this.Controls.Add(this.grpModoVictoria);
            this.Controls.Add(this.nudVelocidad);
            this.Controls.Add(this.lblVelocidad);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnBuenas);
            this.Controls.Add(this.btnSacarCarta);
            this.Controls.Add(this.panelCarton);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblCartaActual);
            this.Controls.Add(this.picCartaActual);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotería Mexicana - Juego";
            this.Load += new System.EventHandler(this.FrmJuego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCartaActual)).EndInit();
            this.grpModoVictoria.ResumeLayout(false);
            this.grpModoVictoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Timer timerAuto;
        private System.Windows.Forms.PictureBox picCartaActual;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Panel panelCarton;
        private System.Windows.Forms.Button btnSacarCarta;
        private System.Windows.Forms.Button btnBuenas;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblCartaActual;

        private System.Windows.Forms.GroupBox grpModoVictoria;
        private System.Windows.Forms.CheckBox chkHorizontal;
        private System.Windows.Forms.CheckBox chkVertical;
        private System.Windows.Forms.CheckBox chkDiagonal;
        private System.Windows.Forms.CheckBox chkLleno;

        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.NumericUpDown nudVelocidad;

        private System.Windows.Forms.Button btnCrearCarton;
        private System.Windows.Forms.Button btnCargarCarton;
        private System.Windows.Forms.Button btnGuardarCarton;

        private System.Windows.Forms.Label lblEstadoRed;
        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.Button btnUnirsePartida;
        private System.Windows.Forms.Button btnDesconectarRed;

        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.ListBox lstHistorial;

        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtMensajeChat;
        private System.Windows.Forms.Button btnEnviarChat;
    }
}