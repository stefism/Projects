function math (){
    return {
        add: (vec1 = [], vec2 = []) => {

            let output =[]

            let vec1Result = vec1[0] + vec2[0]
            let vec2Result = vec1[1] + vec2[1]

            output.push(vec1Result)
            output.push(vec2Result)

            return output
        },

        multiply: (vec1, number) => {
            let output =[]

            output.push(vec1[0] * number)
            output.push(vec1[1] * number)

            return output

        },

        length: () => {

        },

        dot: () => {

        },

        cross: () => {

        }
    }
}

let result = math()
console.log(result.add([1, 1], [1, 0]))
console.log(result.multiply([3.5, -2], 2))