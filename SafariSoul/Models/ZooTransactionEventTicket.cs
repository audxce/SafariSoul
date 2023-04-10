using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class ZooTransactionEventTicket
{
    public int MultiEventTicketsId { get; set; }

    public int EventId { get; set; }

    public int TransactionId { get; set; }

    public int TicketQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ZooEvent Event { get; set; } = null!;

    public virtual ZooTransaction Transaction { get; set; } = null!;
}
