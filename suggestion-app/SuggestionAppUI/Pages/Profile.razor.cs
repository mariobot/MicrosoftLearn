namespace SuggestionAppUI.Pages;

public partial class Profile
{
    private UserModel loggedInUser;
    private List<SuggestionModel> submissions;
    private List<SuggestionModel> approved;
    private List<SuggestionModel> archived;
    private List<SuggestionModel> pending;
    private List<SuggestionModel> rejected;
    protected override async Task OnInitializedAsync()
    {
        loggedInUser = await authProvider.GetUserFromAuth(userData);
        var results = await suggestionData.GetUsersSuggestions(loggedInUser.Id);
        if (loggedInUser is not null && results is not null)
        {
            submissions = results.OrderByDescending(x => x.DateCreated).ToList();
            approved = submissions.Where(x => x.ApprovedForRelease && x.Archived == false && x.Rejected == false).ToList();
            archived = submissions.Where(x => x.Archived && x.Rejected == false).ToList();
            pending = submissions.Where(x => x.ApprovedForRelease == false && x.Rejected == false).ToList();
            rejected = submissions.Where(x => x.Rejected).ToList();
        }
    }

    private void ClosePage()
    {
        navManager.NavigateTo("/");
    }
}