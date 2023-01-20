namespace SuggestionAppUI.Pages;

public partial class AdminApproval
{
    private List<SuggestionModel> submissions;
    private SuggestionModel editingModel;
    private string currentEditingTitle = "";
    private string editedTitle = "";
    private string currentEditingDescription = "";
    private string editedDescription = "";
    protected override async Task OnInitializedAsync()
    {
        submissions = await suggestionData.GetAllSuggestionsWaitingForApproval();
    }

    private async Task ApproveSubmission(SuggestionModel submission)
    {
        submission.ApprovedForRelease = true;
        submissions.Remove(submission);
        await suggestionData.UpdateSuggestion(submission);
    }

    private async Task RejectSubmission(SuggestionModel submission)
    {
        submission.Rejected = true;
        submissions.Remove(submission);
        await suggestionData.UpdateSuggestion(submission);
    }

    private void EditTitle(SuggestionModel model)
    {
        editingModel = model;
        editedTitle = model.Suggestion;
        currentEditingTitle = model.Id;
        currentEditingDescription = "";
    }

    private async Task SaveTitle(SuggestionModel model)
    {
        currentEditingTitle = string.Empty;
        model.Suggestion = editedTitle;
        await suggestionData.UpdateSuggestion(model);
    }

    private void EditDescription(SuggestionModel model)
    {
        editingModel = model;
        editedDescription = model.Description;
        currentEditingTitle = "";
        currentEditingDescription = model.Id;
    }

    private async Task SaveDescription(SuggestionModel model)
    {
        currentEditingDescription = string.Empty;
        model.Description = editedDescription;
        await suggestionData.UpdateSuggestion(model);
    }

    private void ClosePage()
    {
        navManager.NavigateTo("/");
    }
}