<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reset_password.aspx.cs" Inherits="base.pages.user.reset_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id="form1" runat="server">
    <h3>Reset Your Password</h3>
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Placeholder="New password..."></asp:TextBox><br />
    <asp:Button ID="btnReset" runat="server" Text="Change Password" OnClick="btnReset_Click" /><br />
    <asp:Label ID="lblStatus" runat="server" ForeColor="Green"></asp:Label>
</form>
</asp:Content>
