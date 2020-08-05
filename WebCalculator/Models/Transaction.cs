using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Result { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public char OperationType { get; set; }
    }
}
