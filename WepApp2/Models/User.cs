using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WepApp2.Models;

public partial class User
{
[Key]
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string Role { get; set; } = null!;

    public string Faculty { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public DateTime LastLogIn { get; set; }

    public bool IsActive { get; set; }
    [NotMapped]
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
