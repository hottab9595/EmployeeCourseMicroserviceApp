﻿using System.Net;

namespace Common.Exceptions
{
    public class DepartmentException : BaseException
    {
        public DepartmentException()
            : base(message, statusCode)
        {

        }

        protected DepartmentException(string message, HttpStatusCode statusCode) : base(message, statusCode)
        {

        }

        protected DepartmentException(string message) : base(message, statusCode)
        {

        }

        private const string message = "Some department data is not valid";
        private const HttpStatusCode statusCode = HttpStatusCode.BadRequest;
    }

    public class DepartmentNotFoundException : DepartmentException
    {
        public DepartmentNotFoundException() : base(message, statusCode)
        {

        }

        private const HttpStatusCode statusCode = HttpStatusCode.BadRequest;
        private const string message = "Department not found";
    }

    public class DepartmentAlreadyExistsException : EmployeeException
    {
        public DepartmentAlreadyExistsException() : base(message, statusCode)
        {

        }

        private const HttpStatusCode statusCode = HttpStatusCode.BadRequest;
        private const string message = "Department already exists";
    }
}