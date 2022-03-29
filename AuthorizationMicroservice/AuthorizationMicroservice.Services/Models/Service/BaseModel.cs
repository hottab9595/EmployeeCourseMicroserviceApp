using System;

namespace AuthorizationMicroservice.Services.Models.Service
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