using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MVC465
{
    public class CategoryDBRepository : IDataEntityRepository<Category>
    {

        public Category Get(int id)
        {
            Category cat = new Category();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {

                //Perform your database operations
                //Initialize the connection object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;//or .StoredProcedure
                command.CommandText = "SELECT * FROM Category WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();

                //Open the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cat.ID = (int)reader["ID"];
                        cat.CategoryName = reader["CategoryName"].ToString();
                    }
                }
            }
            return cat;
        }
        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                InventoryDBRepository inv = new InventoryDBRepository();
                List<Inventory> ti = inv.GetList();

                foreach (Inventory t in ti) // Remove each of the itmes before removing the category
                {
                    if(t.CategoryID == id)
                    {
                        inv.Remove(t.ID);
                    }
                }

                //Perform your database operations
                //Initialize the connection object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;//or .StoredProcedure
                command.CommandText = "DELETE FROM [Category] WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();

                //Open the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                    }
                }
            }
        }

        public void Save(Category post)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (post.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Category(CategoryName) VALUES(@CategoryName)";

                    }
                    else
                    {
                        command.CommandText = "UPDATE Category SET CategoryName=@CategoryName WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", post.ID);

                    }

                    command.Parameters.AddWithValue("@CategoryName", post.CategoryName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Category> GetList()
        {
            List<Category> cats = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    //Perform your database operations
                    //Initialize the connection object
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Category";
                    command.Connection.Open();

                    //Open the connection
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category juanc = new Category();
                            juanc.ID = (int)reader["ID"];
                            juanc.CategoryName = reader["CategoryName"].ToString();
                            cats.Add(juanc);
                        }
                    }
                }
                return cats;
            }
        }
    }
}