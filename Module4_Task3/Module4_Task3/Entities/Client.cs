using System;
using System.Collections.Generic;

namespace Module4_Task3.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FoundationDate { get; set; }
        public string ActvityScope { get; set; }

        public virtual List<Project> Projects { get; set; } = new List<Project>();
    }
}
