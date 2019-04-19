//Dashboard
handlers.getDashboard = function(ctx){                 
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    let filter = ctx.params.category.slice(1, -1);
    
    petService.getOtherPets(filter)
        .then(function(res) {
            ctx.pets = res;               
            return ctx.loadPartials({
                header: '/views/common/header.hbs',
                footer: '/views/common/footer.hbs',
                otherPet: '/views/dashboard/otherPet.hbs'
            })
        })
        .then(function () {
            this.partial('/views/dashboard/index.hbs')
        });       
}

handlers.getOtherDetails = function (ctx) {
    petService.getPet(ctx.params.id)
        .then(function (res){   
            ctx.pet = res;          
            loadPartials(ctx)   
                .then(function () {                   
                    this.partial('/views/dashboard/otherPetDetails.hbs')
                });
    })    
}

handlers.like = function(ctx){
    petService.getPet(ctx.params.id)
        .then(function (res){
            res.likes = Number(res.likes) + 1;            
            petService.edit(res);
            return ctx;       
        }).then(function(){
            ctx.redirect('#/dashboard');
    })
}

//My pets
handlers.getMyPets = function (ctx) {   
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    petService.getPets(sessionStorage.id)  
        .then(function(res){          
            ctx.pets = res;
            return ctx.loadPartials({
                header: '/views/common/header.hbs',
                footer: '/views/common/footer.hbs',
                myPet: '/views/myPets/mypet.hbs'
            })
        })
        .then(function () {
            this.partial('/views/myPets/index.hbs')
        });
}

handlers.getCreate = function (ctx) {
    loadPartials(ctx)
        .then(function () {
            this.partial('/views/myPets/create.hbs')
    });
}

handlers.addPet = function(ctx){
    let pet = {...ctx.params, likes : 0};

    petService.create(pet).then(function (res){
        notifications.showSuccess('Pet created.');
        ctx.redirect('#/home');    
    });
}

handlers.getRemovePet = function (ctx) {
    petService.getPet(ctx.params.id)
        .then(function (res){   
            ctx.pet = res;          
            loadPartials(ctx)   
                .then(function () {                   
                    this.partial('/views/myPets/delete.hbs')
                });
        })    
}

handlers.removePet = function(ctx){
    petService.remove(ctx.target.id)
        .then(function (){
            notifications.showSuccess('Pet removed successfully!');
            ctx.redirect('#/home');    
    });
}