using EmployeeAttendance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeAttendance.DAL.EntityTypeConfig
{
    public class AttendanceEntityTypeConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(a => a.CrossDateTime)
                .IsRequired();
            
            builder.Property(a => a.AttendanceType)
                .IsRequired()
                .HasConversion<string>();          

            builder.HasOne(a => a.Employee)
                .WithMany(e => e.EmployeeAttendance)
                .HasForeignKey(a => a.EmployeeId);
        }

    }
}