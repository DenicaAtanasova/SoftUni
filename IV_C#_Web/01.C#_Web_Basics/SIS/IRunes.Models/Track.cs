﻿namespace IRunes.Models
{
    public class Track : BaseModel
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }
    }
}