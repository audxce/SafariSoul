using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooTransaction
{
    public int TransactionId { get; set; }

    public DateTime DateAndTime { get; set; }

    public int? Customer { get; set; }

    public int? SellerId { get; set; }

    public int? Location { get; set; }

    public string? Discount { get; set; }

    public virtual Customer? CustomerNavigation { get; set; }

    public virtual Discount? DiscountNavigation { get; set; }

    public virtual Employee? Seller { get; set; }

    public virtual ICollection<ZooTransactionEventTicket> ZooTransactionEventTickets { get; } = new List<ZooTransactionEventTicket>();

    public virtual ICollection<ZooTransactionItem> ZooTransactionItems { get; } = new List<ZooTransactionItem>();
}
