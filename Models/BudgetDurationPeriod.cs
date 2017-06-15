using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP.Models
{
    public class BudgetDurationPeriod

    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Budget>Budgets { get; set; }
    }
}