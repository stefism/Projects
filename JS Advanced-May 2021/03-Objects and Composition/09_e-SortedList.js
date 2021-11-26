function createSortedList(){
    let result = [];

    let command = {
        add: function(number){
            result.push(number);
            result.sort((a, b) => a - b);
            this.size = result.length;
        },
        remove: function(index){
            if (index >= 0 && index < result.length) {
                result.splice(index, 1);
                result.sort((a, b) => a - b);
                this.size = result.length;
            }  
        },
        get: function(index){
            if (index >= 0 && index < result.length) {
                return result[index];
            }   
        },

        size: 0
    }

    return command;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(8));
console.log(list.size);