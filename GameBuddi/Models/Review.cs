using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuddi.Models
{
    /*
     * The reviews for the games.  These will be on the games page and will be displayed with their own reputation and comments.  The review will
     * have the posters name which will connect to their page.
     */
    internal class Review
    {
        public int Id { get; set; }
        public string GameID { get; set; }
        public int PosterId { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;
        public double Score { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewContent { get; set; }
        public int ReviewReputation { get; set; }
    }
}
