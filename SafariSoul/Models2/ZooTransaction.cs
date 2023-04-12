using System;
using System.Collections.Generic;

namespace SafariSoul.Models2;

public partial class ZooTransaction
{
    public int TransactionId { get; set; }

    public DateTime DateAndTime { get; set; }

    public int? CustomerId { get; set; }

    public int? SellerId { get; set; }

    public int? LocationId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Location? Location { get; set; }

    public virtual Employee? Seller { get; set; }

    public virtual ICollection<ZooTransactionEventTicket> ZooTransactionEventTickets { get; } = new List<ZooTransactionEventTicket>();

    public virtual ICollection<ZooTransactionItem> ZooTransactionItems { get; } = new List<ZooTransactionItem>();
}
