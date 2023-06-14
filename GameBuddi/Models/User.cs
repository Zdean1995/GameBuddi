using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuddi.Models
{
    /*
     * The Users.  Must be used inorder to post or vote on comments and reviews. Ban status will determine if the user is being punished for breaking the rules
     * Profile picture will be an image that is kept on the server and will be restricted in reselution and filesize.
     */
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string BanStatus { get; set; }
        public string AboutMe { get; set; }
        public int Reputation { get; set; }
        public string ProfilePicture { get; set; }
    }
}
