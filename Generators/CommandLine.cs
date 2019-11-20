using System;

namespace Kata_Payslip.Generators 
{
    public class CommandLine : CalculationEngine
    {
        private String name;
        private String surname;
        private String salary;
        private String superRate;
        private String startDate;
        private String endDate;
        
        public CommandLine()
        {
            getInput();
            createOutput();
        }
        
        private void getInput()
        {
            Console.WriteLine("Please input your name:");
            name = Console.ReadLine();
            Console.WriteLine("Please input your surname:");
            surname = Console.ReadLine();
            Console.WriteLine("Please enter your annual salary:");
            salary = Console.ReadLine();
            Console.WriteLine("Please enter your super rate:");
            superRate = Console.ReadLine();
            Console.WriteLine("Please enter your payment start date:");
            startDate = Console.ReadLine();
            Console.WriteLine("Please enter your payment end date:");
            endDate = Console.ReadLine();
        }
        
        private void createOutput()
        {
            Console.WriteLine("Your payslip has been generated:\n");
            Console.WriteLine("Name: "+name+" "+surname);
            Console.WriteLine("Pay Period: "+startDate+" - "+endDate);
            Console.WriteLine("Gross Income: "+calcGross(salary));
            Console.WriteLine("Income Tax: "+calcTax(salary));
            Console.WriteLine("Net Income: "+(calcGross(salary)-calcTax(salary)));
            Console.WriteLine("Super: "+calcSuper(salary,superRate));
        }
    }
}