using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class Donation
{
    public int DonationId { get; set; }

    public int DonorId { get; set; }

    public int AmountDonated { get; set; }

    public string? DonationPurpose { get; set; }

    public DateOnly DateDonated { get; set; }

    public string? Feedback { get; set; }

    public string? Recognition { get; set; }

    public virtual Customer Donor { get; set; } = null!;
}
