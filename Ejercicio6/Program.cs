namespace Ejercicio6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EVALUADOR DE EXPRESIONES MATEMÁTICAS");
            Console.WriteLine("Caracteres permitidos: 0-9, +, -, *, /, ., (, )");
            Console.WriteLine("Ejemplo: (5.3+2)*4-6/2");
            Console.WriteLine("\nIngrese una expresión:");

            string expresion = Console.ReadLine();

            try
            {
                double resultado = EvaluadorExpresiones.Evaluar(expresion);
                Console.WriteLine($"\nResultado: {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
