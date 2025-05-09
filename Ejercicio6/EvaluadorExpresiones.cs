using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio6
{
    public class EvaluadorExpresiones
    {
        private static readonly HashSet<char> CaracteresPermitidos = new HashSet<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '+', '-', '*', '/', '.', '(', ')', ' '
        };

        public static double Evaluar(string expresion)
        {
            if (!EsExpresionValida(expresion))
                throw new ArgumentException("Expresión no válida");

            try
            {
                // Eliminar espacios en blanco
                expresion = expresion.Replace(" ", "");

                // Convertir a notación postfija (RPN)
                var tokens = ConvertirAPostfijo(expresion);

                // Evaluar la expresión postfija
                return EvaluarPostfijo(tokens);
            }
            catch
            {
                throw new ArgumentException("La expresión no se puede evaluar");
            }
        }

        private static bool EsExpresionValida(string expresion)
        {
            // Verificar caracteres permitidos
            foreach (char c in expresion)
            {
                if (!CaracteresPermitidos.Contains(c))
                    return false;
            }

            // Verificar paréntesis balanceados
            int balance = 0;
            foreach (char c in expresion)
            {
                if (c == '(') balance++;
                if (c == ')') balance--;
                if (balance < 0) return false;
            }
            if (balance != 0) return false;

            // Verificar operadores válidos (permitir - al inicio)
            if (new Regex(@"(^|[+\-*/[(])([+\*/])").IsMatch(expresion))
                return false;

            return true;
        }

        private static List<string> ConvertirAPostfijo(string expresion)
        {
            var output = new List<string>();
            var operadores = new Stack<char>();
            int i = 0;

            while (i < expresion.Length)
            {
                if (char.IsDigit(expresion[i]) || expresion[i] == '.')
                {
                    // Capturar números (enteros o decimales)
                    string numero = "";
                    while (i < expresion.Length && (char.IsDigit(expresion[i]) || expresion[i] == '.'))
                    {
                        numero += expresion[i++];
                    }
                    output.Add(numero);
                }
                else if (expresion[i] == '(')
                {
                    operadores.Push(expresion[i++]);
                }
                else if (expresion[i] == ')')
                {
                    while (operadores.Count > 0 && operadores.Peek() != '(')
                    {
                        output.Add(operadores.Pop().ToString());
                    }
                    operadores.Pop();
                    i++;
                }
                else if (expresion[i] == '-' && (i == 0 || expresion[i - 1] == '(' || EsOperador(expresion[i - 1])))
                {
                    // Manejar signo negativo unario
                    i++;
                    if (i < expresion.Length && (char.IsDigit(expresion[i]) || expresion[i] == '.'))
                    {
                        string numero = "-";
                        while (i < expresion.Length && (char.IsDigit(expresion[i]) || expresion[i] == '.'))
                        {
                            numero += expresion[i++];
                        }
                        output.Add(numero);
                    }
                }
                else
                {
                    // Manejar operadores binarios
                    while (operadores.Count > 0 && operadores.Peek() != '(' &&
                           Precedencia(expresion[i]) <= Precedencia(operadores.Peek()))
                    {
                        output.Add(operadores.Pop().ToString());
                    }
                    operadores.Push(expresion[i++]);
                }
            }

            while (operadores.Count > 0)
            {
                output.Add(operadores.Pop().ToString());
            }

            return output;
        }

        // Método auxiliar para detectar operadores
        private static bool EsOperador(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private static double EvaluarPostfijo(List<string> tokens)
        {
            var pila = new Stack<double>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double numero))
                {
                    pila.Push(numero);
                }
                else
                {
                    double b = pila.Pop();
                    double a = pila.Pop();
                    pila.Push(Operar(a, b, token[0]));
                }
            }

            return pila.Pop();
        }

        private static int Precedencia(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

        private static double Operar(double a, double b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/':
                    if (b == 0) throw new DivideByZeroException();
                    return a / b;
                default: throw new ArgumentException("Operador no válido");
            }
        }

    }
}
