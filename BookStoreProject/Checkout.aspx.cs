using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreProject.BusinessClasses;

namespace BookStoreProject
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("Account/Login.aspx");
        }

        protected void Btn_BackToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void Btn_BackToStore_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Btn_Buy_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Session["ASPNETShoppingCart"] = null;
            //Session.Remove("ASPNETShoppingCart");
            ShoppingCart.Instance.RemoveAllItems();
            lbl_ThankYou.Text = "Thank you for Shopping at my Store. Your purchase has been processed.";
        }
    }
}