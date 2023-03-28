using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul;

public partial class OfficalZooDbContext : DbContext
{
    public OfficalZooDbContext()
    {
    }

    public OfficalZooDbContext(DbContextOptions<OfficalZooDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalCareProgram> AnimalCarePrograms { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<EducationProgram> EducationPrograms { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    public virtual DbSet<ExhibitFeedingSchedule> ExhibitFeedingSchedules { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseItem> ExpenseItems { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationDaysClosed> LocationDaysCloseds { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Occupation> Occupations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<TotalTickeSell> TotalTickeSells { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VeterinaryVisit> VeterinaryVisits { get; set; }

    public virtual DbSet<ZooEvent> ZooEvents { get; set; }

    public virtual DbSet<ZooEventRequiredInventory> ZooEventRequiredInventories { get; set; }

    public virtual DbSet<ZooTransaction> ZooTransactions { get; set; }

    public virtual DbSet<ZooTransactionEventTicket> ZooTransactionEventTickets { get; set; }

    public virtual DbSet<ZooTransactionItem> ZooTransactionItems { get; set; }

    public virtual DbSet<ZooUser> ZooUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=zoo-db-server.mysql.database.azure.com;userid=audace;password=37PE&CWYy9e@;database=offical_zoo_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PRIMARY");

            entity.ToTable("animal");

            entity.HasIndex(e => e.MotherId, "IS_CHILD_OF_1");

            entity.HasIndex(e => e.FatherId, "IS_CHILD_OF_2");

            entity.HasIndex(e => new { e.Genus, e.Species }, "IS_SPECIES");

            entity.Property(e => e.AnimalId)
                .ValueGeneratedNever()
                .HasColumnName("Animal_ID");
            entity.Property(e => e.AnimalName)
                .HasMaxLength(30)
                .HasColumnName("Animal_Name");
            entity.Property(e => e.CauseOfDeath)
                .HasColumnType("tinytext")
                .HasColumnName("Cause_of_Death");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_Birth");
            entity.Property(e => e.DateOfDeath)
                .HasColumnType("datetime")
                .HasColumnName("Date_of_Death");
            entity.Property(e => e.DietaryRestrictions)
                .HasColumnType("tinytext")
                .HasColumnName("Dietary_Restrictions");
            entity.Property(e => e.FatherId).HasColumnName("Father_ID");
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female','N/A')");
            entity.Property(e => e.Genus).HasMaxLength(30);
            entity.Property(e => e.MotherId).HasColumnName("Mother_ID");
            entity.Property(e => e.Notes).HasColumnType("mediumtext");
            entity.Property(e => e.Recreation).HasColumnType("tinytext");
            entity.Property(e => e.Species).HasMaxLength(30);
            entity.Property(e => e.UniqueDescriptors)
                .HasColumnType("tinytext")
                .HasColumnName("Unique_Descriptors");

            entity.HasOne(d => d.SpeciesNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => new { d.Genus, d.Species })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IS_SPECIES");
        });

        modelBuilder.Entity<AnimalCareProgram>(entity =>
        {
            entity.HasKey(e => e.AnimalProgramNum).HasName("PRIMARY");

            entity.ToTable("animal_care_program");

            entity.HasIndex(e => e.ProgramName, "Program_Name").IsUnique();

            entity.Property(e => e.AnimalProgramNum)
                .ValueGeneratedNever()
                .HasColumnName("Animal_Program_Num");
            entity.Property(e => e.Feedback).HasColumnType("mediumtext");
            entity.Property(e => e.ProgramDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Program_Description");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(45)
                .HasColumnName("Program_Name");
            entity.Property(e => e.ProgramResults)
                .HasColumnType("mediumtext")
                .HasColumnName("Program_Results");

            entity.HasMany(d => d.Animals).WithMany(p => p.AnimalProgramNums)
                .UsingEntity<Dictionary<string, object>>(
                    "AnimalCareProgramAnimalsInvolved",
                    r => r.HasOne<Animal>().WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ANIMAL_PARTICIPATING"),
                    l => l.HasOne<AnimalCareProgram>().WithMany()
                        .HasForeignKey("AnimalProgramNum")
                        .HasConstraintName("animal_care_program_animals_involved_ibfk_1"),
                    j =>
                    {
                        j.HasKey("AnimalProgramNum", "AnimalId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("animal_care_program_animals_involved");
                        j.HasIndex(new[] { "AnimalId" }, "ANIMAL_PARTICIPATING");
                        j.IndexerProperty<int>("AnimalProgramNum").HasColumnName("Animal_Program_Num");
                        j.IndexerProperty<int>("AnimalId").HasColumnName("Animal_ID");
                    });

            entity.HasMany(d => d.Employees).WithMany(p => p.AnimalProgramNums)
                .UsingEntity<Dictionary<string, object>>(
                    "AnimalCareProgramStaffInvolved",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EMPLOYEE_CARING_IN"),
                    l => l.HasOne<AnimalCareProgram>().WithMany()
                        .HasForeignKey("AnimalProgramNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("animal_care_program_staff_involved_ibfk_1"),
                    j =>
                    {
                        j.HasKey("AnimalProgramNum", "EmployeeId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("animal_care_program_staff_involved");
                        j.HasIndex(new[] { "EmployeeId" }, "EMPLOYEE_CARING_IN");
                        j.IndexerProperty<int>("AnimalProgramNum").HasColumnName("Animal_Program_Num");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("Employee_ID");
                    });
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.MembershipLevel, "IS_MEMBER");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("Customer_ID");
            entity.Property(e => e.Address).HasMaxLength(45);
            entity.Property(e => e.CreditCardNo)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("Credit_Card_No");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_Birth");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Fname).HasMaxLength(20);
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female','Do not wish to answer')");
            entity.Property(e => e.IsDonor)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Is_Donor");
            entity.Property(e => e.Lname).HasMaxLength(20);
            entity.Property(e => e.MembershipLevel)
                .HasMaxLength(20)
                .HasColumnName("Membership_Level");
            entity.Property(e => e.MembershipStartDate).HasColumnName("Membership_Start_Date");
            entity.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Phone_No");

            entity.HasOne(d => d.MembershipLevelNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.MembershipLevel)
                .HasConstraintName("IS_MEMBER");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.DeptName, "Dept_Name").IsUnique();

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.ManagerId, "Manager_ID").IsUnique();

            entity.HasIndex(e => e.PhoneNum, "Phone_Num").IsUnique();

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("Dept_ID");
            entity.Property(e => e.DeptName)
                .HasMaxLength(30)
                .HasColumnName("Dept_Name");
            entity.Property(e => e.Description).HasColumnType("mediumtext");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.ManagerId).HasColumnName("Manager_ID");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Phone_Num");

            entity.HasOne(d => d.Manager).WithOne(p => p.Department)
                .HasForeignKey<Department>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MANAGED_BY");

            entity.HasMany(d => d.AnimalProgramNums).WithMany(p => p.Depts)
                .UsingEntity<Dictionary<string, object>>(
                    "DepartmentAnimalProgram",
                    r => r.HasOne<AnimalCareProgram>().WithMany()
                        .HasForeignKey("AnimalProgramNum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ANIMAL_PROGRAM_IN"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("DeptId")
                        .HasConstraintName("department_animal_programs_ibfk_1"),
                    j =>
                    {
                        j.HasKey("DeptId", "AnimalProgramNum")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("department_animal_programs");
                        j.HasIndex(new[] { "AnimalProgramNum" }, "ANIMAL_PROGRAM_IN");
                        j.IndexerProperty<int>("DeptId").HasColumnName("Dept_ID");
                        j.IndexerProperty<int>("AnimalProgramNum").HasColumnName("Animal_Program_Num");
                    });

            entity.HasMany(d => d.ProgramNos).WithMany(p => p.Depts)
                .UsingEntity<Dictionary<string, object>>(
                    "DepartmentEducationProgram",
                    r => r.HasOne<EducationProgram>().WithMany()
                        .HasForeignKey("ProgramNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EDUCATION_PROGRAM_IN"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("DeptId")
                        .HasConstraintName("department_education_programs_ibfk_1"),
                    j =>
                    {
                        j.HasKey("DeptId", "ProgramNo")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("department_education_programs");
                        j.HasIndex(new[] { "ProgramNo" }, "EDUCATION_PROGRAM_IN");
                        j.IndexerProperty<int>("DeptId").HasColumnName("Dept_ID");
                        j.IndexerProperty<int>("ProgramNo").HasColumnName("Program_No");
                    });
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.Fname, e.Bdate })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("dependent");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.Fname).HasMaxLength(20);
            entity.Property(e => e.Address).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female')");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Phone_Num");

            entity.HasOne(d => d.Employee).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("DEPENDENT_ON");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountName).HasName("PRIMARY");

            entity.ToTable("discount");

            entity.Property(e => e.DiscountName)
                .HasMaxLength(30)
                .HasColumnName("Discount_Name");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("float(5,2)")
                .HasColumnName("Discount_Percentage");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PRIMARY");

            entity.ToTable("donation");

            entity.HasIndex(e => e.DonorId, "IS_DONOR");

            entity.Property(e => e.DonationId)
                .ValueGeneratedNever()
                .HasColumnName("Donation_ID");
            entity.Property(e => e.AmountDonated).HasColumnName("Amount_Donated");
            entity.Property(e => e.DateDonated).HasColumnName("Date_Donated");
            entity.Property(e => e.DonationPurpose)
                .HasColumnType("tinytext")
                .HasColumnName("Donation_Purpose");
            entity.Property(e => e.DonorId).HasColumnName("Donor_ID");
            entity.Property(e => e.Feedback).HasColumnType("mediumtext");
            entity.Property(e => e.Recognition).HasColumnType("mediumtext");

            entity.HasOne(d => d.Donor).WithMany(p => p.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IS_DONOR");
        });

        modelBuilder.Entity<EducationProgram>(entity =>
        {
            entity.HasKey(e => e.ProgramNo).HasName("PRIMARY");

            entity.ToTable("education_program");

            entity.HasIndex(e => e.ProgramName, "Program_Name").IsUnique();

            entity.Property(e => e.ProgramNo)
                .ValueGeneratedNever()
                .HasColumnName("Program_No");
            entity.Property(e => e.Feedback).HasColumnType("mediumtext");
            entity.Property(e => e.ProgramDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Program_Description");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(45)
                .HasColumnName("Program_Name");

            entity.HasMany(d => d.Animals).WithMany(p => p.ProgramNos)
                .UsingEntity<Dictionary<string, object>>(
                    "EducationProgramAnimalsInvolved",
                    r => r.HasOne<Animal>().WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ANIMAL_TAKING_PART"),
                    l => l.HasOne<EducationProgram>().WithMany()
                        .HasForeignKey("ProgramNo")
                        .HasConstraintName("education_program_animals_involved_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProgramNo", "AnimalId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("education_program_animals_involved");
                        j.HasIndex(new[] { "AnimalId" }, "ANIMAL_TAKING_PART");
                        j.IndexerProperty<int>("ProgramNo").HasColumnName("Program_No");
                        j.IndexerProperty<int>("AnimalId").HasColumnName("Animal_ID");
                    });

            entity.HasMany(d => d.Employees).WithMany(p => p.ProgramNos)
                .UsingEntity<Dictionary<string, object>>(
                    "EducationProgramStaffInvolvled",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EMPLOYEE_EDUCATING"),
                    l => l.HasOne<EducationProgram>().WithMany()
                        .HasForeignKey("ProgramNo")
                        .HasConstraintName("education_program_staff_involvled_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProgramNo", "EmployeeId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("education_program_staff_involvled");
                        j.HasIndex(new[] { "EmployeeId" }, "EMPLOYEE_EDUCATING");
                        j.IndexerProperty<int>("ProgramNo").HasColumnName("Program_No");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("Employee_ID");
                    });
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.Occupation, "JOB_IS");

            entity.HasIndex(e => e.SupId, "SUPERVISED_BY");

            entity.HasIndex(e => e.Location, "WORKS_AT");

            entity.HasIndex(e => e.DeptNo, "WORKS_IN");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("Employee_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Bonus).HasColumnType("double(8,2)");
            entity.Property(e => e.DateJoined).HasColumnName("Date_Joined");
            entity.Property(e => e.DateLeft).HasColumnName("Date_Left");
            entity.Property(e => e.DeptNo).HasColumnName("Dept_No");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactEmail)
                .HasMaxLength(50)
                .HasColumnName("Emergency_Contact_Email");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(40)
                .HasColumnName("Emergency_Contact_Name");
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Emergency_Contact_Phone");
            entity.Property(e => e.Fname).HasMaxLength(20);
            entity.Property(e => e.Insurance).HasColumnType("double(8,2)");
            entity.Property(e => e.InsurancePlan)
                .HasMaxLength(20)
                .HasColumnName("Insurance_Plan");
            entity.Property(e => e.Lname).HasMaxLength(20);
            entity.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.MobilePhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Mobile_Phone_Num");
            entity.Property(e => e.Occupation).HasMaxLength(30);
            entity.Property(e => e.OccupationBasedBenefits)
                .HasColumnType("tinytext")
                .HasColumnName("Occupation_Based_Benefits");
            entity.Property(e => e.SickDaysLeft).HasColumnName("Sick_Days_Left");
            entity.Property(e => e.SupId).HasColumnName("Sup_ID");
            entity.Property(e => e.TimeBasedBenefits)
                .HasColumnType("tinytext")
                .HasColumnName("Time_Based_Benefits");
            entity.Property(e => e.TrainingAndCerts)
                .HasColumnType("tinytext")
                .HasColumnName("Training_and_Certs");
            entity.Property(e => e.VacationDaysLeft).HasColumnName("Vacation_Days_Left");
            entity.Property(e => e.Wage)
                .HasComment("Enter an hourly salary")
                .HasColumnType("double(8,2)");
            entity.Property(e => e.WorkPhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Work_Phone_Num");

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WORKS_IN");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("WORKS_AT");

            entity.HasOne(d => d.OccupationNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Occupation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("JOB_IS");

            entity.HasOne(d => d.Sup).WithMany(p => p.InverseSup)
                .HasForeignKey(d => d.SupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SUPERVISED_BY");
        });

        modelBuilder.Entity<EmployeeShift>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.ShiftStart })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("employee_shift");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.ShiftStart)
                .HasColumnType("datetime")
                .HasColumnName("Shift_Start");
            entity.Property(e => e.LunchEnd)
                .HasColumnType("datetime")
                .HasColumnName("Lunch_End");
            entity.Property(e => e.LunchStart)
                .HasColumnType("datetime")
                .HasColumnName("Lunch_Start");
            entity.Property(e => e.ShiftEnd)
                .HasColumnType("datetime")
                .HasColumnName("Shift_End");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeShifts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("employee_shift_ibfk_1");
        });

        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.HasKey(e => e.ExhibitNo).HasName("PRIMARY");

            entity.ToTable("exhibit");

            entity.HasIndex(e => e.Zookeeper, "HAS_ZOOKEEPER");

            entity.HasIndex(e => e.Location, "IS_LOCATED_IN");

            entity.Property(e => e.ExhibitName)
                .HasMaxLength(30)
                .HasColumnName("Exhibit_Name");
            entity.Property(e => e.ExhibitNo)
                .ValueGeneratedNever()
                .HasColumnName("Exhibit_No");
            entity.Property(e => e.Flora).HasMaxLength(20);
            entity.Property(e => e.Humidity)
                .HasComment("Humidity in percentage")
                .HasColumnType("float(3,1)");
            entity.Property(e => e.IsIndoors).HasColumnName("Is_Indoors");
            entity.Property(e => e.LowerTemperature)
                .HasComment("Temperature in Fahrenheit")
                .HasColumnType("float(4,1)")
                .HasColumnName("Lower_Temperature");
            entity.Property(e => e.UpperTemperature)
                .HasComment("Temperature in Fahrenheit")
                .HasColumnType("float(4,1)")
                .HasColumnName("Upper_Temperature");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IS_LOCATED_IN");

            entity.HasOne(d => d.ZookeeperNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.Zookeeper)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("HAS_ZOOKEEPER");
        });

