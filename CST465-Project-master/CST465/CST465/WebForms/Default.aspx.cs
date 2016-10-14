using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CST465.WebForms
{
    public partial class Default : System.Web.UI.Page
    {

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            if (uxName.Text.Length > 0 && uxPriority.Text.Length > 0 && uxDescription.Text.Length > 0)
            {
                builder.Append("Welcome ").Append(uxName.Text).Append(" this ").Append(uxPriority.Text).Append(" Message is coming to you with this long description of: ").Append(uxDescription.Text).Append(". This message has a subject of: ").Append(uxSubject.Text);
                uxFormOutput.Text = builder.ToString();
            }
            else
            {
                uxFormOutput.Text = "You need to fill it out completely!";
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            uxEventOutput.Text += "~Init called ";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            uxEventOutput.Text += "~Load called ";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            uxEventOutput.Text += "~PreRender called ";
        }


    }
}