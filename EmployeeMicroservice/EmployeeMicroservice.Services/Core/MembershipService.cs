using AutoMapper;
using EmployeeMicroservice.Db.Interfaces;
using EmployeeMicroservice.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeMicroservice.Services.Helpers;
using EmployeeMicroservice.Services.Models;
using Microsoft.EntityFrameworkCore;
using BaseModel = EmployeeMicroservice.Services.Models.BaseModel;
using DbMembership = EmployeeMicroservice.Db.Models.CourseEmployee;

namespace EmployeeMicroservice.Services.Core
{
    public class MembershipService<T> : CoreService<T>, IMembershipService<Membership> where T : BaseModel
    {
        public MembershipService(IUnitOfWork db, IMapper mapper, IUtils utils) : base(db)
        {
            _mapper = mapper;
            _utils = utils;
        }

        private readonly IMapper _mapper;
        private readonly IUtils _utils;

        public async Task<IEnumerable<Membership>> GetAsync() => _mapper.Map<List<Membership>>(await _db.CourseEmployees.GetAll().ToListAsync());

        public async Task<Membership> GetAsync(int id) => _mapper.Map<Membership>(await _db.CourseEmployees.FindBy(x => x.Id == id).FirstOrDefaultAsync());

        public async Task<Membership> AddNewAsync(int employeeId, int courseId)
        {
            await _utils.IsMembershipNotExists(employeeId, courseId);

            DbMembership dbMembership = new DbMembership
            {
                CourseId = courseId,
                EmployeeId = employeeId
            };

            _db.CourseEmployees.Add(dbMembership);

            await _db.SaveAsync();
            return await GetAsync(dbMembership.Id);
        }

        public async Task DeleteAsync(int id)
        {
            await _utils.IsMembershipExists(id);

            _db.CourseEmployees.Delete(id);
        }
    }
}