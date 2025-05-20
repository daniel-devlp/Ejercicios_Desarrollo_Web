namespace Ejercicio7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el número de fracciones (n):");
            int n = int.Parse(Console.ReadLine());

            Fraccion[] fracciones = new Fraccion[n];

            Console.WriteLine($"Ingrese las {n} fracciones en formato numerador/denominador (ej. 3/4 o -1/2):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Fracción {i + 1}: ");
                string[] partes = Console.ReadLine().Split('/');
                int numerador = int.Parse(partes[0]);
                int denominador = int.Parse(partes[1]);
                fracciones[i] = new Fraccion(numerador, denominador);
            }

            // a) Ordenar las fracciones de mayor a menor usando Quicksort
            QuickSortFracciones.Ordenar(fracciones);
            Console.WriteLine("\nFracciones ordenadas de mayor a menor:");
            foreach (var fraccion in fracciones)
            {
                Console.WriteLine(fraccion);
            }

            // b) Calcular la suma de las fracciones como fracción irreducible
            Fraccion suma = new Fraccion(0, 1); // 0/1 es la fracción neutra para la suma
            foreach (var fraccion in fracciones)
            {
                suma += fraccion;
            }
            Console.WriteLine($"\nSuma de las fracciones: {suma}");
        }
    }
}
