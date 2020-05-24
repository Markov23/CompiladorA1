using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Lexico
{
    class LexerP
    {
        List<string> listaNoTerminales = new List<string>();
        List<string> terminalPalabrasReservadas = new List<string>();
        List<string> terminalControladoresFlujo = new List<string>();
        List<string> terminalTipoDato = new List<string>();
        List<string> terminalOperadorLogico = new List<string>();
        List<string> terminalOperadorMatematico = new List<string>();
        List<string> terminalOperadorRelacional = new List<string>();
        List<string> terminalOperadorAritmetico = new List<string>();
        List<string> terminalSimbolo = new List<string>();
        List<string> terminalEntrada = new List<string>();
        string[] arregloP;

        public LexerP()
        {
            llenarListaNoTerminales();
            llenarListaTerminales();
        }

        public void llenarListaNoTerminales()
        {
            listaNoTerminales.Add("<raiz>");
            listaNoTerminales.Add("<importacion-librerias>");
            listaNoTerminales.Add("<clase>");
            listaNoTerminales.Add("<libreria>");
            listaNoTerminales.Add("<tipo-acceso>");
            listaNoTerminales.Add("<main>");
            listaNoTerminales.Add("<bloque-codigo>");
            listaNoTerminales.Add("<operacion-variable>");
            listaNoTerminales.Add("<declaracion-variable>");
            listaNoTerminales.Add("<tipo-dato");
            listaNoTerminales.Add("<variable>");
            listaNoTerminales.Add("<valor>");
            listaNoTerminales.Add("<entrada-datos>");
            listaNoTerminales.Add("<tipo-entrada>");
            listaNoTerminales.Add("<expresion-aritmetica>");
            listaNoTerminales.Add("<operador-aritmetico>");
            listaNoTerminales.Add("<valor-logico>");
            listaNoTerminales.Add("<asignar-valor>");
            listaNoTerminales.Add("<operador-asignacion>");
            listaNoTerminales.Add("<declaracion-scanner>");
            listaNoTerminales.Add("<operacion-simple>");
            listaNoTerminales.Add("<salida-pantalla>");
            listaNoTerminales.Add("<controlador-flujo>");
            listaNoTerminales.Add("<if>");
            listaNoTerminales.Add("<bloque-if>");
            listaNoTerminales.Add("<condicion>");
            listaNoTerminales.Add("<operador-relacional>");
            listaNoTerminales.Add("<operador-logico>");
            listaNoTerminales.Add("<bloque-else>");
            listaNoTerminales.Add("<switch>");
            listaNoTerminales.Add("<bloque-switch>");
            listaNoTerminales.Add("<caso>");
            listaNoTerminales.Add("<declaracion-arreglo>");
            listaNoTerminales.Add("<arreglo>");
            listaNoTerminales.Add("<bloque-for>");
            listaNoTerminales.Add("<bloque-while>");
            listaNoTerminales.Add("<bloque-do-while>");
        }

        public void llenarListaTerminales()
        {
            #region Palabras Reservadas
            terminalPalabrasReservadas.Add("null");
            terminalPalabrasReservadas.Add("true");
            terminalPalabrasReservadas.Add("false");
            terminalPalabrasReservadas.Add("show");
            terminalPalabrasReservadas.Add("showln");
            terminalPalabrasReservadas.Add("break");
            terminalPalabrasReservadas.Add("main");
            terminalPalabrasReservadas.Add("public");
            terminalPalabrasReservadas.Add("private");
            terminalPalabrasReservadas.Add("class");
            terminalPalabrasReservadas.Add("new");
            terminalPalabrasReservadas.Add("use");
            terminalPalabrasReservadas.Add("assign");
            #endregion

            #region Controladores de flujo
            terminalControladoresFlujo.Add("if");
            terminalControladoresFlujo.Add("else");
            terminalControladoresFlujo.Add("default");
            terminalControladoresFlujo.Add("while");
            terminalControladoresFlujo.Add("do");
            terminalControladoresFlujo.Add("until");
            terminalControladoresFlujo.Add("cases");
            terminalControladoresFlujo.Add("when");
            #endregion

            #region Tipo de dato
            terminalTipoDato.Add("int");
            terminalTipoDato.Add("float");
            terminalTipoDato.Add("double");
            terminalTipoDato.Add("boolean");
            terminalTipoDato.Add("string");
            terminalTipoDato.Add("char");
            #endregion

            #region Operadores logicos
            terminalOperadorLogico.Add("and");
            terminalOperadorLogico.Add("or");
            terminalOperadorLogico.Add("not");
            #endregion

            #region Operadores matematicos
            terminalOperadorMatematico.Add("assignA");
            terminalOperadorMatematico.Add("assignS");
            terminalOperadorMatematico.Add("assignM");
            terminalOperadorMatematico.Add("assingD");
            terminalOperadorMatematico.Add("inc");
            terminalOperadorMatematico.Add("dec");
            #endregion

            #region Operadores relacionales
            terminalOperadorRelacional.Add("==");
            terminalOperadorRelacional.Add("!=");
            terminalOperadorRelacional.Add(">");
            terminalOperadorRelacional.Add(">=");
            terminalOperadorRelacional.Add("<");
            terminalOperadorRelacional.Add("<=");
            #endregion

            #region Operadores aritmeticos
            terminalOperadorAritmetico.Add("+");
            terminalOperadorAritmetico.Add("-");
            terminalOperadorAritmetico.Add("*");
            terminalOperadorAritmetico.Add("/");
            terminalOperadorAritmetico.Add("%");
            #endregion

            #region Simbolos
            terminalSimbolo.Add(".");
            terminalSimbolo.Add(",");
            terminalSimbolo.Add(":");
            terminalSimbolo.Add(";");
            terminalSimbolo.Add("(");
            terminalSimbolo.Add(")");
            terminalSimbolo.Add("[");
            terminalSimbolo.Add("]");
            terminalSimbolo.Add("{");
            terminalSimbolo.Add("}");
            terminalSimbolo.Add("=");
            #endregion

            #region Entrada de datos
            terminalEntrada.Add("getInt");
            terminalEntrada.Add("getFloat");
            terminalEntrada.Add("getDouble");
            terminalEntrada.Add("getBoolean");
            terminalEntrada.Add("getChar");
            terminalEntrada.Add("getString");
            #endregion

        }

        public List<string> Formatear(List<string> listaNodos)
        {
            for (int i = 0; i < listaNoTerminales.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    if (listaNodos[j].Contains(listaNoTerminales[i]))
                    {
                        listaNodos.RemoveAt(j);
                        j--;
                    }
                }
            }

            for (int i = 0; i < terminalPalabrasReservadas.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalPalabrasReservadas[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Palabra_Reservada";
                    }
                }
            }

            for (int i = 0; i < terminalControladoresFlujo.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalControladoresFlujo[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Controlador_Flujo";
                    }
                }
            }

            for (int i = 0; i < terminalTipoDato.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalTipoDato[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Tipo_Dato";
                    }
                }
            }

            for (int i = 0; i < terminalOperadorLogico.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalOperadorLogico[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Operador_Logico";
                    }
                }
            }

            for (int i = 0; i < terminalOperadorMatematico.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalOperadorMatematico[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Operador_Matematico";
                    }
                }
            }

            for (int i = 0; i < terminalOperadorRelacional.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalOperadorRelacional[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Operador_Relacional";
                    }
                }
            }

            for (int i = 0; i < terminalOperadorAritmetico.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalOperadorAritmetico[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Operador_Aritmetico";
                    }
                }
            }

            for (int i = 0; i < terminalSimbolo.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalSimbolo[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Simbolo";
                    }
                }
            }

            for (int i = 0; i < terminalEntrada.Count; i++)
            {
                for (int j = 0; j < listaNodos.Count; j++)
                {
                    arregloP = listaNodos[j].Split(' ');

                    if (arregloP[0].Equals(terminalEntrada[i]))
                    {
                        listaNodos[j] = listaNodos[j] + " Entrada_Datos";
                    }
                }
            }

            bool usado;

            for (int i = 0; i < listaNodos.Count; i++)
            {
                usado = false;
                arregloP = listaNodos[i].Split(' ');

                if (!arregloP[arregloP.Length - 1].Equals("Palabra_Reservada") && !arregloP[arregloP.Length - 1].Equals("Controlador_Flujo") && !arregloP[arregloP.Length - 1].Equals("Tipo_Dato") && !arregloP[arregloP.Length - 1].Equals("Operador_Logico") && !arregloP[arregloP.Length - 1].Equals("Operador_Matematico") && !arregloP[arregloP.Length - 1].Equals("Operador_Relacional") && !arregloP[arregloP.Length - 1].Equals("Operador_Aritmetico") && !arregloP[arregloP.Length - 1].Equals("Simbolo") && !arregloP[arregloP.Length - 1].Equals("Entrada_Datos"))
                {
                    if (listaNodos[i].Contains("(string)"))
                    {
                        listaNodos[i] = listaNodos[i] + " String";
                        usado = true;
                    }

                    if (listaNodos[i].Contains("(comentario)"))
                    {
                        listaNodos[i] = listaNodos[i] + " Comentario";
                        usado = true;
                    }

                    if (listaNodos[i].Contains("(id)"))
                    {
                        listaNodos[i] = listaNodos[i] + " Variable";
                        usado = true;
                    }

                    if (listaNodos[i].Contains("(numero)"))
                    {
                        listaNodos[i] = listaNodos[i] + " Numero";
                        usado = true;
                    }

                    if (usado == false)
                    {
                        listaNodos[i] = listaNodos[i] + " Null";
                    }

                }
            }

            return listaNodos;
        }
    }
}
