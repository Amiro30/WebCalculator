using WebCalculator.Interfaces;


namespace WebCalculator.Service
{
    public class Calculator:ICalculator
    {
        public double Add(int numA, int numB)
        { return (numA + numB); }

        public double Sub(int numA, int numB)
        { return (numA - numB); }

        public double Multiplication(int numA, int numB)
        { return (numA * numB); }
        public double Division(int numA, int numB)
        { return (numA / numB); }

    }
}
