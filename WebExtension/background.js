
chrome.runtime.onMessage.addListener(
    function(request, sender, sendResponse) {
        if (request.type === 'auth') {
            fetch(`https://localhost:5001/api/authenticate/auth?` + new URLSearchParams({pinCode:request.message}), {mode: 'cors', method: 'GET'
            }).then(function (response) {
                if (response.status === 200) {
                    return response.json();
                } else {
                    console.log("failed");
                    return Promise.reject(response);
                }
            }).then(function (data) {
                chrome.storage.local.set({jwt:data});
                sendResponse({status:'success'});
            }).catch(function (err) {
                console.warn('Something went wrong.', err);
                sendResponse({status:'error'});
            });
        }
        if(request.type === 'fetchData'){
            chrome.tabs.query({active: true, lastFocusedWindow: true}, tabs => {
                fetch(`https://localhost:5001/api/credentials/websiteCredentials?` +  new URLSearchParams({website:tabs[0].url}), {mode: 'cors',
                headers: {
                    'Authorization':`Bearer ${chrome.storage.local.get('jwt')}`,
                    'Content-type':'application/json'
                }
                }).then(function (response) {
                    if (response.status === 200) {
                        return response.json();
                        
                    } else {
                        return Promise.reject(response);
                    }
                }).then(function (data) {
                    chrome.storage.local.set({"credentials": data});
                    sendResponse({status:'success'});

                }).catch(function (err) {
                    console.warn('Something went wrong.', err);
                    sendResponse({status:'error'});
                });
            });
        }
        if (request.type === "executeCode") {
            // The content script has asked for the tab.
            var selected = request.selected;
            chrome.storage.local.get('credentials', (data) => {
                chrome.tabs.query({active: true, lastFocusedWindow: true}, tabs => {
                    for (let i = 0; i < data.credentials.length; i++) {
                        if(selected == data.credentials[i].username){
                                console.log('executing');
                                chrome.storage.local.set({"username": data.credentials[i].username});
                                chrome.storage.local.set({"password": data.credentials[i].password})
                                chrome.scripting.executeScript({
                                    target: {tabId: tabs[0].id, allFrames: true},
                                    files: ['populate.js'],
                                   
                        });
                               
                        }
                       
                    }
                 
            });
           
        });
        }
        return true;
});
