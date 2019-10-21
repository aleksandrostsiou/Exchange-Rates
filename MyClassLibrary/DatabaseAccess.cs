using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace MyClassLibrary
{
    public static class DatabaseAccess
    {
        public static void GetAccess(DataModel data)
        {
            using (IDbConnection conn = new SQLiteConnection("Data Source=MellonDB.db;Version=3;New=True;Compress=True;"))
            {
                conn.Open();
                //**Testing without Dapper
                //var cmd = new SQLiteCommand();
                //cmd.CommandText = "INSERT INTO Payments(ACOUNT_NUMBER) VALUES('231');";
                //cmd.ExecuteNonQuery();


                if (conn.State.ToString()=="Open")
                {
                    for (int i = 0; i < data.Acount.Count(); i++)
                    {
                        string sql = "INSERT INTO Payments(ACOUNT_NUMBER,DESCRIPTION,PAYDATE,PAY_AMOUNT,BALANCE,CURRENCY,PAY_AMOUNT_CURRENCY,BALANCE_CURRENCY)" +
                                     " VALUES(@data.Acount[i],@data.Description[i],@data.PayAmount[i],@data.Balance[i],@data.Currency[i],@data.PayAmount_EUR[i],@data.Balance_EUR[i]) ;";

                        conn.Execute(sql);
                    } 
                }
                else
                {
                    Console.WriteLine($"Connection could not be established..");
                }
            }
        }
    }
}
