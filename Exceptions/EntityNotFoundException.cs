using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendance.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message)
        : base(message) { }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner) { }
 
    }
}