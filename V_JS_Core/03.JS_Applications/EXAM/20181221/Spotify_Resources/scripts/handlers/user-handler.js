handlers.getRegister = function (ctx) {
    loadPartials(ctx).then(function () {
      this.partial('/views/user/register.hbs')
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
    try {
        if (username.length < 3 || username === '') {
            throw ('Username must be at least 3 symbols');
          }
        if (password.length < 6 || password === '') {
            throw 'Password must be at least 6 symbols';
        }

        userService.register(username, password).then(function (res) {
            userService.saveSession(res);
            notify.showInfo('User registration successful.');
            ctx.redirect('#/home')
        });
    } catch (err) {
        notify.showError(err);
    }    
}
  
handlers.loginUser = function (ctx) {
    let username = ctx.params.username;
    let password = ctx.params.password;

    userService.login(username, password).then(function (res) {
        userService.saveSession(res);
        notify.showInfo('Login successful.');
        ctx.redirect('#/home')
    }).catch(function(){   
        notify.showError('Wrong username or password.')});
}
  
handlers.logoutUser = function (ctx) {
    userService.logout().then(function() {
        sessionStorage.clear();
        notify.showInfo('Logout successful.');
        ctx.redirect('#/home');
    });
}