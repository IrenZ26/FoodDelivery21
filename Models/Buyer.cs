using FoodDelivery21.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
<<<<<<< HEAD
=======

<<<<<<< HEAD
>>>>>>> regexValidation
=======
        public Buyer(string name,string address,string telephone) 
        {
            Name = name;
            Address = address;
            Telephone = telephone;
        }
>>>>>>> jsonSerialization
    }
}
