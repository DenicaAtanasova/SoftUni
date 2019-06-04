namespace IRunes.App.Controllers
{
    using Extensions;
    using Models;
    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Security;

    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : Controller
    {
        private IAlbumService albumService;

        public AlbumsController()
        {
            this.albumService = new AlbumService();
        }

        [Authorize]
        public ActionResult All()
        {
            ICollection<Album> allAlbums = this.albumService.GetAllAlbums();

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

            return this.View();
        }

        [Authorize()]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize()]
        public ActionResult Details()
        {
            var albumId = this.Request.QueryData["id"].ToString();
            var albumFromDb = this.albumService.GetAlbumById(albumId);

            if (albumFromDb == null)
                    return this.Redirect("/Albums/All");

            this.ViewData["Album"] = albumFromDb.ToHtmlDetails();

            return this.View();
        }

        [Authorize()]
        [HttpPost(ActionName = "Create")]
        public ActionResult DoCreate()
        {
            var name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
            var cover = ((ISet<string>)this.Request.FormData["cover"]).FirstOrDefault();

            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0M
            };

            this.albumService.CreateAlbum(album);
            return this.Redirect("/Albums/All");
        }
    }
}