using WebCalculator.Models;

namespace WebCalculator.Interfaces
{
    public interface ICalculator
    {
        public decimal Execute(decimal a, decimal b, OperationType type);
    }
}
