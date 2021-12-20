function argumentInfo(...args){
    let resultCounts = {};
    let output = '';

    args.forEach(element => {
        let type = typeof(element);

        if(!resultCounts[type]) {
            resultCounts[type] = 0;
        }
        
        resultCounts[type] ++;

        output += `${type}: ${element}\n`;
    });

    for (const type in resultCounts) {
        output += `${type} = ${resultCounts[type]}\n`
    }

    console.log(output);
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); });