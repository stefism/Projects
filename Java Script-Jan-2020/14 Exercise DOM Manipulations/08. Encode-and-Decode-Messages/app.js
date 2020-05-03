function encodeAndDecodeMessages() {
    let encodeBtn = document
        .getElementsByTagName('button')[0]

    let decodeBtn = document
        .getElementsByTagName('button')[1]

    let encodeArea = document
        .getElementsByTagName('textarea')[0]

    let decodeArea = document
        .getElementsByTagName('textarea')[1]

    encodeBtn.addEventListener('click', encode)
    decodeBtn.addEventListener('click', decode)

    function encode() {
        let text = encodeArea.value
        text = encoderDecoder(text, 'enc')
        decodeArea.value = text
        encodeArea.value = ''
    }

    function decode() {
        let text = decodeArea.value
        text = encoderDecoder(text, 'dec')
        decodeArea.value = text
    }

    function encoderDecoder(text, operation) {
        let output = ''

        for (let i = 0; i < text.length; i++) {
            let currChar = ''

            operation === 'enc'
                ? currChar = text[i].charCodeAt(0) + 1
                : currChar = text[i].charCodeAt(0) - 1

            let currCharDecoded = String.fromCharCode(currChar)
            output += currCharDecoded
        }

        return output
    }
}