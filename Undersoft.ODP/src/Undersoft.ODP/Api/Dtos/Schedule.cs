﻿using RadicalR;

namespace Undersoft.ODP.Api
{
    public class Schedule : Dto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Interval { get; set; }

        public bool IsView { get; set; }

        public long? TeamId { get; set; }

        public virtual DtoSet<Shift> Shifts { get; set; }
    }
}
