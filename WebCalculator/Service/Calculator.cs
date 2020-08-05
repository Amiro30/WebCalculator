using System;
using WebCalculator.Interfaces;
using WebCalculator.Models;

namespace WebCalculator.Service
{
    public class Calculator:ICalculator
    {
		public decimal Execute(decimal a, decimal b, OperationType type)
		{
			switch (type)
			{
				case OperationType.Add: return a + b;
				case OperationType.Sub: return a - b;
				case OperationType.Mult: return a * b;
				case OperationType.Div: return a / b;
				default: throw new NotSupportedException();
			}
		}
	}
}
