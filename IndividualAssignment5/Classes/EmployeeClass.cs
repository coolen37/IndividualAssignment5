using SQLite;

namespace IndividualAssignment5.Classes
{
    class EmployeeClass
    {
        [PrimaryKey, AutoIncrement]
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
        public string officePhone { get; set; }
        public string cellPhone { get; set; }
        public string email { get; set; }
        public string managerName { get; set; }
        public string managerEmail { get; set; }

        public override string ToString()
        {
            return firstName + " " + lastName + "\n" + jobTitle;
        }
    }
}