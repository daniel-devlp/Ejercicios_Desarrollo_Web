using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio9
{
    public class Pangram
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
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (!Separators.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
