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

namespace Compilador
{
    public partial class Compilador : Form
    {
        public Compilador()
        {
            InitializeComponent();
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
                MessageBox.Show("Analisis Exitoso");
                PrintParseTree(arbol.Root, lista);
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i]);
            }

            Console.ReadLine();
        }

        public void PrintParseTree(ParseTreeNode node, List<string> lista, int index = 0, int level = 0)
        {
            /*
            for (var levelIndex = 0; levelIndex < level; levelIndex++)
            {
                Console.Write("\t");
            }*/

            lista.Add(node + " [" + index + "]");

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
