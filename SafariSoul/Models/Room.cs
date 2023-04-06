using System;
using System.Collections.Generic;

namespace SafariSoul.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public string? RoomFunction { get; set; }

    public int? LocationNum { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Location? LocationNumNavigation { get; set; }
}
