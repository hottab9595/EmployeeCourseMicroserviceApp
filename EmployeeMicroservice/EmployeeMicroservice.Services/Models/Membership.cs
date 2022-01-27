namespace EmployeeMicroservice.Services.Models
{
    public class Membership : BaseModel
    {
        private Membership() : base()
        {
            
        }

        public Membership(int id) : base(id)
        {
        }

        public Employee Employee { get; set; }
        public Course Course { get; set; }
    }
}