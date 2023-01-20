namespace SuggestionAppUI.Pages;

public partial class Index
{
    private UserModel loggedInUser;
    private List<SuggestionModel> suggestions;
    private List<CategoryModel> categories;
    private List<StatusModel> statuses;
    private SuggestionModel archivingSuggestion;
    private string selectedCategory = "All";
    private string selectedStatus = "All";
    private string searchText = "";
    bool isSortedByNew = true;
    protected async override Task OnInitializedAsync()
    {
        categories = await categoryData.GetAllCategories();
        statuses = await statusData.GetAllStatuses();
        await LoadAndVerifyUser();
    }

    private async Task ArchiveSuggestion()
    {
        archivingSuggestion.Archived = true;
        await suggestionData.UpdateSuggestion(archivingSuggestion);
        suggestions.Remove(archivingSuggestion);
        archivingSuggestion = null;
        //await FilterSuggestions();
    }

    private void LoadCreatePage()
    {
        if (loggedInUser is not null)
        {
            navManager.NavigateTo("/Create");
        }
        else
        {
            navManager.NavigateTo("/MicrosoftIdentity/Account/SignIn", true);
        }
    }

    private async Task LoadAndVerifyUser()
    {
        var authState = await authProvider.GetAuthenticationStateAsync();
        string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
        if (string.IsNullOrWhiteSpace(objectId) == false)
        {
            loggedInUser = await userData.GetUserFromAuthentication(objectId) ?? new();
            string firstName = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("givenname"))?.Value;
            string lastName = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("surname"))?.Value;
            string displayName = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("name"))?.Value;
            string email = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("email"))?.Value;
            bool isDirty = false;
            if (objectId.Equals(loggedInUser.ObjectIdentifier) == false)
            {
                isDirty = true;
                loggedInUser.ObjectIdentifier = objectId;
            }

            if (firstName.Equals(loggedInUser.FirstName) == false)
            {
                isDirty = true;
                loggedInUser.FirstName = firstName;
            }

            if (lastName.Equals(loggedInUser.LastName) == false)
            {
                isDirty = true;
                loggedInUser.LastName = lastName;
            }

            if (displayName.Equals(loggedInUser.DisplayName) == false)
            {
                isDirty = true;
                loggedInUser.DisplayName = displayName;
            }

            if (email.Equals(loggedInUser.EmailAddress) == false)
            {
                isDirty = true;
                loggedInUser.EmailAddress = email;
            }

            if (isDirty)
            {
                if (string.IsNullOrWhiteSpace(loggedInUser.Id))
                {
                    await userData.CreateUser(loggedInUser);
                }
                else
                {
                    await userData.UpdateUser(loggedInUser);
                }
            }
        }
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadFilterState();
            await FilterSuggestions();
            StateHasChanged();
        }
    }

    private async Task LoadFilterState()
    {
        var stringResults = await sessionStorage.GetAsync<string>(nameof(selectedCategory));
        selectedCategory = stringResults.Success ? stringResults.Value : "All";
        stringResults = await sessionStorage.GetAsync<string>(nameof(selectedStatus));
        selectedStatus = stringResults.Success ? stringResults.Value : "All";
        stringResults = await sessionStorage.GetAsync<string>(nameof(searchText));
        searchText = stringResults.Success ? stringResults.Value : "";
        var boolResults = await sessionStorage.GetAsync<bool>(nameof(isSortedByNew));
        isSortedByNew = stringResults.Success ? boolResults.Value : true;
    }

    private async Task SaveFilterState()
    {
        await sessionStorage.SetAsync(nameof(selectedCategory), selectedCategory);
        await sessionStorage.SetAsync(nameof(selectedStatus), selectedStatus);
        await sessionStorage.SetAsync(nameof(searchText), searchText);
        await sessionStorage.SetAsync(nameof(isSortedByNew), isSortedByNew);
    }

    private async Task FilterSuggestions()
    {
        var output = await suggestionData.GetAllApprovedSuggestions();
        if (selectedCategory != "All")
        {
            output = output.Where(s => s.Category?.CategoryName == selectedCategory).ToList();
        }

        if (selectedStatus != "All")
        {
            output = output.Where(s => s.SuggestionStatus?.StatusName == selectedStatus).ToList();
        }

        if (string.IsNullOrWhiteSpace(searchText) == false)
        {
            output = output.Where(s => s.Suggestion.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) || s.Description.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        if (isSortedByNew)
        {
            output = output.OrderByDescending(s => s.DateCreated).ToList();
        }
        else
        {
            output = output.OrderByDescending(s => s.UserVotes.Count).ThenByDescending(s => s.DateCreated).ToList();
        }

        suggestions = output;
        await SaveFilterState();
    }

    private async Task OrderByNew(bool isNew)
    {
        isSortedByNew = isNew;
        await FilterSuggestions();
    }

    private async Task OnSearchInput(string searchInput)
    {
        searchText = searchInput;
        await FilterSuggestions();
    }

    private async Task OnCategoryClick(string category = "All")
    {
        selectedCategory = category;
        await FilterSuggestions();
    }

    private async Task OnStatusClick(string status = "All")
    {
        selectedStatus = status;
        await FilterSuggestions();
    }

    private async Task VoteUp(SuggestionModel suggestion)
    {
        if (loggedInUser is not null)
        {
            if (suggestion.Author.Id == loggedInUser.Id)
            {
                // Cant vote on your own suggestion
                return;
            }

            if (suggestion.UserVotes.Add(loggedInUser.Id) == false)
            {
                suggestion.UserVotes.Remove(loggedInUser.Id);
            }

            await suggestionData.UpvoteSuggestion(suggestion.Id, loggedInUser.Id);
            if (isSortedByNew == false)
            {
                suggestions = suggestions.OrderByDescending(x => x.UserVotes.Count).ThenByDescending(x => x.DateCreated).ToList();
            }
        }
        else
        {
            navManager.NavigateTo("/MicrosoftIdentity/Account/SignIn", true);
        }
    }

    private string GetUpvoteTopText(SuggestionModel suggestion)
    {
        if (suggestion.UserVotes?.Count > 0)
        {
            return suggestion.UserVotes.Count.ToString("00");
        }
        else
        {
            if (suggestion.Author.Id == loggedInUser?.Id)
            {
                return "Awaiting";
            }
            else
            {
                return "Click To";
            }
        }
    }

    private string GetUpvoteBottomText(SuggestionModel suggestion)
    {
        if (suggestion.UserVotes?.Count > 1)
        {
            return "Upvotes";
        }
        else
        {
            return "Upvote";
        }
    }

    private void OpenDetails(SuggestionModel suggestion)
    {
        navManager.NavigateTo($"/Details/{suggestion.Id}");
    }

    private string SorterByNewClass(bool isNew)
    {
        if (isNew == isSortedByNew)
        {
            return "sort-selected";
        }
        else
        {
            return "";
        }
    }

    private string GetVoteClass(SuggestionModel suggestion)
    {
        if (suggestion.UserVotes is null || suggestion.UserVotes.Count == 0)
        {
            return "suggestion-entry-no-votes";
        }
        else if (suggestion.UserVotes.Contains(loggedInUser?.Id))
        {
            return "suggestion-entry-voted";
        }
        else
        {
            return "suggestion-entry-not-voted";
        }
    }

    private string GetSuggestionStatus(SuggestionModel suggestion)
    {
        if (suggestion is null || suggestion.SuggestionStatus is null)
        {
            return "suggestion-entry-status-none";
        }

        string output = suggestion.SuggestionStatus.StatusName switch
        {
            "Completed" => "suggestion-entry-status-completed",
            "Watching" => "suggestion-entry-status-watching",
            "Upcoming" => "suggestion-entry-status-upcoming",
            "Dismissed" => "suggestion-entry-status-dismissed",
            _ => "suggestion-entry-status-none",
        };
        return output;
    }

    private string GetSelectedCategory(string category = "All")
    {
        if (category == selectedCategory)
        {
            return "selected-category";
        }
        else
        {
            return "";
        }
    }

    private string GetSelectedStatus(string status = "All")
    {
        if (status == selectedStatus)
        {
            return "selected-status";
        }
        else
        {
            return "";
        }
    }
}