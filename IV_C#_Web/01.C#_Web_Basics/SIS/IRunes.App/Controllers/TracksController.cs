namespace IRunes.App.Controllers
{
    using Extensions;
    using Data;
    using Models;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    public class TracksController : Controller
    {
        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            var albumId = httpRequest.QueryData["albumId"].ToString();
            this.ViewData["AlbumId"] = albumId;

            return this.View();
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            var albumId = httpRequest.QueryData["albumId"].ToString();

            using (var context = new RunesDbContext())
            {
                var trackId = httpRequest.QueryData["trackId"].ToString();
                var currentTrack = context.Tracks
                    .FirstOrDefault(track => track.Id == trackId);

                if (currentTrack == null)
                    return this.Redirect($"/Albums/Details?id={albumId}");

                this.ViewData["AlbumId"] = albumId;
                this.ViewData["Track"] = currentTrack.ToHtmlDetails(albumId);
            }

            return this.View();
        }

        [HttpPost(ActionName = "Create")]
        public IHttpResponse DoCreate(IHttpRequest httpRequest)
        {
            if(!this.IsLoggedIn(httpRequest))
                return this.Redirect("/Users/Login");

            var albumId = httpRequest.QueryData["albumId"].ToString();

            using (var context = new RunesDbContext())
            {
                this.ViewData["AlbumId"] = albumId;

                var currentAlbum = context.Albums
                    .FirstOrDefault(album => album.Id == albumId);

                var name = ((ISet<string>)httpRequest.FormData["name"]).FirstOrDefault();
                var link = ((ISet<string>)httpRequest.FormData["link"]).FirstOrDefault();
                var price = ((ISet<string>)httpRequest.FormData["price"]).FirstOrDefault();

                var track = new Track
                {
                    Name = name,
                    Link = link,
                    Price = decimal.Parse(price)
                };

                if (track == null)
                    this.Redirect("/Albums/All");

                currentAlbum.Tracks.Add(track);
                currentAlbum.Price = currentAlbum.Tracks.Sum(t => t.Price) * 0.87M;

                context.Update(currentAlbum);
                context.SaveChanges();
            }

            return this.Redirect($"/Albums/Details?id={albumId}");
        }
    }
}