class Kitchen{
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products){
        products.forEach(product => {
            let [productName, productQuantity, productPrice] = product.split(/\s+/);
            let price = +productPrice;
            if(this.budget >= price){
                if(this.productsInStock.hasOwnProperty(productName)){
                    this.productsInStock[productName] += +productQuantity;
                } else{
                    this.productsInStock[productName] = +productQuantity;
                }
                
                this.budget -= price;
                this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else{
                this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`)
            }
        });

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts, price){
        let currentNeededProducts = {};
        neededProducts.forEach(product =>{
            let [productName, productQuantity] = product.split(' ');
            currentNeededProducts[productName] = +productQuantity;
        })
        
        if(!this.menu.hasOwnProperty(meal)){
            this.menu[meal] = {
                neededProducts : currentNeededProducts,
                price : +price      
            };
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        } else{
            return `The ${meal} is already in our menu, try something different.`;
        }
        
    }

    showTheMenu(){
        let currentMenu = [];

        Object.keys(this.menu).forEach(meal =>{
            currentMenu.push(`${meal} - $ ${this.menu[meal].price}`);
        })

        if(currentMenu.length === 0){
            return `Our menu is not ready yet, please come later...`;
        }

        return currentMenu.join('\n') + '\n';
    }

    makeTheOrder(meal){
        if(!this.menu.hasOwnProperty(meal)){
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        } else{
            let areAllProductsInStock = true;
            
            Object.keys(this.menu[meal].neededProducts).forEach(product =>{
                let quantity = this.menu[meal].neededProducts[product];
                if(this.productsInStock.hasOwnProperty(product)){
                    if (this.productsInStock[product] < quantity) {
                        areAllProductsInStock = false;
                    }
                } else{
                    areAllProductsInStock = false;
                }
            });
            

            if(areAllProductsInStock){
                this.budget += this.menu[meal].price;
                Object.keys(this.menu[meal].neededProducts).forEach(product =>{
                    let quantity = this.menu[meal].neededProducts[product];
                    this.productsInStock[product] -= quantity;
                });
                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
            }else{
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }
    }
}

let testKitchen = new Kitchen(500);
testKitchen.addToMenu("yogurt", ["Banana 10", "Ice 5"], 8.50);
;