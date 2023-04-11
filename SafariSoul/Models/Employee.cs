using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    [DisplayName("First Name")]
    public string Fname { get; set; } = null!;

    [DisplayName("Middle Initial")]
    public string? Minit { get; set; }

    [DisplayName("Last Name")]
    public string Lname { get; set; } = null!;

    [DisplayName("Date of Birth")]
    public DateOnly? Bdate { get; set; }

    public string Occupation { get; set; } = null!;

    [DisplayName("Department")]
    public string? DeptName { get; set; }

    [DisplayName("Supervisor")]
    public int? SupId { get; set; }

    public double? Salary { get; set; }

    [DisplayName("Mobile Phone Number")]
    public string? MobilePhoneNum { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    [DisplayName("E.C. Name")]
    public string? EmergencyContactName { get; set; }

    [DisplayName("E.C. Phone")]
    public string? EmergencyContactPhone { get; set; }

    [DisplayName("E.C. Email")]
    public string? EmergencyContactEmail { get; set; }

    [DisplayName("Date Joined")]
    public DateOnly DateJoined { get; set; }

    [DisplayName("Date Left")]
    public DateOnly? DateLeft { get; set; }

    [DisplayName("Vacation Days Left")]
    public int VacationDaysLeft { get; set; }

    [DisplayName("Sick Days Left")]
    public int SickDaysLeft { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Dependent> Dependents { get; } = new List<Dependent>();

    [DisplayName("Department")]
    public virtual Department? DeptNameNavigation { get; set; }

    public virtual ICollection<EmployeeShift> EmployeeShifts { get; } = new List<EmployeeShift>();

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<Employee> InverseSup { get; } = new List<Employee>();

    [DisplayName("Supervisor")]
    public virtual Employee? Sup { get; set; }

    public virtual ICollection<VeterinaryVisit> VeterinaryVisits { get; } = new List<VeterinaryVisit>();

    public virtual ICollection<ZooEventStaffInvolved> ZooEventStaffInvolveds { get; } = new List<ZooEventStaffInvolved>();

    public virtual ICollection<ZooTransaction> ZooTransactions { get; } = new List<ZooTransaction>();

    public virtual ICollection<ZooUser> ZooUsers { get; } = new List<ZooUser>();

    [DisplayName("Full Name")]
    public string FullName
    {
        get { return Fname + " " + Lname; }
    }
}


