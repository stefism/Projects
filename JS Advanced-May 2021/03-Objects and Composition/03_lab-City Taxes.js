function cityTaxes(city, population, treasury){
    return {
        city: city,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes: function(){
            this.treasury = this.treasury + (this.population * this.taxRate)
        },
        applyGrowth: function(percentage){
            let percentageValue = (percentage / 100) * this.population;
            this.population += percentageValue;
        },
        applyRecession: function(percentage){
            let percentageValue = (percentage / 100) * this.treasury;
            this.treasury -= percentageValue;
        }
    }
}

const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);