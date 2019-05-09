const handlers = {}

$(() => {
  const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs');

    // home page routes
    this.get('/index', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);

    //user routes
    this.get('#/register', handlers.getRegister);
    this.get('#/login', handlers.getLogin);
    this.get('#/logout', handlers.logoutUser);

    this.post('#/register', handlers.registerUser);
    this.post('#/login', handlers.loginUser);

    //movies routes
    this.get('#/cinema', handlers.getCinema);
    this.get('#/myMovies', handlers.getMyMovies);
    this.get('#/details/:id', handlers.getDetails);
    this.get('#/create', handlers.getCreate);
    this.get('#/edit/:id', handlers.getEdit);
    this.get('#/delete/:id', handlers.getDelete);
    this.get('#/buyTicket/:id', handlers.buyTicket);

    this.post('#/create', handlers.createMovie);
    this.post('#/edit/:id', handlers.editMovie);
    this.post('#/delete/:id', handlers.deleteMovie);
  });

  app.run('#/home');
});