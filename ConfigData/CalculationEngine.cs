using System;

namespace Kata_Payslip
{
    public class CalculationEngine : TaxBrackets
    {
       
        public double calcGross(String salary)
        {

            double money = Convert.ToDouble(salary);
            return Math.Round(money/12.0);
        }
        
        public double calcTax(String salary)
        {
            double money = Convert.ToDouble(salary) ;
            double taxOutput = 0.0;
            
            if(money < 18201.0)
            {
                return taxOutput;
            }
            if (18200.0 < money && money < 37001.0)
            {
                taxOutput =  ((money-18200.0)*0.19);
            }
            if (37000.0 < money && money < 87001.0)
            {
                taxOutput =  ((money-37000.0)*0.325)+3572.0;
            }
            if (87000.0 < money && money < 180001.0)
            {
                taxOutput = ((money-87000.0)*0.37)+19822.0;
            }
            if (180000.0 < money)
            {
                taxOutput = ((money-180000.0)*0.45)+54232.0;
            }

            return Math.Round(taxOutput/12.0);

        }
        public double calcSuper(String salary, String rate)
        {
            double gross = calcGross(salary);
            double super = Convert.ToDouble(rate);
            return Math.Round(gross*(super/100.0));
        }
    }
}