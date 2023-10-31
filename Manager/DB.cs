using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Manager
{
    internal class DB
    {

        public int InsertProductData(string connectionstring)
        {
            string name, image, description;
            int categoryId, price;
            Console.WriteLine("insert categoryId");
            categoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert name");
            name = Console.ReadLine();
            Console.WriteLine("insert price");
            price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert description");
            description = Console.ReadLine();
            Console.WriteLine("insert image");
            image = Console.ReadLine();

            string queryString = "INSERT INTO Products(categoryId,name,price,description,image)" +
                    "VALUES(@categoryId,@name,@price,@description,@image)";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                command.Parameters.Add("@description", SqlDbType.VarChar, 200).Value = description;
                command.Parameters.Add("@image", SqlDbType.VarChar, 50).Value = image;
                command.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                command.Parameters.Add("@price", SqlDbType.Int).Value = price;
                connection.Open();
                int rowsAffect = command.ExecuteNonQuery();
                return rowsAffect;
            }
        }
        public int InsertCategoryData(string connectionstring)
        {
            string Name;


            Console.WriteLine("insert name");
            Name = Console.ReadLine();


            string queryString = "INSERT INTO Category(Name)" +
                    "VALUES(@Name)";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = Name;

                connection.Open();
                int rowsAffect = command.ExecuteNonQuery();
                return rowsAffect;
            }
        }

        public void readCategoryData(string connectionstring)
        {
            string queryString = "select * from Category";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();

            }

        }
        public void readProductData(string connectionstring)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();

            }

        }




    }
}
