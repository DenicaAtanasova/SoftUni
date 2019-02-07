function solve() {

    let buttonElements = Array.from(document.querySelectorAll('button'));
    buttonElements.pop().addEventListener('click', buy);
    buttonElements.forEach(btn => btn.addEventListener('click', add));
    
    let textArea = document.querySelector('textArea');
    let products = [];

    function add(e){
        let productElements = e.target.parentElement;
        let name = productElements.querySelectorAll('p')[0].textContent;
        let price = +productElements.querySelectorAll('p')[1].textContent.split(' ').pop();
        let picture = productElements.querySelector('img').src;

        let currentProduct = {
            name : name,
            price : price,
            picture : picture
        }

        textArea.value += `Added ${currentProduct.name} for ${currentProduct.price.toFixed(2)} to the cart.\n`;  
        
        products.push(currentProduct);
    }

    function buy(){
        let totalPrice = products.reduce((a, b) => a + b.price, 0);
        let productsList = products.map(x => x.name)
                                   .filter((val, idx, arr) =>{
                                        if(arr.indexOf(val) === idx){
                                            return val;
                                        }
                                   })
                                   .join(', ');

        textArea.value += `You bought ${productsList} for ${totalPrice.toFixed(2)}.\n`;
    }
}