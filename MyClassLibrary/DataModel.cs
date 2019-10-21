using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class DataModel
    {
        //properties
        public List<string> Acount { get; set; } = new List<string>();
        public List<string> Description { get; set; } = new List<string>();
        public List<DateTime> PayDate { get; set; } = new List<DateTime>();
        public List<decimal> PayAmount { get; set; } = new List<decimal>();
        public List<decimal> Balance { get; set; } = new List<decimal>();
        public List<string> Currency { get; set; } = new List<string>();
        public List<decimal> PayAmount_EUR { get; set; } = new List<decimal>();
        public List<decimal> Balance_EUR { get; set; } = new List<decimal>();

        public enum CurrencySelector
        {
            EUR = 0,
            PLN = 1,
            GBP = 2,
            ISK = 3,
            TRY = 4,
            USD = 5,
            BGN = 6,
            CHF = 7,
            RON = 8,
            CNY = 9,
            SEK = 10
        }
    }
}
