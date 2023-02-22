using System;
using System.IO;
using SupportBank;


   
 List<Transaction> transactions = new List<Transaction>(); //transactions list;
 List<Account> accounts=new List<Account>();

Budget Budget2014 = new Budget(accounts,transactions,"Transactions2014.csv");

Budget2014.ListAll();

Budget2014.ListAccount();







