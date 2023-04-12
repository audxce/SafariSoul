﻿using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class Donation
{
    public int DonationId { get; set; }

    public int? DonorId { get; set; }

    public int AmountDonated { get; set; }

    public string? DonationPurpose { get; set; }

    public DateOnly DateDonated { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Donor { get; set; }
}