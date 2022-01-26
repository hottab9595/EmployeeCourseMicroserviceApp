using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroservice.Db.Model
{
    public class Employee : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<CourseEmployee> CourseEmployees { get; set; }
    }
}