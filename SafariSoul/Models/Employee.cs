using System;
using System.Collections.Generic;


namespace SafariSoul.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Fname { get; set; } = null!;

    public string? Minit { get; set; }

    public string Lname { get; set; } = null!;

    public DateOnly? Bdate { get; set; }

    public string? TrainingAndCerts { get; set; }

    public string Occupation { get; set; } = null!;

    public string? TimeBasedBenefits { get; set; }

    public string? OccupationBasedBenefits { get; set; }

    public int? Location { get; set; }

    public int DeptNo { get; set; }

    public int? SupId { get; set; }

    /// <summary>
    /// Enter an hourly salary
    /// </summary>
    public double? Wage { get; set; }

    public double? Bonus { get; set; }

    public double? Insurance { get; set; }

    public string? InsurancePlan { get; set; }

    public string? WorkPhoneNum { get; set; }

    public string? MobilePhoneNum { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? EmergencyContactEmail { get; set; }

    public DateOnly DateJoined { get; set; }

    public DateOnly? DateLeft { get; set; }

    public int VacationDaysLeft { get; set; }

    public int SickDaysLeft { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Dependent> Dependents { get; } = new List<Dependent>();

    public virtual Department DeptNoNavigation { get; set; } = null!;

    public virtual ICollection<EmployeeShift> EmployeeShifts { get; } = new List<EmployeeShift>();

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<Employee> InverseSup { get; } = new List<Employee>();

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestFulfillerNavigations { get; } = new List<MaintenanceRequest>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestRequesterNavigations { get; } = new List<MaintenanceRequest>();

    public virtual Occupation OccupationNavigation { get; set; } = null!;

    public virtual Employee? Sup { get; set; }

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();

    public virtual ICollection<ZooUser> ZooUsers { get; } = new List<ZooUser>();

    public virtual ICollection<AnimalCareProgram> AnimalProgramNums { get; } = new List<AnimalCareProgram>();

    public virtual ICollection<ZooEvent> Events { get; } = new List<ZooEvent>();

    public virtual ICollection<EducationProgram> ProgramNos { get; } = new List<EducationProgram>();

    public virtual ICollection<VeterinaryVisit> VetVisits { get; } = new List<VeterinaryVisit>();
}
