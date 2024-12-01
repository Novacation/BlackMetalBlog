/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./wwwroot/js/Auth/register.js":
/*!*************************************!*\
  !*** ./wwwroot/js/Auth/register.js ***!
  \*************************************/
/***/ (() => {

eval("function onSignup() {\n  var _checkSignupInputs = checkSignupInputs(),\n    status = _checkSignupInputs.status,\n    message = _checkSignupInputs.message;\n  if (status) {\n    var registerForm = document.getElementById(\"signupButton\").parentElement;\n    registerForm.submit();\n    return;\n  }\n  alert(message);\n}\nfunction checkSignupInputs() {\n  var returnObject = {\n    status: true,\n    message: \"\"\n  };\n  var usernameInputValue = document.getElementById(\"usernameInput\").value;\n  var passwordInputValue = document.getElementById(\"passwordInput\").value;\n  var passwordConfirmationInputValue = document.getElementById(\"confirmPasswordInput\").value;\n  if (!usernameInputValue.length) {\n    returnObject.status = false;\n    returnObject.message = \"Username should not be empty!\";\n    return returnObject;\n  }\n  if (!passwordInputValue.length || !passwordConfirmationInputValue.length) {\n    returnObject.status = false;\n    returnObject.message = \"Password inputs can't be empty!\";\n    return returnObject;\n  }\n  if (passwordInputValue !== passwordConfirmationInputValue) {\n    returnObject.status = false;\n    returnObject.message = \"Password inputs can't be different!\";\n    return returnObject;\n  }\n  return returnObject;\n}\nwindow.onSignup = onSignup;\n\n//# sourceURL=webpack://blackmetalblog/./wwwroot/js/Auth/register.js?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./wwwroot/js/Auth/register.js"]();
/******/ 	
/******/ })()
;