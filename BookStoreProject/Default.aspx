<%@ Page Language="C#"  MasterPageFile="MasterPages/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookStoreProject.Default" Theme="MyStoreTheme" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<div class="container">
		<h1>My Store</h1>
		<asp:GridView ID="GridView1" runat ="server" SkinID="Professional"  AutoGenerateColumns="False" Width="800px" 
			DataSourceID="ObjectDataSource1"
			AllowSorting="True"
			OnSorting ="GridView1_Sorting" 
			OnRowCommand="GridView1_RowCommand">
			<Columns>
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"/>
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
				<asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author"/>
				<asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
				<asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN"/>
				<asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher"/>
				<asp:ButtonField ButtonType="Button" CommandName="Add" ShowHeader="false" Text="Add To Cart" />
			</Columns>
		</asp:GridView>    

		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="BookStoreProject.BusinessClasses.Products">
			<SelectParameters>
				<asp:Parameter Name="sortExpression" Type="String" />
			</SelectParameters>

		</asp:ObjectDataSource>

		<a href="ViewCart.aspx">View Cart</a>
	</div>
	
</asp:Content>
<%--<asp:Content runat="server" ContentPlaceHolderID="footer"></asp:Content>--%>
	
