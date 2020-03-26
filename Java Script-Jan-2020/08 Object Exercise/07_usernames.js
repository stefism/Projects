function usernames(input) {
    input.sort((a, b) => a.length - b.length || a.localeCompare(b))

    return input.join('\n')
}

console.log(usernames(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
))