<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="base.pages.user.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/user.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form style="position: relative;top: -80px;" id="form1" runat="server">
        <p style="margin-bottom: 50px;">&nbsp;</p>
        <h3>Welcome</h3>
        <input type="text" name="Username" id="Username" placeholder="Username" runat="server" />
        <br />
        <input type="password" name="Password" id="Password" placeholder="Password" runat="server" />
        <br />
        <input type="submit" name="submit" id="submit" />

        <a class="button" href="forgot_pass.aspx">Forgot password?</a>

        <!-- Server-controlled error message -->
        <asp:Label ID="LblMessage" runat="server" CssClass="error-message" Visible="false" />
    </form>
</asp:Content>
