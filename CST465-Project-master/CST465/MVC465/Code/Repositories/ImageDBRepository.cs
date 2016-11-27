using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVC465.Code;

namespace MVC465
{
    public class ImageDBRepository
    {

        public Image Get(int id)
        {
            Image cat = new Image();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {

                //Perform your database operations
                //Initialize the connection object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;//or .StoredProcedure
                command.CommandText = "SELECT * FROM Product WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();

                //Open the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cat.FileData = (byte[])reader["ProductImage"];

                    }
                }
            }
            return cat;
        }

        public void Save(Image ProductImage)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //if (ProductImage.ID == 0)
                    //{
                    //    //command.CommandText = "INSERT INTO Product(ProductImage) VALUES(@ProductImage)";
                    //    throw new Exception("Can't insert");
                    //}
                    //else
                    //{

                    command.CommandText = "UPDATE Product SET ProductImage=@ProductImage WHERE ID = ( select MAX(ID) from product);";//ID=@ID";
                        //command.Parameters.AddWithValue("@ID", ProductImage.ID);

                    //}
                    if(ProductImage.FileData != null)
                        command.Parameters.AddWithValue("@ProductImage", ProductImage.FileData);


                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Image> GetList()
        {
            List<Image> cats = new List<Image>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    //Perform your database operations
                    //Initialize the connection object
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Product";
                    command.Connection.Open();

                    //Open the connection
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                Image juanc = new Image();
//                                juanc.ID = (int)reader["ID"];
                                if (reader["ProductImage"].ToString() != null)
                                {
                                    juanc.FileData = (byte[])reader["ProductImage"];
                                }
                                else
                                {
                                    juanc.FileData = null;
                                }
                                cats.Add(juanc);
                            }
                        }
                    }
                }
                return cats;
            }
        }

    }
}