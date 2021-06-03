using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodDelivery21.Service
{
    public class Validator
    {
        public int CheckInt(string s) 
        {
            int result = 0;
            try
            {
                result = int.Parse(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Error");
            }
            return result;
        }
        public decimal CheckDecimal(string s)
        {
            decimal result = 0;
            try
            {
                result = decimal.Parse(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Error");
            }
            return result;
        }
    }
}
