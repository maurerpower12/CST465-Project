using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC465
{
    public class LongAnswerQuestion : TestQuestion
    {
        [DataType(DataType.MultilineText)]
        [Required]
        override public string Answer
        {
            get { return base.Answer; }
            set { base.Answer = value; }
        }
    }
}