using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC465
{
    public class Category: IDataEntity
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

    }
}