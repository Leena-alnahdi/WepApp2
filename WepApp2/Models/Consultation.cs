using System;
using System.Collections.Generic;

namespace WepApp2.Models;

public partial class Consultation
{
    public int ConsultationId { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly RequestedDate { get; set; }

    public string? CommunicationMethod { get; set; }

    public int? ServiceId { get; set; }

    public int? RequestId { get; set; }

    public TimeOnly AvailableTimes { get; set; }

    public virtual ICollection<ConsultationMajor> ConsultationMajors { get; set; } = new List<ConsultationMajor>();

    public virtual Request? Request { get; set; }

    public virtual Service? Service { get; set; }
}
