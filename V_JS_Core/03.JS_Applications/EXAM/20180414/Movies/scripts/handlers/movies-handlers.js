handlers.getCinema = function (ctx) {
    movieService.getAll()
    .then(function(res){
        ctx.movies = res.sort((a, b) => b.tickets - a.tickets);
        loadPartials(ctx).then(function(){
            this.partial('/views/movies/cinema.hbs')
        });
    }) 
}

handlers.getMyMovies = function (ctx) {
    movieService.getMy(sessionStorage.id)
    .then(function(res){          
        ctx.movies = res;
        loadPartials(ctx).then(function(){
            this.partial('/views/movies/myMovies.hbs')
        });
    }) 
}

handlers.getDetails = function (ctx) {
    movieService.getById(ctx.params.id).then(function(res){
        ctx.movie = res;
        loadPartials(ctx).then(function(){
            this.partial('/views/movies/details.hbs')
        });                   
    })  
}

handlers.getCreate = function(ctx){
    loadPartials(ctx).then(function(){
        this.partial('/views/movies/create.hbs')
    });
}

handlers.createMovie = function(ctx){
    let movie = {...ctx.params};
    movie.genres = movie.genres.split(',');
    
    try {
        if (movie.title.length < 6) {
            throw ('Movie title must be at least 6 symbols.');
        }
        if (!movie.imageUrl.startsWith('http://') && !movie.imageUrl.startsWith('https://')) {
            throw ('Movie image Url must start with "http://" or "https://".');
        }
        if (movie.description.length < 10) {
            throw ('Movie description must be at least 10 symbols.');
        }
        if (movie.tickets == '') {
            throw ('You must enter tickets count!');
        }
        movieService.create(movie).then(function(){
            notify.showInfo('Movie created successfully.');
            ctx.redirect('#/home');
        });
    } catch (err) {
        notify.showError(err);
    }     
}

handlers.getEdit = function(ctx){
    movieService.getById(ctx.params.id).then(function(res){
        ctx.movie = res;
        loadPartials(ctx).then(function(){
            this.partial('/views/movies/edit.hbs')
        });                   
    })   
}

handlers.editMovie = function(ctx){
    let movie = {...ctx.params};
    movie.genres = movie.genres.split(',');

    movieService.update(movie.id, movie).then(function(){
        notify.showInfo('Movie edited successfully.');
        ctx.redirect('#/myMovies');
    });   
}

handlers.getDelete = function(ctx){
    movieService.getById(ctx.params.id).then(function(res){
        ctx.movie = res;
        loadPartials(ctx).then(function(){
            this.partial('/views/movies/delete.hbs')
        });                   
    })   
}

handlers.deleteMovie = function(ctx){
    movieService.remove(ctx.params.id).then(function(){
        notify.showInfo('Movie removed successfully!');
        ctx.redirect('#/home');
    });   
}

handlers.buyTicket = function (ctx) {
    let id = ctx.params.id
    movieService.getById(id).then(function(res){
        let movie = res;
                
        if (movie.tickets > 0) {          
            movie.tickets = Number(movie.tickets) - 1;
            movieService.update(id, movie)
                .then(function () {
                    notify.showInfo(`Successfully bought ticket for ${movie.title}!`);                                      
                    ctx.redirect('#/cinema');
                });  
        } 
        else{
            notify.showError('There are no available tickets!');        
        }                     
    });
};