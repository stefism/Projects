function fibonacci(){
    let first = 0;
    let second = 1;

    let i = 0;

    return function() {
        if(i == 0) {
            i++; 
            return 1;
        }

        let result = first + second;
        first = second;
        second = result;

        return result;
    }
}
function fibonacci2(){
    let first = 0;
    let second = 1;

    return function() {
        let result = first + second;
        first = second;
        second = result;

        return first; // Това е за да върне първия път два пъти единица.
    }
}

let fib = fibonacci2();

console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13