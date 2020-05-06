using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Lexico_Sintactico
{
    class GramaticaC : Grammar
    {
        public static class NoTerminales 
        {
            public const string Raiz = "<raiz>";
            public const string DeclaracionVariable = "<declaracion-variable>";
            public const string LineaDeclaracionVariable = "<lista-declaracion-variables>";
            public const string LineaDeclaracionVariableValores = "<lista-declaracion-variables-valores>";
            public const string Tipo = "<tipo>";

            public const string Asignacion = "<asignacion>";
            public const string AsignacionSentencia = "<asignacion-sentencia>";
            public const string Asignable = "<asignable>";
            public const string ListaAsignable = "<lista-asignable>";
            public const string ExpresionAritmetica = "<expresion-aritemtica>";
            public const string OperadorAritmetico = "<operador-aritmetico>";
            public const string ExpresionRelacional = "<expresion-relacional>";
            public const string OperadorRelacional = "<operador-relacional>";
            public const string LlamadaFuncion = "<llamada-funcion>";
            public const string IdLlamadaFuncion = "<id-llamada-funcion>";
            public const string DeclaracionFuncion = "<declaracion-funcion>";
            public const string TipoFuncion = "<tipo-funcion>";
            public const string BloqueFuncion = "<bloque-funcion>";
            public const string Parametro = "<parametro>";
            public const string ListaParametro = "<lista-parametro>";
            public const string Sentencia = "<sentencia>";
            public const string ListaSentencia = "<lista-sentencia>";
            public const string ControladorFlujo = "<controlador-flujo>";
            public const string SentenciaIf = "<if>";
            public const string BloqueIf = "<bloque-if>";
            public const string SentenciaElse = "<else>";
            public const string SentenciaWhen = "<when>";
            public const string BloqueWhen = "<bloque-when>";
            public const string OpcionWhen = "<opcion-when>";
            public const string ListaOpcionWhen = "<lista-opcion-when>";
            public const string DefaultWhen = "<default-when>";
            public const string SentenciaWhile = "<sentencia-while>";
            public const string BloqueWhile = "<bloque-while>";
            public const string SentenciaFor = "<for>";
            public const string ParametrosFor = "<parametros-for>";
            public const string ParametroFor1 = "<parametro-for-1>";
            public const string ParametroFor2 = "<parametro-for-2>";
            public const string ParametroFor3 = "<parametro-for-3>";
            public const string BloqueFor = "<bloque-for>";
            public const string Write = "<write>";
            public const string WriteLine = "<write-line>";
            public const string Instruccion = "<instruccion>";
            public const string Input = "<input>";
        }

        public static class Terminales
        {
            public const string Void = "void";
            public const string Return = "return";
            public const string Const = "const";
            public const string Null = "null";
            public const string True = "true";
            public const string False = "false";
            public const string Console = "Console";
            public const string Write = "Write";
            public const string WriteLine = "WriteLine";
            public const string Break = "break";
            public const string Main = "Main";
            public const string Static = "static";
            public const string Public = "public";
            public const string Private = "private";
            public const string Class = "class";

            public const string If = "if";
            public const string Else = "else";
            public const string Default = "default";
            public const string While = "while";
            public const string For = "for";
            public const string Switch = "switch";
            public const string Case = "case";

            public const string Int = "int";
            public const string Float = "float";
            public const string Double = "double";
            public const string Bool = "bool";
            public const string String = "string";

            public const string And = "&&";
            public const string Or = "||";
            public const string Not = "!";

            public const string Add = "+=";
            public const string Sub = "-=";
            public const string Mul = "*=";
            public const string Div = "/=";
            public const string Mod = "%=";
            public const string Pow = "^=";
            public const string Roo = "~=";

            public const string IgualIgual = "==";
            public const string Diferente = "!=";
            public const string Mayor = ">";
            public const string MayorIgual = ">=";
            public const string Menor = "<";
            public const string MenorIgual = "<=";

            public const string Mas = "+";
            public const string Menos = "-";
            public const string Por = "*";
            public const string Entre = "/";
            public const string Modulo = "%";

            public const string Punto = ".";
            public const string Coma = ",";
            public const string DosPuntos = ":";
            public const string PuntoComa = ";";
            public const string ParentesisAbrir = "(";
            public const string ParentesisCerrar = ")";
            public const string CorcheteAbrir = "[";
            public const string CorcheteCerrar = "]";
            public const string LlavesAbrir = "{";
            public const string LlavesCerrar = "}";
            public const string Igual = "=";

            public const string InputLine = "Console.ReadLine";
            public const string InputChar = "Console.Read";
        }

        public static class ExpresionesRegulares
        {
            public const string Comentario = "comentario";
            public const string ComentarioRegex = "(\\/\\*(\\s*|.*?)*\\*\\/)|(\\/\\/.*)";
            public const string Nombre = "id";
            public const string NombreRegex = "([a-zA-Z]|_*[a-zA-Z]){1}[a-zA-Z0-9_]*";
            public const string Numero = "numero";
            public const string NumeroRegex = "\\d+[f|d]?(\\.\\d+[f|d]?)?";
            public const string String = "string";
            public const string StringRegex = "\"[^\"]*\"";
        }

        public GramaticaC() : base()
        {
            #region NoTerminales
            var raiz = new NonTerminal(NoTerminales.Raiz);
            #endregion

            #region Terminales

            #region Palabras Reservadas
            var void_ = ToTerm(Terminales.Void);
            var return_ = ToTerm(Terminales.Return);
            var const_ = ToTerm(Terminales.Const);
            var null_ = ToTerm(Terminales.Null);
            var true_ = ToTerm(Terminales.True);
            var false_ = ToTerm(Terminales.False);
            var console_ = ToTerm(Terminales.Console);
            var write_ = ToTerm(Terminales.Write);
            var writeline_ = ToTerm(Terminales.WriteLine);
            var break_ = ToTerm(Terminales.Break);
            var main_ = ToTerm(Terminales.Main);
            var static_ = ToTerm(Terminales.Static);
            var public_ = ToTerm(Terminales.Public);
            var private_ = ToTerm(Terminales.Private);
            var class_ = ToTerm(Terminales.Class);
            #endregion

            #region Control de flujo
            var if_ = ToTerm(Terminales.If);
            var else_ = ToTerm(Terminales.Else);
            var default_ = ToTerm(Terminales.Default);
            var while_ = ToTerm(Terminales.While);
            var for_ = ToTerm(Terminales.For);
            var switch_ = ToTerm(Terminales.Switch);
            var case_ = ToTerm(Terminales.Case);
            #endregion

            #region Tipos de dato
            var int_ = ToTerm(Terminales.Int);
            var float_ = ToTerm(Terminales.Float);
            var double_ = ToTerm(Terminales.Double);
            var bool_ = ToTerm(Terminales.Bool);
            var string_ = ToTerm(Terminales.String);
            #endregion

            #region Simbolos
            var punto_ = ToTerm(Terminales.Punto);
            var coma_ = ToTerm(Terminales.Coma);
            var dosPuntos_ = ToTerm(Terminales.DosPuntos);
            var puntoComa_ = ToTerm(Terminales.PuntoComa);
            var parentesisAbrir_ = ToTerm(Terminales.ParentesisAbrir);
            var parentesisCerrar_ = ToTerm(Terminales.ParentesisCerrar);
            var corcheteAbrir_ = ToTerm(Terminales.CorcheteAbrir);
            var corcheteCerrar_ = ToTerm(Terminales.CorcheteCerrar);
            var llavesAbrir_ = ToTerm(Terminales.LlavesAbrir);
            var llavesCerrar_ = ToTerm(Terminales.LlavesCerrar);
            var igual_ = ToTerm(Terminales.Igual);
            #endregion

            #region Operadores logicos
            var and_ = ToTerm(Terminales.And);
            var or_ = ToTerm(Terminales.Or);
            var not_ = ToTerm(Terminales.Not);
            #endregion

            #region Operadores matematicos
            var add_ = ToTerm(Terminales.Add);
            var sub_ = ToTerm(Terminales.Sub);
            var mul_ = ToTerm(Terminales.Mul);
            var div_ = ToTerm(Terminales.Div);
            var mod_ = ToTerm(Terminales.Mod);
            var pow_ = ToTerm(Terminales.Pow);
            var roo_ = ToTerm(Terminales.Roo);
            #endregion

            #region Operadores relacionales
            var igualIgual_ = ToTerm(Terminales.IgualIgual);
            var diferente_ = ToTerm(Terminales.Diferente);
            var mayor_ = ToTerm(Terminales.Mayor);
            var mayorIgual_ = ToTerm(Terminales.MayorIgual);
            var menor_ = ToTerm(Terminales.Menor);
            var menorIgual_ = ToTerm(Terminales.MenorIgual);
            #endregion

            #region Operadores aritmeticos
            var mas_ = ToTerm(Terminales.Mas);
            var menos_ = ToTerm(Terminales.Menos);
            var por_ = ToTerm(Terminales.Por);
            var entre_ = ToTerm(Terminales.Entre);
            var modulo_ = ToTerm(Terminales.Modulo);
            #endregion

            #region Entrada de datos
            var inputLine_ = ToTerm(Terminales.InputLine);
            var inputChar_ = ToTerm(Terminales.InputChar);
            #endregion

            #endregion

            #region ExpresionesRegulares
            var comentario = new RegexBasedTerminal(ExpresionesRegulares.Comentario, ExpresionesRegulares.ComentarioRegex);
            var id = new RegexBasedTerminal(ExpresionesRegulares.Nombre, ExpresionesRegulares.NombreRegex);
            var numero = new RegexBasedTerminal(ExpresionesRegulares.Numero, ExpresionesRegulares.NumeroRegex);
            var stringRegex = new RegexBasedTerminal(ExpresionesRegulares.String, ExpresionesRegulares.StringRegex);
            #endregion

            #region Reglas

            #endregion

            //Root = Raiz;
        }
    }
}
