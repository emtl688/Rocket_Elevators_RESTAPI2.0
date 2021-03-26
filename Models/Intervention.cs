using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Intervention
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long CustomerId { get; set; }
        public long BuildingId { get; set; }
        public long? BatteryId { get; set; }
        public long? ColumnId { get; set; }
        public long? ElevatorId { get; set; }
        public long? EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }

        public virtual Employee Author { get; set; }
        public virtual Battery Battery { get; set; }
        public virtual Building Building { get; set; }
        public virtual Column Column { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Elevator Elevator { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
