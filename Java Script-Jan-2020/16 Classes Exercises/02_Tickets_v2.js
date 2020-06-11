function tickets(ticketInfoArr, sortCriteria) {
    class Ticket{
        constructor(destination, price, status) {
            this.destination = destination
            this.price = +price
            this.status = status
        }
    }

    return ticketInfoArr
        .reduce((outputArr, currInput) => {
            let [destination, price, status] = currInput.split('|')
            let ticket = new Ticket(destination, price, status)
            outputArr.push(ticket)
            return outputArr
        }, [])
            .sort((a, b) => {
                if(typeof a[sortCriteria] === 'string'){
                    return a[sortCriteria].localeCompare(b[sortCriteria])
                } else {
                    return a[sortCriteria] - b[sortCriteria]
                }
            })
}

console.log(tickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
))