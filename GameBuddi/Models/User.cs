using System;
using System.Collections.Generic;

namespace GameBuddi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? JoinDate { get; set; }

    public string? BanStatus { get; set; }

    public string? AboutMe { get; set; }

    public int Reputation { get; set; }

    public string? ProfilePicture { get; set; }

    public virtual ICollection<ReviewComment> ReviewComments { get; set; } = new List<ReviewComment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
