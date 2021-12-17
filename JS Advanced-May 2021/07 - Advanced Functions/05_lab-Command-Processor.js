function solution() {
    let string = '';

    return {
        append: function(input) {
            string += input;
        },
        print: function() {
            console.log(string);
        },
        removeStart: function(characterToRemove) {
            string = string.slice(characterToRemove);
        },
        removeEnd: function(characterToRemove) {
            string = string.slice(0, -characterToRemove);
        }
    }
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();