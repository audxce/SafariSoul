using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Species
{
    public string? SpeciesKingdom { get; set; }

    public string? SpeciesPhylum { get; set; }

    public string? SpeciesClass { get; set; }

    public string? SpeciesOrder { get; set; }

    public string? SpeciesFamily { get; set; }

    public string SpeciesGenus { get; set; } = null!;

    public string SpeciesSpecies { get; set; } = null!;

    public int? ExhibitNo { get; set; }

    public float? LifeExpectancy { get; set; }

    /// <summary>
    /// Body Temperature in Fahrenheit
    /// </summary>
    public float? NormalBodyTemperature { get; set; }

    public string? RegionsFound { get; set; }

    public string? Diet { get; set; }

    /// <summary>
    /// Humidity in percentage
    /// </summary>
    public float? Humidity { get; set; }

    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    public float? UpperTemperature { get; set; }

    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    public float? LowerTemperature { get; set; }

    public string? ActiveHours { get; set; }

    public string? ConservationStatus { get; set; }

    public string? SpeciesInfo { get; set; }

    public string CommonName { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();

    public virtual Exhibit? ExhibitNoNavigation { get; set; }
}
