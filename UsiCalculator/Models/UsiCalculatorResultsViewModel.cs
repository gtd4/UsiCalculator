using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsiCalculator.Models
{
    public class UsiCalculatorResultsViewModel
    {
        public List<UsiCalculatorValue> Values;

        public UsiCalculatorResultsViewModel()
        {
            Values = new List<UsiCalculatorValue>();
        }
    }
}