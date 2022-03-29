using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Db.Models
{
    [Index(nameof(User.Login), IsUnique = true)]
    public class User : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}