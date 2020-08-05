using WebCalculator.Models;
using WebCalculator.Interfaces;

namespace WebCalculator.Service
{
    public class TransactionBuilder:ITransactionBuilder
    {
		private readonly ICalculator _calc;

		public TransactionBuilder(ICalculator calc)
		{
			_calc = calc;
		}

        public Transaction  TransactionCreate (Transaction data)
        {
			switch (data.OperationType)
			{
				case '+':
					data.Result = _calc.Add(data.FirstNumber, data.SecondNumber);
					break;

				case '-':
					data.Result = _calc.Sub(data.FirstNumber, data.SecondNumber);
					break;

				case '*':
					data.Result = _calc.Multiplication(data.FirstNumber, data.SecondNumber);
					break;

				case '/':
					data.Result = _calc.Division(data.FirstNumber, data.SecondNumber);
					break;

			}

			return data;
		}

    }
}
