function trippleSum(a) {
 return function (b) {
    return function (c) {
        return a+b+c
    }
 }
}

let first = trippleSum(5)
let second = first(8)
let result = second(3)

console.log(result)