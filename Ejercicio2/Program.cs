using System.Globalization;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE PROTECCIÓN DE CHEQUES");
            Console.WriteLine("Ingrese el importe monetario:");

            try
            {
                string input = Console.ReadLine();

                // Validar y convertir el input a decimal
                if (!decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal importe))
                {
                    throw new ArgumentException("El valor ingresado no es un importe válido");
                }

                // Formatear el importe según las reglas de protección
                string importeProtegido = FormateadorCheque.FormatearImporte(importe);

                // Mostrar resultados
                Console.WriteLine("\nImporte en el cheque:");
                Console.WriteLine(importeProtegido);
                Console.WriteLine("12345678"); // Guía de posiciones
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
