using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorizationMicroservice.Db.Models
{
    public class Role : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}