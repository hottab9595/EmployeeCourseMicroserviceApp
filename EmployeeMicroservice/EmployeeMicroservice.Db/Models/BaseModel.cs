using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMicroservice.Db.Models
{
    public abstract class BaseModel
    {
        [Key]
        [Column(name: "ID")]
        public int Id { get; set; }
    }
}