namespace BlackMetalBlog.Models.ViewModels.Shared;

public class ButtonModel
{
    public string? Id { get; init; }
    public required string Text { get; init; } = string.Empty;
    public required string Type { get; init; }
    public required string OnClickFunctionName { get; init; } = string.Empty;
}
