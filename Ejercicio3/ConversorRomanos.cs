using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public  class ConversorRomanos
    {
            private static readonly Dictionary<char, int> ValoresRomanos = new Dictionary<char, int>
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

            private static readonly List<(int, string)> ValoresDecimales = new List<(int, string)>
        {
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
            (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
            (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
        };

            public static int RomanToDecimal(string numeroRomano)
            {
                int total = 0;
                int previo = 0;

                for (int i = numeroRomano.Length - 1; i >= 0; i--)
                {
                    int actual = ValoresRomanos[numeroRomano[i]];
                    total = (actual < previo) ? total - actual : total + actual;
                    previo = actual;
                }
                return total;
            }

            public static string DecimalToRoman(int numero)
            {
                if (numero < 1 || numero > 3999)
                    throw new ArgumentOutOfRangeException("El número debe estar entre 1 y 3999");

                string romano = "";
                foreach (var (valor, simbolo) in ValoresDecimales)
                {
                    while (numero >= valor)
                    {
                        romano += simbolo;
                        numero -= valor;
                    }
                }
                return romano;
            }
        }
}
