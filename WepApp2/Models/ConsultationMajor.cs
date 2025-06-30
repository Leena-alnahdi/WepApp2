using System;
using System.Collections.Generic;

namespace WepApp2.Models;

public partial class ConsultationMajor
{
    public int ConsultationMajorId { get; set; }

    public string Major { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? ConsultationId { get; set; }

    public virtual Consultation? Consultation { get; set; }
}
