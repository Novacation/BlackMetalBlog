function onSignup() {
    const {status, message} = checkSignupInputs();

    if (status) {
        const registerForm = document.getElementById("signupButton").parentElement;

        registerForm.submit()
        return;
    }

    alert(message);
}

function checkSignupInputs() {

    const returnObject = {
        status: true,
        message: ""
    }

    const usernameInputValue = document.getElementById("usernameInput").value;

    const passwordInputValue = document.getElementById("passwordInput").value;

    const passwordConfirmationInputValue = document.getElementById(
        "confirmPasswordInput"
    ).value;

    if (!usernameInputValue.length) {
        returnObject.status = false;
        returnObject.message = "Username should not be empty!";
        return returnObject
    }

    if (!passwordInputValue.length || !passwordConfirmationInputValue.length) {

        returnObject.status = false;
        returnObject.message = "Password inputs can't be empty!";

        return returnObject
    }

    if (passwordInputValue !== passwordConfirmationInputValue) {

        returnObject.status = false;
        returnObject.message = "Password inputs can't be different!"
        return returnObject
    }

    return returnObject
}


window.onSignup = onSignup;
