using System;

namespace AuthorizationMicroservice.Services.Models.Service
{
    public class RoleModel : BaseModel
    {
        private RoleModel() : base()
        {

        }

        public RoleModel(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
    }
}