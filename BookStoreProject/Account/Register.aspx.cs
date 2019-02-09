using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreProject.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

        }
    }
}