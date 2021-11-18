function listOfNames(input){
    let sortedInput = input.sort((a, b) => a.localeCompare(b));
    
    sortedInput.map((c, i) => {
        console.log(`${i + 1}.${c}`);
    });
}

listOfNames(["John", "Bob", "Christina", "Ema"]);