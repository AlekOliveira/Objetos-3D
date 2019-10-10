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
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btAbrir
            // 
            this.btAbrir.ActiveControl = null;
            this.btAbrir.Location = new System.Drawing.Point(54, 108);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(109, 94);
            this.btAbrir.Style = MetroFramework.MetroColorStyle.Purple;
            this.btAbrir.TabIndex = 1;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.UseSelectable = true;
            this.btAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // Fprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 589);
            this.Controls.Add(this.btAbrir);
            this.Name = "Fprincipal";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Objetos-3D";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTile btAbrir;
    }
}

