var textInputs = document.querySelectorAll('input[type="text"]');
var emailInputs = document.querySelectorAll('input[type="email"]');
var passwordInputs = document.querySelectorAll('input[type="password"]');


chrome.storage.local.get('username', (data) => {

    if(textInputs != null){
        for(i = 0; i < textInputs.length; i++){
            textInputs[i].value = data.username;
        }
    }
    if(emailInputs != null){
        for(i = 0; i < emailInputs.length; i++){
            emailInputs[i].value = data.username;
        }
    }
   
});
chrome.storage.local.get('password', (data) => {
    if(passwordInputs != null){
        for(i = 0; i < passwordInputs.length; i++){
            passwordInputs[i].value = data.password;
        }
    }

});
