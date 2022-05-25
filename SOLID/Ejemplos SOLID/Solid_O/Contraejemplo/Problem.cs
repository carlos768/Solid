class Program
{
    class Calculator
    {
        public int CalculateSum(int firstNumber, int secondNumber)
        {   
            int total = firstNumber + secondNumber;
            Console.WriteLine(total);
            return total;
        }

        public int CalculateSubtraction(int firstNumber, int secondNumber)
        {
            int total = firstNumber - secondNumber;
            Console.WriteLine(total);
            return total;
        }

        // Se necesita modificar la clase para añadir nuevas funcionalidades
    }
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        calculator.CalculateSum(2, 3);
        calculator.CalculateSubtraction(5, 3);
    }
}