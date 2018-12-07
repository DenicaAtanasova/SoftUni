
namespace IRunesWebApp.Models
{
    using Contracts;
    using System;

    public abstract class BaseModel : IBaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
