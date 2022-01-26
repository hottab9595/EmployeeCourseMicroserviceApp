using System;
using System.Threading.Tasks;
using Common.Exceptions;
using CourseMicroservice.Db.Interfaces;
using CourseMicroservice.Services.Interfaces;
using CourseMicroservice.Services.Models;
using Microsoft.EntityFrameworkCore;
using DbEmployee = CourseMicroservice.Db.Model.Employee;
using DbCourse = CourseMicroservice.Db.Model.Course;
using DbMembership = CourseMicroservice.Db.Model.CourseEmployee;

namespace CourseMicroservice.Services.Helpers
{
    public class Utils : IUtils
    {
        public Utils(IUnitOfWork db)
        {
            _db = db;
        }

        private readonly IUnitOfWork _db;

        #region Exists


        public async Task<(bool isExists, DbCourse course)> IsCourseExistsAsync(int id)
        {
            DbCourse dbCourse = await _db.Courses.FindBy(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            return dbCourse != null ? (true, dbCourse) : throw new CourseNotFoundException();
        }

        public async Task<(bool isExists, DbCourse course)> IsCourseExistsAsync(Course course)
        {
            return await IsCourseExistsAsync(course.Id);
        }

        public async Task<(bool isExists, DbMembership membership)> IsMembershipExists(int id)
        {
            DbMembership dbMembership = await _db.CourseEmployees.FindBy(x => x.Id == id).FirstOrDefaultAsync();

            return dbMembership != null ? (true, dbMembership) : throw new MembershipNotFoundException();
        }

        public async Task<(bool isExists, DbMembership membership)> IsMembershipExists(Membership membership)
        {
            return await IsMembershipExists(membership.Id);
        }

        #endregion

        #region NotExists

        public async Task<bool> IsCourseNotExistsAsync(int id)
        {
            //todo work with employee
            //DbEmployee dbEmployee = await _db.Employees.FindBy(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();

            //return dbEmployee == null ? true : throw new CourseAlreadyExistsException();
            throw new NotImplementedException();
        }

        public async Task<bool> IsCourseNotExistsAsync(Course course)
        {
            return await IsCourseNotExistsAsync(course.Id);
        }

        public async Task<bool> IsMembershipNotExists(int id)
        {
            DbMembership dbMembership = await _db.CourseEmployees.FindBy(x => x.Id == id).FirstOrDefaultAsync();

            return dbMembership == null ? true : throw new MembershipAlreadyExistsException();
        }

        public async Task<bool> IsMembershipNotExists(Membership membership)
        {
            //todo work with employee
            //await IsEmployeeExistsAsync(membership.Employee.Id);
            //await IsCourseExistsAsync(membership.Course.Id);

            //DbMembership dbMembership = await _db.CourseEmployees.FindBy(x => x.Id == membership.Id).FirstOrDefaultAsync() ??
            //                            await _db.CourseEmployees
            //    .FindBy(x => x.EmployeeId == membership.Employee.Id && x.CourseId == membership.Course.Id)
            //    .FirstOrDefaultAsync();

            //return dbMembership == null ? true : throw new MembershipAlreadyExistsException();

            throw new NotImplementedException();
        }

        #endregion
    }
}