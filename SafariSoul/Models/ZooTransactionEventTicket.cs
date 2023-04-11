using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class ZooTransactionEventTicket
{
    public int MultiEventTicketsId { get; set; }

    [DisplayName("Event")]
    public int EventId { get; set; }

    [DisplayName("Transaction ID")]
    public int TransactionId { get; set; }

    [DisplayName("Ticket Quantity")]
    public int TicketQuantity { get; set; }

    [DisplayName("Created At")]
    public DateTime? CreatedAt { get; set; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public virtual ZooEvent Event { get; set; } = null!;

    public virtual ZooTransaction Transaction { get; set; } = null!;
}
