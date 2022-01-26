using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CourseMicroservice.Db.Model
{
    public abstract class BaseModel
    {
        [Key]
        [Column(name: "ID")]
        public int Id { get; set; }
    }
}