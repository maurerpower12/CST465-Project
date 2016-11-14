using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace MVC465
{
    public class TrueFalseQuestion : TestQuestion
    {
        //public bool _valid;
        //[Required(ErrorMessage = "Required Question")]
        //public override string Answer
        //{
        //    set
        //    {
        //        string pat1 = @"(\w+)\s+(True)";
        //        string pat2 = @"(\w+)\s+(False)";
        //        Regex rgx = new Regex( pat1 ,RegexOptions.IgnoreCase );
        //        Regex rgx2 = new Regex( pat2, RegexOptions.IgnoreCase );
        //        Match a = rgx.Match(this.ToString());
        //        Match b = rgx2.Match(this.ToString());
        //        if(a.Success || b.Success)
        //        {
        //            _valid = true;
        //            Answer = value;
        //        }
        //        else
        //        {
        //            _valid = false;
        //        }
        //    }
        //    get { return Answer; }
        //}

        [Required]
        [RegularExpression("(?i:tru|fals)e")]
        override public string Answer { get { return base.Answer; } set { base.Answer = value; } }

    }
}