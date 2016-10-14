using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CST465.WebForms
{
    public partial class RequiredTextBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string LabelText
        {
            get { return lblRequired.Text; }
            set { lblRequired.Text = value; }
        }
        public string Value
        {
            get { return uxRequired.Text; }
            set { uxRequired.Text = value; }
        }

        public string ValidationGroup
        {
            get { return valRequired.ValidationGroup; }
            set { valRequired.ValidationGroup = value; }
        }
    }
}