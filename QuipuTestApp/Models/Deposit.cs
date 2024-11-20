using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuipuTestApp.Models
{
    public class Deposit
    {
        public decimal Amount { get; set; }
        public int TermInMonths { get; set; }
        public double InterestRate { get; set; }
        public bool IsCapitalized { get; set; }
        public string Currency { get; set; }
    }
}
