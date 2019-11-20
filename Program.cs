using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata_Payslip
{
    class Program
    {
        private static Program program = new Program();

        static void Main(string[] args)
        {
            Console.WriteLine("~~~\nWelcome to the payslip generator!\n");
            Console.WriteLine("Are you using a .csv file (f) or a manual input (i)?");
            String input = Console.ReadLine();

            if (program.checkInputType(input))
            {
                //valid input
            }
            else
            {
                while (input != "i" && input != "f" )
                {
                    Console.WriteLine("Sorry, that input seems invalid please type either f or i.");
                    Console.WriteLine("\nAre you using a .csv file (f) or a manual input (i)?");

                    input = Console.ReadLine();
                    program.checkInputType(input);
                }
            }
        }

        private bool checkInputType(String input)
        {
            if (input == "f")
            {
                Console.WriteLine("~~~\nCSV file input mode selected\n");
                fileInput();
            }
            else if (input == "i"){
                Console.WriteLine("~~~\nManual input mode selected\n");
                manualInput();
            }

            return false;
        }
        
        private void fileInput()
        {
            using(var reader = new StreamReader("/Users/mario.sinovcic/Documents/RiderProjects/Kata-Payslip/kata-payslip-given/sample_input.csv"))
            {
                List<string> list = new List<string>();
                bool firstLine = true;
                
                var csv = new StringBuilder();
                csv.Append("name, pay period, gross income, income tax, net income, super\n");
                
                while (!reader.EndOfStream)
                {
                    if (firstLine)
                    {
                        var line = reader.ReadLine();
                        firstLine = false;
                    }
                    else
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        
                        String[] currentLine = new string[5];
                        for(int i=0;i<5;i++)
                        {
                            Regex regex = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.IgnoreCase);
                            currentLine[i]=values[i].Trim();
                        }

                        csv.Append(currentLine[0] + " " + currentLine[1]+",");
                        csv.Append(currentLine[4]+ ",");
                        csv.Append(calcGross(currentLine[2])+ ",");
                        csv.Append(calcTax(currentLine[2])+ ",");
                        csv.Append(calcGross(currentLine[2]) - calcTax(currentLine[2])+ ",");
                        csv.Append(calcSuper(currentLine[2],currentLine[3].Substring(0,values[3].Length-1))+ "\n");

                    }
                }
                File.WriteAllText("/Users/mario.sinovcic/Documents/RiderProjects/Kata-Payslip/kata-payslip-given/test.csv", csv.ToString());
            }
        }

        private void manualInput()
        {
            Console.WriteLine("Please input your name:");
            String name = Console.ReadLine();
            Console.WriteLine("Please input your surname:");
            String surname = Console.ReadLine();
            Console.WriteLine("Please enter your annual salary:");
            String salary = Console.ReadLine();
            Console.WriteLine("Please enter your super rate:");
            String superRate = Console.ReadLine();
            Console.WriteLine("Please enter your payment start date:");
            String startDate = Console.ReadLine();
            Console.WriteLine("Please enter your payment end date:");
            String endDate = Console.ReadLine();

            Console.WriteLine("Your payslip has been generated:\n");
            Console.WriteLine("Name: "+name+" "+surname);
            Console.WriteLine("Pay Period: "+startDate+" - "+endDate);
            Console.WriteLine("Gross Income: "+calcGross(salary));
            Console.WriteLine("Income Tax: "+calcTax(salary));
            Console.WriteLine("Net Income: "+(calcGross(salary)-calcTax(salary)));
            Console.WriteLine("Super: "+calcSuper(salary,superRate));
        }


        private double calcGross(String salary)
        {
            double money = Convert.ToDouble(salary);
            return Math.Round(money/12.0);
        }
        
        private double calcTax(String salary)
        {
            double money = Convert.ToDouble(salary);
            
            if (18201.0 < money && money < 37001.0)
            {
                return (Math.Round(((money-18200.0)*0.19))/12.0);
            }
            if (37001.0 < money && money < 87001.0)
            {
                return Math.Round(((((money-37000.0)*0.325)+3572.0))/12.0);
            }
            if (87001.0 < money && money <= 180001.0)
            {
                return Math.Round(((((money-87000.0)*0.37)+19822.0))/12.0);
            }
            if (180001.0 < money)
            {
                return Math.Round(((((money-180000.0)*0.45)+54232.0))/12.0);

            }
            return 0;
        }
        
        private double calcSuper(String salary, String rate)
        {
            double gross = calcGross(salary);
            double super = Convert.ToDouble(rate);
            return Math.Round(gross*(super/100.0));
        }
        
    }
}