        modelBuilder.Entity<ExhibitFeedingSchedule>(entity =>
        {
            entity.HasKey(e => new { e.ExhibitNo, e.FeedingTime, e.MealContent })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("exhibit_feeding_schedule");

            entity.HasIndex(e => e.MealContent, "IS_FED");

            entity.Property(e => e.ExhibitNo).HasColumnName("Exhibit_No");
            entity.Property(e => e.FeedingTime)
                .HasColumnType("time")
                .HasColumnName("Feeding_Time");
            entity.Property(e => e.MealContent).HasColumnName("Meal_Content");
            entity.Property(e => e.MealQuantity)
                .HasComment("Number of servings of each meal item per feeding")
                .HasColumnType("float(6,3)")
                .HasColumnName("Meal_Quantity");

            entity.HasOne(d => d.ExhibitNoNavigation).WithMany(p => p.ExhibitFeedingSchedules)
                .HasForeignKey(d => d.ExhibitNo)
                .HasConstraintName("exhibit_feeding_schedule_ibfk_1");

            entity.HasOne(d => d.MealContentNavigation).WithMany(p => p.ExhibitFeedingSchedules)
                .HasForeignKey(d => d.MealContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IS_FED");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PRIMARY");

            entity.ToTable("expense");

            entity.HasIndex(e => e.EmployeeNum, "EMPLOYEE_PAID");

            entity.HasIndex(e => e.DeptId, "FOR_DEPT");

            entity.HasIndex(e => e.VendorId, "VENDOR_PAID");

            entity.Property(e => e.ExpenseId)
                .ValueGeneratedNever()
                .HasColumnName("Expense_ID");
            entity.Property(e => e.Category).HasColumnType("enum('Employee','Vendor')");
            entity.Property(e => e.DeptId).HasColumnName("Dept_ID");
            entity.Property(e => e.EmployeeNum).HasColumnName("Employee_Num");
            entity.Property(e => e.ExpenseAccount)
                .HasMaxLength(20)
                .HasColumnName("Expense_Account");
            entity.Property(e => e.ExpenseAmount)
                .HasColumnType("double(10,2)")
                .HasColumnName("Expense_Amount");
            entity.Property(e => e.ExpenseDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Expense_Description");
            entity.Property(e => e.ExpenseTime)
                .HasColumnType("datetime")
                .HasColumnName("Expense_Time");
            entity.Property(e => e.InvoiceNo).HasColumnName("Invoice_No");
            entity.Property(e => e.ReceiptImage)
                .HasColumnType("mediumblob")
                .HasColumnName("Receipt_Image");
            entity.Property(e => e.VendorId).HasColumnName("Vendor_ID");

            entity.HasOne(d => d.Dept).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FOR_DEPT");

            entity.HasOne(d => d.EmployeeNumNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.EmployeeNum)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("EMPLOYEE_PAID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("VENDOR_PAID");
        });

        modelBuilder.Entity<ExpenseItem>(entity =>
        {
            entity.HasKey(e => new { e.ExpenseId, e.ItemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("expense_items");

            entity.HasIndex(e => e.ItemId, "ITEM_BOUGHT_BY_ZOO");

            entity.Property(e => e.ExpenseId).HasColumnName("Expense_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemCost)
                .HasColumnType("double(10,2)")
                .HasColumnName("Item_Cost");
            entity.Property(e => e.ItemQuantity)
                .HasColumnType("float(6,3)")
                .HasColumnName("Item_Quantity");

            entity.HasOne(d => d.Expense).WithMany(p => p.ExpenseItems)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expense_items_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.ExpenseItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ITEM_BOUGHT_BY_ZOO");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.Destination, "PLACE_KEPT");

            entity.HasIndex(e => e.Supplier, "SUPPLIED_BY");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("Item_ID");
            entity.Property(e => e.Category).HasMaxLength(30);
            entity.Property(e => e.DateLastOrdered).HasColumnName("Date_Last_Ordered");
            entity.Property(e => e.HumidityRequirements)
                .HasColumnType("enum('Dry','Damp','Doesn''t Matter')")
                .HasColumnName("Humidity_Requirements");
            entity.Property(e => e.ItemDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Item_Description");
            entity.Property(e => e.ItemName)
                .HasMaxLength(30)
                .HasColumnName("Item_Name");
            entity.Property(e => e.MeasurementUnits)
                .HasColumnType("enum('kg','L','Units')")
                .HasColumnName("Measurement_Units");
            entity.Property(e => e.Price).HasColumnType("double(10,2)");
            entity.Property(e => e.Quantity).HasColumnType("float(6,3)");
            entity.Property(e => e.RefrigerationNeeds)
                .HasColumnType("enum('None','Room Temp','Refrigerated','Frozen')")
                .HasColumnName("Refrigeration_Needs");
            entity.Property(e => e.ReorderQuantity)
                .HasColumnType("float(6,2)")
                .HasColumnName("Reorder_Quantity");
            entity.Property(e => e.ReorderThreshold)
                .HasColumnType("float(6,2)")
                .HasColumnName("Reorder_Threshold");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Destination)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PLACE_KEPT");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Supplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SUPPLIED_BY");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationNum).HasName("PRIMARY");

            entity.ToTable("location");

            entity.HasIndex(e => e.LocationName, "Location_Name").IsUnique();

            entity.Property(e => e.LocationNum)
                .ValueGeneratedNever()
                .HasColumnName("Location_Num");
            entity.Property(e => e.ClosingTime)
                .HasColumnType("time")
                .HasColumnName("Closing_Time");
            entity.Property(e => e.LocationName)
                .HasMaxLength(45)
                .HasColumnName("Location_Name");
            entity.Property(e => e.MaxCapacity).HasColumnName("Max_Capacity");
            entity.Property(e => e.OpeningTime)
                .HasColumnType("time")
                .HasColumnName("Opening_Time");
        });

        modelBuilder.Entity<LocationDaysClosed>(entity =>
        {
            entity.HasKey(e => new { e.LocationNum, e.DayClosed })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("location_days_closed");

            entity.Property(e => e.LocationNum).HasColumnName("Location_Num");
            entity.Property(e => e.DayClosed).HasColumnName("Day_Closed");

            entity.HasOne(d => d.LocationNumNavigation).WithMany(p => p.LocationDaysCloseds)
                .HasForeignKey(d => d.LocationNum)
                .HasConstraintName("location_days_closed_ibfk_1");
        });

        modelBuilder.Entity<MaintenanceRequest>(entity =>
        {
            entity.HasKey(e => e.TicketNo).HasName("PRIMARY");

            entity.ToTable("maintenance_request");

            entity.HasIndex(e => e.Exhibit, "EXHIBIT_SPECIFIED");

            entity.HasIndex(e => e.Fulfiller, "FULFILLEDED_BY");

            entity.HasIndex(e => e.Location, "LOCATION_SPECIFIED");

            entity.HasIndex(e => e.Requester, "REQUESTED_BY");

            entity.Property(e => e.TicketNo)
                .ValueGeneratedNever()
                .HasColumnName("Ticket_No");
            entity.Property(e => e.Details).HasColumnType("tinytext");
            entity.Property(e => e.TimeFulfilled)
                .HasColumnType("datetime")
                .HasColumnName("Time_Fulfilled");
            entity.Property(e => e.TimeRequested)
                .HasColumnType("datetime")
                .HasColumnName("Time_Requested");
            entity.Property(e => e.Urgency).HasColumnType("enum('1','2','3','4','5')");

            entity.HasOne(d => d.ExhibitNavigation).WithMany(p => p.MaintenanceRequests)
                .HasForeignKey(d => d.Exhibit)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("EXHIBIT_SPECIFIED");

            entity.HasOne(d => d.FulfillerNavigation).WithMany(p => p.MaintenanceRequestFulfillerNavigations)
                .HasForeignKey(d => d.Fulfiller)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FULFILLEDED_BY");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.MaintenanceRequests)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("LOCATION_SPECIFIED");

            entity.HasOne(d => d.RequesterNavigation).WithMany(p => p.MaintenanceRequestRequesterNavigations)
                .HasForeignKey(d => d.Requester)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("REQUESTED_BY");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipLevel).HasName("PRIMARY");

            entity.ToTable("membership");

            entity.Property(e => e.MembershipLevel)
                .HasMaxLength(20)
                .HasColumnName("Membership_Level");
            entity.Property(e => e.Benefits).HasColumnType("mediumtext");
            entity.Property(e => e.MembershipFee)
                .HasComment("Yearly cost")
                .HasColumnType("float(5,2)")
                .HasColumnName("Membership_Fee");
        });

        modelBuilder.Entity<Occupation>(entity =>
        {
            entity.HasKey(e => e.JobTitle).HasName("PRIMARY");

            entity.ToTable("occupation");

            entity.Property(e => e.JobTitle)
                .HasMaxLength(30)
                .HasColumnName("Job_Title");
            entity.Property(e => e.JobDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Job_Description");
            entity.Property(e => e.LowerSalaryRange)
                .HasColumnType("double(8,2)")
                .HasColumnName("Lower_Salary_Range");
            entity.Property(e => e.QualificationsRequired)
                .HasColumnType("mediumtext")
                .HasColumnName("Qualifications_required");
            entity.Property(e => e.UpperSalaryRange)
                .HasColumnType("double(8,2)")
                .HasColumnName("Upper_Salary_Range");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.ToTable("room");

            entity.HasIndex(e => e.LocationNum, "LOCATED_IN");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("Room_ID");
            entity.Property(e => e.LocationNum).HasColumnName("Location_Num");
            entity.Property(e => e.RoomFunction)
                .HasMaxLength(45)
                .HasColumnName("Room_Function");
            entity.Property(e => e.RoomName)
                .HasMaxLength(45)
                .HasColumnName("Room_Name");

            entity.HasOne(d => d.LocationNumNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.LocationNum)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("LOCATED_IN");
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => new { e.SpeciesGenus, e.SpeciesSpecies })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("species");

            entity.HasIndex(e => e.ExhibitNo, "IS_CONTAINED_IN");

            entity.Property(e => e.SpeciesGenus)
                .HasMaxLength(30)
                .HasColumnName("Species_Genus");
            entity.Property(e => e.SpeciesSpecies)
                .HasMaxLength(30)
                .HasColumnName("Species_Species");
            entity.Property(e => e.ActiveHours)
                .HasColumnType("enum('Nocturnal','Diurnal','Any Time')")
                .HasColumnName("Active_Hours");
            entity.Property(e => e.CommonName)
                .HasMaxLength(45)
                .HasColumnName("Common_Name");
            entity.Property(e => e.ConservationStatus)
                .HasColumnType("enum('DD','LC','NT','VU','EN','CR','EW','EX')")
                .HasColumnName("Conservation_Status");
            entity.Property(e => e.Diet).HasMaxLength(50);
            entity.Property(e => e.ExhibitNo).HasColumnName("Exhibit_No");
            entity.Property(e => e.Humidity)
                .HasComment("Humidity in percentage")
                .HasColumnType("float(3,1)");
            entity.Property(e => e.LifeExpectancy)
                .HasColumnType("float(3,3)")
                .HasColumnName("Life_Expectancy");
            entity.Property(e => e.LowerTemperature)
                .HasComment("Temperature in Fahrenheit")
                .HasColumnType("float(4,1)")
                .HasColumnName("Lower_Temperature");
            entity.Property(e => e.NormalBodyTemperature)
                .HasComment("Body Temperature in Fahrenheit")
                .HasColumnType("float(4,1)")
                .HasColumnName("Normal_Body_Temperature");
            entity.Property(e => e.RegionsFound)
                .HasMaxLength(20)
                .HasColumnName("Regions_Found");
            entity.Property(e => e.SpeciesClass)
                .HasMaxLength(30)
                .HasColumnName("Species_Class");
            entity.Property(e => e.SpeciesFamily)
                .HasMaxLength(30)
                .HasColumnName("Species_Family");
            entity.Property(e => e.SpeciesInfo)
                .HasColumnType("mediumtext")
                .HasColumnName("Species_Info");
            entity.Property(e => e.SpeciesKingdom)
                .HasMaxLength(20)
                .HasColumnName("Species_Kingdom");
            entity.Property(e => e.SpeciesOrder)
                .HasMaxLength(30)
                .HasColumnName("Species_Order");
            entity.Property(e => e.SpeciesPhylum)
                .HasMaxLength(30)
                .HasColumnName("Species_Phylum");
            entity.Property(e => e.UpperTemperature)
                .HasComment("Temperature in Fahrenheit")
                .HasColumnType("float(4,1)")
                .HasColumnName("Upper_Temperature");

            entity.HasOne(d => d.ExhibitNoNavigation).WithMany(p => p.Species)
                .HasForeignKey(d => d.ExhibitNo)
                .HasConstraintName("IS_CONTAINED_IN");
        });

        modelBuilder.Entity<TotalTickeSell>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_ticke_sells");

            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.TotalSells)
                .HasPrecision(32)
                .HasColumnName("Total_sells");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PRIMARY");

            entity.ToTable("vendor");

            entity.Property(e => e.VendorId)
                .ValueGeneratedNever()
                .HasColumnName("Vendor_ID");
            entity.Property(e => e.ContractInformation)
                .HasColumnType("mediumtext")
                .HasColumnName("Contract_Information");
            entity.Property(e => e.ProductsAndServices)
                .HasColumnType("mediumtext")
                .HasColumnName("Products_and_Services");
            entity.Property(e => e.VendorName)
                .HasMaxLength(45)
                .HasColumnName("Vendor_Name");
        });

        modelBuilder.Entity<VeterinaryVisit>(entity =>
        {
            entity.HasKey(e => e.VetVisitId).HasName("PRIMARY");

            entity.ToTable("veterinary_visit");

            entity.HasIndex(e => e.Animal, "ANIMAL_TREATED");

            entity.Property(e => e.VetVisitId)
                .ValueGeneratedNever()
                .HasColumnName("Vet_Visit_ID");
            entity.Property(e => e.AnimalCondition)
                .HasColumnType("tinytext")
                .HasColumnName("Animal_Condition");
            entity.Property(e => e.AnimalTreatment)
                .HasColumnType("mediumtext")
                .HasColumnName("Animal_Treatment");
            entity.Property(e => e.FollowupNeeded).HasColumnName("Followup_Needed");
            entity.Property(e => e.TimeAdmitted)
                .HasColumnType("datetime")
                .HasColumnName("Time_Admitted");
            entity.Property(e => e.TimeDischarged)
                .HasColumnType("datetime")
                .HasColumnName("Time_Discharged");
            entity.Property(e => e.TimeScheduled)
                .HasColumnType("datetime")
                .HasColumnName("Time_Scheduled");
            entity.Property(e => e.Urgency).HasColumnType("enum('Resuscitation','Emergent Care','Urgent Care','Nonurgent Care','Convenient Care')");

            entity.HasOne(d => d.AnimalNavigation).WithMany(p => p.VeterinaryVisits)
                .HasForeignKey(d => d.Animal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ANIMAL_TREATED");

            entity.HasMany(d => d.Vets).WithMany(p => p.VetVisits)
                .UsingEntity<Dictionary<string, object>>(
                    "VeterinaryVisitVetId",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("VET_ATTENDED"),
                    l => l.HasOne<VeterinaryVisit>().WithMany()
                        .HasForeignKey("VetVisitId")
                        .HasConstraintName("veterinary_visit_vet_id_ibfk_1"),
                    j =>
                    {
                        j.HasKey("VetVisitId", "VetId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("veterinary_visit_vet_id");
                        j.HasIndex(new[] { "VetId" }, "VET_ATTENDED");
                        j.IndexerProperty<int>("VetVisitId").HasColumnName("Vet_Visit_ID");
                        j.IndexerProperty<int>("VetId").HasColumnName("Vet_ID");
                    });
        });

        modelBuilder.Entity<ZooEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("zoo_event");

            entity.HasIndex(e => e.EventLocation, "EVENT_LOCATION");

            entity.HasIndex(e => e.AnimalProgramNo, "IS_ANIMAL_PROGRAM");

            entity.HasIndex(e => e.EducationalProgramNo, "IS_EDUCATION_PROGRAM");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("Event_ID");
            entity.Property(e => e.AdmissionPrice)
                .HasColumnType("float(5,2)")
                .HasColumnName("Admission_Price");
            entity.Property(e => e.AnimalProgramNo).HasColumnName("Animal_Program_No");
            entity.Property(e => e.EducationalProgramNo).HasColumnName("Educational_Program_No");
            entity.Property(e => e.EventDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Event_Description");
            entity.Property(e => e.EventLocation).HasColumnName("Event_Location");
            entity.Property(e => e.EventName)
                .HasMaxLength(45)
                .HasColumnName("Event_Name");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("Event_Time");
            entity.Property(e => e.EventType)
                .HasColumnType("enum('Animal Entertainment','Educational','Tour','Other')")
                .HasColumnName("Event_Type");
            entity.Property(e => e.HostEmail)
                .HasMaxLength(45)
                .HasColumnName("Host_Email");
            entity.Property(e => e.HostName)
                .HasMaxLength(45)
                .HasColumnName("Host_Name");
            entity.Property(e => e.HostPhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Host_Phone_Num");
            entity.Property(e => e.NumberAttending).HasColumnName("Number_Attending");
            entity.Property(e => e.RegistrationDeadline).HasColumnName("Registration_Deadline");

            entity.HasOne(d => d.AnimalProgramNoNavigation).WithMany(p => p.ZooEvents)
                .HasForeignKey(d => d.AnimalProgramNo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_ANIMAL_PROGRAM");

            entity.HasOne(d => d.EducationalProgramNoNavigation).WithMany(p => p.ZooEvents)
                .HasForeignKey(d => d.EducationalProgramNo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_EDUCATION_PROGRAM");

            entity.HasOne(d => d.EventLocationNavigation).WithMany(p => p.ZooEvents)
                .HasForeignKey(d => d.EventLocation)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("EVENT_LOCATION");

            entity.HasMany(d => d.Animals).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "ZooEventAnimalsInvolved",
                    r => r.HasOne<Animal>().WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ANIMAL_INVOLVED"),
                    l => l.HasOne<ZooEvent>().WithMany()
                        .HasForeignKey("EventId")
                        .HasConstraintName("zoo_event_animals_involved_ibfk_1"),
                    j =>
                    {
                        j.HasKey("EventId", "AnimalId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("zoo_event_animals_involved");
                        j.HasIndex(new[] { "AnimalId" }, "ANIMAL_INVOLVED");
                        j.IndexerProperty<int>("EventId").HasColumnName("Event_ID");
                        j.IndexerProperty<int>("AnimalId").HasColumnName("Animal_ID");
                    });

            entity.HasMany(d => d.Employees).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "ZooEventStaffInvolved",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EMPLOYEE_INVOLVED"),
                    l => l.HasOne<ZooEvent>().WithMany()
                        .HasForeignKey("EventId")
                        .HasConstraintName("zoo_event_staff_involved_ibfk_1"),
                    j =>
                    {
                        j.HasKey("EventId", "EmployeeId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("zoo_event_staff_involved");
                        j.HasIndex(new[] { "EmployeeId" }, "EMPLOYEE_INVOLVED");
                        j.IndexerProperty<int>("EventId").HasColumnName("Event_ID");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("Employee_ID");
                    });
        });

        modelBuilder.Entity<ZooEventRequiredInventory>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.ItemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("zoo_event_required_inventory");

            entity.HasIndex(e => e.ItemId, "ITEM_REQUIRED");

            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemQuantity)
                .HasDefaultValueSql("'1.000'")
                .HasColumnType("float(6,3)")
                .HasColumnName("Item_Quantity");

            entity.HasOne(d => d.Event).WithMany(p => p.ZooEventRequiredInventories)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("zoo_event_required_inventory_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.ZooEventRequiredInventories)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ITEM_REQUIRED");
        });

        modelBuilder.Entity<ZooTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("zoo_transaction");

            entity.HasIndex(e => e.Discount, "HAS_DISCOUNT");

            entity.HasIndex(e => e.SellerId, "SOLD_BY");

            entity.HasIndex(e => e.Customer, "SOLD_TO");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("Transaction_ID");
            entity.Property(e => e.DateAndTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_and_Time");
            entity.Property(e => e.Discount).HasMaxLength(30);
            entity.Property(e => e.SellerId).HasColumnName("Seller_ID");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.ZooTransactions)
                .HasForeignKey(d => d.Customer)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SOLD_TO");

            entity.HasOne(d => d.DiscountNavigation).WithMany(p => p.ZooTransactions)
                .HasForeignKey(d => d.Discount)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HAS_DISCOUNT");

            entity.HasOne(d => d.Seller).WithMany(p => p.ZooTransactions)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SOLD_BY");
        });

        modelBuilder.Entity<ZooTransactionEventTicket>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.TransactionId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("zoo_transaction_event_tickets");

            entity.HasIndex(e => e.TransactionId, "Transaction_ID");

            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.TicketQuantity).HasColumnName("Ticket_Quantity");

            entity.HasOne(d => d.Event).WithMany(p => p.ZooTransactionEventTickets)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FOR_EVENT");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ZooTransactionEventTickets)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("zoo_transaction_event_tickets_ibfk_1");
        });

        modelBuilder.Entity<ZooTransactionItem>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.ItemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("zoo_transaction_items");

            entity.HasIndex(e => e.ItemId, "ITEM_BOUGHT");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemQuantity)
                .HasColumnType("float(6,3)")
                .HasColumnName("Item_Quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.ZooTransactionItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ITEM_BOUGHT");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ZooTransactionItems)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("zoo_transaction_items_ibfk_1");
        });

        modelBuilder.Entity<ZooUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("zoo_user");

            entity.HasIndex(e => e.CustomerId, "IS_CUSTOMER");

            entity.HasIndex(e => e.EmployeeId, "IS_EMPLOYEE");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("User_ID");
            entity.Property(e => e.AuthenticationKey).HasColumnName("Authentication_Key");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .HasColumnName("User_Name");
            entity.Property(e => e.UserType)
                .HasColumnType("enum('Admin','Employee','Customer','Default')")
                .HasColumnName("User_Type");

            entity.HasOne(d => d.Customer).WithMany(p => p.ZooUsers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_CUSTOMER");

            entity.HasOne(d => d.Employee).WithMany(p => p.ZooUsers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_EMPLOYEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
