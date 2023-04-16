using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SafariSoul.Models;

public class ZooUserCustomerViewModel
{
    public ZooUser ZooUser { get; set; } = default!;
    public Customer Customer { get; set; } = default!;
}

