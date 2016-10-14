using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465.WebForms
{
    public partial class ValidatedFormOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.QueryString["name"]) || string.IsNullOrEmpty(Request.QueryString["favoritecolor"]) || string.IsNullOrEmpty(Request.QueryString["city"]))
            {
                
                uxInvalidDataArgs.Visible = true;
            }
            else
            {
                uxName.Text = Request.QueryString["name"];
                uxFavoriteColor.Text = Request.QueryString["favoritecolor"];
                uxCity.Text = Request.QueryString["city"];
                uxValidDataArea.Visible = true;
            }

        }
    }
}