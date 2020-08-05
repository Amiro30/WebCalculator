using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Models
{
    public class HistoryItem
    {
        public long Id { get; set; }
        public double Result { get; set; }
        public decimal Left { get; set; }
        public decimal Right { get; set; }
        public OperationType Type { get; set; }
    }
}
