﻿using System;
using System.Collections.Generic;

namespace WepApp2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public string Faculty { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string UserPassWord { get; set; } = null!;

    public DateTime LastLogIn { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
