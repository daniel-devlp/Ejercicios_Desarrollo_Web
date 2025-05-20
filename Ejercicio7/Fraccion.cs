using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    public class Fraccion : IComparable<Fraccion>
    {
        public int Numerador { get; private set; }
        public int Denominador { get; private set; }

        public Fraccion(int numerador, int denominador)
        {
            if (denominador == 0)
                throw new ArgumentException("El denominador no puede ser cero.");

            // Simplificamos la fracción al crearla
            int mcd = MaximoComunDivisor(Math.Abs(numerador), Math.Abs(denominador));
            numerador /= mcd;
            denominador /= mcd;

            // Aseguramos que el signo esté en el numerador
            if (denominador < 0)
            {
                numerador = -numerador;
                denominador = -denominador;
            }

            Numerador = numerador;
            Denominador = denominador;
        }

        public static Fraccion operator +(Fraccion a, Fraccion b)
        {
            int nuevoDenominador = a.Denominador * b.Denominador;
            int nuevoNumerador = a.Numerador * b.Denominador + b.Numerador * a.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        public double ValorDecimal()
        {
            return (double)Numerador / Denominador;
        }

        public int CompareTo(Fraccion other)
        {
            double estaFraccion = this.ValorDecimal();
            double otraFraccion = other.ValorDecimal();

            if (estaFraccion > otraFraccion) return -1; // Ordenamos de mayor a menor
            if (estaFraccion < otraFraccion) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }

        private static int MaximoComunDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
