using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordLibrary
{
    public class NumberToWord : INumberToWord
    {
        /// <summary>
        /// returns the words for input Number
        /// </summary>
        /// <param name="InputNumber">InputNumber</param>
        /// <returns></returns>
        public string NumToWords(long InputNumber)
        {
            if (InputNumber == 0)
                return "Zero";

            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;

            string retval = "";
            string x = "";
            string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] thou = { "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion" };


            bool isNegative = false;
            if (InputNumber < 0)
            {
                isNegative = true;
                InputNumber *= -1;
            }

            string s = InputNumber.ToString();
            while (s.Length > 0)
            {
                //Splitting the input number to last 3 digits
                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);
                threeDigits = int.Parse(x);

                //To find the last two digits
                lasttwo = threeDigits % 100;

                //First Digit number in the lastthree Digits
                dig1 = threeDigits / 100;
                //Second Digit number in the lastthree Digits
                dig2 = lasttwo / 10;
                //Third Digit number in the lastthree Digits
                dig3 = (threeDigits % 10);

                //to find the thousands level
                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {
                    retval = thou[level] + " " + retval;
                    retval = retval.Trim();
                }

                //last two digits 
                if (lasttwo > 0)
                {
                    if (lasttwo < 20)
                        retval = ones[lasttwo] + " " + retval;
                    else
                        retval = tens[dig2] + " " + ones[dig3] + " " + retval;

                }

                if (dig1 > 0)
                    retval = ones[dig1] + (!string.IsNullOrEmpty(retval) ? (" Hundred and " + retval) : " Hundred ");
                //Finding the next level of digits
                s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";

                //increasing the level for looping next digits
                level++;
            }

            while (retval.IndexOf("  ") > 0)
                retval = retval.Replace("  ", " ");

            retval = retval.Trim();

            if (isNegative)
                retval = "Negative " + retval;

            return retval;
        }
    }
}
