using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hellow!!!!");
            string connectionstring = "Data Source=SRV2\\PUPILS;Initial Catalog=adoNet;Integrated Security=True";
            int resCategory = 0, resProduct = 0;
            DB db = new DB();
            string yn = "y";
            while (yn == "y")
            {
                resCategory = +db.InsertCategoryData(connectionstring);
                Console.WriteLine();

                Console.WriteLine("continue?? press y/n");
                yn = Console.ReadLine();
            }
            Console.WriteLine(resCategory + " rows affected");
            Console.WriteLine();
            db.readCategoryData(connectionstring);
            Console.WriteLine("now insert products");
            yn = "y";
            while (yn == "y")
            {
                resProduct = +db.InsertProductData(connectionstring);
                Console.WriteLine();

                Console.WriteLine("continue?? press y/n");
                yn = Console.ReadLine();
            }
            
            Console.WriteLine(resProduct + " rows affected");

            db.readProductData(connectionstring);
        }
    }
}
