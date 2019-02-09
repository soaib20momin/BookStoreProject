using BookStoreProject.BusinessClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStoreProject
{
	public partial class ViewCart : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindData();
			}

		}

		protected void BindData()
		{
			gvShoppingCart.DataSource = ShoppingCart.Instance.Items;
			gvShoppingCart.DataBind();
		}

		protected void btnUpdateCart_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gvShoppingCart.Rows){
				if (row.RowType == DataControlRowType.DataRow)
				{
					try
					{
						int productId = Convert.ToInt32(gvShoppingCart.DataKeys[row.RowIndex].Value);

						int quantity = int.Parse(((TextBox)row.Cells[1].FindControl("txtQuantity")).Text);
						ShoppingCart.Instance.SetItemQuantity(productId, quantity);
					}
					catch  (FormatException ex)
					{
						Console.Write(ex.Message);
					}
				}
			  
			}
			BindData();
		}

		protected void gvShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				int productId = Convert.ToInt32(e.CommandArgument);
				ShoppingCart.Instance.RemoveItem(productId);

			}
			BindData();
		}

		protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.Footer)
			{
				e.Row.Cells[6].Text = "Total: " + ShoppingCart.Instance.GetSubTotal().ToString("C");
			}
		}
	}
}