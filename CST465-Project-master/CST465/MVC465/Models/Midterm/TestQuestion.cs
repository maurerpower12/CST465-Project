using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC465
{
    public class TestQuestion
    {
        public int ID { get; set; }
        public string Question { get; set; }
        [Required]
        public virtual string Answer { get; set; }
    }
}
