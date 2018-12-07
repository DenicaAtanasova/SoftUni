
using System.Collections.Generic;

namespace IRunesWebApp.Models
{
    public class Album : BaseModel
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
