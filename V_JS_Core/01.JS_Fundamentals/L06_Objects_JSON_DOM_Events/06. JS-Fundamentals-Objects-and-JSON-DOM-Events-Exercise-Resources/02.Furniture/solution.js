function solve() {
  //let inputTextArea = JSON.parse('[{"name": "Sofa", "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg", "price": 150, "decFactor": 1.2}]');

  let textAreaElements = document.querySelectorAll('#exercise textarea');
  let furniture = [];
   
  Array.from(document.querySelectorAll('#exercise button')).forEach(btn =>{
    btn.addEventListener('click', eval(btn.innerHTML.toLocaleLowerCase()))
  });

  function generate(){
    let inputTextArea = JSON.parse(textAreaElements[0].value);

    for(let obj of inputTextArea){
      addFurniture(obj);   
      furniture.push(obj);  
    } 
  }

  function buy(){
    let indexes = [];
    Array.from(document.querySelectorAll('input[type="checkbox"]')).forEach((el, idx) => {
      if(el.checked){
        indexes.push(idx); 
      }
    });

    let boughtFurniture = furniture.filter((el, idx) =>{
      if(indexes.includes(idx)){
        return el;
      }
    });

    let totalPrice = boughtFurniture.reduce((a, b) => a + b.price, 0).toFixed(2);
    let avarageDF = boughtFurniture.reduce((a, b) => a + b.decFactor, 0) / boughtFurniture.length;
    let furnitureNames = boughtFurniture.map(x => x.name).join(', ');

    textAreaElements[1].value += `Bought furniture: ${furnitureNames}\n`;
    textAreaElements[1].value += `Total price: ${totalPrice}\n`;
    textAreaElements[1].value += `Average decoration factor: ${avarageDF}`;
  }
  
  let furnitureListElement = document.getElementById('furniture-list');
  let divElement = document.createElement('div');

  function addFurniture(obj){
    let furnitureDiv = divElement.cloneNode(); 
    furnitureDiv.classList.add('furniture');
    let img = document.createElement('img');
    img.setAttribute('src', obj.img);

    let checkBox = document.createElement('input');
    checkBox.setAttribute('type', 'checkbox')

    furnitureDiv.appendChild(cloneParagraph(`Name: ${obj.name}`));
    furnitureDiv.appendChild(img);
    furnitureDiv.appendChild(cloneParagraph(`Price: ${obj.price}`));
    furnitureDiv.appendChild(cloneParagraph(`Decoration factor: ${obj.decFactor}`));
    furnitureDiv.appendChild(checkBox);

    furnitureListElement.appendChild(furnitureDiv);
  }

  let pElement = document.createElement('p');
  function cloneParagraph(text){
    let clonedElement = pElement.cloneNode();
    clonedElement.textContent = text;
    return clonedElement;
  }
}