namespace IRunes.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Album : BaseModel
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}