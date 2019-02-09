<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="BookStoreProject.ViewCart" Theme="MyStoreTheme" %>
<%@ Import Namespace="BookStoreProject.BusinessClasses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div class="container">
			<h1>Shopping Cart</h1>
			<a href="Default.aspx">&lt; Back to Products</a>
			<br /><br />
			<asp:GridView runat="server" ID="gvShoppingCart" SkinID="Fun" AutoGenerateColumns="false" EmptyDataText="There is nothing in your shopping cart."
				DataKeyNames="ProductId" OnRowCommand="gvShoppingCart_RowCommand" OnRowDataBound="gvShoppingCart_RowDataBound">
				<Columns>
					<asp:BoundField DataField="Title" HeaderText="Title"/>
					<asp:BoundField DataField="Author" HeaderText="Author"/>
					<asp:BoundField DataField="Publisher" HeaderText="Publisher"/>
					<asp:BoundField DataField="ISBN" HeaderText="ISBN"/>
					<asp:TemplateField HeaderText="Quantity">
						<ItemTemplate>
							<asp:TextBox runat="server" ID="txtQuantity" Text='<%# Eval("Quantity") %>'></asp:TextBox><br />
							<asp:LinkButton ID="btnRemove" runat="server" Text="Remove" CommandName ="Remove" CommandArgument='<%# Eval("ProductId") %>'>Remove</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="UnitPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Right" 
						HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:c}" />
					<asp:BoundField DataField="TotalPrice" HeaderText="Total" 
						ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:c}" />
				</Columns>
			</asp:GridView>
			<br />
			<table>
			<%--<tr>
				<td align="right">Total Price: $<%=ShoppingCart.Instance.GetSubTotal() %></td>
			</tr>--%>
			<tr>
				<td align="left">
			<asp:Button ID="btnUpdateCart" runat="server" Text="Update Cart" OnClick="btnUpdateCart_Click" />
				</td>
				<td>
					<a href="Checkout.aspx">Check Out</a>                    
				</td>
			</tr>

			<tr>
				<td align="left">
					&nbsp;</td>

			</tr>
				</table>
		</div>
	</form>
</body>
</html>
