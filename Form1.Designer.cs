namespace Objetos_3D
{
    partial class Fprincipal
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ocultacao = new MetroFramework.Controls.MetroToggle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.bt_luz = new MetroFramework.Controls.MetroTile();
            this.pbxZ = new System.Windows.Forms.PictureBox();
            this.pbxY = new System.Windows.Forms.PictureBox();
            this.pbxX = new System.Windows.Forms.PictureBox();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.btAbrir = new MetroFramework.Controls.MetroTile();
            this.gpBoxModo = new System.Windows.Forms.GroupBox();
            this.rbShading = new System.Windows.Forms.RadioButton();
            this.rbProj = new System.Windows.Forms.RadioButton();
            this.lbModo = new System.Windows.Forms.Label();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.trkR = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trkG = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.trkB = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.gpBoxModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkB)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 789);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X:  Y:";
            // 
            // ocultacao
            // 
            this.ocultacao.AutoSize = true;
            this.ocultacao.Location = new System.Drawing.Point(1152, 193);
            this.ocultacao.Name = "ocultacao";
            this.ocultacao.Size = new System.Drawing.Size(80, 17);
            this.ocultacao.Style = MetroFramework.MetroColorStyle.Purple;
            this.ocultacao.TabIndex = 8;
            this.ocultacao.Text = "Off";
            this.ocultacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ocultacao.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ocultacao.UseSelectable = true;
            this.ocultacao.CheckedChanged += new System.EventHandler(this.Ocultacao_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(1148, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Backface Culling";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(893, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Frontal(X,Y)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(893, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Superior(X,Z)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(893, 789);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Lateral(Y,Z)";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "xy",
            "Cabinet",
            "Cavalheira",
            "1 Ponto de fuga"});
            this.metroComboBox1.Location = new System.Drawing.Point(1152, 251);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroComboBox1.TabIndex = 16;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.MetroComboBox1_SelectedIndexChanged);
            // 
            // bt_luz
            // 
            this.bt_luz.ActiveControl = null;
            this.bt_luz.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_luz.Location = new System.Drawing.Point(455, 252);
            this.bt_luz.Name = "bt_luz";
            this.bt_luz.Size = new System.Drawing.Size(30, 30);
            this.bt_luz.Style = MetroFramework.MetroColorStyle.Black;
            this.bt_luz.TabIndex = 17;
            this.bt_luz.TileImage = global::Objetos_3D.Properties.Resources.Light_Bulb_256_redimensionada;
            this.bt_luz.UseSelectable = true;
            this.bt_luz.UseTileImage = true;
            this.bt_luz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MetroTile1_MouseMove);
            // 
            // pbxZ
            // 
            this.pbxZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbxZ.Location = new System.Drawing.Point(897, 570);
            this.pbxZ.Name = "pbxZ";
            this.pbxZ.Size = new System.Drawing.Size(240, 240);
            this.pbxZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxZ.TabIndex = 12;
            this.pbxZ.TabStop = false;
            // 
            // pbxY
            // 
            this.pbxY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbxY.Location = new System.Drawing.Point(897, 315);
            this.pbxY.Name = "pbxY";
            this.pbxY.Size = new System.Drawing.Size(240, 240);
            this.pbxY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxY.TabIndex = 11;
            this.pbxY.TabStop = false;
            // 
            // pbxX
            // 
            this.pbxX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbxX.Location = new System.Drawing.Point(897, 60);
            this.pbxX.Name = "pbxX";
            this.pbxX.Size = new System.Drawing.Size(240, 240);
            this.pbxX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxX.TabIndex = 10;
            this.pbxX.TabStop = false;
            // 
            // pbx
            // 
            this.pbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbx.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbx.Location = new System.Drawing.Point(20, 60);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(850, 740);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx.TabIndex = 3;
            this.pbx.TabStop = false;
            this.pbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pbx_MouseDown);
            this.pbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pbx_MouseMove);
            // 
            // btAbrir
            // 
            this.btAbrir.ActiveControl = null;
            this.btAbrir.Location = new System.Drawing.Point(160, 13);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(83, 41);
            this.btAbrir.Style = MetroFramework.MetroColorStyle.Purple;
            this.btAbrir.TabIndex = 1;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAbrir.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbrir.UseSelectable = true;
            this.btAbrir.UseTileImage = true;
            this.btAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // gpBoxModo
            // 
            this.gpBoxModo.Controls.Add(this.rbShading);
            this.gpBoxModo.Controls.Add(this.rbProj);
            this.gpBoxModo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpBoxModo.Location = new System.Drawing.Point(1152, 63);
            this.gpBoxModo.Name = "gpBoxModo";
            this.gpBoxModo.Size = new System.Drawing.Size(133, 84);
            this.gpBoxModo.TabIndex = 19;
            this.gpBoxModo.TabStop = false;
            this.gpBoxModo.Text = "Modo";
            // 
            // rbShading
            // 
            this.rbShading.AutoSize = true;
            this.rbShading.ForeColor = System.Drawing.SystemColors.Control;
            this.rbShading.Location = new System.Drawing.Point(6, 46);
            this.rbShading.Name = "rbShading";
            this.rbShading.Size = new System.Drawing.Size(96, 17);
            this.rbShading.TabIndex = 1;
            this.rbShading.Text = "Sombreamento";
            this.rbShading.UseVisualStyleBackColor = true;
            this.rbShading.CheckedChanged += new System.EventHandler(this.rbProj_CheckedChanged);
            // 
            // rbProj
            // 
            this.rbProj.AutoSize = true;
            this.rbProj.Checked = true;
            this.rbProj.ForeColor = System.Drawing.SystemColors.Control;
            this.rbProj.Location = new System.Drawing.Point(7, 19);
            this.rbProj.Name = "rbProj";
            this.rbProj.Size = new System.Drawing.Size(67, 17);
            this.rbProj.TabIndex = 0;
            this.rbProj.TabStop = true;
            this.rbProj.Text = "Projeção";
            this.rbProj.UseVisualStyleBackColor = true;
            this.rbProj.CheckedChanged += new System.EventHandler(this.rbProj_CheckedChanged);
            // 
            // lbModo
            // 
            this.lbModo.AutoSize = true;
            this.lbModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModo.ForeColor = System.Drawing.SystemColors.Control;
            this.lbModo.Location = new System.Drawing.Point(1148, 228);
            this.lbModo.Name = "lbModo";
            this.lbModo.Size = new System.Drawing.Size(71, 20);
            this.lbModo.TabIndex = 18;
            this.lbModo.Text = "Projeção";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(1156, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Cor";
            // 
            // trkR
            // 
            this.trkR.Location = new System.Drawing.Point(1150, 390);
            this.trkR.Maximum = 255;
            this.trkR.Name = "trkR";
            this.trkR.Size = new System.Drawing.Size(148, 45);
            this.trkR.TabIndex = 22;
            this.trkR.Value = 255;
            this.trkR.ValueChanged += new System.EventHandler(this.trkR_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(1163, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "R";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(1165, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "G";
            // 
            // trkG
            // 
            this.trkG.Location = new System.Drawing.Point(1150, 444);
            this.trkG.Maximum = 255;
            this.trkG.Name = "trkG";
            this.trkG.Size = new System.Drawing.Size(148, 45);
            this.trkG.TabIndex = 24;
            this.trkG.Value = 255;
            this.trkG.ValueChanged += new System.EventHandler(this.trkR_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(1165, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "B";
            // 
            // trkB
            // 
            this.trkB.Location = new System.Drawing.Point(1150, 492);
            this.trkB.Maximum = 255;
            this.trkB.Name = "trkB";
            this.trkB.Size = new System.Drawing.Size(148, 45);
            this.trkB.TabIndex = 26;
            this.trkB.Value = 255;
            this.trkB.ValueChanged += new System.EventHandler(this.trkR_ValueChanged);
            // 
            // Fprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 820);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trkB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trkG);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trkR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gpBoxModo);
            this.Controls.Add(this.lbModo);
            this.Controls.Add(this.bt_luz);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbxZ);
            this.Controls.Add(this.pbxY);
            this.Controls.Add(this.pbxX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ocultacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbx);
            this.Controls.Add(this.btAbrir);
            this.Name = "Fprincipal";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Objetos-3D";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            ((System.ComponentModel.ISupportInitialize)(this.pbxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.gpBoxModo.ResumeLayout(false);
            this.gpBoxModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTile btAbrir;
        private System.Windows.Forms.PictureBox pbx;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroToggle ocultacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbxX;
        private System.Windows.Forms.PictureBox pbxY;
        private System.Windows.Forms.PictureBox pbxZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroTile bt_luz;
        private System.Windows.Forms.GroupBox gpBoxModo;
        private System.Windows.Forms.RadioButton rbShading;
        private System.Windows.Forms.RadioButton rbProj;
        private System.Windows.Forms.Label lbModo;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trkR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trkG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trkB;
    }
}

