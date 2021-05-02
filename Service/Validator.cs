using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodDelivery21.Service
{
    public class Validator
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

        public bool AddressValidation(string address)
        {
            bool result = false;
            string addressMatch = @"[а-яА-Я0-9]{1,8}\s[а-яА-Я0-9]{1,20}\s[а-яА-Я0-9]{1,3}\s\d{1,5}\s[а-яА-Я0-9]{1,8}\s\d{1,5}";
            string addressMatch1 = @"[а-яА-Я0-9]{1,8}\s[а-яА-Я0-9]{1,20}\,\s[а-яА-Я0-9]{1,3}\s\d{1,5}\,\s[а-яА-Я0-9]{1,8}\s\d{1,5}";
            string addressMatch2 = @"[а-яА-Я0-9]{1,8}\s[а-яА-Я0-9]{1,20}\,\s[а-яА-Я0-9]{1,3}\.\s\d{1,5}\,\s[а-яА-Я0-9]{1,8}\.\s\d{1,5}";
            string addressMatch3 = @"[а-яА-Я0-9]{1,8}\s[а-яА-Я0-9]{1,20}\.\s[а-яА-Я0-9]{1,3}\.\d{1,5}\,\s[а-яА-Я0-9]{1,8}\.\d{1,5}";
            string addressMatch4 = @"[а-яА-Я0-9]{1,8}\.[а-яА-Я0-9]{1,20}\.[а-яА-Я0-9]{1,3}\.\d{1,5}\,[а-яА-Я0-9]{1,8}\.\d{1,5}";
            string addressMatch5 = @"[а-яА-Я0-9]{1,8}\.[а-яА-Я0-9]{1,20}\.[а-яА-Я0-9]{1,3}\.\d{1,5}";
            string addressMatch6 = @"[а-яА-Я0-9]{1,8}\.[а-яА-Я0-9]{1,20}\.[а-яА-Я0-9]{1,3}\s\d{1,5}\,\s[а-яА-Я0-9]{1,8}\s\d{1,5}";
            if ((Regex.IsMatch(address, addressMatch)) || (Regex.IsMatch(address, addressMatch1))|| (Regex.IsMatch(address, addressMatch2)) 
                || (Regex.IsMatch(address, addressMatch3))|| (Regex.IsMatch(address, addressMatch4)) || (Regex.IsMatch(address, addressMatch5)) || (Regex.IsMatch(address, addressMatch6))) { result = true; }
            return result;
        }
        public bool TelephoneValidation(string telephone)
        {
            bool result = false;
            string match = @"\d{10}";
            string match1 = @"\d{3}\s\d{3}\s\d{2}\s\d{2}";
            string match2 = @"\+\d{12}";
            string match3 = @"\+\d{3}\(\d{2}\)\d{3}\s\d{2}\s\d{2}";
            if((Regex.IsMatch(telephone, match))||(Regex.IsMatch(telephone, match1))||(Regex.IsMatch(telephone, match2))|| (Regex.IsMatch(telephone, match3))){ result = true; }
            return result;
        }
    }
}
