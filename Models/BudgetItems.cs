using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.Models
{
    public class BudgetItem  // This is for individual budgets within the larger budget - like individual family members budgets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        //One budgetItem can only be part of one Budget
        public int BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
        //Im thinking if you want to break your separate budget items down by category, like food, etc, and a budget item could only have one transaction category
        public int? TransactionCategoryId { get; set; }
        public TransactionCategory TransactionCategory { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}