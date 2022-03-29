using System;

namespace AuthorizationMicroservice.Services.Models.Service
{
    public class UserRoleModel : BaseModel
    {
        private UserRoleModel() : base()
        {

        }

        public UserRoleModel(Guid id) : base(id)
        {
        }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}