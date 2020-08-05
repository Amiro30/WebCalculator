using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Result { get; set; }
        [Required]
        public int FirstNumber { get; set; }
        [Required]
        public int SecondNumber { get; set; }
        [Required]
        public char OperationType { get; set; }
    }
}
