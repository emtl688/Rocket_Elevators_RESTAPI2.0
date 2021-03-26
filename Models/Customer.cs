using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Buildings = new HashSet<Building>();
        }

        public long Id { get; set; }
        public DateTime? CustomersCreationDate { get; set; }
        public string CompanyName { get; set; }
        public string FullNameOfCompanyContact { get; set; }
        public string CompanyContactPhone { get; set; }
        public string EmailOfCompanyContact { get; set; }
        public string CompanyDescription { get; set; }
        public string FullNameOfServiceTechnicalAuthority { get; set; }
        public string TechnicalAuthorityPhoneForService { get; set; }
        public string TechnicalManagerEmailForService { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
