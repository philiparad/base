<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="forgot_pass.aspx.cs" Inherits="base.pages.user.forgot_pass" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form id="form1" runat="server" class="forgot-password-form">
    <h3>Password reset</h3>

    <asp:TextBox ID="txtUsername" runat="server" placeholder="user name"></asp:TextBox>

    <asp:DropDownList ID="ddlQuestion1" runat="server">
        <asp:ListItem Value="mom">What is your mother's name?</asp:ListItem>
        <asp:ListItem Value="date">What is your sister's birthday?</asp:ListItem>
        <asp:ListItem Value="food">What is your favorite food?</asp:ListItem>
    </asp:DropDownList>

    <asp:TextBox ID="txtAnswer1" runat="server" placeholder="first answer"></asp:TextBox>

  <asp:DropDownList ID="ddlQuestion2" runat="server">
    <asp:ListItem Value="dad">What is your father's full name?</asp:ListItem>
    <asp:ListItem Value="date">What is your parents' wedding date?</asp:ListItem>
    <asp:ListItem Value="food">What is your dog's favorite food?</asp:ListItem>
</asp:DropDownList>

<asp:TextBox ID="txtAnswer2" runat="server" placeholder="Second Answer"></asp:TextBox>

<asp:Button ID="btnSubmit" runat="server" Text="Reset Password" CssClass="asp-button" OnClick="btnSubmit_Click" />

<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

<br />
<a href="login.aspx" class="button">Back to Login</a>
</form>

</asp:Content>

