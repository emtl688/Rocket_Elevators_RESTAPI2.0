using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Building
    {
        public Building()
        {
            Batteries = new HashSet<Battery>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }

        public virtual ICollection<Battery> Batteries { get; set; }
    }
}
