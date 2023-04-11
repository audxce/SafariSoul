using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Species
{
    public int SpeciesId { get; set; }

    public string? Kingdom { get; set; }

    public string? Phylum { get; set; }

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string Genus { get; set; } = null!;

    [DisplayName("Species")]
    public string Species1 { get; set; } = null!;

    [DisplayName("Exhibit ID")]
    public int? ExhibitId { get; set; }

    [DisplayName("Life Expectancy")]
    public int? LifeExpectancy { get; set; }

    [DisplayName("Normal Body Temperature")]
    public float? NormalBodyTemperature { get; set; }

    [DisplayName("Regions Found")]
    public string? RegionsFound { get; set; }

    public string? Diet { get; set; }

    public float? Humidity { get; set; }

    [DisplayName("Active Hours")]
    public string? ActiveHours { get; set; }

    [DisplayName("Conservation Status")]
    public string? ConservationStatus { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    [DisplayName("Common Name")]
    public string? CommonName { get; set; }

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual Exhibit? Exhibit { get; set; }
}
