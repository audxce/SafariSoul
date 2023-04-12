using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ZooTransaction
{
    public int TransactionId { get; set; }

    [DisplayName("Date and Time")]
    public DateTime DateAndTime { get; set; }

    [DisplayName("Customer")]
    public int? CustomerId { get; set; }

    [DisplayName("Seller")]
    public int? SellerId { get; set; }

    [DisplayName("Location")]
    public int? LocationId { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; } = null!;

    public virtual Location? Location { get; set; } = null!;

    public virtual Employee? Seller { get; set; } = null!;

    public virtual ICollection<ZooTransactionEventTicket> ZooTransactionEventTickets { get; } = new List<ZooTransactionEventTicket>();

    public virtual ICollection<ZooTransactionItem> ZooTransactionItems { get; } = new List<ZooTransactionItem>();
}
