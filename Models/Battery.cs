using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Battery
    {
        public Battery()
        {
            Columns = new HashSet<Column>();
        }

        public long Id { get; set; }
        public string Status { get; set; }
        public long? BuildingId { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}
