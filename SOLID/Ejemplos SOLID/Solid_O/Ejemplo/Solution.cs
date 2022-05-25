class Program
{
    public interface ICalculator
    {
        public double GetTotal(int firtNumber, int secondNumber);
    }

    class CalculateSum : ICalculator
    {
        public double GetTotal(int firstNumber, int secondNumber)
        {
            int total = firstNumber + secondNumber;
            Console.WriteLine(total);
            return total;
        }
    }

    class CalculateSubtraction : ICalculator
    {
        public double GetTotal(int firstNumber, int secondNumber)
        {
            int total = firstNumber - secondNumber;
            Console.WriteLine(total);
            return total;
        }
    }

    // Se pueden añadir funcionalidades extras sin modificar el codigo existente

    class CalculateMultiplication : ICalculator
    {
        public double GetTotal(int firstNumber, int secondNumber)
        {
            int total = firstNumber * secondNumber;
            Console.WriteLine(total);
            return total;
        }
    }

    class CalculateDivision : ICalculator
    {
        public double GetTotal(int firstNumber, int secondNumber)
        {
            int total = firstNumber / secondNumber;
            Console.WriteLine(total);
            return total;
        }
    }

    public static void Main(string[] args)
    {
        CalculateSum calculateSum = new CalculateSum();
        calculateSum.GetTotal(1, 2);

        CalculateSubtraction calculateSubtraction = new CalculateSubtraction();
        calculateSubtraction.GetTotal(5, 3);

        CalculateMultiplication calculateMultiplication = new CalculateMultiplication();
        calculateMultiplication.GetTotal(6, 2);

        CalculateDivision calculateDivision = new CalculateDivision();
        calculateDivision.GetTotal(8, 3);
    }
}