﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
            InterventionAuthors = new HashSet<Intervention>();
            InterventionEmployees = new HashSet<Intervention>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public long? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<Intervention> InterventionAuthors { get; set; }
        public virtual ICollection<Intervention> InterventionEmployees { get; set; }
    }
}
