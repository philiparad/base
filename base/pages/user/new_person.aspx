<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="new_person.aspx.cs" Inherits="base.pages.user.new_person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/user.css" rel="stylesheet" />
    <style>
        .field-error {
            color: red;
            margin-top: 3px;
            margin-bottom: 3px;
            font-size: 0.9em;
        }
        .form-group {
            margin-bottom: 20px;
            width:500px;
        }
    </style>
    <script src="/JavaScript/JavaScript.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Sign Up</h3>
    <p style="margin-bottom: 50px;">&nbsp;</p>

    <form id="signupForm" method="post" runat="server">

        <div class="form-group">
            <label for="username">Username:</label>
            <input type="text" id="username" name="username" runat="server" />
            <div id="usernameError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" runat="server" />
            <div id="passwordError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="passwordVerification">Confirm Password:</label>
            <input type="password" id="passwordVerification" name="passwordVerification" runat="server" />
            <div id="passwordVerificationError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="firstName">First Name:</label>
            <input type="text" id="firstName" name="firstName" runat="server" />
            <div id="firstNameError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="lastName">Last Name:</label>
            <input type="text" id="lastName" name="lastName" runat="server" />
            <div id="lastNameError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="gender">Gender:</label><br>
            <label style="position: relative;top: 23px;left: 79px;" for="male">Male</label>
            <input type="radio" id="male" name="userGender" value="male" runat="server" />
            <label style="position: relative;top: 23px;left: 79px;"     for="female">Female</label>
            <input type="radio" id="female" name="userGender" value="female" runat="server" />
            <div id="genderError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Enter your Gmail address" runat="server" />
            <div id="emailError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="phone">Phone Number:</label>
            <input type="text" id="phone" name="phone" runat="server" />
            <div id="phoneError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="birthday">Birthday:</label>
            <input type="date" id="birthday" name="birthday" runat="server" />
        </div>

        <div class="form-group">
            <label for="country">Country:</label>
            <select id="country" name="country" runat="server">
                <option value="Israel">Israel</option>
                <option value="Jordan">Jordan</option>
                <option value="Lebanon">Lebanon</option>
                <option value="Syria">Syria</option>
                <option value="Egypt">Egypt</option>
                <option value="Iraq">Iraq</option>
                <option value="Kuwait">Kuwait</option>
                <option value="Bahrain">Bahrain</option>
                <option value="Qatar">Qatar</option>
                <option value="UnitedArabEmirates">United Arab Emirates</option>
                <option value="Oman">Oman</option>
                <option value="SaudiArabia">Saudi Arabia</option>
                <option value="France">France</option>
                <option value="Germany">Germany</option>
                <option value="Romania">Romania</option>
                <option value="China">China</option>
                <option value="Japan">Japan</option>
                <option value="South Korea">South Korea</option>
                <option value="North Korea">North Korea</option>
                <option value="Russia">Russia</option>
                <option value="Mongolia">Mongolia</option>
                <option value="Poland">Poland</option>
                <option value="Switzerland">Switzerland</option>
            </select>
            <div id="countryError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="city">City:</label>
            <input type="text" id="city" name="city" runat="server" />
            <div id="cityError" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="question1">Security Question 1:</label>
            <select id="question1" name="question1" runat="server">
                <option value="mom">What is your mother's name?</option>
                <option value="date">What is your sister's birth date?</option>
                <option value="food">What is your favorite food?</option>
            </select>
            <div id="question1Error" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="answer1">Answer 1:</label>
            <input type="text" id="answer1" name="answer1" runat="server" />
            <div id="answer1Error" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="question2">Security Question 2:</label>
            <select id="question2" name="question2" runat="server">
                <option value="dad">What is your father's full name?</option>
                <option value="date">What is your parents' wedding date?</option>
                <option value="food">What is your dog's favorite food?</option>
            </select>
            <div id="question2Error" class="field-error"></div>
        </div>

        <div class="form-group">
            <label for="answer2">Answer 2:</label>
            <input type="text" id="answer2" name="answer2" runat="server" />
            <div id="answer2Error" class="field-error"></div>
        </div>

        <p style="margin-bottom: 1px;">&nbsp;</p>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return validateForm();" OnClick="btnSubmit_Click" />
        <input type="reset" id="reset" name="reset" value="Reset" />
    </form>

    <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false" />
</asp:Content>
