function storeTickets(ticketsArgs, sortingCriteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = ticketsArgs.map(x =>{
        let args = x.split('|');
        return new Ticket(args[0], parseFloat(args[1]), args[2]);
    })
    
    function sortByCriteria(a, b){
        if(a[sortingCriteria] > b[sortingCriteria]){
            return 1;
        } else if(a[sortingCriteria] < b[sortingCriteria]){
            return -1;
        }
        return 0;
    }

    return tickets.sort(sortByCriteria);
}

storeTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
);