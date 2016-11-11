using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC465.Code.ExtensionMethods
{
    static public class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> t, string str)
        {
            List<BlogPost> temp = t.GetList();

            temp = temp.Where(m => m.Content.Contains(str) || m.Title.Contains(str)).ToList();

            return temp;
        }
    }
}