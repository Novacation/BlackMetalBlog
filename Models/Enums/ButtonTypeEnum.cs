namespace BlackMetalBlog.Models.Enums;

public enum ButtonTypeEnum
{
    Button, // Maps to "button"
    Submit, // Maps to "submit"
    Reset // Maps to "reset"
}

public static class ButtonTypeExtensions
{
    public static string GetValue(this ButtonTypeEnum buttonType)
    {
        return buttonType switch
        {
            ButtonTypeEnum.Button => "button",
            ButtonTypeEnum.Submit => "submit",
            ButtonTypeEnum.Reset => "reset",
            _ => "button"
        };
    }
}
