function filterEmployees(data, criteria) {
    let parsedData = JSON.parse(data)
    let [criteriaKey, criteriaValue] = criteria.split('-')

    let outputData = []
    let objId = 0

    for(let obj of parsedData){
        if(obj[criteriaKey] === criteriaValue){
            let person = {
                id: objId++,
                fullName: obj.first_name + ' ' + obj.last_name,
                email: obj.email
            }

            outputData.push(person)
        }
    }

    let outputString = ''

    for(let person of outputData){
        outputString += `${person.id}. ${person.fullName} - ${person.email}\n`
    }

    return outputString.trim()
}

console.log(filterEmployees(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female'
))