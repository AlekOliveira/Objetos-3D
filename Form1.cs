﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objetos_3D
{
    public partial class Fprincipal : MetroFramework.Forms.MetroForm
    {
        private Obj3D Objeto3D = null;
        private DirectBitmap Dbmp;
        private Point posi;
        private Boolean mouseDown = false;
        public Fprincipal()
        {
            InitializeComponent();

            Dbmp= new DirectBitmap(pbx.Width, pbx.Height);
            pbx.Image = (Image)Dbmp.Bitmap;
            pbxX.Image = (Image)Dbmp.Bitmap;
            pbxY.Image = (Image)Dbmp.Bitmap;
            pbxZ.Image = (Image)Dbmp.Bitmap;

            openFileDialog1.Filter = "Objetos 3d|*.obj";
            openFileDialog1.FileName = "Selecione um Objeto";
            openFileDialog1.Title = "Abrir Arquivos";            
            this.pbx.MouseWheel += ScrollMouse;
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
            Dbmp = new DirectBitmap(pbx.Width, pbx.Width);
            pbx.Image = (Image)Dbmp.Bitmap;
            pbxX.Image = (Image)Dbmp.Bitmap;
            pbxY.Image = (Image)Dbmp.Bitmap;
            pbxZ.Image = (Image)Dbmp.Bitmap;
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

                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (linha != "")
                            if (linha[0] == 'v' && linha[1] == ' ')
                            {
                                Console.WriteLine(linha);
                                linha = linha.Remove(0, 2);
                                linha = linha.Replace('.', ',');
                                split = linha.Split(' ');
                                Vertices.Add(new Vertice((int)double.Parse(split[0]), (int)double.Parse(split[1]), (int)double.Parse(split[2])));
                            }
                            else if (linha[0] == 'f')
                            {
                                Console.WriteLine(linha);
                                linha = linha.Remove(0, 2);
                                split = linha.Split(' ');
                                split[0] = split[0].Substring(0, split[0].IndexOf('/'));
                                split[1] = split[1].Substring(0, split[1].IndexOf('/'));
                                split[2] = split[2].Substring(0, split[2].IndexOf('/'));
                                Faces.Add(new Face(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
                            }
                    }
                    AtualizaImagem();
                    Objeto3D = new Obj3D(Vertices, Faces); //talvez vire lista
                    Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
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
                Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
                RefreshPbx();
            }
        }

        private void Pbx_MouseMove(object sender, MouseEventArgs e)
        {
            if(Objeto3D != null)
                if (e.Button == MouseButtons.Right)
                {                                
                    //label1.Text = "X: " + e.X.ToString() + "  Y:" + e.Y.ToString();

                    AtualizaImagem();

                    Objeto3D.Translada(e.X - posi.X, e.Y - posi.Y, 0);
                    Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
                    RefreshPbx();
                    posi = e.Location;                
                }
                else if(e.Button == MouseButtons.Left)
                {
                    AtualizaImagem();
                    if (e.X > posi.X)
                        Objeto3D.RotacionaY(1);
                    if(e.X < posi.X)
                        Objeto3D.RotacionaY(-1);                   
                    if(e.Y > posi.Y)
                        Objeto3D.RotacionaX(-1);
                    if (e.Y < posi.Y)
                        Objeto3D.RotacionaX(1);

                    Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
                    RefreshPbx();
                }
            
        }
        private void Pbx_MouseDown(object sender, MouseEventArgs e)
        {
            posi = new Point(e.X, e.Y);
        }       

        private void MetroTile2_Click(object sender, EventArgs e)
        {
            AtualizaImagem();
            
            Objeto3D.RotacionaX(10);
            Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
            RefreshPbx();
        }

        private void MetroTile3_Click(object sender, EventArgs e)
        {
            AtualizaImagem();

            Objeto3D.RotacionaZ(10);
            Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
            RefreshPbx();
        }

        private void MetroTile4_Click(object sender, EventArgs e)
        {
            AtualizaImagem();

            Objeto3D.RotacionaY(7);
            Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
            RefreshPbx();
        }      

        private void Ocultacao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizaImagem();
            Objeto3D.DesenhaFaces(Dbmp, Color.White, ocultacao.Checked);
            RefreshPbx();
        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Flat - Usaa normal da face
            // Gourard - normal do vetor (A = (n1+n2+n3+n4)), depois sair varrendo a listas de normais dos vertices
        }
    }
}

