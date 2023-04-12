using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string AnimalName { get; set; } = null!;

    public int? SpeciesId { get; set; }

    public int? Mother { get; set; }

    public int? Father { get; set; }

    public string? UniqueDescriptors { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateTime? DateOfDeath { get; set; }

    public string? CauseOfDeath { get; set; }

    public string Gender { get; set; } = null!;

    public string? DietaryRestrictions { get; set; }

    public string? Recreation { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Animal? FatherNavigation { get; set; }

    public virtual ICollection<Animal> InverseFatherNavigation { get; } = new List<Animal>();

    public virtual ICollection<Animal> InverseMotherNavigation { get; } = new List<Animal>();

    public virtual Animal? MotherNavigation { get; set; }

    public virtual Species? Species { get; set; }

    public virtual ICollection<VeterinaryVisit> VeterinaryVisits { get; } = new List<VeterinaryVisit>();

    public virtual ICollection<ZooEventAnimalsInvolved> ZooEventAnimalsInvolveds { get; } = new List<ZooEventAnimalsInvolved>();
}
