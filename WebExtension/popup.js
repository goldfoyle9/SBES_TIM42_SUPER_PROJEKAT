const pinCode = document.getElementById('pinCode');
const auth = document.getElementById('authButton');
const load = document.getElementById('loadButton');
const fill = document.getElementById('fillButton');
const credentials = document.getElementById('credentials');

auth.addEventListener('click', () => {
    chrome.runtime.sendMessage({type: "auth", message: pinCode.value}, (response) =>{
    if(response.status === 'success'){
        pinCode.hidden = true;
        auth.hidden = true;
        load.hidden = false;
    }
    else{
        console.log("ne radi??");
    }
  });
});

load.addEventListener('click', () =>{

    chrome.runtime.sendMessage({type: "fetchData"}, (response) =>{
        if(response.status === 'success'){
           populateList();
        }
        else{
            console.log("ne radi??");
        }
      });
});

function populateList(){
    console.log(document.body);
    chrome.storage.local.get('credentials', (data) => {
        for (let i = 0; i < data.credentials.length; i++) {
            console.log(data.credentials[i]);
            credentials.add(new Option(data.credentials[i].username, data.credentials[i].username));
        }
      });
    load.hidden = true;
    fill.hidden = false;
    credentials.hidden = false;
}

fill.addEventListener('click', () =>{
    var select = document.getElementById("credentials");
    var selected = select.options[select.selectedIndex].value;
    var data = chrome.storage.local.get('credentials').credentials;
    console.log(selected);
    chrome.runtime.sendMessage({ type: 'executeCode',  selected:selected, credentials:data });
});

