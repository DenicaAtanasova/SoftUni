﻿using IRunes.Data;
using IRunes.Models;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.App.Controllers
{
    public class UsersController : BaseController
    {
        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            this.SignOut(httpRequest);

            return this.Redirect("/");
        }

        private string HashPassword(string password)
        {
            using (var hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public IHttpResponse DoLogin(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData["username"]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData["password"]).FirstOrDefault();

                var currentUser = context.Users
                    .Where(user =>
                        (user.Username == username ||
                        user.Email == username) &&
                        user.Password == this.HashPassword(password))
                    .FirstOrDefault();

                if (currentUser == null)
                    return this.Redirect("/Users/Login");

                this.SignIn(httpRequest, currentUser);
            }

            return this.Redirect("/");
        }

        public IHttpResponse DoRegister(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                var username = ((ISet<string>)httpRequest.FormData["username"]).FirstOrDefault();
                var password = ((ISet<string>)httpRequest.FormData["password"]).FirstOrDefault();
                var confirmPassword = ((ISet<string>)httpRequest.FormData["confirmPassword"]).FirstOrDefault();
                var email = ((ISet<string>)httpRequest.FormData["email"]).FirstOrDefault();

                if (password != confirmPassword)
                    return this.Redirect("/Users/Register");

                var user = new User
                {
                    Username = username,
                    Password = this.HashPassword(password),
                    Email = email
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.Redirect("/Users/Login");
        }
    }
}