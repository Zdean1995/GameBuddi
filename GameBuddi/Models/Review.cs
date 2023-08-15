using System;
using System.Collections.Generic;

namespace GameBuddi.Models;

public partial class Review
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int? PosterId { get; set; }

    public DateTime? PostDate { get; set; }

    public int Score { get; set; }

    public string ReviewTitle { get; set; } = null!;

    public string ReviewContent { get; set; } = null!;

    public int ReviewReputation { get; set; }

    public virtual User? Poster { get; set; }

    public virtual ICollection<ReviewComment> ReviewComments { get; set; } = new List<ReviewComment>();
}
