function tickets(ticketsArray, sortingCriteria) {
    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    ticketsArray.forEach(ticket => {
        let [destination, price, status] = ticket.split('|');
        tickets.push(new Ticket(destination, price, status));
    });

    if(sortingCriteria == 'price'){
        tickets.sort((a, b) => a[sortingCriteria] - b[sortingCriteria]);
    } else {
        tickets.sort((a, b) => a[sortingCriteria].localeCompare(b[sortingCriteria]));
    }
    
    return tickets;
}

function tickets2(ticketsArray, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    const sortMapper = {
        'destination': (a, b) => a.destination.localeCompare(b.destination),
        'price': (a, b) => a.price - b.price,
        'status': (a, b) => a.status.localeCompare(b.status)
    }

    function splitLine(line) {
        return line.split('|');
    }

    function convertToTicket([destination, price, status]) {
        return new Ticket(destination, Number(price), status);
    }

    return ticketsArray
        .map(splitLine) // [[destination, price, status], ...]
        .map(convertToTicket)
        .sort(sortMapper[sortingCriteria]);
}

console.log(tickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price'
));