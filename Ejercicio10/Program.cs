using System.Text;

namespace Ejercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SUMA DE FRACCIONES");
            Console.WriteLine("Ingrese el número de fracciones (N):");
            int n = int.Parse(Console.ReadLine());

            Fraccion[] fracciones = new Fraccion[n];
            StringBuilder expresion = new StringBuilder();

            Console.WriteLine($"\nIngrese las {n} fracciones (ej. 1/2, -3/4, 5):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Fracción {i + 1}: ");
                string input = Console.ReadLine().Trim();

                // Procesar la entrada
                string[] partes = input.Split('/');
                int num, den = 1;

                if (partes.Length == 1)
                {
                    num = int.Parse(partes[0]);
                }
                else
                {
                    num = int.Parse(partes[0]);
                    den = int.Parse(partes[1]);
                }

                fracciones[i] = new Fraccion(num, den);

                // Construir la expresión
                if (i == 0)
                {
                    expresion.Append(fracciones[i].ToString());
                }
                else
                {
                    expresion.Append($" {fracciones[i].ConSigno()}");
                }
            }

            // Calcular la suma
            Fraccion suma = new Fraccion(0);
            foreach (var f in fracciones)
            {
                suma += f;
            }

            // Mostrar resultados
            Console.WriteLine($"\nExpresión: {expresion} = {suma}");
        }
    }
}
