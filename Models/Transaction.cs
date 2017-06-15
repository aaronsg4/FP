using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.Models
{
    public class Transaction  // This is the actual transaction, a debit, credit, or transfer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }

        public bool Void { get; set; }

        public decimal? ReconciledAmount { get; set; }
        public bool Reconciled { get; set; }


        public int? BudgetId { get; set; }
        public virtual Budget Budget { get; set; }

        public int? BudgetItemId { get; set; }
        public virtual BudgetItem BudgetItem { get; set; }


        //Transaction neeeds to be tied to an Account - just one account
        public int FinancialAccountId { get; set; }
        public virtual FinancialAccount FinancialAccount {get;set;}

        //One transaction can only have one User
        public string SubmitterUserId { get; set; }
        public virtual ApplicationUser SubmitterUser { get; set; }
        //One transaction can only have one Transcaction Type
        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        //One transaction can only have one Transaction Category
        public int? TransactionCategoryId { get; set; }
        public virtual TransactionCategory TransactionCategory { get; set; }
    }
}