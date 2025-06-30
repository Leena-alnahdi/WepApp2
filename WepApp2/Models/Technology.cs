using System;
using System.Collections.Generic;

namespace WepApp2.Models;

public partial class Technology
{
    public int TechnologyId { get; set; }

    public string TechnologyName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? DeviceId { get; set; }

    public virtual Device? Device { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
