using BlackMetalBlog.Models.Enums;

namespace BlackMetalBlog.Models.ViewModels.Shared;

public class InputViewModel(
    string labelFor,
    string inputId,
    string inputName,
    string? inputPlaceholder,
    InputTypesEnum
        inputType)
{
    public bool InputAutocomplete => false;

    public string LabelFor { get; init; } = labelFor;

    public string InputId { get; init; } = inputId;

    public string InputName { get; init; } = inputName;

    public string? InputPlaceholder { get; init; } = inputPlaceholder;

    public string InputType { get; init; } = inputType.GetValue();
}
