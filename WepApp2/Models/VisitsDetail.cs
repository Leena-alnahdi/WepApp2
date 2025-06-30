using System;
using System.Collections.Generic;

namespace WepApp2.Models;

public partial class VisitsDetail
{
    public int VisitsDetailsId { get; set; }

    public string VisitType { get; set; } = null!;

    public int? LabVisitId { get; set; }

    public virtual LabVisit? LabVisit { get; set; }
}
