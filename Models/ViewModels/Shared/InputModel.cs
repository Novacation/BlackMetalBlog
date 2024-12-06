namespace BlackMetalBlog.Models.ViewModels.Shared;

public class InputModel
{
    public bool InputAutocomplete => false;

    public required string LabelFor { get; init; }

    public required string InputId { get; init; }

    public required string InputName { get; init; }

    public string? InputPlaceholder { get; init; }
}
