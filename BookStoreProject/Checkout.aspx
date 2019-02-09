<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BookStoreProject.Checkout" %>
<%@ Import Namespace="BookStoreProject.BusinessClasses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" Height="18px" Width="366px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" ColumnSpan="2">Please Confirm your purchase or continue shopping</asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Subtotal amount</asp:TableCell>
                    <asp:TableCell runat="server"><%= ShoppingCart.Instance.GetSubTotal().ToString("C") %></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">HST @ 13%</asp:TableCell>
                    <asp:TableCell runat="server"><%= ShoppingCart.Instance.GetSubTotal()* (decimal) 0.13 %></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Total Amount</asp:TableCell>
                    <asp:TableCell runat="server"><%= (ShoppingCart.Instance.GetSubTotal()* (decimal) 0.13)+(decimal)ShoppingCart.Instance.GetSubTotal()  %></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"><asp:Button ID="Btn_Buy" Text="Buy" OnClick="Btn_Buy_Click" runat="server"/></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" ColumnSpan="2"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:Button ID="Btn_BackToCart" Text="Back to Shopping Cart"  OnClick="Btn_BackToCart_Click" runat="server"/></asp:TableCell>
                    <asp:TableCell runat="server"><asp:Button ID="Btn_BackToStore" Text="Back to Store" OnClick="Btn_BackToStore_Click" runat="server"/></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell ColumnSpan="2" runat="server"><asp:Label ID="lbl_ThankYou" Text="" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                
            </asp:Table>
        </div>
    </form>
</body>
</html>
