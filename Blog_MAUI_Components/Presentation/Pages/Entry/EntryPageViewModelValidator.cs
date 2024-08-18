using FluentValidation;

namespace Blog_MAUI_Components.Presentation.Pages.Entry;

public class EntryPageViewModelValidator : AbstractValidator<EntryPageViewModel>
{
    public EntryPageViewModelValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();
    }
}