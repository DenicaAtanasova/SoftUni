namespace IRunes.App.Controllers
{
    using Extensions;
    using Data;
    using Models;
    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Security;

    using System.Collections.Generic;
    using System.Linq;

    public class TracksController : Controller
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController()
        {
            this.trackService = new TrackService();
            this.albumService = new AlbumService();
        }

        [Authorize]
        public ActionResult Create()
        {
            var albumId = this.Request.QueryData["albumId"].ToString();
            this.ViewData["AlbumId"] = albumId;

            return this.View();
        }

        [Authorize]
        public ActionResult Details()
        {
            var albumId = this.Request.QueryData["albumId"].ToString();
            var trackId = this.Request.QueryData["trackId"].ToString();

            var trackFromDb = this.trackService.GetTrackById(trackId);

            if (trackFromDb == null)
                return this.Redirect($"/Albums/Details?id={albumId}");

            this.ViewData["AlbumId"] = albumId;
            this.ViewData["Track"] = trackFromDb.ToHtmlDetails(albumId);

            return this.View();
        }

        [Authorize]
        [HttpPost(ActionName = "Create")]
        public ActionResult DoCreate()
        {
            var albumId = this.Request.QueryData["albumId"].ToString();
            var albumFromDb = this.albumService.GetAlbumById(albumId);

            this.ViewData["AlbumId"] = albumId;

            var name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
            var link = ((ISet<string>)this.Request.FormData["link"]).FirstOrDefault();
            var price = ((ISet<string>)this.Request.FormData["price"]).FirstOrDefault();

            var trackFromDb = new Track
            {
                Name = name,
                Link = link,
                Price = decimal.Parse(price)
            };

            if (!this.albumService.AddTrackToAlbum(albumId, trackFromDb))
                this.Redirect("/Albums/All");

            return this.Redirect($"/Albums/Details?id={albumId}");
        }
    }
}