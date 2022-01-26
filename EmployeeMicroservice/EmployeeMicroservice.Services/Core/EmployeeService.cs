﻿using AutoMapper;
using EmployeeMicroservice.Db.Interfaces;
using EmployeeMicroservice.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeMicroservice.Services.Models;

namespace EmployeeMicroservice.Services.Core
{
    public class EmployeeService<T> : CoreService<T>, IEmployeeService<Employee> where T : BaseModel
    {
        public EmployeeService(IUnitOfWork db, IMapper mapper, IUtils utils) : base(db)
        {
            _mapper = mapper;
            _utils = utils;
        }

        private readonly IMapper _mapper;
        private readonly IUtils _utils;

        #region Interfaces realization

        public async Task<IEnumerable<Employee>> GetAsync() => _mapper.Map<List<Employee>>(await _db.Employees.FindBy(x => !x.IsDeleted).ToListAsync());

        public async Task<Employee> GetAsync(int id) => _mapper.Map<Employee>((await _utils.IsEmployeeExistsAsync(id)).employee);

        public async Task<Employee> AddNewAsync(Employee employee)
        {
            await _utils.IsEmployeeNotExistsAsync(employee);

            Db.Models.Employee employeeDb = _db.Employees.Add(_mapper.Map<Db.Models.Employee>(employee));
            await _db.SaveAsync();
            return _mapper.Map<Employee>(employeeDb);
        }

        public async Task<Employee> UpdateAsync(int id, Employee employee)
        {
            Db.Models.Employee employeeDb = (await _utils.IsEmployeeExistsAsync(id)).employee;

            employeeDb.Surname = employee.Surname;
            employeeDb.Name = employee.Name;
            employeeDb.Patronymic = employee.Patronymic;
            employeeDb.IsDeleted = employee.IsDeleted;
            employeeDb.DepartmentId = employee.DepartmentId;

            _db.Employees.Update(employeeDb);
            await _db.SaveAsync();
            return _mapper.Map<Employee>(employeeDb);
        }

        public async Task DeleteAsync(int id)
        {
            await _utils.IsEmployeeExistsAsync(id);

            _db.Employees.Delete(id);
            await _db.SaveAsync();
        }

        #endregion
    }
}