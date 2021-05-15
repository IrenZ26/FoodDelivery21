using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery21.Service
{
    class Logger
    {
        public void SaveIntoFile(string massage)
        {//Логироваться должны запросы на добавление, на удаление и на изменение данных.
            var now = DateTime.Now;
            string path = now.ToString("d") + "-log.txt";
            using var writer = new StreamWriter(path, true);
            string time = now.ToString("T");
            writer.WriteLine(time + " " + massage);
            writer.Close();
        }
    }
}
