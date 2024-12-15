using BlackMetalBlog.Models.Enums;

namespace BlackMetalBlog.Models.ViewModels.Shared;

public class ButtonViewModel(string? id, string text, ButtonTypesEnum buttonType, string onClickFunctionName = "")
{
    public string? Id { get; init; } = id;
    public string Text { get; init; } = text;
    public string Type { get; init; } = buttonType.GetValue();
    public string OnClickFunctionName { get; init; } = onClickFunctionName;
}
