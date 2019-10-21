using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mapping data from csv to props
            var dataModel = CsvHelper.GetDataFromCsv();

            //Calc exchange rates
            CurrencyProcessor.GetExchangeRates(dataModel);

            //Inserting models to db
            //DatabaseAccess.GetAccess(dataModel);

        }
    }
}
