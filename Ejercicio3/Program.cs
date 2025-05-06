namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MULTIPLICADOR DE NÚMEROS ROMANOS");
            Console.WriteLine("Ingrese tres números romanos válidos (I a MMMCMXCIX):");

            try
            {
                // Leer los tres números romanos
                Console.Write("Primer número: ");
                string romano1 = Console.ReadLine().ToUpper();
                Console.Write("Segundo número: ");
                string romano2 = Console.ReadLine().ToUpper();
                Console.Write("Tercer número: ");
                string romano3 = Console.ReadLine().ToUpper();

                // Convertir a decimal
                int decimal1 = ConversorRomanos.RomanToDecimal(romano1);
                int decimal2 = ConversorRomanos.RomanToDecimal(romano2);
                int decimal3 = ConversorRomanos.RomanToDecimal(romano3);

                // Calcular producto
                int producto = decimal1 * decimal2 * decimal3;

                // Verificar límite
                if (producto > 3999)
                    throw new Exception("El resultado excede MMMCMXCIX (3999)");

                // Convertir resultado a romano
                string productoRomano = ConversorRomanos.DecimalToRoman(producto);

                // Mostrar resultados
                Console.WriteLine($"\nResultado:");
                Console.WriteLine($"{romano1} × {romano2} × {romano3} = {productoRomano}");
                Console.WriteLine($"({decimal1} × {decimal2} × {decimal3} = {producto})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
