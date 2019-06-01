﻿namespace IRunes.Models
{
    using System;

    public abstract class BaseModel
    {
        protected BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}