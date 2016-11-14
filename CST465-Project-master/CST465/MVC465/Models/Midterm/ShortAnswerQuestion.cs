using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC465
{
    public class ShortAnswerQuestion : TestQuestion
    {
        [Required]
        [MaxLength(100)]
        override public string Answer { get { return base.Answer; } set { base.Answer = value; } }
    }
}