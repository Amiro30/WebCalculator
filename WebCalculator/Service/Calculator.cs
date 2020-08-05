using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCalculator.Models;

namespace WebCalculator.Service
{
    public class Calculator
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
