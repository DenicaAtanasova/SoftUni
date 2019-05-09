class Hotel{
    constructor(name, capacity){
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;
        this._availableRooms={
            single: Math.floor(this.capacity * 0.5),
            double: Math.floor(this.capacity * 0.3),
            maisonette: Math.floor(this.capacity * 0.2)
        }
    }

    get roomsPricing() {
        return {
            single:50,
            double:90,
            maisonette:135
        };
    }

    get servicesPricing(){
        return {
            food:10,
            drink:15,
            housekeeping:25
        };
    } 

    rentARoom(clientName, roomType, nights){
        if(this._availableRooms[roomType] > 0){
            let reservation = {
                clientName,
                roomType,
                nights,
                roomNumber: this.currentBookingNumber
            };
            this.currentBookingNumber++;
            this.capacity--;
            this._availableRooms[roomType]--;
            this.bookings.push(reservation);

            return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${this.currentBookingNumber - 1}.`;           
        } else{
            let result =  [`No ${roomType} rooms available!`];

            Object.keys(this._availableRooms).map(room =>{
                if(this._availableRooms[room]>0){
                    result.push(`Available ${room} rooms:${this._availableRooms[room]}.`);      
                }    
            })

            return result.join(' ');
        }
    }

    roomService(currentBookingNumber, serviceType){

        let isInvalidBookingNumber = true;
        for(let entry of this.bookings){
            if(entry.roomNumber === currentBookingNumber){
                if(!this.servicesPricing.hasOwnProperty(serviceType)){
                    return `We do not offer ${serviceType} service.`;
                }

                if(entry.services === undefined){ 
                    entry.services = [];
                }

                entry.services.push(serviceType);
                isInvalidBookingNumber = false;
                return `Mr./Mrs. ${entry.clientName}, Your order for ${serviceType} service has been successful.`
            }         
        }  
        
        if(isInvalidBookingNumber){
            return `The booking ${currentBookingNumber} is invalid.`;
        }
    }

    checkOut(currentBookingNumber){
        let isInvalidBookingNumber = true;
        let totalServiceMoney = 0;
        let totalMoney = 0;

        let clientName;
        for(let entry of this.bookings){
            if(entry.roomNumber === currentBookingNumber){
                clientName = entry.clientName;

                isInvalidBookingNumber = false;
                if(entry.services !== undefined){ 
                    for(let service of entry.services){
                        totalServiceMoney += this.servicesPricing[service];
                    } 
                }
                totalMoney = entry.nights * this.roomsPricing[entry.roomType];
                this.capacity++;
                this._availableRooms[entry.roomType]++;
                this.bookings.splice(entry.roomNumber -1, 1);
            }  
        }

        if (isInvalidBookingNumber) {
            return `The booking ${currentBookingNumber} is invalid.`;
        }
        if (totalServiceMoney > 0) {
            return `We hope you enjoyed your time here, Mr./Mrs. ${clientName}. The total amount of money you have to pay is ${totalMoney + totalServiceMoney} BGN. You have used additional room services, costing ${totalServiceMoney} BGN.`;
        } else{
            return `We hope you enjoyed your time here, Mr./Mrs. ${clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`;
        }
    }

    report(){
        let result = `${this.name.toUpperCase()} DATABASE:\n` +
        '-'.repeat(20) + '\n';
        this.bookings.forEach((b, idx) => {
            if(idx != 0){
                result += '-'.repeat(10) + '\n';
            }
            result += `bookingNumber - ${b.roomNumber}\n` +        
                `clientName - ${b.clientName}\n` +        
                `roomType - ${b.roomType}\n` +            
                `nights - ${b.nights}\n`;
                
                if(b.services !== undefined){
                    result += `services: ${b.services.join(', ')}`;
                }
        });

        return result;
    }
}

let hotel = new Hotel('HotUni', 10);
hotel.rentARoom('Peter', 'single', 4);
hotel.rentARoom('Robert', 'double', 4);
hotel.rentARoom('Geroge', 'maisonette', 6);

console.log(hotel.roomService(3, 'housekeeping'));
console.log(hotel.roomService(3, 'drink'));
console.log(hotel.roomService(2, 'room'));
console.log(hotel.report());