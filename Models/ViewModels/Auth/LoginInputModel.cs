namespace BlackMetalBlog.Models.ViewModels.Auth;

public class LoginInputModel
{
    public bool InputAutocomplete => false;

    public required string LabelFor { get; init; }

    public required string InputId { get; init; }

    public required string InputName { get; init; }

    public string? InputPlaceholder { get; init; }
}
