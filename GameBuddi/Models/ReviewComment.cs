using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuddi.Models
{
    /*
     * The comments for the reviews.  They will be displayed under the reviews and have their own scores.  
     * The commenters account can be accessed by their account name on the comment.
     */
    internal class ReviewComment
    {
        public int Id {  get; set; }
        public int ReviewId { get; set; }
        public int PosterId { get; set; }
        public string Content { get; set; }
        public int CommentScore { get; set; }
    }
}
