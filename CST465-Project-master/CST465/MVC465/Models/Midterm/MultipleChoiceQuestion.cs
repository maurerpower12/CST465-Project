using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC465
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required]
        override public string Answer { get { return base.Answer; } set { base.Answer = value; } }
        public List<string> Choices { get; set; }

    }
}