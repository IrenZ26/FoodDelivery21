using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDelivery21.Service
{
    class Validator
    {
        public int IsValidInt(string s) 
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
        public decimal IsValidDecimal(string s)
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
