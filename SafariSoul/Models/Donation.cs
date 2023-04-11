using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class Donation
{
    public int DonationId { get; set; }

    public int DonorId { get; set; }

    [DisplayName("Amount Donated")]
    public int AmountDonated { get; set; }

    [DisplayName("Donation Purpose")]
    public string? DonationPurpose { get; set; }

    [DisplayName("Date Donated")]
    public DateOnly DateDonated { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Customer Donor { get; set; } = null!;
}
