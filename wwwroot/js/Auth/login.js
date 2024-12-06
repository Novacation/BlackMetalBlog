const millisecondsToSeconds = (seconds) => seconds * 1000;


window.onload = function () {
    let errorMessageDiv = document.getElementById("invalidCredentialsError");
    if (errorMessageDiv) {
        setTimeout(function () {
            errorMessageDiv.style.display = "none";
        }, millisecondsToSeconds(3)); // 3000 milliseconds = 3 seconds
    }
};
