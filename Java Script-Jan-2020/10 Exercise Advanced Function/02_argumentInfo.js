function argumentInfo(...args) {
    let outputStr = ''
    let report = {}

    for (let i = 0; i < args.length; i++) {
        if(!report.hasOwnProperty(typeof args[i])){
            report[typeof args[i]] = 0
        }

        report[typeof args[i]]++

        console.log(`${typeof args[i]}: ${args[i]}`)
    }

    let reportAsArray = Object.entries(report)
        .sort((a, b) => b[1] - a[1])

    for (let i = 0; i < reportAsArray.length; i++) {
        console.log(`${reportAsArray[i][0]} = ${reportAsArray[i][1]}`)
    }
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); })