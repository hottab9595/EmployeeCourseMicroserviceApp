namespace EmployeeMicroservice.Services.Models
{
    public abstract class BaseModel
    {
        protected BaseModel(int id)
        {
            Id = id;
        }

        protected BaseModel()
        {
            
        }

        public int Id { get; }
    }
}