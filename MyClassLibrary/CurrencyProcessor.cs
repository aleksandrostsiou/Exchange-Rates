using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyClassLibrary
{
    public static class CurrencyProcessor
    {
        public static async void GetExchangeRates(DataModel data)
        {
            //Init the api client
            ApiHelper.InitClient();

            for (int i = 1; i < data.Acount.Count(); i++)
            {
                //If the currency is not euro
                if (data.Currency[i]!="EUR")
                {
                    //get a httpResponse with currency rate on specific payDate and specific currency
                    using (var response = ApiHelper.ApiClient.GetAsync($"https://api.exchangeratesapi.io/{ data.PayDate[i].ToString(@"yyyy-MM-dd") }?symbols={ data.Currency[i] }").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();

                            //Json Deserialze
                            //var json = JsonConvert.DeserializeObject(result);

                            //Isolating the currency rate 
                            JObject j = JObject.Parse(result);
                            var rate = (string)j["rates"][$"{data.Currency[i]}"];

                            Console.WriteLine(i);

                            //Importing the amount to pay in EUR
                            var pay = data.PayAmount[i] / decimal.Parse(rate);
                            data.PayAmount_EUR.Insert(i,pay);

                            //Importing the balance in EUR
                            var bal = data.Balance[i] / decimal.Parse(rate);
                            data.Balance_EUR.Insert(i, bal);
                        }
                        else
                        {
                            File.AppendAllText(@"C:\Users\alext\source\repos\MellonConsoleApp\bad.txt",$"{response.StatusCode.ToString()} at Acount_Number {data.Acount[i]} on currency {data.Currency[i]}");
                        }
                    }
                }
                else
                {
                    //euro - euro
                }
                
            }
        }
    }
}
