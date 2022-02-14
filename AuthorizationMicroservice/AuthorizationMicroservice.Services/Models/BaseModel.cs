using System;

namespace AuthorizationMicroservice.Services.Models
{
    public abstract class BaseModel
    {
        protected BaseModel(Guid id)
        {
            Id = id;
        }

        protected BaseModel()
        {

        }

        public Guid Id { get; }
    }
}