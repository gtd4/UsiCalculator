using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsiCalculator.Models
{
    public class UsiCalculatorViewModel
    {
        public int InitialPackages { get; set; }
        public int GoalPackages { get; set; }

        public List<UsiCalculatorValue> Values { get; set; }

        public UsiCalculatorViewModel()
        {
            Values = new List<UsiCalculatorValue>();
        }
    }
}