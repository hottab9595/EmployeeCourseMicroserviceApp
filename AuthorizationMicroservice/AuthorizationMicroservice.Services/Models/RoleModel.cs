using System;
using System.Collections.Generic;

namespace AuthorizationMicroservice.Services.Models
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