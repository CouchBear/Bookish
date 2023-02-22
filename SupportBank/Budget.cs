namespace SupportBank;

class Budget
{
    public List<Account> Accounts { get; set; }
    public List<Transaction> Transactions { get; set; }

    public string CsvFilePath { get; set; }

    public Budget(List<Account> accounts, List<Transaction> transactions, string csvFilePath)
    {

        Accounts = accounts;
        Transactions = transactions;
        CsvFilePath = csvFilePath;

        using (StreamReader reader = new StreamReader(csvFilePath))
        {
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
                if(!Accounts.Any(a => a.Name==nextTransaction.PersonFrom.Name)) 
                    Accounts.Add(nextTransaction.PersonFrom);
                if(!Accounts.Any(a => a.Name==nextTransaction.PersonTo.Name)) 
                    Accounts.Add(nextTransaction.PersonTo);
                
                //list.Any(x=>x.name==string) from stack overflow;
                //if account list doesn't contain this, then Add to account list

                Transactions.Add(nextTransaction);
            }
        }

    }
    public void ListAll()
    {
        foreach(Account a in Accounts) {
            decimal accountSum = 0;
            foreach(Transaction t in Transactions) {
                if (t.PersonFrom.Name == a.Name) accountSum += t.Amount;
                if (t.PersonTo.Name == a.Name) accountSum -= t.Amount;
            }
            Console.WriteLine($"Name: {a.Name} Amount: {accountSum} in {(accountSum > 0 ? "credit" : "debit")}"); 

        }

    }
    public void ListAccount(string name) {
        Console.WriteLine($"user {name} has the following transactions:");
            foreach(Transaction t in Transactions){
                if (t.PersonFrom.Name==name || t.PersonTo.Name==name){
                    Console.WriteLine($"Date: {t.Date}\b From: {t.PersonFrom.Name}\b  To: {t.PersonTo.Name}\b Narrative: {t.Narrative}\b  Amount: {t.Amount}");
                }
            }
    }
}


