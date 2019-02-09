using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreProject.MasterPages
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginName1.FormatString = "Welcome to our Store, {0}";

        }
        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {

        }
    }
}