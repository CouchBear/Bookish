﻿using System;
using System.IO;
using SupportBank;


   
 List<Transaction> transactions = new List<Transaction>(); //transactions list;
 List<Account> accounts=new List<Account>();

Budget Budget2014 = new Budget(accounts,transactions,"Transactions2014.csv");

// Console.WriteLine($"{Budget2014.Transactions[10].PersonTo.Name}");

// Console.WriteLine($"{Budget2014.Accounts[10].Name}");

Budget2014.ListAll();

//Budget2014.ListAccount("Gergana I");







