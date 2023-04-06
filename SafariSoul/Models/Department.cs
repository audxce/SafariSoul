using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public int ManagerId { get; set; }

    public string? PhoneNum { get; set; }

    public string? Email { get; set; }

    public int? Location { get; set; }

    public int Budget { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<DepartmentAnimalProgram> DepartmentAnimalPrograms { get; } = new List<DepartmentAnimalProgram>();

    public virtual ICollection<DepartmentEducationProgram> DepartmentEducationPrograms { get; } = new List<DepartmentEducationProgram>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual Employee Manager { get; set; } = null!;
}
