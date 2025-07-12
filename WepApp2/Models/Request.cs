﻿namespace WepApp2.Models
{
    public int RequestId { get; set; }

    public string RequestType { get; set; } = null!;

    public string SupervisorStatus { get; set; } = null!;

    public DateTime RequestDate { get; set; }

    public int SupervisorAssigned { get; set; }

    public string AdminStatus { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public int? DeviceId { get; set; }

    public virtual ICollection<BookingDevice> BookingDevices { get; set; } = new List<BookingDevice>();

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Device? Device { get; set; }

    public virtual ICollection<DeviceLoan> DeviceLoans { get; set; } = new List<DeviceLoan>();

    public virtual ICollection<LabVisit> LabVisits { get; set; } = new List<LabVisit>();

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Course> CoursesNavigation { get; set; } = new List<Course>();
}