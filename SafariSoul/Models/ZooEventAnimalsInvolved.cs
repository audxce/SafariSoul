using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SafariSoul.Models;

public partial class ZooEventAnimalsInvolved
{
    public int MultiAnimalId { get; set; }

    [DisplayName("Event ID")]
    public int? EventId { get; set; }

    [DisplayName("Animal ID")]
    public int? AnimalId { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Animal? Animal { get; set; } = null!;

    public virtual ZooEvent? Event { get; set; } = null!;
}
