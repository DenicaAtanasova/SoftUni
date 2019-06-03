namespace IRunes.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using IRunes.Data;
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class AlbumService : IAlbumService
    {
        private RunesDbContext context;

        public AlbumService()
        {
            this.context = new RunesDbContext();
        }

        public bool AddTrackToAlbum(string albumId, Track trackFromDb)
        {
            var albumFromDb = this.GetAlbumById(albumId);

            if (albumFromDb == null)
                return false;

            albumFromDb.Tracks.Add(trackFromDb);
            albumFromDb.Price = albumFromDb.Tracks.Sum(t => t.Price) * 0.87M;

            this.context.Update(albumFromDb);
            this.context.SaveChanges();

            return true;
        }

        public Album CreateAlbum(Album album)
        {
            album = this.context.Albums.Add(album).Entity;
            this.context.SaveChanges();

            return album;
        }

        public Album GetAlbumById(string albumId)
        {
            return this.context.Albums
                .Include(album => album.Tracks)
                .SingleOrDefault(album => album.Id == albumId);
        }

        public ICollection<Album> GetAllAlbums()
        {
            return this.context.Albums.ToList();
        }
    }
}
