namespace IRunes.Services
{
    using System.Linq;
    using IRunes.Data;
    using IRunes.Models;

    public class TrackService : ITrackService
    {
        private readonly RunesDbContext context;

        public Track GetTrackById(string trackId)
        {
            return this.context.Tracks
                    .SingleOrDefault(track => track.Id == trackId);

        }
    }
}