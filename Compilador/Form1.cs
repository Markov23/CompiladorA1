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

namespace Compilador
{
    public partial class Compilador : Form
    {
        DataTable dt = new DataTable();

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

            var gramatica = new GramaticaJ();
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
            LexerJ Formateador = new LexerJ();

            lista = Formateador.Formatear(lista);

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
            Compilar();
        }
    }
}
