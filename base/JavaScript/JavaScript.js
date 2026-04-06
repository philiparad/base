// Validation functions

function isAlphaNumeric(str) {
    for (let i = 0; i < str.length; i++) {
        let code = str.charCodeAt(i);
        if (!(code >= 48 && code <= 57) &&  // 0–9
            !(code >= 65 && code <= 90) &&  // A–Z
            !(code >= 97 && code <= 122)) { // a–z
            return false;
        }
    }
    return str.length > 0;
}

function isValidPassword(pwd) {
    if (pwd.length < 6 || pwd.length > 12) return false;
    let hasUpper = false, hasNumber = false, hasSmall = false;

    for (let i = 0; i < pwd.length; i++) {
        const ch = pwd[i];
        if (ch >= 'A' && ch <= 'Z') hasUpper = true;
        if (ch >= 'a' && ch <= 'z') hasSmall = true;
        if (ch >= '0' && ch <= '9') hasNumber = true;
    }
    return hasUpper && hasNumber && hasSmall;
}

function isLettersOnly(str) {
    for (let i = 0; i < str.length; i++) {
        const code = str.charCodeAt(i);
        if (!((code >= 65 && code <= 90) || (code >= 97 && code <= 122) || (code >= 1488 && code <= 1514))) {
            return false;
        }
    }
    return str.length > 0;
}

function isValidEmail(email) {
    if (email.includes(" ") || !email.includes("@")) return false;
    const parts = email.split("@");
    if (parts.length !== 2) return false;
    const [local, domain] = parts;
    if (!local || !domain || !domain.includes(".")) return false;
    return true;
}

function isTenDigitNumber(str) {
    if (str.length !== 10) return false;
    for (let i = 0; i < str.length; i++) {
        if (str[i] < '0' || str[i] > '9') return false;
    }
    return true;
}

// Main validation function

function validateForm() {
    let isValid = true;

    const fields = [
        "username", "password", "passwordVerification",
        "firstName", "lastName", "gender", "email", "phone",
        "country", "city", "question1", "answer1", "question2", "answer2"
    ];
    fields.forEach(field => {
        let errorSpan = document.getElementById(field + "Error");
        if (errorSpan) errorSpan.innerText = "";
    });

    let username = document.getElementById("ContentPlaceHolder1_username").value;
    if (!isAlphaNumeric(username)) {
        document.getElementById("usernameError").innerText = "Only letters and numbers.";
        isValid = false;
    }

    let password = document.getElementById("ContentPlaceHolder1_password").value;
    if (!isValidPassword(password)) {
        document.getElementById("passwordError").innerText = "6-12 chars, 1 uppercase, 1 lowercase, 1 number.";
        isValid = false;
    }

    let passwordVerification = document.getElementById("ContentPlaceHolder1_passwordVerification").value;
    if (password !== passwordVerification) {
        document.getElementById("passwordVerificationError").innerText = "Passwords do not match.";
        isValid = false;
    }

    let firstName = document.getElementById("ContentPlaceHolder1_firstName").value;
    if (!isLettersOnly(firstName)) {
        document.getElementById("firstNameError").innerText = "Only letters (Eng/Heb).";
        isValid = false;
    }

    let lastName = document.getElementById("ContentPlaceHolder1_lastName").value;
    if (!isLettersOnly(lastName)) {
        document.getElementById("lastNameError").innerText = "Only letters (Eng/Heb).";
        isValid = false;
    }

    let genderSelected = document.querySelector("input[name='ctl00$ContentPlaceHolder1$userGender']:checked");
    if (!genderSelected) {
        document.getElementById("genderError").innerText = "Please select gender.";
        isValid = false;
    }

    let email = document.getElementById("ContentPlaceHolder1_email").value;
    if (!isValidEmail(email)) {
        document.getElementById("emailError").innerText = "Invalid email.";
        isValid = false;
    }

    let phone = document.getElementById("ContentPlaceHolder1_phone").value;
    if (!isTenDigitNumber(phone)) {
        document.getElementById("phoneError").innerText = "Must be 10 digits.";
        isValid = false;
    }

    let country = document.getElementById("ContentPlaceHolder1_country").value;
    if (!country) {
        document.getElementById("countryError").innerText = "Please select country.";
        isValid = false;
    }

    let city = document.getElementById("ContentPlaceHolder1_city").value;
    if (!city.trim()) {
        document.getElementById("cityError").innerText = "Please enter city.";
        isValid = false;
    }

    let question1 = document.getElementById("ContentPlaceHolder1_question1").value;
    let answer1 = document.getElementById("ContentPlaceHolder1_answer1").value;
    if (!question1 || answer1.trim() === "") {
        document.getElementById("question1Error").innerText = "Select question and provide answer.";
        document.getElementById("answer1Error").innerText = "Answer required.";
        isValid = false;
    }

    let question2 = document.getElementById("ContentPlaceHolder1_question2").value;
    let answer2 = document.getElementById("ContentPlaceHolder1_answer2").value;
    if (!question2 || answer2.trim() === "") {
        document.getElementById("question2Error").innerText = "Select question and provide answer.";
        document.getElementById("answer2Error").innerText = "Answer required.";
        isValid = false;
    }

    return isValid;
}
