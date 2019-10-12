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
            this.btAbrir = new MetroFramework.Controls.MetroTile();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
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
            this.btAbrir.Location = new System.Drawing.Point(165, 13);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(78, 38);
            this.btAbrir.Style = MetroFramework.MetroColorStyle.Purple;
            this.btAbrir.TabIndex = 1;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.UseSelectable = true;
            this.btAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // pbx
            // 
            this.pbx.BackColor = System.Drawing.Color.Black;
            this.pbx.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbx.Location = new System.Drawing.Point(20, 60);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(949, 661);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbx.TabIndex = 3;
            this.pbx.TabStop = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.Fuchsia;
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(967, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(236, 661);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // Fprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 741);
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
    }
}

