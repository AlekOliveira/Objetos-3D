using System;
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
                    string linha = sr.ReadLine();
                    while(sr.ReadLine() != null) 
                    {
                        Console.WriteLine(linha);





                        linha = sr.ReadLine();
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
