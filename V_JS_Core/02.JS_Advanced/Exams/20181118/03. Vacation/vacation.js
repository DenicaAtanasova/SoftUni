class Vacation{
    constructor(organizer, destination, budget){
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget
        this.kids = {}
    }

    get numberOfChildren() {
        let count = 0;
        for (let grade of Object.keys(this.kids)) {
            count += this.kids[grade].length;
        }

        return count;
    }

    registerChild(name, grade, budget){
        if(this.budget > budget){
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        let kidToAdd = `${name}-${budget}`;
        if(this.kids.hasOwnProperty(grade)){
            if(this.kids[grade].includes(kidToAdd)){
                return `${name} is already in the list for this ${this.destination} vacation.`;
            }
        } else{
            this.kids[grade] = [];
        }

        this.kids[grade].push(kidToAdd);
    }

    removeChild(name, grade){
        let index = -1;

        if(this.kids.hasOwnProperty(grade)){
            let kidsNamesInGrade = this.kids[grade].map(x => x.split('-')[0]);
           
            if(kidsNamesInGrade.includes(name)){
                index = kidsNamesInGrade.indexOf(name);
                this.kids[grade].splice(index, 1);
            }      
        } 
        if(index < 0){
            return `We couldn't find ${name} in ${grade} grade.`;
        } else {
            return grade;
        }
    }

    toString(){
        if(Object.keys(this.kids).length < 1){
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`
        }

        let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;
        Object.keys(this.kids).sort((a, b) => a - b)
                              .forEach(grade =>{
                                  result += `Grade: ${grade}\n`;
                                  let currentKidNumber = 1;
                                  this.kids[grade].forEach(kid =>{
                                      result += `${currentKidNumber++}. ${kid}\n`;
                                  })
                              })
        
        return result.trim();
    }
}