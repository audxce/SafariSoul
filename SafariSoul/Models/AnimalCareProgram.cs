using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class AnimalCareProgram
{
    public int AnimalProgramId { get; set; }

    [DisplayName("Program Name")]
    public string ProgramName { get; set; } = null!;

    [DisplayName("Program Descrption")]
    public string? ProgramDescription { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();
}
