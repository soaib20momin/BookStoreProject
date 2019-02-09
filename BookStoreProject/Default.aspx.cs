using BookStoreProject.BusinessClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreProject
{
	public partial class Default : System.Web.UI.Page
	{
		string userRole;
        private string productPropertyName;

        protected void Page_Load(object sender, EventArgs e)
		{
			string productPropertyName = "Id";
			ObjectDataSource1.SelectParameters["sortExpression"].DefaultValue = productPropertyName;
			ObjectDataSource1.SelectMethod = "LoadAll";

            if ((User.Identity.IsAuthenticated) && (User.Identity.Name == "admin"))
            {
                userRole = "Owner";
                productPropertyName = "Price";
                ObjectDataSource1.SelectParameters["sortExpression"].DefaultValue = productPropertyName;
                ObjectDataSource1.SelectMethod = "LoadAll";
            }
            else
            {
                userRole = "Shopper";
                productPropertyName = "Title";
                ObjectDataSource1.SelectParameters["sortExpression"].DefaultValue = productPropertyName;
                ObjectDataSource1.SelectMethod = "LoadAll";

            }
        }

		protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
		{
			e.Cancel = true;
			String productPropertyName = e.SortExpression;
			ObjectDataSource1.SelectMethod = "LoadAll";
			ObjectDataSource1.SelectParameters["sortExpression"].DefaultValue = productPropertyName;
			
		}

		protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Add"))
			{
				int index = Convert.ToInt32(e.CommandArgument);

				int productId = Convert.ToInt32(GridView1.Rows[index].Cells[0].Text);

				ShoppingCart.Instance.AddItem(productId);
				Response.Redirect("ViewCart.aspx");
			}
		}

		
	}
}