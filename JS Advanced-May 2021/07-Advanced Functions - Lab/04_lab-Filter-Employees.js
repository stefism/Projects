function filterEmployes(inputEmployees, inputCriteria) {
    let employees = JSON.parse(inputEmployees);
    let [criteria, value] = inputCriteria.split('-');

    let filteredEmployees = [];

    if(value == 'all') {
        filteredEmployees = employees;
    } else {
        filteredEmployees = employees.filter(e => e[criteria] == value);
    }

    let result = filteredEmployees.reduce((acc, curr, index) => {
        let currOutput = `${index}. ${curr.first_name} ${curr.last_name} - ${curr.email}`;
        acc.push(currOutput);
        return acc;
    }, []);

    console.log(result.join('\n'));
}

filterEmployes(`[{
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
'gender-Female');