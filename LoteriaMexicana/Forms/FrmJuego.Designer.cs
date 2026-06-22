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
            this.lblContador = new System.Windows.Forms.Label();
            this.panelCarton = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSacarCarta = new System.Windows.Forms.Button();
            this.btnBuenas = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.lblCartaActual = new System.Windows.Forms.Label();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.nudVelocidad = new System.Windows.Forms.NumericUpDown();
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.picCartaActual = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlConfigLateral = new System.Windows.Forms.Panel();
            this.label1_Lateral = new System.Windows.Forms.Label();
            this.lblCantidad_Lateral = new System.Windows.Forms.Label();
            this.nudCantidadCartones_Lateral = new System.Windows.Forms.NumericUpDown();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.btnCrearPartida = new System.Windows.Forms.Button();
            this.btnEnviarChat = new System.Windows.Forms.Button();
            this.chkdFormaVictoria_Lateral = new System.Windows.Forms.CheckedListBox();
            this.btnNuevaFormaDeGanar_Lateral = new System.Windows.Forms.Button();
            this.btnGuardarCarton = new System.Windows.Forms.Button();
            this.txtMensajeChat = new System.Windows.Forms.TextBox();
            this.lblTitulo_Lateral = new System.Windows.Forms.Label();
            this.btnCargarCarton = new System.Windows.Forms.Button();
            this.btnDesconectarRed = new System.Windows.Forms.Button();
            this.btnCrearCarton = new System.Windows.Forms.Button();
            this.btnUnirsePartida = new System.Windows.Forms.Button();
            this.btnReiniciarPartida_Lateral = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelCarton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlConfigLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCartones_Lateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.BackColor = System.Drawing.Color.Maroon;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblContador.ForeColor = System.Drawing.Color.White;
            this.lblContador.Location = new System.Drawing.Point(76, 274);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(67, 19);
            this.lblContador.TabIndex = 1;
            this.lblContador.Text = "Contador";
            // 
            // panelCarton
            // 
            this.panelCarton.BackColor = System.Drawing.Color.Tan;
            this.panelCarton.Controls.Add(this.dateTimePicker1);
            this.panelCarton.Location = new System.Drawing.Point(292, 73);
            this.panelCarton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCarton.Name = "panelCarton";
            this.panelCarton.Size = new System.Drawing.Size(873, 532);
            this.panelCarton.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(513, -31);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // btnSacarCarta
            // 
            this.btnSacarCarta.BackColor = System.Drawing.Color.Tan;
            this.btnSacarCarta.Location = new System.Drawing.Point(69, 363);
            this.btnSacarCarta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSacarCarta.Name = "btnSacarCarta";
            this.btnSacarCarta.Size = new System.Drawing.Size(131, 34);
            this.btnSacarCarta.TabIndex = 4;
            this.btnSacarCarta.Text = "Sacar Carta";
            this.btnSacarCarta.UseVisualStyleBackColor = false;
            this.btnSacarCarta.Click += new System.EventHandler(this.btnSacarCarta_Click);
            // 
            // btnBuenas
            // 
            this.btnBuenas.BackColor = System.Drawing.Color.Orange;
            this.btnBuenas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuenas.ForeColor = System.Drawing.Color.Red;
            this.btnBuenas.Location = new System.Drawing.Point(69, 299);
            this.btnBuenas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuenas.Name = "btnBuenas";
            this.btnBuenas.Size = new System.Drawing.Size(131, 55);
            this.btnBuenas.TabIndex = 18;
            this.btnBuenas.Text = "BUENAS";
            this.btnBuenas.UseVisualStyleBackColor = false;
            this.btnBuenas.Click += new System.EventHandler(this.btnBuenas_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.BackColor = System.Drawing.Color.Tan;
            this.btnAuto.Location = new System.Drawing.Point(69, 447);
            this.btnAuto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(131, 34);
            this.btnAuto.TabIndex = 7;
            this.btnAuto.Text = "Auto: OFF";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.Tan;
            this.btnReiniciar.Location = new System.Drawing.Point(69, 404);
            this.btnReiniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(131, 34);
            this.btnReiniciar.TabIndex = 6;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // lblCartaActual
            // 
            this.lblCartaActual.AutoSize = true;
            this.lblCartaActual.BackColor = System.Drawing.Color.Transparent;
            this.lblCartaActual.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaActual.ForeColor = System.Drawing.Color.White;
            this.lblCartaActual.Location = new System.Drawing.Point(75, 5);
            this.lblCartaActual.Name = "lblCartaActual";
            this.lblCartaActual.Size = new System.Drawing.Size(109, 23);
            this.lblCartaActual.TabIndex = 7;
            this.lblCartaActual.Text = "Carta Actual";
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.BackColor = System.Drawing.Color.DarkRed;
            this.lblVelocidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVelocidad.ForeColor = System.Drawing.Color.White;
            this.lblVelocidad.Location = new System.Drawing.Point(76, 592);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(120, 20);
            this.lblVelocidad.TabIndex = 4;
            this.lblVelocidad.Text = "Velocidad (seg):";
            // 
            // nudVelocidad
            // 
            this.nudVelocidad.Location = new System.Drawing.Point(80, 614);
            this.nudVelocidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.nudVelocidad.Size = new System.Drawing.Size(107, 22);
            this.nudVelocidad.TabIndex = 5;
            this.nudVelocidad.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudVelocidad.ValueChanged += new System.EventHandler(this.nudVelocidad_ValueChanged);
            // 
            // lstHistorial
            // 
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.ItemHeight = 16;
            this.lstHistorial.Location = new System.Drawing.Point(17, 494);
            this.lstHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(232, 84);
            this.lstHistorial.TabIndex = 20;
            // 
            // picCartaActual
            // 
            this.picCartaActual.Image = global::LoteriaMexicana.Properties.Resources.FondoTablas;
            this.picCartaActual.Location = new System.Drawing.Point(32, 36);
            this.picCartaActual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCartaActual.Name = "picCartaActual";
            this.picCartaActual.Size = new System.Drawing.Size(207, 228);
            this.picCartaActual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCartaActual.TabIndex = 0;
            this.picCartaActual.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoteriaMexicana.Properties.Resources.Fondo_Tabla;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 682);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlConfigLateral
            // 
            this.pnlConfigLateral.BackColor = System.Drawing.SystemColors.Control;
            this.pnlConfigLateral.BackgroundImage = global::LoteriaMexicana.Properties.Resources.Fondo_Tabla;
            this.pnlConfigLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfigLateral.Controls.Add(this.label1_Lateral);
            this.pnlConfigLateral.Controls.Add(this.lblCantidad_Lateral);
            this.pnlConfigLateral.Controls.Add(this.nudCantidadCartones_Lateral);
            this.pnlConfigLateral.Controls.Add(this.lstChat);
            this.pnlConfigLateral.Controls.Add(this.btnCrearPartida);
            this.pnlConfigLateral.Controls.Add(this.btnEnviarChat);
            this.pnlConfigLateral.Controls.Add(this.chkdFormaVictoria_Lateral);
            this.pnlConfigLateral.Controls.Add(this.btnNuevaFormaDeGanar_Lateral);
            this.pnlConfigLateral.Controls.Add(this.btnGuardarCarton);
            this.pnlConfigLateral.Controls.Add(this.txtMensajeChat);
            this.pnlConfigLateral.Controls.Add(this.lblTitulo_Lateral);
            this.pnlConfigLateral.Controls.Add(this.btnCargarCarton);
            this.pnlConfigLateral.Controls.Add(this.btnDesconectarRed);
            this.pnlConfigLateral.Controls.Add(this.btnCrearCarton);
            this.pnlConfigLateral.Controls.Add(this.btnUnirsePartida);
            this.pnlConfigLateral.Controls.Add(this.btnReiniciarPartida_Lateral);
            this.pnlConfigLateral.Controls.Add(this.btnMenu);
            this.pnlConfigLateral.Controls.Add(this.pictureBox2);
            this.pnlConfigLateral.Controls.Add(this.pictureBox3);
            this.pnlConfigLateral.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlConfigLateral.Location = new System.Drawing.Point(1182, 0);
            this.pnlConfigLateral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlConfigLateral.Name = "pnlConfigLateral";
            this.pnlConfigLateral.Size = new System.Drawing.Size(433, 658);
            this.pnlConfigLateral.TabIndex = 27;
            // 
            // label1_Lateral
            // 
            this.label1_Lateral.AutoSize = true;
            this.label1_Lateral.BackColor = System.Drawing.Color.DarkRed;
            this.label1_Lateral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1_Lateral.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1_Lateral.Location = new System.Drawing.Point(55, 76);
            this.label1_Lateral.Name = "label1_Lateral";
            this.label1_Lateral.Size = new System.Drawing.Size(137, 20);
            this.label1_Lateral.TabIndex = 9;
            this.label1_Lateral.Text = "Forma de Victoria:";
            // 
            // lblCantidad_Lateral
            // 
            this.lblCantidad_Lateral.AutoSize = true;
            this.lblCantidad_Lateral.BackColor = System.Drawing.Color.DarkRed;
            this.lblCantidad_Lateral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidad_Lateral.ForeColor = System.Drawing.Color.White;
            this.lblCantidad_Lateral.Location = new System.Drawing.Point(229, 78);
            this.lblCantidad_Lateral.Name = "lblCantidad_Lateral";
            this.lblCantidad_Lateral.Size = new System.Drawing.Size(156, 20);
            this.lblCantidad_Lateral.TabIndex = 1;
            this.lblCantidad_Lateral.Text = "Número de cartones:";
            // 
            // nudCantidadCartones_Lateral
            // 
            this.nudCantidadCartones_Lateral.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudCantidadCartones_Lateral.Location = new System.Drawing.Point(255, 124);
            this.nudCantidadCartones_Lateral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCantidadCartones_Lateral.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCantidadCartones_Lateral.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadCartones_Lateral.Name = "nudCantidadCartones_Lateral";
            this.nudCantidadCartones_Lateral.Size = new System.Drawing.Size(117, 30);
            this.nudCantidadCartones_Lateral.TabIndex = 2;
            this.nudCantidadCartones_Lateral.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lstChat
            // 
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 16;
            this.lstChat.Location = new System.Drawing.Point(20, 506);
            this.lstChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(393, 84);
            this.lstChat.TabIndex = 21;
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.BackColor = System.Drawing.Color.Tan;
            this.btnCrearPartida.Location = new System.Drawing.Point(69, 380);
            this.btnCrearPartida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(147, 39);
            this.btnCrearPartida.TabIndex = 16;
            this.btnCrearPartida.Text = "Crear Partida";
            this.btnCrearPartida.UseVisualStyleBackColor = false;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // btnEnviarChat
            // 
            this.btnEnviarChat.Location = new System.Drawing.Point(20, 594);
            this.btnEnviarChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnviarChat.Name = "btnEnviarChat";
            this.btnEnviarChat.Size = new System.Drawing.Size(91, 34);
            this.btnEnviarChat.TabIndex = 23;
            this.btnEnviarChat.Text = "Enviar";
            this.btnEnviarChat.UseVisualStyleBackColor = true;
            this.btnEnviarChat.Click += new System.EventHandler(this.btnEnviarChat_Click);
            // 
            // chkdFormaVictoria_Lateral
            // 
            this.chkdFormaVictoria_Lateral.BackColor = System.Drawing.Color.SandyBrown;
            this.chkdFormaVictoria_Lateral.FormattingEnabled = true;
            this.chkdFormaVictoria_Lateral.Items.AddRange(new object[] {
            "Línea horizontal",
            "Línea vertical",
            "Diagonal",
            "Cartón lleno"});
            this.chkdFormaVictoria_Lateral.Location = new System.Drawing.Point(45, 102);
            this.chkdFormaVictoria_Lateral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkdFormaVictoria_Lateral.Name = "chkdFormaVictoria_Lateral";
            this.chkdFormaVictoria_Lateral.Size = new System.Drawing.Size(169, 72);
            this.chkdFormaVictoria_Lateral.TabIndex = 6;
            // 
            // btnNuevaFormaDeGanar_Lateral
            // 
            this.btnNuevaFormaDeGanar_Lateral.BackColor = System.Drawing.Color.Chocolate;
            this.btnNuevaFormaDeGanar_Lateral.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNuevaFormaDeGanar_Lateral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNuevaFormaDeGanar_Lateral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNuevaFormaDeGanar_Lateral.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFormaDeGanar_Lateral.Location = new System.Drawing.Point(92, 191);
            this.btnNuevaFormaDeGanar_Lateral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevaFormaDeGanar_Lateral.Name = "btnNuevaFormaDeGanar_Lateral";
            this.btnNuevaFormaDeGanar_Lateral.Size = new System.Drawing.Size(260, 46);
            this.btnNuevaFormaDeGanar_Lateral.TabIndex = 7;
            this.btnNuevaFormaDeGanar_Lateral.Text = "Crear nueva forma";
            this.btnNuevaFormaDeGanar_Lateral.UseVisualStyleBackColor = false;
            this.btnNuevaFormaDeGanar_Lateral.Click += new System.EventHandler(this.btnNuevaFormaDeGanar_Lateral_Click);
            // 
            // btnGuardarCarton
            // 
            this.btnGuardarCarton.Location = new System.Drawing.Point(69, 338);
            this.btnGuardarCarton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarCarton.Name = "btnGuardarCarton";
            this.btnGuardarCarton.Size = new System.Drawing.Size(144, 36);
            this.btnGuardarCarton.TabIndex = 26;
            this.btnGuardarCarton.Text = "Guardar cartón";
            this.btnGuardarCarton.UseVisualStyleBackColor = true;
            this.btnGuardarCarton.Click += new System.EventHandler(this.btnGuardarCarton_Click_1);
            // 
            // txtMensajeChat
            // 
            this.txtMensajeChat.Location = new System.Drawing.Point(116, 601);
            this.txtMensajeChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMensajeChat.Name = "txtMensajeChat";
            this.txtMensajeChat.Size = new System.Drawing.Size(297, 22);
            this.txtMensajeChat.TabIndex = 16;
            this.txtMensajeChat.TextChanged += new System.EventHandler(this.txtMensajeChat_TextChanged);
            // 
            // lblTitulo_Lateral
            // 
            this.lblTitulo_Lateral.AutoSize = true;
            this.lblTitulo_Lateral.BackColor = System.Drawing.Color.Maroon;
            this.lblTitulo_Lateral.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo_Lateral.Location = new System.Drawing.Point(137, 14);
            this.lblTitulo_Lateral.Name = "lblTitulo_Lateral";
            this.lblTitulo_Lateral.Size = new System.Drawing.Size(145, 28);
            this.lblTitulo_Lateral.TabIndex = 0;
            this.lblTitulo_Lateral.Text = "Configuración";
            // 
            // btnCargarCarton
            // 
            this.btnCargarCarton.Location = new System.Drawing.Point(228, 338);
            this.btnCargarCarton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCargarCarton.Name = "btnCargarCarton";
            this.btnCargarCarton.Size = new System.Drawing.Size(144, 36);
            this.btnCargarCarton.TabIndex = 25;
            this.btnCargarCarton.Text = "Cargar cartón";
            this.btnCargarCarton.UseVisualStyleBackColor = true;
            this.btnCargarCarton.Click += new System.EventHandler(this.btnCargarCarton_Click_1);
            // 
            // btnDesconectarRed
            // 
            this.btnDesconectarRed.BackColor = System.Drawing.Color.Tan;
            this.btnDesconectarRed.Enabled = false;
            this.btnDesconectarRed.Location = new System.Drawing.Point(213, 459);
            this.btnDesconectarRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDesconectarRed.Name = "btnDesconectarRed";
            this.btnDesconectarRed.Size = new System.Drawing.Size(160, 34);
            this.btnDesconectarRed.TabIndex = 18;
            this.btnDesconectarRed.Text = "Desconectar Red";
            this.btnDesconectarRed.UseVisualStyleBackColor = false;
            this.btnDesconectarRed.Click += new System.EventHandler(this.btnDesconectarRed_Click);
            // 
            // btnCrearCarton
            // 
            this.btnCrearCarton.Location = new System.Drawing.Point(228, 298);
            this.btnCrearCarton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearCarton.Name = "btnCrearCarton";
            this.btnCrearCarton.Size = new System.Drawing.Size(144, 34);
            this.btnCrearCarton.TabIndex = 24;
            this.btnCrearCarton.Text = "Crear cartón";
            this.btnCrearCarton.UseVisualStyleBackColor = true;
            this.btnCrearCarton.Click += new System.EventHandler(this.btnCrearCarton_Click_1);
            // 
            // btnUnirsePartida
            // 
            this.btnUnirsePartida.BackColor = System.Drawing.Color.Tan;
            this.btnUnirsePartida.Location = new System.Drawing.Point(75, 459);
            this.btnUnirsePartida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnirsePartida.Name = "btnUnirsePartida";
            this.btnUnirsePartida.Size = new System.Drawing.Size(131, 34);
            this.btnUnirsePartida.TabIndex = 17;
            this.btnUnirsePartida.Text = "Unirse";
            this.btnUnirsePartida.UseVisualStyleBackColor = false;
            this.btnUnirsePartida.Click += new System.EventHandler(this.btnUnirsePartida_Click);
            // 
            // btnReiniciarPartida_Lateral
            // 
            this.btnReiniciarPartida_Lateral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReiniciarPartida_Lateral.Location = new System.Drawing.Point(228, 379);
            this.btnReiniciarPartida_Lateral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReiniciarPartida_Lateral.Name = "btnReiniciarPartida_Lateral";
            this.btnReiniciarPartida_Lateral.Size = new System.Drawing.Size(144, 39);
            this.btnReiniciarPartida_Lateral.TabIndex = 4;
            this.btnReiniciarPartida_Lateral.Text = "Reiniciar partida";
            this.btnReiniciarPartida_Lateral.UseVisualStyleBackColor = false;
            this.btnReiniciarPartida_Lateral.Click += new System.EventHandler(this.btnIniciarPartida_Lateral_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(69, 297);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(144, 34);
            this.btnMenu.TabIndex = 8;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LoteriaMexicana.Properties.Resources.FondoTablas;
            this.pictureBox2.Location = new System.Drawing.Point(45, 279);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(349, 159);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LoteriaMexicana.Properties.Resources.FondoTablas;
            this.pictureBox3.Location = new System.Drawing.Point(20, 53);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(407, 203);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // FrmJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.madera1;
            this.ClientSize = new System.Drawing.Size(1615, 658);
            this.Controls.Add(this.lstHistorial);
            this.Controls.Add(this.nudVelocidad);
            this.Controls.Add(this.lblVelocidad);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnBuenas);
            this.Controls.Add(this.btnSacarCarta);
            this.Controls.Add(this.panelCarton);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblCartaActual);
            this.Controls.Add(this.picCartaActual);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlConfigLateral);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lotería Mexicana - Juego";
            this.Load += new System.EventHandler(this.FrmJuego_Load);
            this.panelCarton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCartaActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlConfigLateral.ResumeLayout(false);
            this.pnlConfigLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadCartones_Lateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.PictureBox picCartaActual;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Panel panelCarton;
        private System.Windows.Forms.Button btnSacarCarta;
        private System.Windows.Forms.Button btnBuenas;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblCartaActual;

        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.NumericUpDown nudVelocidad;
        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.Button btnUnirsePartida;
        private System.Windows.Forms.Button btnDesconectarRed;
        private System.Windows.Forms.ListBox lstHistorial;

        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtMensajeChat;
        private System.Windows.Forms.Button btnEnviarChat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReiniciarPartida_Lateral;
        private System.Windows.Forms.Button btnCrearCarton;
        private System.Windows.Forms.Button btnCargarCarton;
        private System.Windows.Forms.Label lblTitulo_Lateral;
        private System.Windows.Forms.Button btnGuardarCarton;
        private System.Windows.Forms.Panel pnlConfigLateral;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1_Lateral;
        private System.Windows.Forms.Label lblCantidad_Lateral;
        private System.Windows.Forms.NumericUpDown nudCantidadCartones_Lateral;
        private System.Windows.Forms.CheckedListBox chkdFormaVictoria_Lateral;
        private System.Windows.Forms.Button btnNuevaFormaDeGanar_Lateral;
        private System.Windows.Forms.PictureBox pictureBox3;
        // --- FIN AÑADIDO ---
    }
}
