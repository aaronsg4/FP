using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.Models
{
    public class FinancialAccount   //Bank account, etc
    {
        public FinancialAccount()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ActualBalance { get; set; }   //This is the real balance of the account
        public decimal ReconciledBalance { get; set; }  //This is the balance of the account as compared with the amount of income/expenses in budgeter?
        public DateTime CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Include { get; set; }

        public virtual ICollection<Transaction>Transactions { get; set; }

        public string AccountHolderUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        //one account can only have one household
        public int HouseholdId { get; set; }
        public virtual Household Household { get; set; }

        //one account can only have one account type
        public int AccountTypeId { get; set; }
        public virtual FinancialAccountType AccountType { get; set; }
    }
}