class Tickets{
    outputArray = []

    constructor(ticketsArray, sortCriteria) {
        this.sortCriteria = sortCriteria
debugger
        for (let i = 0; i < ticketsArray.length; i++) {
            [this.destination, this.price, this.status] = ticketsArray[i].split('|')

            let currObj = {
                Ticket: {
                    destination: this.destination,
                    price: this.price,
                    status: this.status
                }
            }

            this.outputArray.push(currObj)
        }
    }

    returnTickets(){
        return this.outputArray
    }
}

let ticket1 = new Tickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
)