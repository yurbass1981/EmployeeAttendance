using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}