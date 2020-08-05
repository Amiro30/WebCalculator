using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculator.Interfaces
{
    public interface ICalculator
    {
        double Add(int numA, int numB);

        double Sub(int numA, int numB);

        double Multiplication(int numA, int numB);
        double Division(int numA, int numB);
    }
}
