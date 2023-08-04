using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
