using Magazin.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Business
{
    public class ProductCommands
    {
        string connection = "Server=DESKTOP-H6STNB7; database=Magazin; integrated security=true;";
        public void ShowAll()
        {
            Product product= new Product();
            List<Product> products = new List<Product>();
            SqlConnection con=new SqlConnection(connection);
            con.Open();
            using(con)
            {
                SqlCommand command = new SqlCommand("use Magazin; Select*from Product;",con);
                SqlDataReader reader=command.ExecuteReader();
                using(reader)
                {
                    while (reader.Read())
                    {
                        product.ID = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Price=reader.GetDecimal(2);
                        product.Stock = reader.GetInt32(3);
                        products.Add(product);
                    }
                }
            }
            con.Close();
            foreach (var item in products)
            {
                Console.WriteLine("ID:"+item.ID);
                Console.WriteLine("Name:"+item.Name);
                Console.WriteLine("Price:"+item.Price);
                Console.WriteLine("Amount:"+item.Stock);
            }
        }
        public Product ShowCertainProduct(int id)
        {
            Product product = new Product();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand("use Magazin; Select*from Product where id=@id;", con);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        product.ID = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Price = reader.GetDecimal(2);
                        product.Stock = reader.GetInt32(3);
                    }
                }
            }
            con.Close();
            return product;
        }
        public void Add(Product product)
        {
            SqlConnection con=new SqlConnection(connection);
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand("use Magazin; Insert into Product values(@id, @name, @price, @stock);",con);
                command.Parameters.AddWithValue("@id",product.ID);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
            }
            con.Close();
        }
        public void Update(Product product)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand("use Magazin; Update Product set name=@name, price=@price, stock=@stock where id=@id;", con);
                command.Parameters.AddWithValue("@id", product.ID);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
            }
            con.Close();
        }
        public void Delete(int id)
        {
            SqlConnection con= new SqlConnection(connection);
            con.Open();
            using(con)
            {
                SqlCommand command = new SqlCommand("use Magazin; Delete from Product where id=@id;", con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
