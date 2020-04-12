function solve() {
    let send = document.getElementById('send')
    let chatInput = document.getElementById('chat_input')
    let chatMessages = document.getElementById('chat_messages')

    send.addEventListener('click', sendTextToChat)

    function sendTextToChat() {
        let div = document.createElement('div')
        div.setAttribute('class', 'message my-message')
        div.innerText = chatInput.value
        //debugger
        chatMessages.appendChild(div)
        chatInput.value = ''
    }
}
