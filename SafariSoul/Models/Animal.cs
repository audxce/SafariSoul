using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    [DisplayName("Animal Name")]
    public string AnimalName { get; set; } = null!;

    [DisplayName("Species ID")]
    public int? SpeciesId { get; set; }

    public int? Mother { get; set; }

    public int? Father { get; set; }

    [DisplayName("Unique Descriptors")]
    public string? UniqueDescriptors { get; set; }

    [DisplayName("Date of Birth")]
    public DateOnly DateOfBirth { get; set; }

    [DisplayName("Date of Death")]
    public DateTime? DateOfDeath { get; set; }

    [DisplayName("Cause of Death")]
    public string? CauseOfDeath { get; set; }

    public string Gender { get; set; } = null!;

    [DisplayName("Dietary Restrictions")]
    public string? DietaryRestrictions { get; set; }

    public string? Recreation { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Animal? FatherNavigation { get; set; }

    public virtual ICollection<Animal> InverseFatherNavigation { get; } = new List<Animal>();

    public virtual ICollection<Animal> InverseMotherNavigation { get; } = new List<Animal>();

    public virtual Animal? MotherNavigation { get; set; }

    public virtual Species? Species { get; set; }

    public virtual ICollection<VeterinaryVisit> VeterinaryVisits { get; } = new List<VeterinaryVisit>();

    public virtual ICollection<ZooEventAnimalsInvolved> ZooEventAnimalsInvolveds { get; } = new List<ZooEventAnimalsInvolved>();
}
