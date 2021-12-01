function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
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
            restaurants[restaurantName].push({name, salary});
         });  
      });

      let highAverageSalaryRestaurant = '';
      let avgSallary = 0;

      for (const restaurant in restaurants) {
         let currAvgSallary = restaurants[restaurant].reduce((acc, x, i, arr) => {
            return acc + (Number(x.salary) / arr.length);
         }, 0)

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