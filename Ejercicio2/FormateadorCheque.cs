using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class FormateadorCheque
    {
        private const int EspaciosDisponibles = 8;

        public static string FormatearImporte(decimal importe)
        {
            // Validar que el importe sea positivo
            if (importe < 0)
                throw new ArgumentException("El importe no puede ser negativo");

            // Convertir a string con formato de moneda (2 decimales)
            string importeFormateado = importe.ToString("F2", CultureInfo.InvariantCulture);

            // Reemplazar el punto decimal por coma (formato común en cheques)
            importeFormateado = importeFormateado.Replace(".", ",");

            // Verificar si el importe ocupa más de 8 caracteres
            if (importeFormateado.Length > EspaciosDisponibles)
                throw new ArgumentException($"El importe '{importeFormateado}' excede los {EspaciosDisponibles} espacios disponibles");

            // Si el importe es menor a 1000, aplicar protección con asteriscos
            if (importe < 1000)
            {
                int asteriscosNecesarios = EspaciosDisponibles - importeFormateado.Length;
                StringBuilder sb = new StringBuilder();

                // Agregar asteriscos a la izquierda
                for (int i = 0; i < asteriscosNecesarios; i++)
                {
                    sb.Append('*');
                }

                sb.Append(importeFormateado);
                return sb.ToString();
            }

            return importeFormateado;
        }
    }
}
