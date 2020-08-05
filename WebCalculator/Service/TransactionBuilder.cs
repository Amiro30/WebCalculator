using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCalculator.Models;

namespace WebCalculator.Service
{
    public class TransactionBuilder
    {
        Calculator calc = new Calculator();

        public Transaction  TransactionCreate (Transaction data)
        {
			switch (data.OperationType)
			{
				case '+':
					data.Result = calc.Add(data.FirstNumber, data.SecondNumber);
					break;

				case '-':
					data.Result = calc.Sub(data.FirstNumber, data.SecondNumber);
					break;

				case '*':
					data.Result = calc.Multiplication(data.FirstNumber, data.SecondNumber);
					break;

				case '/':
					data.Result = calc.Division(data.FirstNumber, data.SecondNumber);
					break;

			}
			return data;
		}

    }
}
