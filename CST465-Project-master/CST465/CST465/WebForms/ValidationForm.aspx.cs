using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CST465.WebForms
{
    public partial class ValidationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder queryString = new StringBuilder();

            queryString.Append("ValidatedFormOutput.aspx").Append("?name=").Append(uxName.Value).Append("&favoritecolor=").Append(uxColor.Value).Append("&city=").Append(uxCity.Value);

            Response.Redirect(queryString.ToString());

        }
    }
}