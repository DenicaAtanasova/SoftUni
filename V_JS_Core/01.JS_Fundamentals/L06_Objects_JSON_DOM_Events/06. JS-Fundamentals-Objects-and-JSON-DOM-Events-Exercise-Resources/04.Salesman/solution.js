function solve() {
  //let loadInput =JSON.parse('[{"name": "tomatoes", "quantity": 20, "price": 0.50}, {"name": "potatoes", "quantity": 10, "price": 0.60}]');
  //let buyInput =JSON.parse('{"name": "tomatoes", "quantity": 20}');
  let textAreaElements = document.querySelectorAll('textarea');
  let buttonElements = document.querySelectorAll('button');

  let log = textAreaElements[2];

  let storage = {__profit__: 0};

  buttonElements[0].addEventListener('click', () => {
    let loadInput = JSON.parse(textAreaElements[0].value);
    loadInput.forEach(product => {
      if(!storage.hasOwnProperty(product.name)){
        storage[product.name] = {
          quantity : product.quantity,
          price : product.price
        }
      } else{
        storage[product.name].quantity += product.quantity;
        storage[product.name].price = product.price;
      } 
      log.value += `Successfully added ${product.quantity} ${product.name}. Price: ${product.price}\n`;
    });
  });

  buttonElements[1].addEventListener('click', () => {
    let product = JSON.parse(textAreaElements[1].value);

    if(storage.hasOwnProperty(product.name) && storage[product.name].quantity >= product.quantity){
      storage[product.name].quantity -= product.quantity;

      let orderMoney = storage[product.name].price * product.quantity;
      storage.__profit__ += orderMoney;

      log.value += `${product.quantity} ${product.name} sold for ${orderMoney}.\n`;
    } else {
      log.value += 'Cannot complete order.\n';
    }
  });

  buttonElements[2].addEventListener('click', () => {
    log.value += `Profit: ${storage.__profit__.toFixed(2)}.\n`

    Array.from(buttonElements).forEach(btn => btn.disabled = true)
  });
}