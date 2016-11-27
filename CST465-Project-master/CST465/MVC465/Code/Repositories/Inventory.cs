using MVC465.Code;
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
        [Required]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Product Image")]
        public Image ProductImage { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public  decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}