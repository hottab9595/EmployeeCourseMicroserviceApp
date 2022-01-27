namespace EmployeeMicroservice.Services.Models
{
    public class Department : BaseModel
    {
        private Department() : base()
        {
            
        }

        public Department(int id) : base(id)
        {
        }

        public string Signature { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}