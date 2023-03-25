using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Location
{
    public int LocationNum { get; set; }

    public string LocationName { get; set; } = null!;

    public int? MaxCapacity { get; set; }

    public TimeOnly? OpeningTime { get; set; }

    public TimeOnly? ClosingTime { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Exhibit> Exhibits { get; } = new List<Exhibit>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<LocationDaysClosed> LocationDaysCloseds { get; } = new List<LocationDaysClosed>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    public virtual ICollection<ZooEvent> ZooEvents { get; } = new List<ZooEvent>();
}
