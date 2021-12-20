function listProcessor(input) {
    let output = [];

    input.forEach(element => {
        let[command, string] = element.split(' ');

        switch (command) {
            case 'add':
                output.push(string);
                break;

            case 'remove':
                output = output.filter(currString => currString != string);
                break;
        
            case 'print':
                console.log(output.join(','));
                break;
        }
    });
}

listProcessor(['add pesho', 'add george', 'add peter', 'remove peter','print']);