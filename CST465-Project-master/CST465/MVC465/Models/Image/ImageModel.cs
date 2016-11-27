using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC465.Models
{
    public class ImageModel
    {
        public int ID { get; set; }
        public HttpPostedFileWrapper SampleImage { get; set; }
    }
}