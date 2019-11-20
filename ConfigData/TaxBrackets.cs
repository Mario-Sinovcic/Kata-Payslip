using System;
using System.Collections.Generic;

namespace Kata_Payslip
{
    public class TaxBrackets
    {
        public IDictionary<int, double[]> taxDict = new Dictionary<int, double[]>();

        public TaxBrackets()
        {
            double[] firstBracket = {0.0, 18201.0};
            taxDict.Add(1, firstBracket);
            
            double[] secondBracket = {18201.0, 37001.0};
            taxDict.Add(2, secondBracket);
            
            double[] third = {37001.0, 87001.0};
            taxDict.Add(3, thirdBracket);
            
            double[] fourth = {870000.0, 180001.0};
            taxDict.Add(4, fourth);
        }
        
        
    
    }
}