using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Fname { get; set; } = null!;

    public string? Minit { get; set; }

    public string Lname { get; set; } = null!;

    public DateOnly? Bdate { get; set; }

    public string Occupation { get; set; } = null!;

    public string? DeptName { get; set; }

    public int? SupId { get; set; }

    public double? Salary { get; set; }

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

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Dependent> Dependents { get; } = new List<Dependent>();

    public virtual Department? DeptNameNavigation { get; set; }

    public virtual ICollection<EmployeeShift> EmployeeShifts { get; } = new List<EmployeeShift>();

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<Employee> InverseSup { get; } = new List<Employee>();

    public virtual Employee? Sup { get; set; }

    public virtual ICollection<VeterinaryVisit> VeterinaryVisits { get; } = new List<VeterinaryVisit>();

    public virtual ICollection<ZooEventStaffInvolved> ZooEventStaffInvolveds { get; } = new List<ZooEventStaffInvolved>();

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();

    public virtual ICollection<ZooUser> ZooUsers { get; } = new List<ZooUser>();
}
