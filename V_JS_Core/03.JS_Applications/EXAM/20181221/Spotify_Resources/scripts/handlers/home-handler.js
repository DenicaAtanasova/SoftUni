handlers.getHome = function (ctx) {  
    loadPartials(ctx)
    .then(function () {
      this.partial('/views/home/home.hbs');
    });
}