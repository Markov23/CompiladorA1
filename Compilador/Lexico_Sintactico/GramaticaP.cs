using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace Compilador.Lexico_Sintactico
{
    class GramaticaP : Grammar
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
            public const string AsignarValor = "<asignar-valor>";
            public const string OperadorAsignacion = "<operador-asignacion>";
            public const string OperacionSimple = "<operacion-simple>";
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
            public const string Arreglo = "<arreglo>";
            public const string BloqueFor = "<bloque-for>";
            public const string BloqueWhile = "<bloque-while>";
            public const string BloqueDoWhile = "<bloque-do-while>";

        }

        public static class Terminales
        {
            public const string Empty = "empty";
            public const string True = "true";
            public const string False = "false";
            public const string Show = "show";
            public const string Showln = "showln";
            public const string Break = "break";
            public const string Main = "main";
            public const string Public = "public";
            public const string Private = "private";
            public const string Class = "class";
            public const string New = "new";
            public const string Use = "use";
            public const string Assign = "assign";

            public const string If = "if";
            public const string Else = "else";
            public const string Default = "default";
            public const string While = "while";
            public const string Do = "do";
            public const string Until = "until";
            public const string Cases = "cases";
            public const string When = "when";

            public const string Int = "int";
            public const string Float = "float";
            public const string Double = "double";
            public const string Bool = "bool";
            public const string String = "string";
            public const string Char = "char";

            public const string And = "and";
            public const string Or = "or";
            public const string Not = "not";

            public const string AssignA = "assignA";
            public const string AssignS = "assignS";
            public const string AssignM = "assignM";
            public const string AssignD = "assignD";
            public const string Inc = "inc";
            public const string Dec = "dec";

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

            public const string GetInt = "getInt";
            public const string GetFloat = "getFloat";
            public const string GetDouble = "getDouble";
            public const string GetBoolean = "getBoolean";
            public const string GetChar = "getChar";
            public const string GetString = "getString";
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
            public const string Char = "string";
            public const string CharRegex = "\'[^\']*\'";
        }

        public GramaticaP() : base()
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
            //var declaracionScanner = new NonTerminal(NoTerminales.DeclaracionScanner);
            var operacionSimple = new NonTerminal(NoTerminales.OperacionSimple);
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
            var arreglo = new NonTerminal(NoTerminales.Arreglo);
            var bloqueFor = new NonTerminal(NoTerminales.BloqueFor);
            //var declaracionFor = new NonTerminal(NoTerminales.DeclaracionFor);
            //var asignarFor = new NonTerminal(NoTerminales.AsignarFor);
            var bloqueWhile = new NonTerminal(NoTerminales.BloqueWhile);
            var bloqueDoWhile = new NonTerminal(NoTerminales.BloqueDoWhile);

            #endregion

            #region Terminales

            #region Palabras Reservadas
            var empty_ = ToTerm(Terminales.Empty);
            var true_ = ToTerm(Terminales.True);
            var false_ = ToTerm(Terminales.False);
            var show_ = ToTerm(Terminales.Show);
            var showln_ = ToTerm(Terminales.Showln);
            var break_ = ToTerm(Terminales.Break);
            var main_ = ToTerm(Terminales.Main);
            var public_ = ToTerm(Terminales.Public);
            var private_ = ToTerm(Terminales.Private);
            var class_ = ToTerm(Terminales.Class);
            var new_ = ToTerm(Terminales.New);
            var use_ = ToTerm(Terminales.Use);
            var assign_ = ToTerm(Terminales.Assign);
            #endregion

            #region Control de flujo
            var if_ = ToTerm(Terminales.If);
            var else_ = ToTerm(Terminales.Else);
            var default_ = ToTerm(Terminales.Default);
            var while_ = ToTerm(Terminales.While);
            var do_ = ToTerm(Terminales.Do);
            var until_ = ToTerm(Terminales.Until);
            var cases_ = ToTerm(Terminales.Cases);
            var when_ = ToTerm(Terminales.When);
            #endregion

            #region Tipos de dato
            var int_ = ToTerm(Terminales.Int);
            var float_ = ToTerm(Terminales.Float);
            var double_ = ToTerm(Terminales.Double);
            var bool_ = ToTerm(Terminales.Bool);
            var string_ = ToTerm(Terminales.String);
            var char_ = ToTerm(Terminales.Char);
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
            var assignA_ = ToTerm(Terminales.AssignA);
            var assignS_ = ToTerm(Terminales.AssignS);
            var assignM_ = ToTerm(Terminales.AssignM);
            var assignD_ = ToTerm(Terminales.AssignD);
            var inc_ = ToTerm(Terminales.Inc);
            var dec_ = ToTerm(Terminales.Dec);
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
            var getInt_ = ToTerm(Terminales.GetInt);
            var getFloat_ = ToTerm(Terminales.GetFloat);
            var getDouble_ = ToTerm(Terminales.GetDouble);
            var getBoolean_ = ToTerm(Terminales.GetBoolean);
            var getString_ = ToTerm(Terminales.GetString);
            var getChar_ = ToTerm(Terminales.GetChar);
            #endregion

            #endregion

            #region ExpresionesRegulares
            var comentario = new RegexBasedTerminal(ExpresionesRegulares.Comentario, ExpresionesRegulares.ComentarioRegex);
            var nombre = new RegexBasedTerminal(ExpresionesRegulares.Nombre, ExpresionesRegulares.NombreRegex);
            var numero = new RegexBasedTerminal(ExpresionesRegulares.Numero, ExpresionesRegulares.NumeroRegex);
            var stringRegex = new RegexBasedTerminal(ExpresionesRegulares.String, ExpresionesRegulares.StringRegex);
            var charRegex = new RegexBasedTerminal(ExpresionesRegulares.Char, ExpresionesRegulares.CharRegex);
            #endregion

            #region Reglas

            raiz.Rule = importacionLibrerias + declaracionClase | declaracionClase;

            //Importacion de librerias
            importacionLibrerias.Rule = use_ + llamadaLibreria;

            llamadaLibreria.Rule = nombre + puntoComa_ |
                nombre + punto_ + llamadaLibreria;

            //Declaracion de clase
            declaracionClase.Rule = tipoAcceso + class_ + nombre + llavesAbrir_ + llavesCerrar_ |
                tipoAcceso + class_ + nombre + llavesAbrir_ + metodoMain + llavesCerrar_;

            tipoAcceso.Rule = private_ | public_;

            //Main
            metodoMain.Rule = main_ + parentesisAbrir_ + parentesisCerrar_ + llavesAbrir_ + llavesCerrar_ |
                main_ + parentesisAbrir_ + parentesisCerrar_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_;

            //Bloque de codigo
            bloqueCodigo.Rule = declaracionVariable | declaracionVariable + bloqueCodigo |
                asignarValor | asignarValor + bloqueCodigo |
                salidaPantalla | salidaPantalla + bloqueCodigo |
                declaracionArreglo | declaracionArreglo + bloqueCodigo |
                comentario | comentario + bloqueCodigo |
                controladorFlujo | controladorFlujo + bloqueCodigo |
                bloqueFor | bloqueFor + bloqueCodigo |
                bloqueWhile | bloqueWhile + bloqueCodigo |
                bloqueDoWhile | bloqueDoWhile + bloqueCodigo |
                entradaDatos | entradaDatos + bloqueCodigo;

            //Declaracion de variables
            declaracionVariable.Rule = tipoDato + nombre + puntoComa_;

            tipoDato.Rule = int_ | float_ | double_ | bool_ | string_ | char_;

            asignarValor.Rule = operadorAsignacion + parentesisAbrir_ + nombre + coma_ + valor + parentesisCerrar_ + puntoComa_ |
                operadorAsignacion + parentesisAbrir_ + arreglo + coma_ + valor + parentesisCerrar_ + puntoComa_ | operacionSimple + puntoComa_;

            operadorAsignacion.Rule = assignA_ | assignS_ | assignM_ | assignD_ | assign_;

            valor.Rule = expresionAritmetica | valorLogico | charRegex | empty_;

            expresionAritmetica.Rule = numero | nombre | stringRegex |
                parentesisAbrir_ + expresionAritmetica + parentesisCerrar_ |
                expresionAritmetica + operadorAritmetico + expresionAritmetica;

            operadorAritmetico.Rule = mas_ | menos_ | por_ | entre_ | modulo_;

            valorLogico.Rule = false_ | true_;

            entradaDatos.Rule = tipoEntrada + parentesisAbrir_ + nombre + parentesisCerrar_ + puntoComa_ |
                tipoEntrada + parentesisAbrir_ + arreglo + parentesisCerrar_ + puntoComa_;

            tipoEntrada.Rule = getInt_ | getFloat_ | getDouble_ | getBoolean_ | getString_ | getChar_;

            declaracionArreglo.Rule = tipoDato + corcheteAbrir_ + corcheteCerrar_ + nombre + igual_ + new_ + tipoDato + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + puntoComa_|
                tipoDato + corcheteAbrir_ + corcheteCerrar_ + corcheteAbrir_ + corcheteCerrar_ + nombre + igual_ + new_ + tipoDato + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + puntoComa_;

            arreglo.Rule = nombre + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ |
                nombre + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_ + corcheteAbrir_ + expresionAritmetica + corcheteCerrar_;

            operacionSimple.Rule = inc_ + parentesisAbrir_ + nombre + parentesisCerrar_ |
                dec_ + parentesisAbrir_ + nombre + parentesisCerrar_;

            //Salida a pantalla

            salidaPantalla.Rule = show_ + parentesisAbrir_ + parentesisCerrar_ + puntoComa_ |
                show_ + parentesisAbrir_ + expresionAritmetica + parentesisCerrar_ + puntoComa_ |
                showln_ + parentesisAbrir_ + parentesisCerrar_ + puntoComa_ |
                showln_ + parentesisAbrir_ + expresionAritmetica + parentesisCerrar_ + puntoComa_;

            //Controlador flujo
            controladorFlujo.Rule = bloqueIf | switchRegla;

            //If
            ifRegla.Rule = if_ + parentesisAbrir_ + condicion + parentesisCerrar_;

            bloqueIf.Rule = ifRegla + llavesAbrir_ + llavesCerrar_ |
                ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                ifRegla + llavesAbrir_ + llavesCerrar_ + bloqueElse |
                ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ + bloqueElse;

            condicion.Rule = expresionAritmetica + operadorRelacional + expresionAritmetica |
                condicion + operadorLogico + condicion |
                valorLogico |
                not_ + expresionAritmetica;

            operadorRelacional.Rule = igualIgual_ | mayor_ | mayorIgual_ | menor_ | menorIgual_ | diferente_;

            operadorLogico.Rule = and_ | or_ | not_;

            bloqueElse.Rule = else_ + llavesAbrir_ + llavesCerrar_ |
                    else_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                    else_ + ifRegla + llavesAbrir_ + llavesCerrar_ |
                    else_ + ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                    else_ + ifRegla + llavesAbrir_ + llavesCerrar_ + bloqueElse |
                    else_ + ifRegla + llavesAbrir_ + bloqueCodigo + llavesCerrar_ + bloqueElse;

            //Switch
            switchRegla.Rule = cases_ + parentesisAbrir_ + nombre + parentesisCerrar_ + llavesAbrir_ + bloqueSwitch + llavesCerrar_;

            bloqueSwitch.Rule = caso | caso + bloqueSwitch;

            caso.Rule = when_ + valor + dosPuntos_ |
                when_ + valor + dosPuntos_ + bloqueCodigo |
                when_ + valor + dosPuntos_ + break_ + puntoComa_ |
                when_ + valor + dosPuntos_ + bloqueCodigo + break_ + puntoComa_ |
                default_ + dosPuntos_ |
                default_ + dosPuntos_ + bloqueCodigo |
                default_ + dosPuntos_ + break_ + puntoComa_ |
                default_ + dosPuntos_ + bloqueCodigo + break_ + puntoComa_;

            //For
            bloqueFor.Rule = until_ + parentesisAbrir_ + declaracionVariable + asignarValor + condicion + puntoComa_ + operacionSimple + parentesisCerrar_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_ |
                until_ + parentesisAbrir_ + declaracionVariable + asignarValor + condicion + puntoComa_ + operacionSimple + parentesisCerrar_ + llavesAbrir_ + llavesCerrar_;

            //While
            bloqueWhile.Rule = while_ + parentesisAbrir_ + condicion + parentesisCerrar_ + llavesAbrir_ + llavesCerrar_ |
                while_ + parentesisAbrir_ + condicion + parentesisCerrar_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_;

            bloqueDoWhile.Rule = do_ + llavesAbrir_ + llavesCerrar_ + while_ + parentesisAbrir_ + condicion + parentesisCerrar_ + puntoComa_ |
                do_ + llavesAbrir_ + bloqueCodigo + llavesCerrar_ + while_ + parentesisAbrir_ + condicion + parentesisCerrar_ + puntoComa_;

            Root = raiz;

            #endregion
        }
    }
}
