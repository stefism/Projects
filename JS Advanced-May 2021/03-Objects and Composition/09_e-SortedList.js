function createSortedList(){
    let result = [];

    let command = {
        add: function(number){
            result.push(number);
            result.sort((a, b) => a - b);
        },
        remove: function(index){
            result.splice(index, 1);
            result.sort((a, b) => a - b);
        },
        get: function(index){
            return result[index];
        },
        size: result.length
    }

    return command;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);