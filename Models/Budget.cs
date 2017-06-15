
using FP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.Models
{
    public class Budget  // This is for a household budget or big picture budget
    {

        public Budget()
{
    Users = new HashSet<ApplicationUser>();
    BudgetItems = new HashSet<BudgetItem>();
}
public int Id { get; set; }
public string Name { get; set; }
public decimal Amount { get; set; }
public decimal BudgetRemaining { get; set; }
public string Description { get; set; }
public decimal? SuggestedAmount { get; set; }  //Should the master budget be able to give a suggested budget based on your average expenses? 
public int BudgetEndDate { get; set; }  //how often the user wants the budget to reset - every week, 30 days, quarter, etc - this will somehow have to calculate between ints and months
 //public DateTime BugetEndDate { get; set; }
 public DateTime BudgetEnd { get; set; }
public DateTime BudgetStartDate { get; set; }


//public int? Outcome { get; set; }

  public string UserId { get; set; }

        public int? BudgetDurationPeriodId { get; set; }
        public virtual BudgetDurationPeriod BudgetDurationPeriod { get; set; }

//Which household will this budget belong to?
//Specific budget can only have one household
public int HouseholdId { get; set; }  //This would include the members or Users 
public virtual Household Household { get; set; }


//The Budget can have many users
public virtual ICollection<ApplicationUser> Users { get; set; }

//How many budget items will this budget have?
//A budget can have many budget items which are like sub-budgets of the Budget
public virtual ICollection<BudgetItem> BudgetItems { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}