using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodDelivery21.Service
{
    public class Validator
    {
        public int IntValidation(string s) 
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
        public decimal DecimalValidation(string s)
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
            string addressMatch = @"[а-яА-Я0-9]{1,8}\.?\s?[а-яА-Я0-9]{1,20}\.?\,?\s?[а-яА-Я0-9]{1,3}\.?\s?\d{1,5}\,?\s?[а-яА-Я0-9]{0,8}\.?\s?\d{0,5}";
            return Regex.IsMatch(address, addressMatch);
        }
        public bool TelephoneValidation(string telephone)
        {
            
            string match = @"\+?\d{3,5}\s?\(?\d{2,3}\)?\s?\d{0,3}\d{2}\s?\d{2}";
            return Regex.IsMatch(telephone, match);
        }
    }
}
