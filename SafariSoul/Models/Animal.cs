using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string AnimalName { get; set; } = null!;

    public string Genus { get; set; } = null!;

    public string Species { get; set; } = null!;

    public int? MotherId { get; set; }

    public int? FatherId { get; set; }

    public string? UniqueDescriptors { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateTime? DateOfDeath { get; set; }

    public string? CauseOfDeath { get; set; }

    public string Gender { get; set; } = null!;

    public string? DietaryRestrictions { get; set; }

    public string? Recreation { get; set; }

    public string? Notes { get; set; }

    public virtual Species SpeciesNavigation { get; set; } = null!;

    public virtual ICollection<VeterinaryVisit> VeterinaryVisits { get; } = new List<VeterinaryVisit>();

    public virtual ICollection<AnimalCareProgram> AnimalProgramNums { get; } = new List<AnimalCareProgram>();

    public virtual ICollection<ZooEvent> Events { get; } = new List<ZooEvent>();

    public virtual ICollection<EducationProgram> ProgramNos { get; } = new List<EducationProgram>();
}
