using SQLite;

namespace IndividualAssignment5.Classes
{
    class ManagerClass
    {
        [PrimaryKey]
            public string managerEmail { get; set; }
            public string managerName { get; set; }
    }
}
