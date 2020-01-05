using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace Objetos_3D
{
    public partial class Fprincipal : MetroFramework.Forms.MetroForm
    {
        private Obj3D Objeto3D = null;
        private DirectBitmap Dbmp;
        private DirectBitmap DbmpXY;
        private DirectBitmap DbmpXZ;
        private DirectBitmap DbmpYZ;
        private Point posi;
        private string modo = "xy";
        private int x, y;

        public Fprincipal()
        {
            InitializeComponent();

            Dbmp= new DirectBitmap(pbx.Width, pbx.Height);
            DbmpXY = new DirectBitmap(pbx.Width, pbx.Height);
            DbmpXZ = new DirectBitmap(pbx.Width, pbx.Height);
            DbmpYZ = new DirectBitmap(pbx.Width, pbx.Height);

            pbx.Image = (Image)Dbmp.Bitmap;
            pbxX.Image = (Image)DbmpXY.Bitmap;
            pbxY.Image = (Image)DbmpXZ.Bitmap;
            pbxZ.Image = (Image)DbmpYZ.Bitmap;            

            openFileDialog1.Filter = "Objetos 3d|*.obj";
            openFileDialog1.FileName = "Selecione um Objeto";
            openFileDialog1.Title = "Abrir Arquivos";
            metroComboBox1.SelectedIndex = 0;
            this.pbx.MouseWheel += ScrollMouse;
            this.bt_luz.MouseWheel += ScrollMouseLuz;
        }

        private void RefreshPbx()
        {
            pbx.Refresh();
            pbxX.Refresh();
            pbxY.Refresh();
            pbxZ.Refresh();
        }

        private void AtualizaImagem()
        {
            pbx.Image = null;
            Dbmp.Dispose();
            DbmpXY.Dispose();
            DbmpXZ.Dispose();
            DbmpYZ.Dispose();
            Dbmp = new DirectBitmap(pbx.Width, pbx.Width);
            DbmpXY = new DirectBitmap(pbx.Width, pbx.Height);
            DbmpXZ = new DirectBitmap(pbx.Width, pbx.Height);
            DbmpYZ = new DirectBitmap(pbx.Width, pbx.Height);
            pbx.Image = (Image)Dbmp.Bitmap;
            pbxX.Image = (Image)DbmpXY.Bitmap;
            pbxY.Image = (Image)DbmpXZ.Bitmap;
            pbxZ.Image = (Image)DbmpYZ.Bitmap;
        }

        private void BtAbrir_Click(object sender, EventArgs e)
        {
            pbx.Image = new Bitmap(pbx.Width, pbx.Height);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Vertice> Vertices = new List<Vertice>();
                    List<Face> Faces = new List<Face>();
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string[] split;
                    string linha;
                    string[] s;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (linha != "")
                        {
                            if (linha[0] == 'v' && linha[1] == ' ')
                            {
                                linha = linha.Remove(0, 2);
                                linha = linha.Replace('.', ',');
                                split = linha.Split(' ');
                                Vertices.Add(new Vertice(double.Parse(split[0]), double.Parse(split[1]), double.Parse(split[2])));
                            }
                            else if (linha[0] == 'f')
                            {
                                linha = linha.Remove(0, 2);
                                split = linha.Split(' ');
                                List<int> indices = new List<int>();
                                for (int i = 0; i < split.Length; i++)
                                {
                                    split[i] = split[i].Substring(0, split[i].IndexOf('/'));
                                    indices.Add(int.Parse(split[i])-1);
                                }
                                Faces.Add(new Face(indices));
                            }
                        }
                            
                    }
                    AtualizaImagem();
                    Objeto3D = new Obj3D(Vertices, Faces); 
                    Desenha();                    
                    RefreshPbx();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                     $"Details:\n\n{ex.StackTrace}");
                    Objeto3D = null;
                }
            }
        }

        private void ScrollMouse(object sender, MouseEventArgs e)  // Evento que detecta Scrollup & Down
        {
            if (Objeto3D != null)
            {

                if (e.Delta > 0)//up
                    Objeto3D.Escala(1.1, 1.1, 1.1);
                else//down
                    Objeto3D.Escala(0.9, 0.9, 0.9);

                AtualizaImagem();
                Desenha();
                RefreshPbx();
            }
        }

        private void ScrollMouseLuz(object sender, MouseEventArgs e)  // Evento que detecta Scrollup & Down
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                x = e.X + bt_luz.Location.X;
                y = e.Y + bt_luz.Location.Y;

                int z;
                if (e.Delta > 0)
                    z = 1;
                else
                    z = -1;

                bt_luz.SetBounds(x, y, 30, 30);

                Objeto3D.setLuz(x, y, z);
                AtualizaImagem();
                Desenha();
                RefreshPbx();
            }
        }

        private void Pbx_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + e.X.ToString() + "  Y:" + e.Y.ToString();
            if (Objeto3D != null)
                /*if (e.Button == MouseButtons.Middle && e.Button == MouseButtons.Right)
                {
                    AtualizaImagem();

                    Objeto3D.Translada(0, 0, e.Y - posi.Y);
                    Desenha();
                    RefreshPbx();
                    posi = e.Location;
                }
                else */if (e.Button == MouseButtons.Middle /*&& e.Button == MouseButtons.Left*/)
                {
                    AtualizaImagem();

                    if (e.X > posi.X)
                        Objeto3D.RotacionaZ(2);
                    else
                        Objeto3D.RotacionaZ(-2);

                    Desenha();
                    RefreshPbx();
                }
               else if (e.Button == MouseButtons.Right && (e.X != posi.X || e.Y != posi.Y))
                {        
                    AtualizaImagem();

                    Objeto3D.Translada(e.X - posi.X, e.Y - posi.Y, 0);
                    Desenha();
                    RefreshPbx();
                    posi = e.Location;                
                }
                else if(e.Button == MouseButtons.Left)
                {
                    AtualizaImagem();
                    if (e.X > posi.X)
                        Objeto3D.RotacionaY(2);
                    if (e.X < posi.X)
                        Objeto3D.RotacionaY(-2);
                    if (e.Y > posi.Y)
                        Objeto3D.RotacionaX(-2);
                    if (e.Y < posi.Y)
                        Objeto3D.RotacionaX(2);

                    Desenha();
                    RefreshPbx();
                }
        }
        
        private void Pbx_MouseDown(object sender, MouseEventArgs e)
        {
            posi = new Point(e.X, e.Y);
        }       

        private void Ocultacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizaImagem();
            Desenha();
            RefreshPbx();
        }

        public void Desenha()
        {
            if (modo == "xy")
                Objeto3D.DesenhaXY(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);
            else if (modo == "Cabinet")
                Objeto3D.DesenhaCabinet(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);
            else if (modo == "Cavalheira")
                Objeto3D.DesenhaCavaleira(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);
            else if (modo == "1 Ponto de fuga")
                Objeto3D.DesenhaPtfuga(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);
            else if (modo == "Flat")
                Objeto3D.FlatShading(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value));
            else if (modo == "Gouraud")
                Objeto3D.GouraudtShading(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value));
            else if (modo == "Phong")
                Objeto3D.PhongShading(Dbmp, Color.FromArgb(trkR.Value, trkG.Value, trkB.Value));

            Objeto3D.DesenhaXY(DbmpXY , Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);
            Objeto3D.DesenhaXZ(DbmpXZ , Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);
            Objeto3D.DesenhaYZ(DbmpYZ , Color.FromArgb(trkR.Value, trkG.Value, trkB.Value), ocultacao.Checked);

        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Objeto3D != null)
            {
                modo = metroComboBox1.Text;
                AtualizaImagem();
                Desenha();
                RefreshPbx();
            }            
        }

        private void rbProj_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton) sender).Text.Equals("Projeção"))
            {
                ocultacao.Enabled = true;
                metroComboBox1.Items.Clear();
                metroComboBox1.Items.Add("xy");
                metroComboBox1.Items.Add("Cabinet");
                metroComboBox1.Items.Add("Cavalheira");
                metroComboBox1.Items.Add("1 Ponto de fuga");
                metroComboBox1.SelectedIndex = 0;
                lbModo.Text = "Projeção";
            }
            else
            {
                ocultacao.Enabled = false;
                metroComboBox1.Items.Clear();
                metroComboBox1.Items.Add("Flat");
                metroComboBox1.Items.Add("Gouraud");
                metroComboBox1.Items.Add("Phong");
                metroComboBox1.SelectedIndex = 0;
                lbModo.Text = "Sombreamento";
            }
        }

        private void trkR_ValueChanged(object sender, EventArgs e)
        {
            AtualizaImagem();
            Desenha();
            RefreshPbx();
        }

        private void MetroTile1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Left))
            {
                x = e.X + bt_luz.Location.X;
                y = e.Y + bt_luz.Location.Y;
                if (x > pbx.Location.X && x < pbx.Location.X + pbx.Width - bt_luz.Width) 
                    if(y > pbx.Location.Y && y < pbx.Location.Y + pbx.Height - bt_luz.Height)
                    {
                        bt_luz.SetBounds(x, y, 30, 30);
                        Objeto3D.setLuz(x, y, 10);
                        AtualizaImagem();
                        Desenha();
                        RefreshPbx();
                    }                        
            }
        }
    }
}

