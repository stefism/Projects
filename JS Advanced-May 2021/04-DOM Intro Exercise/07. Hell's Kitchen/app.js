function solve2_me() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = document.querySelector('#inputs textarea').value.split(',"');
      let inputJson = JSON.parse(input);

      let restaurants = {};

      inputJson.forEach(r => {
         let [restaurantName, workersAsString] = r.split(' - ');

         let workersAsArray = workersAsString.split(', ');

         if (!restaurants[restaurantName]) {
            restaurants[restaurantName] = [];
         }

         workersAsArray.forEach(worker => {
            let [name, salary] = worker.split(' ');
            restaurants[restaurantName].push({ name, salary });
         });
      });

      let highAverageSalaryRestaurant = '';
      let avgSallary = 0;

      for (const restaurant in restaurants) {
         let currAvgSallary = restaurants[restaurant].reduce((acc, x, i, arr) => {
            return acc + (Number(x.salary) / arr.length);
         }, 0);

         if (currAvgSallary > avgSallary) {
            avgSallary = currAvgSallary;
            highAverageSalaryRestaurant = restaurant;
         }
      }

      let bestRestaurantElement = document.querySelector('#bestRestaurant p');
      let workersElement = document.querySelector('#workers p');

      let bestSalary = 0;

      restaurants[highAverageSalaryRestaurant].forEach(r => {
         let currSalary = Number(r.salary);

         if (currSalary > bestSalary) {
            bestSalary = currSalary;
         }
      });

      let bestRestaurantResult = `Name: ${highAverageSalaryRestaurant} Average Salary: ${avgSallary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

      bestRestaurantElement.textContent = bestRestaurantResult;

      let workersResult = '';

      restaurants[highAverageSalaryRestaurant].sort((a, b) => {
         return Number(b.salary) - Number(a.salary);
      });

      restaurants[highAverageSalaryRestaurant].forEach(r => {
         workersResult += `Name: ${r.name} With Salary: ${r.salary} `;
      });

      workersElement.textContent = workersResult;
   }
}

function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   const input = document.querySelector('#inputs>textarea');
   const bestRestaurantP = document.querySelector('#bestRestaurant>p');
   const workersP = document.querySelector('#workers>p');

   function onClick() {
      const arr = JSON.parse(input.value);

      let restaurants = {};

      arr.forEach(line => {
         const tokens = line.split(' - ');
         const name = tokens[0];
         const workersArr = tokens[1].split(', ');
         let workers = [];

         for (let worker of workersArr) {
            const workerTokens = worker.split(' ');
            const salary = Number(workerTokens[1]);
            workers.push({ name: workerTokens[0], salary });
         }

         if (restaurants[name]) {
            workers = workers.concat(restaurants[name].workers);
         }

         workers.sort((worker1, worker2) => worker2.salary - worker1.salary);
         const bestSalary = workers[0].salary;
         const averageSalary = workers.reduce((sum, worker) => sum + worker.salary, 0) / workers.length;

         restaurants[name] = {
            workers,
            averageSalary,
            bestSalary
         }; //Когато напишем в обекта ново проперти е равно на нещо си, това проперти автоматично се добавя в обекта. Все едно правим push.
      });

      let bestRestaurantSalary = 0;
      let best = undefined;

      for (const name in restaurants) {
         if (restaurants[name].averageSalary >= bestRestaurantSalary) {
            best = {
               name,
               workers: restaurants[name].workers,
               bestSalary: restaurants[name].bestSalary,
               averageSalary: restaurants[name].averageSalary
            }

            bestRestaurantSalary = restaurants[name].averageSalary;
         }
      }

      bestRestaurantP.textContent = `Name: ${best.name} Average Salary: ${best.averageSalary.toFixed(2)} Best Salary: ${best.bestSalary.toFixed(2)}`;

      let workersResult = [];

      best.workers.forEach(worker => {
         workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
      });

      workersP.textContent = workersResult.join(' ');
   }
}