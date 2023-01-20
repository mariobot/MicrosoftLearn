using SuggestionAppUI.Models;

namespace SuggestionAppUI.Pages;

public partial class Create
{
    private CreateSuggestionModel suggestion = new();
    private List<CategoryModel> categories;
    private UserModel loggedInUser;
    protected override async Task OnInitializedAsync()
    {
        categories = await categoryData.GetAllCategories();
        // Todo - Replace with lookup
        //var authState = await authProvider.GetAuthenticationStateAsync();
        //string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
        //loggedInUser = await userData.GetUserFromAuthentication(objectId);
        loggedInUser = await authProvider.GetUserFromAuth(userData);
    }

    private void ClosePage()
    {
        navManager.NavigateTo("/");
    }

    private async Task CreateSuggestion()
    {
        SuggestionModel s = new();
        s.Suggestion = suggestion.Suggestion;
        s.Description = suggestion.Description;
        s.Author = new BasicUserModel(loggedInUser);
        s.Category = categories.Where(c => c.Id == suggestion.CategoryId).FirstOrDefault();
        if (s.Category is null)
        {
            suggestion.CategoryId = "";
            return;
        }

        await suggestionData.CreateSuggestion(s);
        suggestion = new();
        ClosePage();
    }
}