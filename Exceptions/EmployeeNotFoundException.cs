using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendance.Exceptions
{
    public class EmployeeNotFoundException : EntityNotFoundException
    {
        public EmployeeNotFoundException(string message)
        : base(message) { }

        public EmployeeNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}