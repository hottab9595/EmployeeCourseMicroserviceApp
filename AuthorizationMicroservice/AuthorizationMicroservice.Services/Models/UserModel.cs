using System;
using System.Collections.Generic;

namespace AuthorizationMicroservice.Services.Models
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