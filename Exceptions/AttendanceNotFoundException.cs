using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendance.Exceptions
{
    public class AttendanceNotFoundException : EntityNotFoundException
    {
        public AttendanceNotFoundException(string message)
        : base(message) { }

        public AttendanceNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}