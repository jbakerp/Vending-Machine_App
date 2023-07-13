using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class TransactionLog

    {
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string TrackUserInput { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal CurrentBalance { get; set; }

        public TransactionLog(string trackUserInput, decimal previousBalance, decimal currentBalance)
        {
            TrackUserInput = trackUserInput;
            PreviousBalance = previousBalance;
            CurrentBalance = currentBalance;
        }

        


    }
}
