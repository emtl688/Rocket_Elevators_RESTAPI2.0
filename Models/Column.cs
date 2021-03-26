using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
        }

        public long Id { get; set; }
        public string Status { get; set; }
        public long? BatteryId { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }
    }
}
