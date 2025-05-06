using System;
using System.IO;

namespace Ejercicio9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string inputFile = "C:\\Users\\dany8\\source\\repos\\Ejercicios_Desarrollo_Web\\Ejercicio9\\Pamgrama.txt";
                string outputFile = "C:\\Users\\dany8\\source\\repos\\Ejercicios_Desarrollo_Web\\Ejercicio9\\Solucion.txt";

                if (!File.Exists(inputFile))
                {
                    Console.WriteLine($"El archivo {inputFile} no existe");
                    return;
                }

                string[] lines = File.ReadAllLines(inputFile);
                if (lines.Length == 0)
                {
                    Console.WriteLine("El archivo está vacío");
                    return;
                }

                if (!int.TryParse(lines[0], out int n) || n <= 0)
                {
                    Console.WriteLine("La primera línea debe contener un número entero positivo");
                    return;
                }

                if (lines.Length - 1 < n)
                {
                    Console.WriteLine($"Se esperaban {n} frases pero solo hay {lines.Length - 1}");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    for (int i = 1; i <= n; i++)
                    {
                        var result = PangramChecker.CheckPangram(lines[i]);
                        writer.WriteLine($"{(result.Item1 ? "SI" : "NO")} {result.Item2}");
                    }
                }

                Console.WriteLine($"Procesamiento completado. Resultados guardados en {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public static class PangramChecker
    {
        private static readonly char[] Separators = { '.', ',', '!', ':', ';', ' ' };

        public static Tuple<bool, int> CheckPangram(string phrase)
        {
            string cleaned = RemoveSeparators(phrase.ToLower());
            var uniqueLetters = cleaned.Distinct().Where(c => c >= 'a' && c <= 'z');
            int letterCount = uniqueLetters.Count();
            int totalChars = cleaned.Length;

            return Tuple.Create(letterCount == 26, totalChars);
        }

        private static string RemoveSeparators(string input)
        {
            return new string(input.Where(c => !Separators.Contains(c)).ToArray());
        }
    }
}