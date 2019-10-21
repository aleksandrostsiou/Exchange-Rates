using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace MyClassLibrary
{
    public static class CsvHelper
    {
        public static DataModel GetDataFromCsv()
        {
            DataModel data = new DataModel();
            try
            {
                //Fetching csv
                var lines = File.ReadAllLines(@"C:\Users\alext\source\repos\MellonConsoleApp\mellonDB\PF.csv");

                    //**Testing**
                //foreach (var line in lines)
                //{
                //    Console.WriteLine(line);
                //}

                for (int i = 1; i < lines.Length; i++)
                {
                    //Spliting the lines with ";"
                    var split = lines[i].Split(';');

                    //Parsing the splitted to props (default format for DateTime)
                    data.Acount.Add(split[0]);
                    data.Description.Add(split[1]);

                    if (DateTime.TryParse(split[2], out DateTime _payDate))
                    {
                        //If parsed successfull add to prop PayDate
                        data.PayDate.Add(_payDate);
                    }
                    else
                    {
                        //If can not be parsed append to .txt the specific value
                        File.AppendAllText(@"C:\Users\alext\source\repos\MellonConsoleApp\bad.txt",split[2].ToString());
                    }

                    if (decimal.TryParse(split[3],out decimal _payAmount))
                    {
                        data.PayAmount.Add(_payAmount);
                    }
                    else
                    {
                        File.AppendAllText(@"C:\Users\alext\source\repos\MellonConsoleApp\bad.txt", split[3].ToString());
                    }

                    if (decimal.TryParse(split[4], out decimal _balanceAmount))
                    {
                        data.Balance.Add(_balanceAmount);
                    }
                    else
                    {
                        File.AppendAllText(@"C:\Users\alext\source\repos\MellonConsoleApp\bad.txt", split[4].ToString());
                    }
                    data.Currency.Add(split[5]);
                }
                return data;
            }
            //Exceptions
            catch (Exception e)
            {
                Console.WriteLine($"An exception has occurred: {e.Message}");
                return null;
            }
        }
    }
}
