function wordsUppercase(string) {
    return string.match(/\w+/gim)
        .map(x => x.toUpperCase())
        .join(', ')
}

console.log(wordsUppercase('Hi, how are you?'))