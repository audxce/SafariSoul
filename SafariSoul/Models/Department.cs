﻿using System;
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

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual Employee Manager { get; set; } = null!;

    public virtual ICollection<AnimalCareProgram> AnimalProgramNums { get; } = new List<AnimalCareProgram>();

    public virtual ICollection<EducationProgram> ProgramNos { get; } = new List<EducationProgram>();
}