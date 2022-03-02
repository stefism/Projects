let sendBtn = document.getElementById('submit');
sendBtn.addEventListener('click', sendMessage);

let refreshBtn = document.getElementById('refresh');
refreshBtn.addEventListener('click', refreshData);

let messagesElement = document.getElementById('messages');

let nameElement = document.querySelector('[name="author"]');
let messageElement = document.querySelector('[name="content"]');

let url = 'http://localhost:3030/jsonstore/messenger';

async function sendMessage() {
    let author = nameElement.value;
    let content = messageElement.value;
    
    try {
        let responce = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ author, content })
        });

        if(responce.status != 200) {
            const error = await responce.json();
            throw new Error(`Error: ${error.message}`);
        }

        await responce.json();

        messageElement.value = '';
    } catch (error) {
        alert(error.message);
    }
    
}

async function refreshData() {
    try {
        let responce = await fetch(url);

        if(responce.status != 200) {
            const error = await responce.json();
            throw new Error(`Error: ${error.message}`);
        }

        let result = await responce.json();

        // let allMessages = '';

        // Object.values(result).forEach(m => {
        //     allMessages += m.author + '\n';
        //     allMessages += m.content + '\n';
        // });

        // messagesElement.value = allMessages.trim();

        console.log(Object.values(result));
        //0: {author: 'Spami', content: 'Hello, are you there?'}
        //1: {author: 'Garry', content: 'Yep, whats up :?'} 
        //2: ect ...

        console.log(Object.values(result).map(m => `${m.author}: ${m.content}`));
        //0: "Spami: Hello, are you there?"
        //1: "Garry: Yep, whats up :?"
        //2: ect ...
        
        messagesElement.value = Object.values(result).map(m => `${m.author}: ${m.content}`).join('\n'); //До join, мапинг операцията трансформира result от масив от обекти в масив от стрингове и после с join ги правим на един общ стринг по нов ред и го връщаме като един стринг.
    } catch (error) {
        alert(error.message);
    }
}