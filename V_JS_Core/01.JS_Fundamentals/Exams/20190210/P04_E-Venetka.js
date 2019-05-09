function solve(input) {
  let towns = {};

  input.forEach(obj =>{
      if(!towns.hasOwnProperty(obj.town)) {
          towns[obj.town] = {
              profit : 0,
              vignetteSold : 0
          };
      }
      if(!towns[obj.town].hasOwnProperty(obj.model)){
          towns[obj.town][obj.model] = {
              regNumbers : [obj.regNumber],
              price : +obj.price
          };

      } else {
          towns[obj.town][obj.model].regNumbers.push(obj.regNumber);
          towns[obj.town][obj.model].price += +obj.price;
      }

      towns[obj.town].profit += +obj.price;
      towns[obj.town].vignetteSold ++;
  });

  let mostProfitableTown = Object.keys(towns).sort((a, b) => a.localeCompare(b))
      .sort((a, b) => towns[b].vignetteSold - towns[a].vignetteSold)
      .sort((a, b) => towns[b].profit - towns[a].profit)
      .map(a => a)[0];

  console.log(`${mostProfitableTown} is most profitable - ${towns[mostProfitableTown].profit} BGN`);

  let mostDrivenModel = Object.keys(towns[mostProfitableTown])
      .filter(a => a !== 'profit' && a !== 'vignetteSold')
      .sort((a,b) => towns[mostProfitableTown][b].price - towns[mostProfitableTown][a].price)
      .sort((a,b) => towns[mostProfitableTown][b].regNumbers.length - towns[mostProfitableTown][a].regNumbers.length)[0];

  console.log(`Most driven model: ${mostDrivenModel}`);

  Object.keys(towns).sort((a,b) => a.localeCompare(b))
      .forEach(town =>{
      if(towns[town].hasOwnProperty(mostDrivenModel)){
          let sortedRegNumbers = towns[town][mostDrivenModel].regNumbers.sort((a, b) => a.localeCompare(b)).join(', ');
          let output = `${town}: ${sortedRegNumbers}`;
          console.log(output);
      }
  })
}

solve([ { 'model': 'BMW', 'regNumber': 'B1234SM', 'town': 'Varna', 'price': '2'},
  { 'model': 'BMW', 'regNumber': 'C5959', 'town': 'Sofia', 'price': '8'},
  { 'model': 'BMW', 'regNumber': 'C4959CZ', 'town': 'Sofia', 'price': '8'},
  { 'model': 'BMW', 'regNumber': 'SJSCA', 'town': 'Sofia', 'price': '8'},
  { 'model': 'BMW', 'regNumber': 'SJSCA', 'town': 'Sofia', 'price': '8'},
  { 'model': 'Tesla', 'regNumber': 'NIKOLA', 'town': 'Burgas', 'price': '9'},
  { 'model': 'BMW', 'regNumber': 'A3423SM', 'town': 'Varna', 'price': '3'},
  { 'model': 'Lada', 'regNumber': 'SJSCA', 'town': 'Sofia', 'price': '2'} ]
);