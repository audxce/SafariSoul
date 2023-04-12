using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Species
{
    public int SpeciesId { get; set; }

    public string? Kingdom { get; set; }

    public string? Phylum { get; set; }

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string Genus { get; set; } = null!;

    public string Species1 { get; set; } = null!;

    public int? ExhibitId { get; set; }

    public int? LifeExpectancy { get; set; }

    public float? NormalBodyTemperature { get; set; }

    public string? RegionsFound { get; set; }

    public string? Diet { get; set; }

    public float? Humidity { get; set; }

    public string? ActiveHours { get; set; }

    public string? ConservationStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CommonName { get; set; }

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual Exhibit? Exhibit { get; set; }
}
