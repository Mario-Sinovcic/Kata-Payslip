using System;
using Kata_Payslip.Generators;

namespace Kata_Payslip
{
    class Program
    {
        private static readonly Program program = new Program();

        static void Main()
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
            CsvFile csvOutput = new CsvFile();
            csvOutput.generate();
        }

        private void manualInput()
        { 
            CommandLine consoleOutput = new CommandLine();
            consoleOutput.generate();
        }
    }
}