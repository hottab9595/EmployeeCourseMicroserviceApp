using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationMicroservice.Db.Models
{
    public class UserRole : BaseModel
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}