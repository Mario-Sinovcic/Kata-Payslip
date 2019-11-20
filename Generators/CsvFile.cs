using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata_Payslip.Generators
{
    public class CsvFile : CalculationEngine
    {
        private static PathLog paths = new PathLog();
        
        public CsvFile()
        {
            
        }

        public void createOutput()
        {
            using(var reader = new StreamReader(paths.getSource()))
            {
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
                            Regex charRemover = new Regex(@"[^%]", RegexOptions.IgnoreCase);
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
        
    }
}