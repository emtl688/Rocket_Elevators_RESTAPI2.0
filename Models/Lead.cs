using System;
using System.Collections.Generic;


namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Lead
    {
        public long Id { get; set; }
        //Added Column to Lead Table
        public long? CustomerId { get; set; }
        //
        public string FullNameOfContact { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string DepartmentInChargeOfElevators { get; set; }
        public string Message { get; set; }
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
    }
}
