using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio7
{
    public static class QuickSortFracciones
    {
        public static void Ordenar(Fraccion[] array)
        {
            if (array == null || array.Length == 0)
                return;

            Quicksort(array, 0, array.Length - 1);
        }

        private static void Quicksort(Fraccion[] array, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int indiceParticion = Particionar(array, izquierda, derecha);
                Quicksort(array, izquierda, indiceParticion - 1);
                Quicksort(array, indiceParticion + 1, derecha);
            }
        }

        private static int Particionar(Fraccion[] array, int izquierda, int derecha)
        {
            Fraccion pivote = array[derecha];
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                if (array[j].CompareTo(pivote) <= 0)
                {
                    i++;
                    Intercambiar(array, i, j);
                }
            }

            Intercambiar(array, i + 1, derecha);
            return i + 1;
        }

        private static void Intercambiar(Fraccion[] array, int i, int j)
        {
            Fraccion temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
