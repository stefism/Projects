function solution(){
    let number = 1
    return function (a, b) {
        console.log(a+b - number++)
    }
}

let manager = solution()
manager(3, 5)
manager(4, 4)