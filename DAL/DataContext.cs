using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.DAL.EntityTypeConfig;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttendanceEntityTypeConfig).Assembly);
        }
    }
}