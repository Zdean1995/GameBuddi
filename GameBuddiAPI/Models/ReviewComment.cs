using System;
using System.Collections.Generic;

namespace GameBuddiAPI.Models;

public partial class ReviewComment
{
    public int Id { get; set; }

    public int? ReviewId { get; set; }

    public int? PosterId { get; set; }

    public string Comment { get; set; } = null!;

    public int? CommentScore { get; set; }

    public DateTime? PostDate { get; set; }

    public virtual User? Poster { get; set; }

    public virtual Review? Review { get; set; }
}
