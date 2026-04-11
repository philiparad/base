<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="base.pages.user.adminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/user_table.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Admin Page</h3>

    <form id="form1" runat="server">
        <asp:Literal ID="TableLiteral" runat="server" />
        <asp:Literal ID="ErrorMsg" runat="server" />
    </form>
</asp:Content>
