using System;
using System.IO;
using SupportBank;

   
List<Transaction> transactions = new List<Transaction>(); //transactions list;

using(StreamReader reader = new StreamReader("transactions2014.csv")) {
string line;
bool isFirstLine = true;
while ((line = reader.ReadLine()) != null)
{
    if (isFirstLine)
    {
        isFirstLine = false;
        continue;
    }
    string[] values = line.Split(',');
    Transaction nextTransaction = new Transaction(Convert.ToString(values[0]),
                                        new Account(Convert.ToString(values[1])), 
                                        new Account(Convert.ToString(values[2])),
                                        Convert.ToString(values[3]),
                                        Convert.ToDecimal(values[4])
                                        //remove Convert.ToString if not needed;
                                         );

    transactions.Add(nextTransaction);
    }
}

Console.WriteLine($"{transactions[10].PersonTo.Name}");







