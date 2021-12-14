function encodeAndDecodeMessages() {
    let buttons = document.querySelectorAll('#main div button');
    let textAreas = document.querySelectorAll('#main div textarea');

    let encodeButton = buttons[0];
    let decodeButton = buttons[1];

    let sendTextArea = textAreas[0];
    let receiveTextArea = textAreas[1];

    encodeButton.addEventListener('click', () => {
        receiveTextArea.textContent = processingMessage(sendTextArea.value, 'encode');
        sendTextArea.value = '';
    });

    decodeButton.addEventListener('click', () => {
        receiveTextArea.textContent = processingMessage(receiveTextArea.textContent, 'decode');
    });

    function processingMessage(message, process) {
        let newMessage = '';

        for (const character of message) {
            let index = 0;
            let asciiCode = character.charCodeAt(index);
            process == 'encode' ? asciiCode++ : asciiCode--;

            newMessage += String.fromCharCode(asciiCode);       
        }

        return newMessage;
    }
}