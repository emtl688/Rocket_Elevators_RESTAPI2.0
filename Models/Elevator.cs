using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Elevator
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public long? ColumnId { get; set; }
        public virtual Column Column { get; set; }
    }
}
