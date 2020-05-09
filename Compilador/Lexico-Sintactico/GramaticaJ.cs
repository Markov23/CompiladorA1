using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace Compilador.Lexico_Sintactico
{
    class GramaticaJ : Grammar
    {
        public static class NoTerminales
        {
            public const string Raiz = "<raiz>";
            public const string ImportacionLibrerias = "<importacion-librerias>";
            public const string DeclaracionClase = "<clase>";
            public const string LLamadaLibreria = "<libreria>";
            public const string TipoAcceso = "<tipo-acceso>";
            public const string MetodoMain = "<main>";
            public const string BloqueCodigo = "<bloque-codigo>";
            public const string OperacionVariable = "<operacion-variable>";
            public const string DeclaracionVariable = "<declaracion-variable>";
            public const string TipoDato = "<tipo-dato";
            public const string Variable = "<variable>";
            public const string Valor = "<valor>";
            public const string EntradaDatos = "<entrada-datos>";
            public const string TipoEntrada = "<tipo-entrada>";
            public const string ExpresionAritmetica = "<expresion-aritmetica>";
            public const string OperadorAritmetico = "<operador-aritmetico>";
            public const string ValorLogico = "<valor-logico>";
            //public const string AsignacionValor = "<asignacion-valor>";
            public const string AsignarValor = "<asignar-valor>";
            public const string OperadorAsignacion = "<operador-asignacion>";
            public const string DeclaracionScanner = "<declaracion-scanner>";
            //public const string OperacionSimple = "<operacion-simple>";
            public const string SalidaPantalla = "<salida-pantalla>";
            public const string ControladorFlujo = "<controlador-flujo>";
            public const string If = "<if>";
            public const string BloqueIf = "<bloque-if>";
            public const string Condicion = "<condicion>";
            public const string OperadorRelacional = "<operador-relacional>";
            public const string OperadorLogico = "<operador-logico>";
            public const string BloqueElse = "<bloque-else>";
            public const string Switch = "<switch>";
            public const string BloqueSwitch = "<bloque-switch>";
            public const string Caso = "<caso>";
            public const string DeclaracionArreglo = "<declaracion-arreglo>";
        }

        public static class Terminales
        {
            public const string Void = "void";
            public const string Return = "return";
            public const string Null = "null";
            public const string True = "true";
            public const string False = "false";
            public const string System = "System";
            public const string Out = "out";
            public const string Print = "print";
            public const string Println = "println";
            public const string Break = "break";
            public const string Main = "main";
            public const string Static = "static";
            public const string Public = "public";
            public const string Private = "private";
            public const string Class = "class";
            public const string Scanner = "Scanner";
            public const string New = "new";
            public const string In = "in";
            public const string Import = "import";

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
            public const string Boolean = "boolean";
            public const string String = "string";

            public const string And = "&&";
            public const string Or = "||";
            public const string Not = "!";

            public const string Sumar = "+=";
            public const string Restar = "-=";
            public const string Multiplicar = "*=";
            public const string Dividir = "/=";
            public const string Modular = "%=";

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

            public const string NextInt = "nextInt";
            public const string NextFloat = "nextFloat";
            public const string NextDouble = "nextDouble";
            public const string NextBoolean = "nextBoolean";
            public const string Next = "next";
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

        public GramaticaJ() : base()
        {
            #region NoTerminales
            var raiz = new NonTerminal(NoTerminales.Raiz);
            var importacionLibrerias = new NonTerminal(NoTerminales.ImportacionLibrerias);
            var declaracionClase = new NonTerminal(NoTerminales.DeclaracionClase);
            var llamadaLibreria = new NonTerminal(NoTerminales.LLamadaLibreria);
            var tipoAcceso = new NonTerminal(NoTerminales.TipoAcceso);
            var metodoMain = new NonTerminal(NoTerminales.MetodoMain);
            var bloqueCodigo = new NonTerminal(NoTerminales.BloqueCodigo);
            var operacionVariable = new NonTerminal(NoTerminales.OperacionVariable);
            var declaracionVariable = new NonTerminal(NoTerminales.DeclaracionVariable);
            var tipoDato = new NonTerminal(NoTerminales.TipoDato);
            var variable = new NonTerminal(NoTerminales.Variable);
            var valor = new NonTerminal(NoTerminales.Valor);
            var entradaDatos = new NonTerminal(NoTerminales.EntradaDatos);
            var tipoEntrada = new NonTerminal(NoTerminales.TipoEntrada);
            var expresionAritmetica = new NonTerminal(NoTerminales.ExpresionAritmetica);
            var operadorAritmetico = new NonTerminal(NoTerminales.OperadorAritmetico);
            var valorLogico = new NonTerminal(NoTerminales.ValorLogico);
            //var asignacionValor = new NonTerminal(NoTerminales.AsignacionValor);
            var asignarValor = new NonTerminal(NoTerminales.AsignarValor);
            var operadorAsignacion = new NonTerminal(NoTerminales.OperadorAsignacion);
            var declaracionScanner = new NonTerminal(NoTerminales.DeclaracionScanner);
            //var operacionSimple = new NonTerminal(NoTerminales.OperacionSimple);
            var salidaPantalla = new NonTerminal(NoTerminales.SalidaPantalla);
            var controladorFlujo = new NonTerminal(NoTerminales.ControladorFlujo);
            var ifRegla = new NonTerminal(NoTerminales.If);
            var bloqueIf = new NonTerminal(NoTerminales.BloqueIf);
            var condicion = new NonTerminal(NoTerminales.Condicion);
            var operadorRelacional = new NonTerminal(NoTerminales.OperadorRelacional);
            var operadorLogico = new NonTerminal(NoTerminales.OperadorLogico);
            var bloqueElse = new NonTerminal(NoTerminales.BloqueElse);
            var switchRegla = new NonTerminal(NoTerminales.Switch);
            var bloqueSwitch = new NonTerminal(NoTerminales.BloqueSwitch);
            var caso = new NonTerminal(NoTerminales.Caso);
            var declaracionArreglo = new NonTerminal(NoTerminales.DeclaracionArreglo);

            #endregion

            #region Terminales

            #region Palabras Reservadas
            var void_ = ToTerm(Terminales.Void);
            var return_ = ToTerm(Terminales.Return);
            var null_ = ToTerm(Terminales.Null);
            var true_ = ToTerm(Terminales.True);
            var false_ = ToTerm(Terminales.False);
            var system_ = ToTerm(Terminales.System);
            var out_ = ToTerm(Terminales.Out);
            var print_ = ToTerm(Terminales.Print);
            var println_ = ToTerm(Terminales.Println);
            var break_ = ToTerm(Terminales.Break);
            var main_ = ToTerm(Terminales.Main);
            var static_ = ToTerm(Terminales.Static);
            var public_ = ToTerm(Terminales.Public);
            var private_ = ToTerm(Terminales.Private);
            var class_ = ToTerm(Terminales.Class);
            var scanner_ = ToTerm(Terminales.Scanner);
            var new_ = ToTerm(Terminales.New);
            var in_ = ToTerm(Terminales.In);
            var import_ = ToTerm(Terminales.Import);
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
            var boolean_ = ToTerm(Terminales.Boolean);
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
            var sumar_ = ToTerm(Terminales.Sumar);
            var restar_ = ToTerm(Terminales.Restar);
            var multiplicar_ = ToTerm(Terminales.Multiplicar);
            var dividir_ = ToTerm(Terminales.Dividir);
            var modular_ = ToTerm(Terminales.Modular);
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
            var nextInt_ = ToTerm(Terminales.NextInt);
            var nextFloat_ = ToTerm(Terminales.NextFloat);
            var nextDouble_ = ToTerm(Terminales.NextDouble);
            var nextBoolean_ = ToTerm(Terminales.NextBoolean);
            var next_ = ToTerm(Terminales.Next);
            #endregion

            #endregion

            #region ExpresionesRegulares
            var comentario = new RegexBasedTerminal(ExpresionesRegulares.Comentario, ExpresionesRegulares.ComentarioRegex);
            var nombre = new RegexBasedTerminal(ExpresionesRegulares.Nombre, ExpresionesRegulares.NombreRegex);
            var numero = new RegexBasedTerminal(ExpresionesRegulares.Numero, ExpresionesRegulares.NumeroRegex);
            var stringRegex = new RegexBasedTerminal(ExpresionesRegulares.String, ExpresionesRegulares.StringRegex);
            #endregion

            #region Reglas
            raiz.Rule = importacionLibrerias + declaracionClase |
                declaracionClase;

            //Importacion de librerias
            importacionLibrerias.Rule = import_ + llamadaLibreria;

            llamadaLibreria.Rule = nombre + puntoComa_ |
                nombre + punto_ + llamadaLibreria;
            ;
            //Declaracion de la clase
            declaracionClase.Rule = tipoAcceso + class_ + nombre + llavesAbrir_ + llavesCerrar_ |
                tipoAcceso + class_ + nombre + llavesAbrir_ + metodoMain + llavesCerrar_;

            tipoAcceso.Rule = private_ | public_;

            //Metodo main
            metodoMain.Rule = public_ + static_ + void_ + main_ + parentesisAbrir_ + string_ + corcheteAbrir_ + corcheteCerrar_ + nombre + parentesisCerrar_ + llavesAbrir_ + llavesCerrar_ |
                public_ + static_ + void_ + main_ + parentesisAbrir_ + string_ + corcheteAbrir_ + corcheteCerrar_ + nombre + parentesisCerrar_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_;

            //Bloque de codigo
            bloqueCodigo.Rule = declaracionScanner | declaracionScanner + bloqueCodigo |
                salidaPantalla | salidaPantalla + bloqueCodigo |
                operacionVariable | operacionVariable + bloqueCodigo |
                controladorFlujo | controladorFlujo + bloqueCodigo |
                declaracionArreglo | declaracionArreglo + bloqueCodigo;

            //Operaciones con variables\
            //Declaracion
            operacionVariable.Rule = declaracionVariable + puntoComa_;

            declaracionVariable.Rule = tipoDato + variable;

            tipoDato.Rule = int_ | float_ | double_ | boolean_ | string_;

            variable.Rule = nombre | nombre + coma_ + variable |
                asignarValor | asignarValor + coma_ + variable;

            valor.Rule = expresionAritmetica | valorLogico | entradaDatos;

            expresionAritmetica.Rule = numero | nombre | stringRegex |
                parentesisAbrir_ + expresionAritmetica + parentesisCerrar_ |
                expresionAritmetica + operadorAritmetico + expresionAritmetica;

            operadorAritmetico.Rule = mas_ | menos_ | por_ | entre_ | modulo_;

            valorLogico.Rule = false_ | true_;

            entradaDatos.Rule = nombre + punto_ + tipoEntrada + parentesisAbrir_ + parentesisCerrar_;

            tipoEntrada.Rule = nextInt_ | nextFloat_ | nextDouble_ | nextBoolean_ | next_;

            asignarValor.Rule = nombre + operadorAsignacion + valor;

            operadorAsignacion.Rule = igual_ | sumar_ | restar_ | multiplicar_ | dividir_ | modular_;

            //operacionSimple.Rule = nombre + mas_ + mas_ + puntoComa_ | nombre + menos_ + menos_ + puntoComa_;

            //Arreglo

            declaracionArreglo.Rule = tipoDato + corcheteAbrir_ + corcheteCerrar_ + nombre + puntoComa_ |
                tipoDato + corcheteAbrir_ + corcheteCerrar_ + nombre  + igual_ + new_ + tipoDato + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + puntoComa_ |
                tipoDato + nombre + corcheteAbrir_ + corcheteCerrar_ + puntoComa_ |
                tipoDato + nombre + corcheteAbrir_ + corcheteCerrar_ + igual_ + new_ + tipoDato + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + puntoComa_ |
                tipoDato + corcheteAbrir_ + corcheteCerrar_ + corcheteAbrir_ + corcheteCerrar_ + nombre + puntoComa_ |
                tipoDato + corcheteAbrir_ + corcheteCerrar_ + corcheteAbrir_ + corcheteCerrar_ + nombre + igual_ + new_ + tipoDato + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + puntoComa_ |
                tipoDato + nombre + corcheteAbrir_ + corcheteCerrar_ + corcheteAbrir_ + corcheteCerrar_ + puntoComa_ |
                tipoDato + nombre + corcheteAbrir_ + corcheteCerrar_ + corcheteAbrir_ + corcheteCerrar_ + igual_ + new_ + tipoDato + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + puntoComa_;

            //Scanner
            declaracionScanner.Rule = scanner_ + nombre + igual_ + new_ + scanner_ + parentesisAbrir_ + system_ + punto_ + in_ + parentesisCerrar_ + puntoComa_;

            //Salida a pantalla
            salidaPantalla.Rule = system_+punto_+out_+punto_+print_+parentesisAbrir_+ expresionAritmetica +parentesisCerrar_+puntoComa_ |
                system_ + punto_ + out_ + punto_ + println_ + parentesisAbrir_ + expresionAritmetica + parentesisCerrar_ + puntoComa_;

            //Controlador flujo
            controladorFlujo.Rule = bloqueIf | switchRegla;

            //If
            ifRegla.Rule = if_ + parentesisAbrir_ + condicion + parentesisCerrar_;

            bloqueIf.Rule = ifRegla + llavesAbrir_ + llavesCerrar_ |
                ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                ifRegla + llavesAbrir_ + llavesCerrar_ + bloqueElse|
                ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ + bloqueElse;

            condicion.Rule = expresionAritmetica + operadorRelacional + expresionAritmetica | 
                condicion + operadorLogico + condicion | 
                valorLogico | 
                not_ + expresionAritmetica;

            operadorRelacional.Rule = igualIgual_ | mayor_ | mayorIgual_ | menor_ | menorIgual_ | diferente_;

            operadorLogico.Rule = and_ | or_ | not_;

            bloqueElse.Rule = else_ +llavesAbrir_ + llavesCerrar_ |
                    else_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                    else_ + ifRegla + llavesAbrir_ + llavesCerrar_ |
                    else_ + ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                    else_ + ifRegla + llavesAbrir_ + llavesCerrar_ + bloqueElse |
                    else_ + ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ + bloqueElse;

            //Switch
            switchRegla.Rule = switch_ + parentesisAbrir_ + nombre + parentesisCerrar_ + llavesAbrir_ + bloqueSwitch + llavesCerrar_;

            bloqueSwitch.Rule = caso | caso + bloqueSwitch;

            caso.Rule = case_ + valor + dosPuntos_|
                case_ + valor + dosPuntos_ + bloqueCodigo | 
                case_ + valor + dosPuntos_ + break_  + puntoComa_|
                case_ + valor + dosPuntos_ + bloqueCodigo + break_ + puntoComa_|
                default_ + dosPuntos_ |
                default_ + dosPuntos_ + bloqueCodigo |
                default_ + dosPuntos_ + break_ + puntoComa_|
                default_ + dosPuntos_ + bloqueCodigo + break_ + puntoComa_;

            #endregion

            Root = raiz;
        }
    }
}
