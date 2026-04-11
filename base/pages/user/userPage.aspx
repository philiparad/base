<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userPage.aspx.cs" Inherits="base.pages.user.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-size: cover;
            background-attachment: scroll;
            font-family: Arial, sans-serif;
            color: #333;
        }

        h2 {
            text-align: center;
            font-size: 60px;
            color: #115586;
        }

        form {
            display: flex;
            flex-wrap: wrap;
            max-width: 720px;
            margin: auto;
        }

        input, select {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        label {
            width: 100%;
            margin-top: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div>
            <h3>Update User Details</h3>

            <asp:ValidationSummary ID="valSummary" runat="server" ForeColor="Red" />

            <label>Username:</label><br />
            <asp:TextBox ID="txtUsername" runat="server" Enabled="false" /><br /><br />

            <label>Password:</label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />

            <label>Email:</label><br />
            <asp:TextBox ID="txtEmail" runat="server" /><br /><br />

            <label>First Name:</label><br />
            <asp:TextBox ID="txtFirstName" runat="server" /><br /><br />

            <label>Last Name:</label><br />
            <asp:TextBox ID="txtLastName" runat="server" /><br /><br />

            <label>Birthday:</label><br />
            <asp:TextBox ID="txtBirthday" runat="server" TextMode="Date" /><br /><br />

            <label>Phone:</label><br />
            <asp:TextBox ID="txtPhone" runat="server" /><br /><br />

            <label>Country:</label><br />
            <asp:DropDownList ID="ddlCountry" runat="server">
                <asp:ListItem Value="Israel">Israel</asp:ListItem>
                <asp:ListItem Value="France">France</asp:ListItem>
                <asp:ListItem Value="Germany">Germany</asp:ListItem>
            </asp:DropDownList><br /><br />

            <label>City:</label><br />
            <asp:TextBox ID="txtCity" runat="server" /><br /><br />

            <asp:Button ID="btnUpdate" runat="server" Text="Update Details" OnClick="btnUpdate_Click" /><br /><br />

            <asp:Label ID="lblStatus" runat="server" ForeColor="Green" Style="font-weight:bold; font-size:16px;" />
        </div>
    </form>

</asp:Content>