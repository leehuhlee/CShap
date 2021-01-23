using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace BankyStuffLibrary
{
    public class Transaction
    {
        public decimal Amount { get; }

        public string AmountForHumans { 
            get
            {
                return ((int)Amount).ToWords();
            } 
        }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}