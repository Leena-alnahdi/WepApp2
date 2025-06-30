﻿using System;
using System.Collections.Generic;

namespace WepApp2.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? TechnologyId { get; set; }

    public virtual ICollection<BookingDevice> BookingDevices { get; set; } = new List<BookingDevice>();

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<DeviceLoan> DeviceLoans { get; set; } = new List<DeviceLoan>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<LabVisit> LabVisits { get; set; } = new List<LabVisit>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Technology? Technology { get; set; }
}
