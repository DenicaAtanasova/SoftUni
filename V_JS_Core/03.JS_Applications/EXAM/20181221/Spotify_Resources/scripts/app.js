const handlers = {}

$(() => {
  const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs');

    // home page routes
    this.get('/index', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);

    // user routes
    this.get('#/register', handlers.getRegister);
    this.get('#/login', handlers.getLogin);
    this.get('#/logout', handlers.logoutUser);

    this.post('#/register', handlers.registerUser);
    this.post('#/login', handlers.loginUser);

    // songs routes
    this.get('#/allSongs', handlers.getAllSongs);
    this.get('#/mySongs', handlers.getMySongs);
    this.get('#/create', handlers.getCreate);
    this.get('#/like/:id', handlers.likeSong);
    this.get('#/listen/:id', handlers.listenSong);
    this.get('#/delete/:id', handlers.deleteSong);
    
    this.post('#/create', handlers.createSong);
  });

  app.run('#/home');
});