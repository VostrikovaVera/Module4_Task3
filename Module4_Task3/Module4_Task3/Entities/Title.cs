using System.Collections.Generic;

namespace Module4_Task3.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
