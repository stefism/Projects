function commandProcessor() {
    let text = ''
    
    function append(string) {
        text += string
    }

    function removeStart(number) {
        text = text.substring(number)
    }

    function removeEnd(number) {
        text = text.substring(0, text.length-number)
    }

    function print() {
        console.log(text)
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    }
}

let firstTest = commandProcessor()

firstTest.append('hello')
firstTest.append('again')
firstTest.removeStart(3)
firstTest.removeEnd(4)
firstTest.print()