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
    public partial class Form1 : Form
    {

        private List<Vertice> Vertices = new List<Vertice>();
        private List<Face> Faces = new List<Face>();

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Objetos 3d|*.obj";
            openFileDialog1.FileName = "Selecione um Objeto";
            openFileDialog1.Title = "Abrir Arquivos";

        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string[] split;
                    string linha;     
                    

                    while((linha = sr.ReadLine()) != null) 
                    {
                      
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
                            linha = linha.Remove(0, 2);
                            split = linha.Split(' ');
                            split[0] = split[0].Remove(1, 3);

                            //Faces.Add(new Face())

                            Console.WriteLine(linha);
                        }

                    }
                }
                catch(SecurityException ex){
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                     $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
