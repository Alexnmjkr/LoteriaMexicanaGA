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
            this.btnCrearCarton = new System.Windows.Forms.Button();
            this.chkHorizontal = new System.Windows.Forms.CheckBox();
            this.chkVertical = new System.Windows.Forms.CheckBox();
            this.chkDiagonal = new System.Windows.Forms.CheckBox();
            this.chkLleno = new System.Windows.Forms.CheckBox();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.nudVelocidad = new System.Windows.Forms.NumericUpDown();
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
            this.picCartaActual.Location = new System.Drawing.Point(51, 66);
            this.picCartaActual.Name = "picCartaActual";
            this.picCartaActual.Size = new System.Drawing.Size(200, 198);
            this.picCartaActual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCartaActual.TabIndex = 0;
            this.picCartaActual.TabStop = false;
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.BackColor = System.Drawing.Color.Transparent;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblContador.Location = new System.Drawing.Point(104, 264);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(67, 19);
            this.lblContador.TabIndex = 1;
            this.lblContador.Text = "Contador";
            // 
            // panelCarton
            // 
            this.panelCarton.BackColor = System.Drawing.Color.Transparent;
            this.panelCarton.Location = new System.Drawing.Point(292, 33);
            this.panelCarton.Name = "panelCarton";
            this.panelCarton.Size = new System.Drawing.Size(502, 490);
            this.panelCarton.TabIndex = 2;
            // 
            // btnSacarCarta
            // 
            this.btnSacarCarta.Location = new System.Drawing.Point(81, 305);
            this.btnSacarCarta.Name = "btnSacarCarta";
            this.btnSacarCarta.Size = new System.Drawing.Size(120, 40);
            this.btnSacarCarta.TabIndex = 3;
            this.btnSacarCarta.Text = "Sacar Carta";
            this.btnSacarCarta.UseVisualStyleBackColor = true;
            this.btnSacarCarta.Click += new System.EventHandler(this.btnSacarCarta_Click);
            // 
            // btnBuenas
            // 
            this.btnBuenas.Location = new System.Drawing.Point(81, 351);
            this.btnBuenas.Name = "btnBuenas";
            this.btnBuenas.Size = new System.Drawing.Size(120, 32);
            this.btnBuenas.TabIndex = 18;
            this.btnBuenas.Text = "¡Buenas!";
            this.btnBuenas.UseVisualStyleBackColor = true;
            this.btnBuenas.Click += new System.EventHandler(this.btnBuenas_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(81, 443);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(120, 32);
            this.btnAuto.TabIndex = 4;
            this.btnAuto.Text = "Auto: OFF";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(81, 393);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(120, 32);
            this.btnReiniciar.TabIndex = 5;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(81, 491);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(120, 32);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblCartaActual
            // 
            this.lblCartaActual.AutoSize = true;
            this.lblCartaActual.BackColor = System.Drawing.Color.Transparent;
            this.lblCartaActual.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaActual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCartaActual.Location = new System.Drawing.Point(76, 33);
            this.lblCartaActual.Name = "lblCartaActual";
            this.lblCartaActual.Size = new System.Drawing.Size(107, 23);
            this.lblCartaActual.TabIndex = 7;
            this.lblCartaActual.Text = "Carta Actual";
            // 
            // grpModoVictoria
            // 
            this.grpModoVictoria.BackColor = System.Drawing.Color.Transparent;
            this.grpModoVictoria.Controls.Add(this.btnCrearCarton);
            this.grpModoVictoria.Controls.Add(this.chkHorizontal);
            this.grpModoVictoria.Controls.Add(this.chkVertical);
            this.grpModoVictoria.Controls.Add(this.chkDiagonal);
            this.grpModoVictoria.Controls.Add(this.chkLleno);
            this.grpModoVictoria.Controls.Add(this.lblVelocidad);
            this.grpModoVictoria.Controls.Add(this.nudVelocidad);
            this.grpModoVictoria.Controls.Add(this.btnCargarCarton);
            this.grpModoVictoria.Controls.Add(this.btnGuardarCarton);
            this.grpModoVictoria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpModoVictoria.Location = new System.Drawing.Point(867, 12);
            this.grpModoVictoria.Name = "grpModoVictoria";
            this.grpModoVictoria.Size = new System.Drawing.Size(320, 413);
            this.grpModoVictoria.TabIndex = 8;
            this.grpModoVictoria.TabStop = false;
            this.grpModoVictoria.Text = "Modo de victoria";
            // 
            // btnCrearCarton
            // 
            this.btnCrearCarton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCrearCarton.Location = new System.Drawing.Point(102, 311);
            this.btnCrearCarton.Name = "btnCrearCarton";
            this.btnCrearCarton.Size = new System.Drawing.Size(119, 35);
            this.btnCrearCarton.TabIndex = 8;
            this.btnCrearCarton.Text = "Crear cartón";
            this.btnCrearCarton.UseVisualStyleBackColor = true;
            this.btnCrearCarton.Click += new System.EventHandler(this.btnCrearCarton_Click);
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.AutoSize = true;
            this.chkHorizontal.Checked = true;
            this.chkHorizontal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHorizontal.Location = new System.Drawing.Point(39, 54);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(122, 20);
            this.chkHorizontal.TabIndex = 0;
            this.chkHorizontal.Text = "Línea horizontal";
            this.chkHorizontal.UseVisualStyleBackColor = true;
            // 
            // chkVertical
            // 
            this.chkVertical.AutoSize = true;
            this.chkVertical.Checked = true;
            this.chkVertical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVertical.Location = new System.Drawing.Point(39, 99);
            this.chkVertical.Name = "chkVertical";
            this.chkVertical.Size = new System.Drawing.Size(108, 20);
            this.chkVertical.TabIndex = 1;
            this.chkVertical.Text = "Línea vertical";
            this.chkVertical.UseVisualStyleBackColor = true;
            // 
            // chkDiagonal
            // 
            this.chkDiagonal.AutoSize = true;
            this.chkDiagonal.Checked = true;
            this.chkDiagonal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDiagonal.Location = new System.Drawing.Point(39, 140);
            this.chkDiagonal.Name = "chkDiagonal";
            this.chkDiagonal.Size = new System.Drawing.Size(84, 20);
            this.chkDiagonal.TabIndex = 2;
            this.chkDiagonal.Text = "Diagonal";
            this.chkDiagonal.UseVisualStyleBackColor = true;
            // 
            // chkLleno
            // 
            this.chkLleno.AutoSize = true;
            this.chkLleno.Checked = true;
            this.chkLleno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLleno.Location = new System.Drawing.Point(39, 180);
            this.chkLleno.Name = "chkLleno";
            this.chkLleno.Size = new System.Drawing.Size(100, 20);
            this.chkLleno.TabIndex = 3;
            this.chkLleno.Text = "Cartón lleno";
            this.chkLleno.UseVisualStyleBackColor = true;
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(35, 222);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(106, 16);
            this.lblVelocidad.TabIndex = 4;
            this.lblVelocidad.Text = "Velocidad (seg):";
            // 
            // nudVelocidad
            // 
            this.nudVelocidad.Location = new System.Drawing.Point(39, 252);
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
            this.nudVelocidad.Size = new System.Drawing.Size(120, 22);
            this.nudVelocidad.TabIndex = 5;
            this.nudVelocidad.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudVelocidad.ValueChanged += new System.EventHandler(this.nudVelocidad_ValueChanged);
            // 
            // btnCargarCarton
            // 
            this.btnCargarCarton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCargarCarton.Location = new System.Drawing.Point(39, 362);
            this.btnCargarCarton.Name = "btnCargarCarton";
            this.btnCargarCarton.Size = new System.Drawing.Size(120, 35);
            this.btnCargarCarton.TabIndex = 6;
            this.btnCargarCarton.Text = "Cargar cartón";
            this.btnCargarCarton.UseVisualStyleBackColor = true;
            this.btnCargarCarton.Click += new System.EventHandler(this.btnCargarCarton_Click);
            // 
            // btnGuardarCarton
            // 
            this.btnGuardarCarton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardarCarton.Location = new System.Drawing.Point(165, 362);
            this.btnGuardarCarton.Name = "btnGuardarCarton";
            this.btnGuardarCarton.Size = new System.Drawing.Size(130, 35);
            this.btnGuardarCarton.TabIndex = 7;
            this.btnGuardarCarton.Text = "Guardar cartón";
            this.btnGuardarCarton.UseVisualStyleBackColor = true;
            this.btnGuardarCarton.Click += new System.EventHandler(this.btnGuardarCarton_Click);
            // 
            // lblEstadoRed
            // 
            this.lblEstadoRed.AutoSize = true;
            this.lblEstadoRed.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoRed.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoRed.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEstadoRed.Location = new System.Drawing.Point(930, 443);
            this.lblEstadoRed.Name = "lblEstadoRed";
            this.lblEstadoRed.Size = new System.Drawing.Size(170, 20);
            this.lblEstadoRed.TabIndex = 9;
            this.lblEstadoRed.Text = "Red Local: Sin conexión";
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.Location = new System.Drawing.Point(867, 471);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(120, 29);
            this.btnCrearPartida.TabIndex = 10;
            this.btnCrearPartida.Text = "Crear Partida";
            this.btnCrearPartida.UseVisualStyleBackColor = true;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // btnUnirsePartida
            // 
            this.btnUnirsePartida.Location = new System.Drawing.Point(1067, 473);
            this.btnUnirsePartida.Name = "btnUnirsePartida";
            this.btnUnirsePartida.Size = new System.Drawing.Size(120, 27);
            this.btnUnirsePartida.TabIndex = 11;
            this.btnUnirsePartida.Text = "Unirse";
            this.btnUnirsePartida.UseVisualStyleBackColor = true;
            this.btnUnirsePartida.Click += new System.EventHandler(this.btnUnirsePartida_Click);
            // 
            // btnDesconectarRed
            // 
            this.btnDesconectarRed.Enabled = false;
            this.btnDesconectarRed.Location = new System.Drawing.Point(935, 506);
            this.btnDesconectarRed.Name = "btnDesconectarRed";
            this.btnDesconectarRed.Size = new System.Drawing.Size(175, 36);
            this.btnDesconectarRed.TabIndex = 12;
            this.btnDesconectarRed.Text = "Desconectar Red";
            this.btnDesconectarRed.UseVisualStyleBackColor = true;
            this.btnDesconectarRed.Click += new System.EventHandler(this.btnDesconectarRed_Click);
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHistorial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTituloHistorial.Location = new System.Drawing.Point(313, 531);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(143, 36);
            this.lblTituloHistorial.TabIndex = 13;
            this.lblTituloHistorial.Text = "Historial";
            // 
            // lstHistorial
            // 
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.ItemHeight = 16;
            this.lstHistorial.Location = new System.Drawing.Point(304, 562);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(455, 84);
            this.lstHistorial.TabIndex = 14;
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 16;
            this.lstChat.Location = new System.Drawing.Point(884, 562);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(303, 84);
            this.lstChat.TabIndex = 15;
            // 
            // txtMensajeChat
            // 
            this.txtMensajeChat.Location = new System.Drawing.Point(887, 652);
            this.txtMensajeChat.Name = "txtMensajeChat";
            this.txtMensajeChat.Size = new System.Drawing.Size(300, 22);
            this.txtMensajeChat.TabIndex = 16;
            // 
            // btnEnviarChat
            // 
            this.btnEnviarChat.Location = new System.Drawing.Point(1215, 580);
            this.btnEnviarChat.Name = "btnEnviarChat";
            this.btnEnviarChat.Size = new System.Drawing.Size(92, 35);
            this.btnEnviarChat.TabIndex = 17;
            this.btnEnviarChat.Text = "Enviar";
            this.btnEnviarChat.UseVisualStyleBackColor = true;
            this.btnEnviarChat.Click += new System.EventHandler(this.btnEnviarChat_Click);
            // 
            // FrmJuego
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.juego;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1337, 721);
            this.Controls.Add(this.btnEnviarChat);
            this.Controls.Add(this.txtMensajeChat);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.lstHistorial);
            this.Controls.Add(this.lblTituloHistorial);
            this.Controls.Add(this.btnDesconectarRed);
            this.Controls.Add(this.btnUnirsePartida);
            this.Controls.Add(this.btnCrearPartida);
            this.Controls.Add(this.lblEstadoRed);
            this.Controls.Add(this.lblCartaActual);
            this.Controls.Add(this.grpModoVictoria);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnBuenas);
            this.Controls.Add(this.btnSacarCarta);
            this.Controls.Add(this.panelCarton);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.picCartaActual);
            this.Name = "FrmJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Button btnCargarCarton;
        private System.Windows.Forms.Button btnGuardarCarton;
        private System.Windows.Forms.Label lblEstadoRed;
        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.Button btnUnirsePartida;
        private System.Windows.Forms.Button btnDesconectarRed;
        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.Button btnCrearCarton;
        private System.Windows.Forms.ListBox lstHistorial;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtMensajeChat;
        private System.Windows.Forms.Button btnEnviarChat;
    }
}