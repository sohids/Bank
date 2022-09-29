using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Console.Models
{
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public double BalanceAfterTransaction { get; set; }
    }
}
