<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteEmployee.aspx.cs" Inherits="Acme.Web.DeleteEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table id="panSearch" runat="server" style="width: auto; color: Black; font-family: Segoe UI; font-size: 14px; float: left; text-align: left; padding: 10px; padding-bottom: 20px;">
        <tr>
            <td>Employee Number</td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="textBox" Placeholder="Enter employee number to delete it"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click"></asp:Button></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblSearchResult" runat="server" Font-Size="Medium"></asp:Label></td>
        </tr>
    </table>
    <hr />
    <div style="float: left">
        <asp:GridView ID="grdEmployees" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="473px">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
</asp:Content>
