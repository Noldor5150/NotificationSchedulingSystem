using System;

namespace Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime SendingDate { get; set; }
        public int ScheduleId { get; set; }
    }
}
