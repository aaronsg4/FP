﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.Models
{
    public class TransactionType  //Income, Transfer, Expense
    {

        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }


        //One Transaction type can belong to many Transactions
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}