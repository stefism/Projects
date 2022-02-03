let circle = {
    radius: 4
};

Object.defineProperty(circle, 'diameter', {
    get: function() {
        return this.radius * 2;
    },
    set: function(value) {
        this.radius = value / 2;
    }
});

console.log(circle.diameter, circle.radius);
circle.diameter = 10;
console.log(circle.diameter, circle.radius);