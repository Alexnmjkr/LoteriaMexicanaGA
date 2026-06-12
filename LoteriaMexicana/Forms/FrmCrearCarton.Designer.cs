namespace LoteriaMexicana.Forms
{
    partial class FrmCrearCarton
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
            this.lstCartas = new System.Windows.Forms.ListBox();
            this.picPreviewCarta = new System.Windows.Forms.PictureBox();
            this.chkPermitirDobles = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pic00 = new System.Windows.Forms.PictureBox();
            this.pic01 = new System.Windows.Forms.PictureBox();
            this.pic02 = new System.Windows.Forms.PictureBox();
            this.pic03 = new System.Windows.Forms.PictureBox();
            this.pic04 = new System.Windows.Forms.PictureBox();
            this.pic10 = new System.Windows.Forms.PictureBox();
            this.pic11 = new System.Windows.Forms.PictureBox();
            this.pic12 = new System.Windows.Forms.PictureBox();
            this.pic13 = new System.Windows.Forms.PictureBox();
            this.pic14 = new System.Windows.Forms.PictureBox();
            this.pic20 = new System.Windows.Forms.PictureBox();
            this.pic21 = new System.Windows.Forms.PictureBox();
            this.pic22 = new System.Windows.Forms.PictureBox();
            this.pic23 = new System.Windows.Forms.PictureBox();
            this.pic24 = new System.Windows.Forms.PictureBox();
            this.pic30 = new System.Windows.Forms.PictureBox();
            this.pic31 = new System.Windows.Forms.PictureBox();
            this.pic32 = new System.Windows.Forms.PictureBox();
            this.pic33 = new System.Windows.Forms.PictureBox();
            this.pic34 = new System.Windows.Forms.PictureBox();
            this.pic40 = new System.Windows.Forms.PictureBox();
            this.pic41 = new System.Windows.Forms.PictureBox();
            this.pic42 = new System.Windows.Forms.PictureBox();
            this.pic43 = new System.Windows.Forms.PictureBox();
            this.pic44 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewCarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic00)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic44)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCartas
            // 
            this.lstCartas.FormattingEnabled = true;
            this.lstCartas.ItemHeight = 20;
            this.lstCartas.Location = new System.Drawing.Point(24, 47);
            this.lstCartas.Name = "lstCartas";
            this.lstCartas.Size = new System.Drawing.Size(220, 404);
            this.lstCartas.TabIndex = 0;
            this.lstCartas.SelectedIndexChanged += new System.EventHandler(this.lstCartas_SelectedIndexChanged);
            // 
            // picPreviewCarta
            // 
            this.picPreviewCarta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreviewCarta.Location = new System.Drawing.Point(270, 47);
            this.picPreviewCarta.Name = "picPreviewCarta";
            this.picPreviewCarta.Size = new System.Drawing.Size(130, 180);
            this.picPreviewCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreviewCarta.TabIndex = 1;
            this.picPreviewCarta.TabStop = false;
            // 
            // chkPermitirDobles
            // 
            this.chkPermitirDobles.AutoSize = true;
            this.chkPermitirDobles.BackColor = System.Drawing.Color.Transparent;
            this.chkPermitirDobles.Location = new System.Drawing.Point(24, 502);
            this.chkPermitirDobles.Name = "chkPermitirDobles";
            this.chkPermitirDobles.Size = new System.Drawing.Size(206, 24);
            this.chkPermitirDobles.TabIndex = 2;
            this.chkPermitirDobles.Text = "Permitir cartas repetidas";
            this.chkPermitirDobles.UseVisualStyleBackColor = false;
            this.chkPermitirDobles.CheckedChanged += new System.EventHandler(this.chkPermitirDobles_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(270, 320);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 35);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(270, 365);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pic00
            // 
            this.pic00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic00.Location = new System.Drawing.Point(430, 47);
            this.pic00.Name = "pic00";
            this.pic00.Size = new System.Drawing.Size(80, 91);
            this.pic00.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic00.TabIndex = 6;
            this.pic00.TabStop = false;
            this.pic00.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic01
            // 
            this.pic01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic01.Location = new System.Drawing.Point(520, 47);
            this.pic01.Name = "pic01";
            this.pic01.Size = new System.Drawing.Size(80, 91);
            this.pic01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic01.TabIndex = 7;
            this.pic01.TabStop = false;
            this.pic01.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic02
            // 
            this.pic02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic02.Location = new System.Drawing.Point(610, 47);
            this.pic02.Name = "pic02";
            this.pic02.Size = new System.Drawing.Size(80, 91);
            this.pic02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic02.TabIndex = 8;
            this.pic02.TabStop = false;
            this.pic02.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic03
            // 
            this.pic03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic03.Location = new System.Drawing.Point(700, 47);
            this.pic03.Name = "pic03";
            this.pic03.Size = new System.Drawing.Size(80, 91);
            this.pic03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic03.TabIndex = 9;
            this.pic03.TabStop = false;
            this.pic03.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic04
            // 
            this.pic04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic04.Location = new System.Drawing.Point(790, 47);
            this.pic04.Name = "pic04";
            this.pic04.Size = new System.Drawing.Size(80, 91);
            this.pic04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic04.TabIndex = 10;
            this.pic04.TabStop = false;
            this.pic04.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic10
            // 
            this.pic10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic10.Location = new System.Drawing.Point(430, 154);
            this.pic10.Name = "pic10";
            this.pic10.Size = new System.Drawing.Size(80, 110);
            this.pic10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic10.TabIndex = 11;
            this.pic10.TabStop = false;
            this.pic10.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic11
            // 
            this.pic11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic11.Location = new System.Drawing.Point(520, 154);
            this.pic11.Name = "pic11";
            this.pic11.Size = new System.Drawing.Size(80, 110);
            this.pic11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic11.TabIndex = 12;
            this.pic11.TabStop = false;
            this.pic11.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic12
            // 
            this.pic12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic12.Location = new System.Drawing.Point(610, 154);
            this.pic12.Name = "pic12";
            this.pic12.Size = new System.Drawing.Size(80, 110);
            this.pic12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic12.TabIndex = 13;
            this.pic12.TabStop = false;
            this.pic12.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic13
            // 
            this.pic13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic13.Location = new System.Drawing.Point(704, 154);
            this.pic13.Name = "pic13";
            this.pic13.Size = new System.Drawing.Size(80, 110);
            this.pic13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic13.TabIndex = 14;
            this.pic13.TabStop = false;
            this.pic13.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic14
            // 
            this.pic14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic14.Location = new System.Drawing.Point(790, 154);
            this.pic14.Name = "pic14";
            this.pic14.Size = new System.Drawing.Size(80, 110);
            this.pic14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic14.TabIndex = 15;
            this.pic14.TabStop = false;
            this.pic14.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic20
            // 
            this.pic20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic20.Location = new System.Drawing.Point(430, 270);
            this.pic20.Name = "pic20";
            this.pic20.Size = new System.Drawing.Size(80, 110);
            this.pic20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic20.TabIndex = 16;
            this.pic20.TabStop = false;
            this.pic20.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic21
            // 
            this.pic21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic21.Location = new System.Drawing.Point(520, 270);
            this.pic21.Name = "pic21";
            this.pic21.Size = new System.Drawing.Size(80, 110);
            this.pic21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic21.TabIndex = 17;
            this.pic21.TabStop = false;
            this.pic21.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic22
            // 
            this.pic22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic22.Location = new System.Drawing.Point(610, 270);
            this.pic22.Name = "pic22";
            this.pic22.Size = new System.Drawing.Size(80, 110);
            this.pic22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic22.TabIndex = 18;
            this.pic22.TabStop = false;
            this.pic22.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic23
            // 
            this.pic23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic23.Location = new System.Drawing.Point(704, 270);
            this.pic23.Name = "pic23";
            this.pic23.Size = new System.Drawing.Size(80, 110);
            this.pic23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic23.TabIndex = 19;
            this.pic23.TabStop = false;
            this.pic23.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic24
            // 
            this.pic24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic24.Location = new System.Drawing.Point(790, 270);
            this.pic24.Name = "pic24";
            this.pic24.Size = new System.Drawing.Size(80, 110);
            this.pic24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic24.TabIndex = 20;
            this.pic24.TabStop = false;
            this.pic24.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic30
            // 
            this.pic30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic30.Location = new System.Drawing.Point(430, 386);
            this.pic30.Name = "pic30";
            this.pic30.Size = new System.Drawing.Size(80, 110);
            this.pic30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic30.TabIndex = 21;
            this.pic30.TabStop = false;
            this.pic30.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic31
            // 
            this.pic31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic31.Location = new System.Drawing.Point(524, 386);
            this.pic31.Name = "pic31";
            this.pic31.Size = new System.Drawing.Size(80, 110);
            this.pic31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic31.TabIndex = 22;
            this.pic31.TabStop = false;
            this.pic31.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic32
            // 
            this.pic32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic32.Location = new System.Drawing.Point(610, 386);
            this.pic32.Name = "pic32";
            this.pic32.Size = new System.Drawing.Size(80, 110);
            this.pic32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic32.TabIndex = 23;
            this.pic32.TabStop = false;
            this.pic32.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic33
            // 
            this.pic33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic33.Location = new System.Drawing.Point(704, 386);
            this.pic33.Name = "pic33";
            this.pic33.Size = new System.Drawing.Size(80, 110);
            this.pic33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic33.TabIndex = 24;
            this.pic33.TabStop = false;
            this.pic33.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic34
            // 
            this.pic34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic34.Location = new System.Drawing.Point(790, 386);
            this.pic34.Name = "pic34";
            this.pic34.Size = new System.Drawing.Size(80, 110);
            this.pic34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic34.TabIndex = 25;
            this.pic34.TabStop = false;
            this.pic34.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic40
            // 
            this.pic40.Location = new System.Drawing.Point(430, 502);
            this.pic40.Name = "pic40";
            this.pic40.Size = new System.Drawing.Size(80, 110);
            this.pic40.TabIndex = 26;
            this.pic40.TabStop = false;
            this.pic40.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic41
            // 
            this.pic41.Location = new System.Drawing.Point(524, 502);
            this.pic41.Name = "pic41";
            this.pic41.Size = new System.Drawing.Size(80, 110);
            this.pic41.TabIndex = 27;
            this.pic41.TabStop = false;
            this.pic41.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic42
            // 
            this.pic42.Location = new System.Drawing.Point(610, 502);
            this.pic42.Name = "pic42";
            this.pic42.Size = new System.Drawing.Size(80, 110);
            this.pic42.TabIndex = 28;
            this.pic42.TabStop = false;
            // 
            // pic43
            // 
            this.pic43.Location = new System.Drawing.Point(704, 502);
            this.pic43.Name = "pic43";
            this.pic43.Size = new System.Drawing.Size(80, 110);
            this.pic43.TabIndex = 29;
            this.pic43.TabStop = false;
            this.pic43.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // pic44
            // 
            this.pic44.Location = new System.Drawing.Point(790, 502);
            this.pic44.Name = "pic44";
            this.pic44.Size = new System.Drawing.Size(80, 110);
            this.pic44.TabIndex = 30;
            this.pic44.TabStop = false;
            this.pic44.Click += new System.EventHandler(this.picCasilla_Click);
            // 
            // FrmCrearCarton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LoteriaMexicana.Properties.Resources.CrearCarton;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(910, 694);
            this.Controls.Add(this.pic44);
            this.Controls.Add(this.pic43);
            this.Controls.Add(this.pic42);
            this.Controls.Add(this.pic41);
            this.Controls.Add(this.pic40);
            this.Controls.Add(this.pic34);
            this.Controls.Add(this.pic33);
            this.Controls.Add(this.pic32);
            this.Controls.Add(this.pic31);
            this.Controls.Add(this.pic30);
            this.Controls.Add(this.pic24);
            this.Controls.Add(this.pic23);
            this.Controls.Add(this.pic22);
            this.Controls.Add(this.pic21);
            this.Controls.Add(this.pic20);
            this.Controls.Add(this.pic14);
            this.Controls.Add(this.pic13);
            this.Controls.Add(this.pic12);
            this.Controls.Add(this.pic11);
            this.Controls.Add(this.pic10);
            this.Controls.Add(this.pic04);
            this.Controls.Add(this.pic03);
            this.Controls.Add(this.pic02);
            this.Controls.Add(this.pic01);
            this.Controls.Add(this.pic00);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.chkPermitirDobles);
            this.Controls.Add(this.picPreviewCarta);
            this.Controls.Add(this.lstCartas);
            this.Name = "FrmCrearCarton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crea tu cartón";
            this.Load += new System.EventHandler(this.FrmCrearCarton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewCarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic00)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic44)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox lstCartas;
        private System.Windows.Forms.PictureBox picPreviewCarta;
        private System.Windows.Forms.CheckBox chkPermitirDobles;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pic00;
        private System.Windows.Forms.PictureBox pic01;
        private System.Windows.Forms.PictureBox pic02;
        private System.Windows.Forms.PictureBox pic03;
        private System.Windows.Forms.PictureBox pic04;
        private System.Windows.Forms.PictureBox pic10;
        private System.Windows.Forms.PictureBox pic11;
        private System.Windows.Forms.PictureBox pic12;
        private System.Windows.Forms.PictureBox pic13;
        private System.Windows.Forms.PictureBox pic14;
        private System.Windows.Forms.PictureBox pic20;
        private System.Windows.Forms.PictureBox pic21;
        private System.Windows.Forms.PictureBox pic22;
        private System.Windows.Forms.PictureBox pic23;
        private System.Windows.Forms.PictureBox pic24;
        private System.Windows.Forms.PictureBox pic30;
        private System.Windows.Forms.PictureBox pic31;
        private System.Windows.Forms.PictureBox pic32;
        private System.Windows.Forms.PictureBox pic33;
        private System.Windows.Forms.PictureBox pic34;
        private System.Windows.Forms.PictureBox pic40;
        private System.Windows.Forms.PictureBox pic41;
        private System.Windows.Forms.PictureBox pic42;
        private System.Windows.Forms.PictureBox pic43;
        private System.Windows.Forms.PictureBox pic44;
    }
}