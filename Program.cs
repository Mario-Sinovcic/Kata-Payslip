using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata_Payslip
{
    class Program : CalculationEngine
    {
        private static Program program = new Program();
        private static PathLog paths = new PathLog();

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
            using(var reader = new StreamReader(paths.getSource()))
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
                File.WriteAllText(paths.getDestination(), csv.ToString());
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
    }
}