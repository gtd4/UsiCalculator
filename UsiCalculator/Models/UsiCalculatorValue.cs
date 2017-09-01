using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsiCalculator.Models
{
    public class UsiCalculatorValue
    {
        public double Commision1 { get; set; }
        public double Commision2 { get; set; }
        public int TotalPackages { get; set; }
        public int NumDays { get; set; }

        public UsiCalculatorValue()
        {
            TotalPackages = 100;
            Commision1 = TotalPackages * 0.1;
            Commision2 = TotalPackages * 0.03;
            NumDays = 140;
        }

        public UsiCalculatorValue(int totalPackages, double commision1, double commision2)
        {
            TotalPackages = totalPackages;
            Commision1 = commision1;
            Commision2 = commision2;
        }

        public UsiCalculatorValue(int totalPackages)
        {
            TotalPackages = totalPackages;
        }
    }
}