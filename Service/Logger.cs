using FoodDelivery21.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    public class Logger:ILogger
    {
        public void SaveIntoFile(string message)
        {
            var now = DateTime.Now;
            string path = now.ToString("d") + "-log.txt";
            using var writer = new StreamWriter(path, true);
            var time = now.ToString("T");
            writer.WriteLine(time + " " + message);
            writer.Close();
        }
    }
}
