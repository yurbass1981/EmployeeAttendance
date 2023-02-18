namespace EmployeeAttendance.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateOnly HireDate { get; set; }
    }
}