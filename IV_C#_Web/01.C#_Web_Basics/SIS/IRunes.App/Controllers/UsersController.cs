namespace IRunes.App.Controllers
{
    using Models;
    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;

    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController()
        {
            this.userService = new UserService();
        }

        public ActionResult Login()
        {
            return this.View();
        }

        public ActionResult Register()
        {
            return this.View();
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        [HttpPost(ActionName = "Login")]
        public ActionResult DoLogin()
        {
            var username = ((ISet<string>)this.Request.FormData["username"]).FirstOrDefault();
            var password = ((ISet<string>)this.Request.FormData["password"]).FirstOrDefault();

            var userFromDb = this.userService.GetUserByUsernameAndPassword(username, this.HashPassword(password));

            if (userFromDb == null)
                return this.Redirect("/Users/Login");

            this.SignIn(userFromDb.Id, userFromDb.Username, userFromDb.Email);

            return this.Redirect("/");
        }

        [HttpPost(ActionName = "Register")]
        public ActionResult DoRegister()
        {
            var username = ((ISet<string>)this.Request.FormData["username"]).FirstOrDefault();
            var password = ((ISet<string>)this.Request.FormData["password"]).FirstOrDefault();
            var confirmPassword = ((ISet<string>)this.Request.FormData["confirmPassword"]).FirstOrDefault();
            var email = ((ISet<string>)this.Request.FormData["email"]).FirstOrDefault();

            if (password != confirmPassword)
                return this.Redirect("/Users/Register");

            var user = new User
            {
                Username = username,
                Password = this.HashPassword(password),
                Email = email
            };

            this.userService.CreateUser(user);

            return this.Redirect("/Users/Login");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (var hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}