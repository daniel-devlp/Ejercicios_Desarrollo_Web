using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class NumeroGrande
    {
        private string valor;

        public NumeroGrande(string valor)
        {
            if (!EsNumeroValido(valor))
                throw new ArgumentException("El valor contiene caracteres no numéricos");
            this.valor = valor.TrimStart('0');
            if (string.IsNullOrEmpty(this.valor)) this.valor = "0";
        }

        private bool EsNumeroValido(string num)
        {
            foreach (char c in num)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static string Dividir(NumeroGrande dividendo, NumeroGrande divisor)
        {
            if (divisor.valor == "0")
                throw new DivideByZeroException("No se puede dividir por cero");

            // Casos especiales para optimización
            if (dividendo.valor == "0") return "0";
            if (divisor.valor == "1") return dividendo.valor;

            StringBuilder cociente = new StringBuilder();
            string restoParcial = "";
            string dividendoStr = dividendo.valor;

            for (int i = 0; i < dividendoStr.Length; i++)
            {
                restoParcial += dividendoStr[i];
                restoParcial = restoParcial.TrimStart('0');
                if (string.IsNullOrEmpty(restoParcial)) restoParcial = "0";

                int digito = 0;
                NumeroGrande restoActual = new NumeroGrande(restoParcial);

                while (Comparar(restoActual, divisor) >= 0)
                {
                    restoActual = Restar(restoActual, divisor);
                    digito++;
                }

                cociente.Append(digito);
                restoParcial = restoActual.valor;
            }

            string resultado = cociente.ToString().TrimStart('0');
            return string.IsNullOrEmpty(resultado) ? "0" : resultado;
        }

        private static int Comparar(NumeroGrande a, NumeroGrande b)
        {
            if (a.valor.Length != b.valor.Length)
                return a.valor.Length.CompareTo(b.valor.Length);

            for (int i = 0; i < a.valor.Length; i++)
            {
                if (a.valor[i] != b.valor[i])
                    return a.valor[i].CompareTo(b.valor[i]);
            }

            return 0;
        }

        private static NumeroGrande Restar(NumeroGrande a, NumeroGrande b)
        {
            if (Comparar(a, b) < 0)
                throw new ArgumentException("El minuendo debe ser mayor o igual que el sustraendo");

            StringBuilder resultado = new StringBuilder();
            int prestamo = 0;

            int i = a.valor.Length - 1, j = b.valor.Length - 1;

            while (i >= 0 || j >= 0)
            {
                int digitoA = i >= 0 ? a.valor[i--] - '0' : 0;
                int digitoB = j >= 0 ? b.valor[j--] - '0' : 0;

                int diferencia = digitoA - digitoB - prestamo;

                if (diferencia < 0)
                {
                    diferencia += 10;
                    prestamo = 1;
                }
                else
                {
                    prestamo = 0;
                }

                resultado.Insert(0, diferencia);
            }

            return new NumeroGrande(resultado.ToString().TrimStart('0'));
        }

        public override string ToString() => valor;
    }
}

