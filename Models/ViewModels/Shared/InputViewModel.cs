using BlackMetalBlog.Models.Enums;

namespace BlackMetalBlog.Models.ViewModels.Shared;

public class InputViewModel(
    string inputId,
    string inputName,
    string? inputPlaceholder,
    InputTypesEnum
        inputType,
    dynamic? value = null)
{
    public bool InputAutocomplete => false;

    public string LabelFor { get; init; } = inputId;

    public string InputId { get; init; } = inputId;

    public string InputName { get; init; } = inputName;

    public string? InputPlaceholder { get; init; } = inputPlaceholder;

    public string InputType { get; init; } = inputType.GetValue();

    public object? Value { get; init; } = value;
}
