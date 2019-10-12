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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fprincipal));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btAbrir = new MetroFramework.Controls.MetroTile();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.btAbrir.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btAbrir.TileImage = ((System.Drawing.Image)(resources.GetObject("btAbrir.TileImage")));
            this.btAbrir.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbrir.UseSelectable = true;
            this.btAbrir.UseTileImage = true;
            this.btAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // pbx
            // 
            this.pbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbx.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbx.Location = new System.Drawing.Point(20, 60);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(974, 720);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx.TabIndex = 3;
            this.pbx.TabStop = false;
            this.pbx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pbx_MouseMove);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1000, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(226, 720);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(20, 783);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(39, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "X:  Y:";
            // 
            // Fprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 800);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.pbx);
            this.Controls.Add(this.btAbrir);
            this.Name = "Fprincipal";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Objetos-3D";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTile btAbrir;
        private System.Windows.Forms.PictureBox pbx;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}

