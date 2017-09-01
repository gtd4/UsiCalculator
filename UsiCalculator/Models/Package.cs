using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsiCalculator.Models
{
    public class Package
    {
        public int DaysLeftTillExpire { get; set; }

        public bool IsActive
        {
            get
            {
                if (DaysLeftTillExpire <= 0)
                {
                    return false;
                }

                return true;
            }
        }

        public Package()
        {
            DaysLeftTillExpire = 140;
        }
    }
}