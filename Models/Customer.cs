﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Buildings = new HashSet<Building>();
            Interventions = new HashSet<Intervention>();
            Leads = new HashSet<Lead>();
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
        public long? UserId { get; set; }
        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
    }
}
