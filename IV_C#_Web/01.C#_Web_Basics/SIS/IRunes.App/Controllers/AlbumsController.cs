namespace IRunes.App.Controllers
{
    using Extensions;
    using Data;
    using Models;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : Controller
    {
        public IHttpResponse All(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            using (var context = new RunesDbContext())
            {
                ICollection<Album> allAlbums = context.Albums.ToList();

                if (allAlbums.Count == 0)
                {
                    this.ViewData["Albums"] = "There are currently no albums.";
                }
                else
                {
                    this.ViewData["Albums"] = 
                        string.Join(string.Empty,
                        allAlbums.Select(album => album.ToHtmlAll()).ToList());
                }
            }

            return this.View();
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            return this.View();
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            using (var context = new RunesDbContext())
            {
                var albumId = httpRequest.QueryData["id"].ToString();
                var currentAlbum = context.Albums
                    .Include(album => album.Tracks)
                    .FirstOrDefault(album => album.Id == albumId);

                if (currentAlbum == null)
                    return this.Redirect("/Albums/All");

                this.ViewData["Album"] = currentAlbum.ToHtmlDetails();
            }

            return this.View();
        }

        [HttpPost(ActionName = "Create")]
        public IHttpResponse DoCreate(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            using (var context = new RunesDbContext())
            {
                var name = ((ISet<string>)httpRequest.FormData["name"]).FirstOrDefault();
                var cover = ((ISet<string>)httpRequest.FormData["cover"]).FirstOrDefault();

                var album = new Album
                {
                    Name = name,
                    Cover = cover,
                    Price = 0M
                };

                if (album == null)
                    this.Redirect("/Albums/Create");

                context.Albums.Add(album);
                context.SaveChanges();
            }

            return this.Redirect("/Albums/All");
        }
    }
}