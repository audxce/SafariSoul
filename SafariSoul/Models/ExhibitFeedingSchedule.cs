using System;
using System.Collections.Generic;

namespace SafariSoul;

public partial class ExhibitFeedingSchedule
{
    public int ExhibitNo { get; set; }

    public TimeOnly FeedingTime { get; set; }

    public int MealContent { get; set; }

    /// <summary>
    /// Number of servings of each meal item per feeding
    /// </summary>
    public float? MealQuantity { get; set; }

    public virtual Exhibit ExhibitNoNavigation { get; set; } = null!;

    public virtual Inventory MealContentNavigation { get; set; } = null!;
}
