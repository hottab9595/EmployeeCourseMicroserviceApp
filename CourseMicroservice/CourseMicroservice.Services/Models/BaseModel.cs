namespace CourseMicroservice.Services.Models
{
    public abstract class BaseModel
    {
        protected BaseModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}