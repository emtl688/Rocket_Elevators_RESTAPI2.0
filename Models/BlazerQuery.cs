using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class BlazerQuery
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Statement { get; set; }
        public string DataSource { get; set; }
        public string Status { get; set; }
    }
}
