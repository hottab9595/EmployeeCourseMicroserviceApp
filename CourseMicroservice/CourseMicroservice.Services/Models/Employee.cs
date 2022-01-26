﻿namespace CourseMicroservice.Services.Models
{
    public class Employee : BaseModel
    {
        public Employee(int id) : base(id)
        {
        }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
}