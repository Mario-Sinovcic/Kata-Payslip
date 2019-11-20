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
            
            if(taxDict[0][0] < money && money < taxDict[0][1])
            {
                return taxOutput;
            }
            if (taxDict[1][0] < money && money < taxDict[1][1])
            {
                taxOutput =  ((money-taxDict[1][0])*0.19);
            }
            if (taxDict[2][0] < money && money < taxDict[2][1])
            {
                taxOutput =  ((money-taxDict[2][0])*0.325)+3572.0;
            }
            if (taxDict[3][0]< money && money < taxDict[3][1])
            {
                taxOutput = ((money-taxDict[3][0])*0.37)+19822.0;
            }
            if (taxDict[4][0] < money)
            {
                taxOutput = ((money-taxDict[4][0])*0.45)+54232.0;
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