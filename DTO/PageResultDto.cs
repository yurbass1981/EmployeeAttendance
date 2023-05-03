using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DTO
{
    public class PageResultDto<T>
    {
        public T Data {get; set;}
        public int Total { get; set; }
    }
}