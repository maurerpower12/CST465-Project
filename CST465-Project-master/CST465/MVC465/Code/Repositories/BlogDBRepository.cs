using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MVC465
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {

        public BlogPost Get(int id)
        {
            BlogPost post = new BlogPost();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {

                //Perform your database operations
                //Initialize the connection object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;//or .StoredProcedure
                command.CommandText = "SELECT * FROM Blog WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();

                //Open the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        post.ID = (int)reader["ID"];
                        post.Title = reader["Title"].ToString();
                        post.Content = reader["Content"].ToString();
                        post.Author = reader["Author"].ToString();
                        post.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                    }
                }
            }
            return post;
        }

        public void Save(BlogPost post)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (post.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Blog(Author, Title, Content) VALUES(@Author, @Title, @Content)";

                    }
                    else
                    {
                        command.CommandText = "UPDATE Blog SET Author=@Author, Title=@Title, Content=@Content WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", post.ID);

                    }

                    command.Parameters.AddWithValue("@Author", post.Author);
                    command.Parameters.AddWithValue("@Title", post.Title);
                    command.Parameters.AddWithValue("@Content", post.Content);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<BlogPost> GetList()
        {
            List<BlogPost> blogs = new List<BlogPost>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    //Perform your database operations
                    //Initialize the connection object
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog";
                    command.Connection.Open();

                    //Open the connection
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPost juanblog = new BlogPost();
                            juanblog.ID = (int)reader["ID"];
                            juanblog.Title = reader["Title"].ToString();
                            juanblog.Content = reader["Content"].ToString();
                            juanblog.Author = reader["Author"].ToString();
                            juanblog.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                            blogs.Add(juanblog);
                        }
                    }
                }
                return blogs;
            }
        }

        public void Remove(int iD)
        {
            throw new NotImplementedException();
        }
    }
}