class Company {
    constructor() {

    }

    departments = {};

    addEmployee(name, salary, position, department) {
        if(name == '' || name == undefined || name == null) {
            throw Error('Invalid input!');
        }

        if(salary < 0) {
            throw Error('Invalid input!');
        }

        if(!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push({name, salary, position});

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let keys = Object.keys(this.departments);
        let bestAvgSalary = 0;
        let bestDepartment = '';

        for(const department of keys) {
            let currAvgSalary = this.departments[department].reduce((acc, curr) => acc + curr.salary, 0) / this.departments[department].length;

            if(currAvgSalary > bestAvgSalary) {
                bestAvgSalary = currAvgSalary;
                bestDepartment = department;
            }
        }

        let output = `Best Department is: ${bestDepartment}\n`;
        output += `Average salary: ${bestAvgSalary.toFixed(2)}\n`;

        let employeesArray = Object.values(this.departments[bestDepartment]);
        employeesArray.sort((a, b) => {
                if(b.salary - a.salary == 0) {
                    return a.name.localeCompare(b.name);
                } else {
                    return b.salary - a.salary;
                }   
        });

        employeesArray.forEach(e => output += `${e.name} ${e.salary} ${e.position}\n`);
    
        output = output.substring(0, output.length - 1);

        return output;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());