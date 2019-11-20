using System;

namespace Kata_Payslip
{
    public class CalculationEngine
    {
        
        public double calcGross(String salary)
        {
            double money = Convert.ToDouble(salary);
            return Math.Round(money/12.0);
        }
        
        public double calcTax(String salary)
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
        public double calcSuper(String salary, String rate)
        {
            double gross = calcGross(salary);
            double super = Convert.ToDouble(rate);
            return Math.Round(gross*(super/100.0));
        }
    }
}