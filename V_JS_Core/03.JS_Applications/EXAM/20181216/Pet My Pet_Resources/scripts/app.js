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

    // dashboard
    this.get('#/dashboard(/:category)?', handlers.getDashboard);
    this.get('#/otherDetails/:id', handlers.getOtherDetails);
    this.get('#/like/:id', handlers.like);

    //my pets
    this.get('#/mypets', handlers.getMyPets);
    this.get('#/create', handlers.getCreate);
    this.get('#/remove-pet/:id', handlers.getRemovePet);

    this.post('#/remove', handlers.removePet);
    this.post('#/create', handlers.addPet);
  });

  app.run('#/home');
});