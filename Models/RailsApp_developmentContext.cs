using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Rocket_Elevators_RESTAPI2._0.Models
{
    public partial class RailsApp_developmentContext : DbContext
    {

        public RailsApp_developmentContext()
        {
        }

        public RailsApp_developmentContext(DbContextOptions<RailsApp_developmentContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Elevator> Elevators { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=nuagedoris9;port=3306;database=RailsApp_development;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasMaxLength(255)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "index_batteries_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.CustomerId, "index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BatteryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("battery_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });



            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers", "RailsApp_development");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyContactPhone)
                    .HasMaxLength(255)
                    .HasColumnName("company_contact_phone");

                entity.Property(e => e.CompanyDescription).HasColumnName("company_description");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.CustomersCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("customers_creation_date");

                entity.Property(e => e.EmailOfCompanyContact)
                    .HasMaxLength(255)
                    .HasColumnName("email_of_company_contact");

                entity.Property(e => e.FullNameOfCompanyContact)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_company_contact");

                entity.Property(e => e.FullNameOfServiceTechnicalAuthority)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_service_technical_authority");

                entity.Property(e => e.TechnicalAuthorityPhoneForService)
                    .HasMaxLength(255)
                    .HasColumnName("technical_authority_phone_for_service_");

                entity.Property(e => e.TechnicalManagerEmailForService)
                    .HasMaxLength(255)
                    .HasColumnName("technical_manager_email_for_service");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                // entity.Property(e => e.BuildingType)
                //     .HasMaxLength(255)
                //     .HasColumnName("building_type");

                // entity.Property(e => e.CertificateOfInspection)
                //     .HasMaxLength(255)
                //     .HasColumnName("certificate_of_inspection");

                entity.Property(e => e.ColumnId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("column_id");

                // entity.Property(e => e.DateOfCommissioning)
                //     .HasColumnType("date")
                //     .HasColumnName("date_of_commissioning");

                // entity.Property(e => e.DateOfLastInspection)
                //     .HasColumnType("date")
                //     .HasColumnName("date_of_last_inspection");

                // entity.Property(e => e.Information)
                //     .HasMaxLength(255)
                //     .HasColumnName("information");

                // entity.Property(e => e.Model)
                //     .HasMaxLength(255)
                //     .HasColumnName("model");

                // entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("serial_number");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("DateTime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Attachment)
                    .HasColumnType("mediumblob")
                    .HasColumnName("attachment");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.DepartmentInChargeOfElevators)
                    .HasMaxLength(255)
                    .HasColumnName("department_in_charge_of_elevators");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .HasColumnName("file_name");

                entity.Property(e => e.FullNameOfContact)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_of_contact");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.ProjectDescription).HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("project_name");

                entity.Property(e => e.CustomerId)
                      .HasColumnType("bigint(20)")
                      .HasColumnName("customer_id");

            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .HasColumnName("contact_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.InstallationFee)
                    .HasMaxLength(255)
                    .HasColumnName("installation_fee");

                entity.Property(e => e.NumOfActivityHoursPerDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_activity_hours_per_day");

                entity.Property(e => e.NumOfApartments)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_apartments");

                entity.Property(e => e.NumOfBasements)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_basements");

                entity.Property(e => e.NumOfDistinctBusinesses)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_distinct_businesses");

                entity.Property(e => e.NumOfElevatorCages)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_elevator_cages");

                entity.Property(e => e.NumOfFloors)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_floors");

                entity.Property(e => e.NumOfOccupantsPerFloor)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_occupants_per_Floor");

                entity.Property(e => e.NumOfParkingSpots)
                    .HasColumnType("int(11)")
                    .HasColumnName("num_of_parking_spots");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(255)
                    .HasColumnName("product_line");

                entity.Property(e => e.RequiredColumns)
                    .HasColumnType("int(11)")
                    .HasColumnName("required_columns");

                entity.Property(e => e.RequiredShafts)
                    .HasColumnType("int(11)")
                    .HasColumnName("required_shafts");

                entity.Property(e => e.SubTotal)
                    .HasMaxLength(255)
                    .HasColumnName("sub_total");

                entity.Property(e => e.Total)
                    .HasMaxLength(255)
                    .HasColumnName("total");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
