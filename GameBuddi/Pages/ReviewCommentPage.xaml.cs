namespace GameBuddi.Pages;

public partial class ReviewCommentPage : ContentPage
{
	public ReviewCommentPage()
	{
		InitializeComponent();
	}

    public int ReviewId { get; internal set; }
    public int PosterId { get; internal set; }
    public string Comment { get; internal set; }
    public int CommentScore { get; internal set; }
    public DateTime PostDate { get; internal set; }
}
