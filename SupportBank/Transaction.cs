namespace SupportBank;

class Transaction
{
    public Account PersonTo { get; set; }
    public Account PersonFrom { get; set; }
    public string Date { get; set; }
    public decimal Amount { get; set; }
    public string Narrative { get; set; }

    public Transaction(string date, Account personFrom, Account personTo, string narrative, decimal amount)
    {
        Date = date;
        PersonFrom = personFrom;
        PersonTo = personTo;
        Narrative = narrative;
        Amount = amount;
    }

}

