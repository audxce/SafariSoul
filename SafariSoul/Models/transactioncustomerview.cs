using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public partial class TransactionCustomerViewModel
{
    public ZooTransaction Transaction { get; set; } = default!;
    public Customer Customer { get; set; } = default!;

}
