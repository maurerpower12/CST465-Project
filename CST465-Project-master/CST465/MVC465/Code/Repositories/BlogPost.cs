﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC465
{
    public class BlogPost: IDataEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

    }
}