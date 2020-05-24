using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using Compilador.Lexico_Sintactico;
using Compilador.Lexico;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Compilador
{
    public partial class Compilador : Form
    {
        DataTable dt = new DataTable();
        string rutaA = "";
        string rutaG = "";
        string nombre = "";

        public Compilador()
        {
            InitializeComponent();
            dt.Columns.Add("Simbolo");
            dt.Columns.Add("Token");
            dt.Columns.Add("Indice");
            datos.DataSource = dt;
        }

        public void Compilar()
        {
            List<string> lista = new List<string>();
            string codigo = entrada.Text;

            Console.WriteLine("Entrada:\n");
            Console.WriteLine(codigo);
            Console.WriteLine();

            Grammar gramatica;

            if(nombre.Contains(".rpc"))
            {
                gramatica = new GramaticaP();
            }
            else
            {
                gramatica = new GramaticaJ();
            }
            
            var parser = new Parser(gramatica);
            var arbol = parser.Parse(codigo);

            if (arbol.Root == null)
            {
                MessageBox.Show("Analisis Fallido");
            }
            else
            {
                //MessageBox.Show("Analisis Exitoso");        
                PrintParseTree(arbol.Root, lista);
                for(int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine(lista[i]);
                }
                Formatear(lista);
                LLenarTabla(lista);
            }        
        }

        public void LLenarTabla(List<string> lista)
        {
            dt.Rows.Clear();
            string[] arregloP;

            for(int i = 0; i < lista.Count; i++)
            {
                arregloP = lista[i].Split(' ');

                DataRow row = dt.NewRow();

                row["Simbolo"] = arregloP[0];
                row["Token"] = arregloP[arregloP.Length - 1].Replace('_',' '); ;
                row["Indice"] = arregloP[arregloP.Length-2];
                //datos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                //datos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                dt.Rows.Add(row);
            }            
        }

        public void Formatear(List<string> lista)
        {
            if (nombre.Contains(".rpc"))
            {
                LexerP Formateador = new LexerP();
                lista = Formateador.Formatear(lista);
            }
            else
            {
                LexerJ Formateador = new LexerJ();
                lista = Formateador.Formatear(lista);
            }        

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i]);
            }
        }

        public void PrintParseTree(ParseTreeNode node, List<string> lista, int index = 0, int level = 0)
        {
            /*
            for (var levelIndex = 0; levelIndex < level; levelIndex++)
            {
                Console.Write("\t");
            }*/

            lista.Add(node.ToString() + " [" + index + "]");

            var childIndex = 0;
            foreach (var child in node.ChildNodes)
            {
                PrintParseTree(child, lista, childIndex, level + 1);
                childIndex++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!rutaA.Equals(""))
            {
                nombre = rutaA.Split('\\')[rutaA.Split('\\').Length-1];

                Compilar();
            }
            else
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "raccoon files (*.rpc)|*.rpc|java files (*.java)|*.java|All files (*.*)|*.*";
                guardar.FilterIndex = 3;
                guardar.RestoreDirectory = true;

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    rutaG = guardar.FileName;

                    TextWriter archivo;

                    archivo = new StreamWriter(rutaG);

                    archivo.WriteLine(entrada.Text);

                    archivo.Close();

                    rutaA = rutaG;

                    nombre = rutaA.Split('\\')[rutaA.Split('\\').Length - 1];
                    tabPage1.Text = nombre;

                    if (nombre.Contains(".rpc"))
                    {
                        tabPage1.ImageIndex = 0;
                    }
                    else
                    {
                        tabPage1.ImageIndex = 1;
                    }

                    Compilar();
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entrada.Clear();
            rutaA = "";
            rutaG = "";
            tabPage1.Text = "Archivo";
            tabPage1.ImageIndex = 2;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "raccoon files (*.rpc)|*.rpc|java files (*.java)|*.java|All files (*.*)|*.*";
            abrir.FilterIndex = 3;
            abrir.RestoreDirectory = true;

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                entrada.Clear();
                rutaA = abrir.FileName;
                StreamReader leer = new StreamReader(rutaA);

                string linea;

                try
                {
                    linea = leer.ReadLine();
                    while (linea != null)
                    {
                        entrada.AppendText(linea + "\n");
                        linea = leer.ReadLine();
                    }

                    nombre = rutaA.Split('\\')[rutaA.Split('\\').Length - 1];
                    tabPage1.Text = nombre;

                    if (nombre.Contains(".rpc"))
                    {
                        tabPage1.ImageIndex = 0;
                    }
                    else
                    {
                        tabPage1.ImageIndex = 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: " + ex.Message);
                }
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!rutaA.Equals(""))
            {
                StreamWriter escribir = new StreamWriter(rutaA);

                try
                {
                    escribir.WriteLine(entrada.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocurrio un error: "+ex.Message);
                }

                escribir.Close();
            }
            else
            {
                GuardarComo();
            }
            
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        public void GuardarComo()
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "raccoon files (*.rpc)|*.rpc|java files (*.java)|*.java|All files (*.*)|*.*";
            guardar.FilterIndex = 3;
            guardar.RestoreDirectory = true;

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                rutaG = guardar.FileName;

                TextWriter archivo;

                archivo = new StreamWriter(rutaG);

                archivo.WriteLine(entrada.Text);

                archivo.Close();

                rutaA = rutaG;

                nombre = rutaA.Split('\\')[rutaA.Split('\\').Length - 1];
                tabPage1.Text = nombre;

                if (nombre.Contains(".rpc"))
                {
                    tabPage1.ImageIndex = 0;
                }
                else
                {
                    tabPage1.ImageIndex = 1;
                }
            }
        }
    }
}
