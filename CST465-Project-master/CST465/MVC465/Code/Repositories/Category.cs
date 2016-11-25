using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465
{
    public class Category: IDataEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}