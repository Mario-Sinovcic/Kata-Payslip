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
            taxDict.Add(0, firstBracket);
            
            double[] secondBracket = {18201.0, 37001.0};
            taxDict.Add(1, secondBracket);
            
            double[] thirdBracket = {37001.0, 87001.0};
            taxDict.Add(2, thirdBracket);
            
            double[] fourthBracket = {87000.0, 180001.0};
            taxDict.Add(3, fourthBracket);
            
            double[] fifthBracket = {180001.0};
            taxDict.Add(4, fifthBracket);
        }
    }
}