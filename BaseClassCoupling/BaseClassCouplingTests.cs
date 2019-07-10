using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaseClassCoupling
{
    [TestClass]
    public class BaseClassCouplingTests
    {
        [TestMethod]
        public void calculate_half_year_employee_bonus()
        {
            //if my monthly salary is 1200, working year is 0.5, my bonus should be 600
            var lessThanOneYearEmployee = new FakeLessThanOneYearEmployee()
            {
                Id = 91,
                //Console.WriteLine("your StartDate should be :{0}", DateTime.Today.AddDays(365/2*-1));
                Today = new DateTime(2018, 1, 27),
                StartWorkingDate = new DateTime(2017, 7, 29)
            };
            lessThanOneYearEmployee.Logger = new TestLogger();

            var actual = lessThanOneYearEmployee.GetYearlyBonus();

            Assert.AreEqual(600, actual);
        }
    }

    public interface ILogger
    {
        void Info(string message);
    }

    internal class TestLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Logger : ILogger
    {
        public void Info(string message)
        {
            DebugHelper.Info(message);
        }
    }

    internal class FakeLessThanOneYearEmployee : LessThanOneYearEmployee
    {
        internal override decimal GetMonthlySalary()
        {
            return 1200;
        }
    }

    public abstract class Employee
    {
        private ILogger _logger;

        public ILogger Logger
        {
            get => _logger ?? new Logger();
            set => _logger = value;
        }

        public DateTime StartWorkingDate { get; set; }
        public DateTime Today { get; set; }

        internal virtual decimal GetMonthlySalary()
        {
            Logger.Info("");
            return SalaryRepo.Get(this.Id);
        }

        public abstract decimal GetYearlyBonus();

        public int Id { get; set; }
    }

    public class LessThanOneYearEmployee : Employee
    {
        public override decimal GetYearlyBonus()
        {
            Logger.Info("--get yearly bonus--");
            var salary = this.GetMonthlySalary();
            Logger.Info($"id:{Id}, his monthly salary is:{salary}");
            return Convert.ToDecimal(this.WorkingYear()) * salary;
        }

        private double WorkingYear()
        {
            Logger.Info("--get working year--");
            var year = (Today - StartWorkingDate).TotalDays / 365;
            return year > 1 ? 1 : Math.Round(year, 2);
        }
    }

    public static class DebugHelper
    {
        public static void Info(string message)
        {
            //you can't modified this function
            throw new NotImplementedException();
        }
    }

    public static class SalaryRepo
    {
        internal static decimal Get(int id)
        {
            //you can't modified this function
            throw new NotImplementedException();
        }
    }
}