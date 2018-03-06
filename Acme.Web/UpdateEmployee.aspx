<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="Acme.Web.UpdateEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table id="panSearch" runat="server" style="width: auto; color: Black; font-family: Segoe UI; font-size: 14px; float: right; text-align: left; padding: 10px; padding-bottom: 20px;">
        <tr>
            <td>Enter Employee ID</td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="textBox" Placeholder="Enter Employee Number e.g PER-123"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button"
                    OnClick="btnSearch_Click"></asp:Button></td>
        </tr>
        <tr>

            <td colspan="3">
                <asp:Label ID="lblSearchResult" runat="server" Font-Size="Medium"></asp:Label></td>
        </tr>
    </table>

    <table id="panUpdate" runat="server" style="width: 100%; color: Black; font-family: Segoe UI; font-size: 14px; float: left; text-align: left;">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td>Employee ID</td>
            <td>
                <asp:Label ID="lblEmpID" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top">Terminated Date</td>
            <td>

                <%--<asp:TextBox ID="txtPhone" runat="server" CssClass="textBox"></asp:TextBox>--%>
                <asp:Calendar ID="cldTerminatedDate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="410px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="bntUpdated" runat="server" Text="Update" CssClass="button" OnClick="bntUpdated_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
