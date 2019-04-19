handlers.getRegister = function (ctx) {
  loadPartials(ctx).then(function () {
    this.partial('../../views/user/register.hbs')
  });
}

handlers.getLogin = function (ctx) {
  loadPartials(ctx).then(function () {
    this.partial('../../views/user/login.hbs')
  });
}

handlers.registerUser = function (ctx) {
  let username = ctx.params.username;
  let password = ctx.params.password;
  
  userService.register(username, password).then(function (res) {
    userService.saveSession(res);
    notifications.showSuccess('User registration successful.');
    ctx.redirect('#/home')
  }).catch(function(){   
    notifications.showError('Invalid username or password')});
}

handlers.loginUser = function (ctx) {
  let username = ctx.params.username;
  let password = ctx.params.password;
  userService.login(username, password).then(function (res) {
    userService.saveSession(res);
    notifications.showSuccess('Login successful.');
    ctx.redirect('#/home')
  }).catch(function(){   
    notifications.showError('Wrong username or password')});
}

handlers.logoutUser = function (ctx) {
  userService.logout().then(function() {
    sessionStorage.clear();
    notifications.showSuccess('Logout successful.');
    ctx.redirect('#/home');
  })
}