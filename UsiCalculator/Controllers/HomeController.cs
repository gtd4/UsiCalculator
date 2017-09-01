using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsiCalculator.Models;

namespace UsiCalculator.Controllers
{
    public class HomeController : Controller
    {
        private const int packagePrice = 85;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RebuyWithCommissions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsiCalculatorViewModel values)
        {
            var initialValue = new UsiCalculatorValue(values.InitialPackages);
            var vm = values;
            var packageList = new List<Package>();

            for (int i = 0; i < values.InitialPackages; i++)
            {
                packageList.Add(new Package());
            }

            var valuesList = vm.Values;
            var totalPackages = packageList.Where(x => x.IsActive).Count();

            double partPackage = 0;

            valuesList.Add(initialValue);

            while (totalPackages < values.GoalPackages)
            {
                foreach (var pckg in packageList)
                {
                    pckg.DaysLeftTillExpire--;
                }

                double number = totalPackages * 0.01;

                long intPart = GetIntPart(number);
                double fractionalPart = GetDecimalPart(number, intPart);

                partPackage += fractionalPart;

                var addTotal = intPart;

                for (var j = 0; j < addTotal; j++)
                {
                    packageList.Add(new Package());
                }

                if (partPackage > 1)
                {
                    partPackage = partPackage - 1;
                    totalPackages++;
                    packageList.Add(new Package());
                }

                totalPackages = packageList.Where(x => x.IsActive).Count();

                valuesList.Add(new UsiCalculatorValue(totalPackages));
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult RebuyWithCommissions(UsiCalculatorViewModel values)
        {
            var initialValue = new UsiCalculatorValue(values.InitialPackages);
            var vm = values;
            var packageList = new List<Package>();

            for (int i = 0; i < initialValue.TotalPackages; i++)
            {
                packageList.Add(new Package());
            }

            var valuesList = vm.Values;
            var totalPackages = packageList.Where(x => x.IsActive).Count();

            double partPackage = 0;
            double comm1PartPackage = 0;
            double comm2PartPackage = 0;

            var comm1 = initialValue.TotalPackages * 0.1;
            var comm2 = initialValue.TotalPackages * 0.03;

            initialValue.Commision1 = comm1;
            initialValue.Commision2 = comm2;

            valuesList.Add(initialValue);

            while (totalPackages < values.GoalPackages)
            {
                foreach (var pckg in packageList)
                {
                    pckg.DaysLeftTillExpire--;
                }

                double number = totalPackages * 0.01;
                comm1 += number * 0.1;
                comm2 += number * 0.03;

                long intPart = GetIntPart(number);
                double fractionalPart = GetDecimalPart(number, intPart);

                var comm1IntPart = GetIntPart(comm1);
                var comm1DecPart = GetDecimalPart(comm1, comm1IntPart);

                var comm2IntPart = GetIntPart(comm2);
                var comm2DecPart = GetDecimalPart(comm2, comm2IntPart);

                partPackage += fractionalPart;
                comm1PartPackage = comm1DecPart;
                comm2PartPackage = comm2DecPart;

                //totalPackages += (int)intPart;
                //totalPackages += (int)comm1IntPart;
                //totalPackages += (int)comm2IntPart;

                var addTotal = intPart + comm1IntPart + comm2IntPart;

                for (var j = 0; j < addTotal; j++)
                {
                    packageList.Add(new Package());
                }

                comm1 = comm1 - comm1IntPart;
                comm2 = comm2 - comm2IntPart;

                if (partPackage > 1)
                {
                    partPackage = partPackage - 1;
                    totalPackages++;
                    packageList.Add(new Package());
                }

                if (comm1PartPackage > 1)
                {
                    comm1PartPackage = comm1PartPackage - 1;
                    totalPackages++;
                    packageList.Add(new Package());
                }

                if (comm2PartPackage > 1)
                {
                    comm2PartPackage = comm2PartPackage - 1;
                    totalPackages++;
                    packageList.Add(new Package());
                }

                totalPackages = packageList.Where(x => x.IsActive).Count();

                valuesList.Add(new UsiCalculatorValue(totalPackages, comm1, comm2));
            }

            return View(vm);
        }

        private long GetIntPart(double number)
        {
            return (long)number;
        }

        private double GetDecimalPart(double number, long intPart)
        {
            return number - intPart;
        }

        //public ActionResult About()
        //{
        //	ViewBag.Message = "Your application description page.";

        //	return View();
        //}

        //public ActionResult Contact()
        //{
        //	ViewBag.Message = "Your contact page.";

        //	return View();
        //}
    }
}