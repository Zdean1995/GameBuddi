using GameBuddi.Pages;
namespace GameBuddiAPI.Models
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
            BindingContext = new ReviewViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }

    public class ReviewViewModel
    {
        public List<ReviewCommentPage> ReviewComments { get; set; }

        public ReviewViewModel()
        {
            // Simulated data (replace with actual database retrieval)
            ReviewComments = new List<ReviewCommentPage>
            {
                new ReviewCommentPage { ReviewId = 1, PosterId = 101, Comment = "Great game!", CommentScore = 5, PostDate = DateTime.Now },
                new ReviewCommentPage {  ReviewId = 2, PosterId = 102, Comment = "I disagree.", CommentScore = 2, PostDate = DateTime.Now }
                // Add more data here
            };
        }
    }
}
