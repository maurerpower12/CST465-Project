using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC465.Code
{
    public class Image
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        [UIHint("ProductImage")]
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
    }
}