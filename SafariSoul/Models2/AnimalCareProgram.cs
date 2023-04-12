using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class AnimalCareProgram
{
    public int AnimalProgramId { get; set; }

    public string ProgramName { get; set; } = null!;

    public string? ProgramDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();
}
