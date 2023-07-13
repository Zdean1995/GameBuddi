using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuddi.Models
{
    /*
     * The model for the games.  PublisherID is a foreign key that links the game to the publisher and the developer key does the same for the developer.
     * This model will be used displayed it's own page.  Users will be allowed to leave reviews for the games. The review scores will be taken from the reviews
     * and therefore the model doesn't need to have a score.
     */
    internal class Game
    {
        public int Id { get; set; }
        public string PublisherId { get; set; }
        public string DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string AgeRating { get; set; }
        public string Platforms { get; set; }
    }
}
