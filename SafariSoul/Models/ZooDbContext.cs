using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SafariSoul.Models;

public partial class ZooDbContext : DbContext
{
    public ZooDbContext()
    {
    }

    public ZooDbContext(DbContextOptions<ZooDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalCareProgram> AnimalCarePrograms { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<EducationProgram> EducationPrograms { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseItem> ExpenseItems { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<OperatingHour> OperatingHours { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VeterinaryVisit> VeterinaryVisits { get; set; }

    public virtual DbSet<ZooEvent> ZooEvents { get; set; }

    public virtual DbSet<ZooEventAnimalsInvolved> ZooEventAnimalsInvolveds { get; set; }

    public virtual DbSet<ZooEventStaffInvolved> ZooEventStaffInvolveds { get; set; }

    public virtual DbSet<ZooTransaction> ZooTransactions { get; set; }

    public virtual DbSet<ZooTransactionEventTicket> ZooTransactionEventTickets { get; set; }

    public virtual DbSet<ZooTransactionItem> ZooTransactionItems { get; set; }

    public virtual DbSet<ZooUser> ZooUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=zoo-db-server.mysql.database.azure.com;userid=audace;password=37PE&CWYy9e@;database=zoo_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PRIMARY");

            entity.ToTable("animal");

            entity.HasIndex(e => e.Mother, "IS_CHILD_OF_1");

            entity.HasIndex(e => e.Father, "IS_CHILD_OF_2");

            entity.HasIndex(e => e.SpeciesId, "IS_SPECIES");

            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.AnimalName)
                .HasMaxLength(30)
                .HasColumnName("Animal_Name");
            entity.Property(e => e.CauseOfDeath)
                .HasColumnType("tinytext")
                .HasColumnName("Cause_of_Death");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_Birth");
            entity.Property(e => e.DateOfDeath)
                .HasColumnType("datetime")
                .HasColumnName("Date_of_Death");
            entity.Property(e => e.DietaryRestrictions)
                .HasColumnType("tinytext")
                .HasColumnName("Dietary_Restrictions");
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female')");
            entity.Property(e => e.Recreation).HasColumnType("tinytext");
            entity.Property(e => e.SpeciesId).HasColumnName("Species_ID");
            entity.Property(e => e.UniqueDescriptors)
                .HasColumnType("tinytext")
                .HasColumnName("Unique_Descriptors");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.FatherNavigation).WithMany(p => p.InverseFatherNavigation)
                .HasForeignKey(d => d.Father)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_CHILD_OF_2");

            entity.HasOne(d => d.MotherNavigation).WithMany(p => p.InverseMotherNavigation)
                .HasForeignKey(d => d.Mother)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_CHILD_OF_1");

            entity.HasOne(d => d.Species).WithMany(p => p.Animals)
                .HasForeignKey(d => d.SpeciesId)
                .HasConstraintName("IS_SPECIES");
        });

        modelBuilder.Entity<AnimalCareProgram>(entity =>
        {
            entity.HasKey(e => e.AnimalProgramId).HasName("PRIMARY");

            entity.ToTable("animal_care_program");

            entity.HasIndex(e => e.ProgramName, "Program_Name").IsUnique();

            entity.Property(e => e.AnimalProgramId).HasColumnName("Animal_Program_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ProgramDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Program_Description");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(45)
                .HasColumnName("Program_Name");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.MembershipLevel, "IS_MEMBER");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.Address).HasMaxLength(45);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
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
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.MembershipLevelNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.MembershipLevel)
                .HasConstraintName("IS_MEMBER");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptName).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.LocationId, "DEPT_IN");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.ManagerId, "Manager_ID").IsUnique();

            entity.HasIndex(e => e.PhoneNum, "Phone_Num").IsUnique();

            entity.Property(e => e.DeptName)
                .HasMaxLength(30)
                .HasColumnName("Dept_Name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.LocationId).HasColumnName("Location_ID");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_ID");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Phone_Num");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Location).WithMany(p => p.Departments)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("DEPT_IN");

            entity.HasOne(d => d.Manager).WithOne(p => p.Department)
                .HasForeignKey<Department>(d => d.ManagerId)
                .HasConstraintName("MANAGED_BY");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(e => e.DependentId).HasName("PRIMARY");

            entity.ToTable("dependent");

            entity.HasIndex(e => e.EmployeeId, "DEPENDENT_ON");

            entity.Property(e => e.DependentId).HasColumnName("Dependent_ID");
            entity.Property(e => e.Address).HasMaxLength(45);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.Fname).HasMaxLength(20);
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female')");
            entity.Property(e => e.Lname).HasMaxLength(20);
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Phone_Num");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Employee).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DEPENDENT_ON");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PRIMARY");

            entity.ToTable("donation");

            entity.HasIndex(e => e.DonorId, "IS_DONOR");

            entity.Property(e => e.DonationId).HasColumnName("Donation_ID");
            entity.Property(e => e.AmountDonated).HasColumnName("Amount_Donated");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateDonated).HasColumnName("Date_Donated");
            entity.Property(e => e.DonationPurpose)
                .HasColumnType("tinytext")
                .HasColumnName("Donation_Purpose");
            entity.Property(e => e.DonorId).HasColumnName("Donor_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Donor).WithMany(p => p.Donations)
                .HasForeignKey(d => d.DonorId)
                .HasConstraintName("IS_DONOR");
        });

        modelBuilder.Entity<EducationProgram>(entity =>
        {
            entity.HasKey(e => e.EducationProgramId).HasName("PRIMARY");

            entity.ToTable("education_program");

            entity.Property(e => e.EducationProgramId).HasColumnName("Education_Program_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ProgramDescription)
                .HasColumnType("mediumtext")
                .HasColumnName("Program_Description");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(45)
                .HasColumnName("Program_Name");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.SupId, "SUPERVISED_BY");

            entity.HasIndex(e => e.DeptName, "WORKS_IN");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateJoined).HasColumnName("Date_Joined");
            entity.Property(e => e.DateLeft).HasColumnName("Date_Left");
            entity.Property(e => e.DeptName)
                .HasMaxLength(30)
                .HasColumnName("Dept_Name");
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
            entity.Property(e => e.Lname).HasMaxLength(20);
            entity.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.MobilePhoneNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Mobile_Phone_Num");
            entity.Property(e => e.Occupation).HasMaxLength(30);
            entity.Property(e => e.Salary).HasColumnType("double(8,2)");
            entity.Property(e => e.SickDaysLeft).HasColumnName("Sick_Days_Left");
            entity.Property(e => e.SupId).HasColumnName("Sup_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VacationDaysLeft).HasColumnName("Vacation_Days_Left");

            entity.HasOne(d => d.DeptNameNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptName)
                .HasConstraintName("WORKS_IN");

            entity.HasOne(d => d.Sup).WithMany(p => p.InverseSup)
                .HasForeignKey(d => d.SupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SUPERVISED_BY");
        });

        modelBuilder.Entity<EmployeeShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PRIMARY");

            entity.ToTable("employee_shift");

            entity.HasIndex(e => e.EmployeeId, "employee_shift_ibfk_1");

            entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.LunchEnd)
                .HasColumnType("datetime")
                .HasColumnName("Lunch_End");
            entity.Property(e => e.LunchStart)
                .HasColumnType("datetime")
                .HasColumnName("Lunch_Start");
            entity.Property(e => e.ShiftEnd)
                .HasColumnType("datetime")
                .HasColumnName("Shift_End");
            entity.Property(e => e.ShiftStart)
                .HasColumnType("datetime")
                .HasColumnName("Shift_Start");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeShifts)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("employee_shift_ibfk_1");
        });

        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.HasKey(e => e.ExhibitId).HasName("PRIMARY");

            entity.ToTable("exhibit");

            entity.HasIndex(e => e.MealContent, "IS_FOOD");

            entity.HasIndex(e => e.Location, "IS_LOCATED_IN");

            entity.HasIndex(e => e.Zookeeper, "IS_THIS_EMPLOYEE");

            entity.Property(e => e.ExhibitId).HasColumnName("Exhibit_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExhibitName)
                .HasMaxLength(45)
                .HasColumnName("Exhibit_Name");
            entity.Property(e => e.FeedingTime)
                .HasColumnType("time")
                .HasColumnName("Feeding_Time");
            entity.Property(e => e.Humidity).HasColumnType("float(3,1)");
            entity.Property(e => e.IsIndoors).HasColumnName("Is_Indoors");
            entity.Property(e => e.MealContent).HasColumnName("Meal_Content");
            entity.Property(e => e.MealQuantity).HasColumnName("Meal_Quantity");
            entity.Property(e => e.NormalTemperature)
                .HasColumnType("float(4,1)")
                .HasColumnName("Normal_Temperature");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("IS_LOCATED_IN");

            entity.HasOne(d => d.MealContentNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.MealContent)
                .HasConstraintName("IS_FOOD");

            entity.HasOne(d => d.ZookeeperNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.Zookeeper)
                .HasConstraintName("IS_THIS_EMPLOYEE");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PRIMARY");

            entity.ToTable("expense");

            entity.HasIndex(e => e.EmployeeId, "EMPLOYEE_PAID");

            entity.HasIndex(e => e.VendorId, "VENDOR_PAID");

            entity.Property(e => e.ExpenseId).HasColumnName("Expense_ID");
            entity.Property(e => e.Category).HasColumnType("enum('Employee','Vendor')");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.ExpenseAccount)
                .HasMaxLength(20)
                .HasColumnName("Expense_Account");
            entity.Property(e => e.ExpenseAmount)
                .HasColumnType("double(10,2)")
                .HasColumnName("Expense_Amount");
            entity.Property(e => e.ExpenseTime).HasColumnName("Expense_Time");
            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VendorId).HasColumnName("Vendor_ID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("EMPLOYEE_PAID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("VENDOR_PAID");
        });

        modelBuilder.Entity<ExpenseItem>(entity =>
        {
            entity.HasKey(e => e.MultiItemsId).HasName("PRIMARY");

            entity.ToTable("expense_items");

            entity.HasIndex(e => e.ItemId, "ITEM_BOUGHT");

            entity.HasIndex(e => e.ExpenseId, "expense_items_ibfk_1");

            entity.Property(e => e.MultiItemsId).HasColumnName("Multi_Items_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpenseId).HasColumnName("Expense_ID");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemQuantity).HasColumnName("Item_Quantity");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Expense).WithMany(p => p.ExpenseItems)
                .HasForeignKey(d => d.ExpenseId)
                .HasConstraintName("expense_items_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.ExpenseItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("ITEM_BOUGHT");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.Destination, "PLACE_KEPT");

            entity.HasIndex(e => e.Supplier, "SUPPLIED_BY");

            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DateLastOrdered).HasColumnName("Date_Last_Ordered");
            entity.Property(e => e.HumidityRequirements)
                .HasColumnType("enum('Dry','Damp','Doesn''t Matter')")
                .HasColumnName("Humidity_Requirements");
            entity.Property(e => e.ItemName)
                .HasMaxLength(30)
                .HasColumnName("Item_Name");
            entity.Property(e => e.MeasurementUnits)
                .HasColumnType("enum('Kg','L','Units')")
                .HasColumnName("Measurement_Units");
            entity.Property(e => e.Price).HasColumnType("double(10,2)");
            entity.Property(e => e.RefrigerationNeeds)
                .HasColumnType("enum('None','Room Temp','Refrigerated','Frozen')")
                .HasColumnName("Refrigeration_Needs");
            entity.Property(e => e.ReorderQuantity).HasColumnName("Reorder_Quantity");
            entity.Property(e => e.ReorderThreshold).HasColumnName("Reorder_Threshold");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Destination)
                .HasConstraintName("PLACE_KEPT");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Supplier)
                .HasConstraintName("SUPPLIED_BY");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PRIMARY");

            entity.ToTable("location");

            entity.HasIndex(e => e.LocationName, "Location_Name").IsUnique();

            entity.Property(e => e.LocationId).HasColumnName("Location_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.LocationName)
                .HasMaxLength(45)
                .HasColumnName("Location_Name");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MaintenanceRequest>(entity =>
        {
            entity.HasKey(e => e.TicketNo).HasName("PRIMARY");

            entity.ToTable("maintenance_request");

            entity.HasIndex(e => e.Exhibit, "EXHIBIT_SPECIFIED");

            entity.HasIndex(e => e.Location, "LOCATION_SPECIFIED");

            entity.Property(e => e.TicketNo).HasColumnName("Ticket_No");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Details).HasColumnType("tinytext");
            entity.Property(e => e.TimeFulfilled)
                .HasColumnType("datetime")
                .HasColumnName("Time_Fulfilled");
            entity.Property(e => e.TimeRequested)
                .HasColumnType("datetime")
                .HasColumnName("Time_Requested");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Urgency).HasColumnType("enum('1','2','3','4','5')");

            entity.HasOne(d => d.ExhibitNavigation).WithMany(p => p.MaintenanceRequests)
                .HasForeignKey(d => d.Exhibit)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("EXHIBIT_SPECIFIED");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.MaintenanceRequests)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("LOCATION_SPECIFIED");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipLevel).HasName("PRIMARY");

            entity.ToTable("membership");

            entity.Property(e => e.MembershipLevel)
                .HasMaxLength(20)
                .HasColumnName("Membership_Level");
            entity.Property(e => e.Benefits).HasColumnType("mediumtext");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.MembershipFee)
                .HasComment("Yearly cost")
                .HasColumnType("float(5,2)")
                .HasColumnName("Membership_Fee");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<OperatingHour>(entity =>
        {
            entity.HasKey(e => e.DayId).HasName("PRIMARY");

            entity.ToTable("operating_hours");

            entity.Property(e => e.DayId).HasColumnName("Day_ID");
            entity.Property(e => e.ClosingTime)
                .HasColumnType("time")
                .HasColumnName("Closing_Time");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DayOfWeek)
                .HasColumnType("enum('Mon','Tues','Wed','Thurs','Fri','Sat','Sun')")
                .HasColumnName("Day_Of_Week");
            entity.Property(e => e.OpeningTime)
                .HasColumnType("time")
                .HasColumnName("Opening_Time");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.SpeciesId).HasName("PRIMARY");

            entity.ToTable("species");

            entity.HasIndex(e => e.ExhibitId, "IS_CONTAINED_IN");

            entity.Property(e => e.SpeciesId).HasColumnName("Species_ID");
            entity.Property(e => e.ActiveHours)
                .HasColumnType("enum('Nocturnal','Diurnal','Any Time')")
                .HasColumnName("Active_Hours");
            entity.Property(e => e.Class).HasMaxLength(30);
            entity.Property(e => e.CommonName)
                .HasMaxLength(45)
                .HasColumnName("Common_Name");
            entity.Property(e => e.ConservationStatus)
                .HasColumnType("enum('DD','LC','NT','VU','EN','CR','EW','EX')")
                .HasColumnName("Conservation_Status");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Diet).HasMaxLength(50);
            entity.Property(e => e.ExhibitId).HasColumnName("Exhibit_ID");
            entity.Property(e => e.Family).HasMaxLength(30);
            entity.Property(e => e.Genus).HasMaxLength(30);
            entity.Property(e => e.Humidity).HasColumnType("float(3,1)");
            entity.Property(e => e.Kingdom).HasMaxLength(20);
            entity.Property(e => e.LifeExpectancy).HasColumnName("Life_Expectancy");
            entity.Property(e => e.NormalBodyTemperature)
                .HasColumnType("float(4,1)")
                .HasColumnName("Normal_Body_Temperature");
            entity.Property(e => e.Order)
                .HasMaxLength(30)
                .HasColumnName("_Order");
            entity.Property(e => e.Phylum).HasMaxLength(30);
            entity.Property(e => e.RegionsFound)
                .HasMaxLength(20)
                .HasColumnName("Regions_Found");
            entity.Property(e => e.Species1)
                .HasMaxLength(30)
                .HasColumnName("Species");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Exhibit).WithMany(p => p.Species)
                .HasForeignKey(d => d.ExhibitId)
                .HasConstraintName("IS_CONTAINED_IN");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PRIMARY");

            entity.ToTable("vendor");

            entity.Property(e => e.VendorId).HasColumnName("Vendor_ID");
            entity.Property(e => e.ContractInformation)
                .HasColumnType("mediumtext")
                .HasColumnName("Contract_Information");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductsAndServices)
                .HasColumnType("mediumtext")
                .HasColumnName("Products_and_Services");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VendorName)
                .HasMaxLength(45)
                .HasColumnName("Vendor_Name");
        });

        modelBuilder.Entity<VeterinaryVisit>(entity =>
        {
            entity.HasKey(e => e.VetVisitId).HasName("PRIMARY");

            entity.ToTable("veterinary_visit");

            entity.HasIndex(e => e.Animal, "ANIMAL_TREATED");

            entity.HasIndex(e => e.VetId, "veterinary_visit_ibfk_1");

            entity.Property(e => e.VetVisitId).HasColumnName("Vet_Visit_ID");
            entity.Property(e => e.AnimalCondition)
                .HasColumnType("tinytext")
                .HasColumnName("Animal_Condition");
            entity.Property(e => e.AnimalTreatment)
                .HasColumnType("mediumtext")
                .HasColumnName("Animal_Treatment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
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
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Urgency).HasColumnType("enum('1','2','3','4','5')");
            entity.Property(e => e.VetId).HasColumnName("Vet_ID");

            entity.HasOne(d => d.AnimalNavigation).WithMany(p => p.VeterinaryVisits)
                .HasForeignKey(d => d.Animal)
                .HasConstraintName("ANIMAL_TREATED");

            entity.HasOne(d => d.Vet).WithMany(p => p.VeterinaryVisits)
                .HasForeignKey(d => d.VetId)
                .HasConstraintName("veterinary_visit_ibfk_1");
        });

        modelBuilder.Entity<ZooEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("zoo_event");

            entity.HasIndex(e => e.EventLocationId, "EVENT_LOCATION");

            entity.HasIndex(e => e.AnimalProgramId, "IS_ANIMAL_PROGRAM");

            entity.HasIndex(e => e.EducationalProgramId, "IS_EDUCATION_PROGRAM");

            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.AdmissionPrice)
                .HasColumnType("float(5,2)")
                .HasColumnName("Admission_Price");
            entity.Property(e => e.AnimalProgramId).HasColumnName("Animal_Program_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EducationalProgramId).HasColumnName("Educational_Program_ID");
            entity.Property(e => e.EventLocationId).HasColumnName("Event_Location_ID");
            entity.Property(e => e.EventName)
                .HasMaxLength(45)
                .HasColumnName("Event_Name");
            entity.Property(e => e.EventTime)
                .HasColumnType("datetime")
                .HasColumnName("Event_Time");
            entity.Property(e => e.RegistrationDeadline).HasColumnName("Registration_Deadline");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AnimalProgram).WithMany(p => p.ZooEvents)
                .HasForeignKey(d => d.AnimalProgramId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_ANIMAL_PROGRAM");

            entity.HasOne(d => d.EducationalProgram).WithMany(p => p.ZooEvents)
                .HasForeignKey(d => d.EducationalProgramId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("IS_EDUCATION_PROGRAM");

            entity.HasOne(d => d.EventLocation).WithMany(p => p.ZooEvents)
                .HasForeignKey(d => d.EventLocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("EVENT_LOCATION");
        });

        modelBuilder.Entity<ZooEventAnimalsInvolved>(entity =>
        {
            entity.HasKey(e => e.MultiAnimalId).HasName("PRIMARY");

            entity.ToTable("zoo_event_animals_involved");

            entity.HasIndex(e => e.AnimalId, "ANIMAL_INVOLVED");

            entity.HasIndex(e => e.EventId, "zoo_event_animals_involved_ibfk_1");

            entity.Property(e => e.MultiAnimalId).HasColumnName("Multi_Animal_ID");
            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Animal).WithMany(p => p.ZooEventAnimalsInvolveds)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("ANIMAL_INVOLVED");

            entity.HasOne(d => d.Event).WithMany(p => p.ZooEventAnimalsInvolveds)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("zoo_event_animals_involved_ibfk_1");
        });

        modelBuilder.Entity<ZooEventStaffInvolved>(entity =>
        {
            entity.HasKey(e => e.MultiStaffId).HasName("PRIMARY");

            entity.ToTable("zoo_event_staff_involved");

            entity.HasIndex(e => e.EmployeeId, "EMPLOYEE_INVOLVED");

            entity.HasIndex(e => e.EventId, "zoo_event_staff_involved_ibfk_1");

            entity.Property(e => e.MultiStaffId).HasColumnName("Multi_Staff_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Employee).WithMany(p => p.ZooEventStaffInvolveds)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("EMPLOYEE_INVOLVED");

            entity.HasOne(d => d.Event).WithMany(p => p.ZooEventStaffInvolveds)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("zoo_event_staff_involved_ibfk_1");
        });

        modelBuilder.Entity<ZooTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("zoo_transaction");

            entity.HasIndex(e => e.LocationId, "LOCATION_SOLD");

            entity.HasIndex(e => e.SellerId, "SOLD_BY");

            entity.HasIndex(e => e.CustomerId, "SOLD_TO");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.DateAndTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_and_Time");
            entity.Property(e => e.LocationId).HasColumnName("Location_ID");
            entity.Property(e => e.SellerId).HasColumnName("Seller_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.ZooTransactions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("SOLD_TO");

            entity.HasOne(d => d.Location).WithMany(p => p.ZooTransactions)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("LOCATION_SOLD");

            entity.HasOne(d => d.Seller).WithMany(p => p.ZooTransactions)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("SOLD_BY");
        });

        modelBuilder.Entity<ZooTransactionEventTicket>(entity =>
        {
            entity.HasKey(e => e.MultiEventTicketsId).HasName("PRIMARY");

            entity.ToTable("zoo_transaction_event_tickets");

            entity.HasIndex(e => e.EventId, "FOR_EVENT");

            entity.HasIndex(e => e.TransactionId, "zoo_transaction_event_tickets_ibfk_1");

            entity.Property(e => e.MultiEventTicketsId).HasColumnName("Multi_Event_Tickets_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.TicketQuantity).HasColumnName("Ticket_Quantity");
            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Event).WithMany(p => p.ZooTransactionEventTickets)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FOR_EVENT");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ZooTransactionEventTickets)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("zoo_transaction_event_tickets_ibfk_1");
        });

        modelBuilder.Entity<ZooTransactionItem>(entity =>
        {
            entity.HasKey(e => e.MultiItemsId).HasName("PRIMARY");

            entity.ToTable("zoo_transaction_items");

            entity.HasIndex(e => e.ItemId, "ITEM_WAS_BOUGHT");

            entity.HasIndex(e => e.TransactionId, "zoo_transaction_items_ibfk_1");

            entity.Property(e => e.MultiItemsId).HasColumnName("Multi_Items_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemQuantity).HasColumnName("Item_Quantity");
            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Item).WithMany(p => p.ZooTransactionItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("ITEM_WAS_BOUGHT");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ZooTransactionItems)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("zoo_transaction_items_ibfk_1");
        });

        modelBuilder.Entity<ZooUser>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PRIMARY");

            entity.ToTable("zoo_user");

            entity.HasIndex(e => e.CustomerId, "IS_CUSTOMER");

            entity.HasIndex(e => e.EmployeeId, "IS_EMPLOYEE");

            entity.Property(e => e.UserName)
                .HasMaxLength(45)
                .HasColumnName("User_Name");
            entity.Property(e => e.AuthenticationKey)
                .HasMaxLength(45)
                .HasColumnName("Authentication_Key");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
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
