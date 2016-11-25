using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465
{
    public class Inventory: IDataEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public  decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}