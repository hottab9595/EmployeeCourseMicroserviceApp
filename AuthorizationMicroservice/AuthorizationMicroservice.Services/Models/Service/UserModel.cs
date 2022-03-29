using System;

namespace AuthorizationMicroservice.Services.Models.Service
{
    public class UserModel : BaseModel
    {
        private UserModel() : base()
        {

        }

        public UserModel(Guid id) : base(id)
        {
        }

        public string Login { get; set; }

        public string Password { get; set; }
        
    }
}