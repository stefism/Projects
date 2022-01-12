class List {
    constructor() {
        this.size = this.elements.length;
    }

    updateSize = () => this.size = this.elements.length;

    elements = [];

    add(number) {
        this.elements.push(number);
        this.updateSize();
        this.sort(this.elements);
    }

    remove(index) {
        if(index >= 0 && index < this.elements.length){
            this.elements.splice(index, 1);
            this.updateSize();
            this.sort(this.elements);
        }
    }

    get(index) {
        if(index >= 0 && index < this.elements.length){
            let result = this.elements[index];
            return result;
        }
    }

    sort(array) {
        array.sort((a, b) => a - b);
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);
list.remove(1);
console.log(list.size);