namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese el dividendo (hasta 150 cifras):");
                string dividendoStr = Console.ReadLine();
                ValidarLongitud(dividendoStr);

                Console.WriteLine("Ingrese el divisor (hasta 150 cifras):");
                string divisorStr = Console.ReadLine();
                ValidarLongitud(divisorStr);

                NumeroGrande dividendo = new NumeroGrande(dividendoStr);
                NumeroGrande divisor = new NumeroGrande(divisorStr);

                string resultado = NumeroGrande.Dividir(dividendo, divisor);
                Console.WriteLine($"\nResultado de la división: {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ValidarLongitud(string num)
        {
            if (num.Length > 150)
                throw new ArgumentException("El número no puede tener más de 150 cifras");
        }
    }
    }

