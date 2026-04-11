<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="regulations.aspx.cs" Inherits="base.pages.user.regulations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .regulations-section {
            padding: 40px;
            background-color: #fefefe;
            color: #333;
            font-family: Arial, sans-serif;
            text-align: left;
            max-width: 900px;
            margin: 0 auto;
        }

        .regulations-section h1 {
            font-size: 32px;
            text-align: center;
            margin-bottom: 30px;
        }

        .regulations-section ul {
            line-height: 1.8;
            font-size: 18px;
        }

        .regulations-section li {
            margin-bottom: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="regulations-section">
        <h1>Site Regulations</h1>
        <ul>
            <li>Users must register with valid information.</li>
            <li>Respectful communication is mandatory.</li>
            <li>Content uploaded must be original or appropriately licensed.</li>
            <li>The administrator may suspend users who violate terms.</li>
            <li>User data is handled according to our privacy policy.</li>
            <li>This site is for personal, non-commercial use unless authorized.</li>
            <li>Any misuse of the system will result in account termination.</li>
        </ul>
    </div>
</asp:Content>
