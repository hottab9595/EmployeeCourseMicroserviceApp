﻿using AutoMapper;
using CourseMicroservice.Db.Interfaces;
using CourseMicroservice.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseMicroservice.Services.Models;
using Microsoft.EntityFrameworkCore;
using BaseModel = CourseMicroservice.Services.Models.BaseModel;
using DbMembership = CourseMicroservice.Db.Model.CourseEmployee;

namespace CourseMicroservice.Services.Core
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

        public async Task<Membership> AddNewAsync(Membership membership)
        {
            await _utils.IsMembershipNotExists(membership);

            DbMembership dbMembership = new DbMembership
            {
                CourseId = membership.Course.Id,
                EmployeeId = membership.Employee.Id
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