using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;


namespace MVC465
{
    public class DBRepo : IDataEntityRepository<BlogPost>
    {
       

        public BlogPost Get(int id)
        {
            List<BlogPost> blogz = GetList();

            BlogPost blog = blogz.Where(i => i.ID == id).FirstOrDefault();
            return blog;

        }

        public void Save(BlogPost post)
        {
            int id = 1;
            var path = "~/App_Data/data.json";
            List<BlogPost> blogz = GetList();
            string temp;
            JavaScriptSerializer js = new JavaScriptSerializer();


            if (post.ID == 0)
            {
                if (blogz == null || blogz.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = blogz.Max(m => m.ID) + 1;
                }
                post.ID = id;
                post.Timestamp = DateTime.UtcNow.ToLocalTime();
                blogz.Add(post);
            }
            else
            {
                id++;
                BlogPost temp2 = blogz.Where(m => m.ID == post.ID).First();
                int offset = blogz.IndexOf(temp2);

                temp2.Title = post.Title;
                temp2.ID = post.ID;


                //blogz[offset] = post;
            }

            temp = js.Serialize(blogz);
            var file = new StreamWriter(HttpContext.Current.Server.MapPath(path));
            file.Write(temp);
            file.Close();
        }


        public List<BlogPost> GetList()
        {
            var path = "~/App_Data/data.json";

            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = new StreamReader(HttpContext.Current.Server.MapPath(path));
            var str = data.ReadToEnd();
           

            List<BlogPost> blogz = null;
            blogz = js.Deserialize<List<BlogPost>>(str);

            if ( blogz == null)
            {
                blogz = new List<BlogPost>();
            }
            data.Close();
            return blogz;
        }

        public void Remove(int iD)
        {
            throw new NotImplementedException();
        }
    }
}