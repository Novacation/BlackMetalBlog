namespace BlackMetalBlog.Models.Enums;

public enum ButtonTypesEnum
{
    Button, // Maps to "button"
    Submit, // Maps to "submit"
    Reset // Maps to "reset"
}

public static class ButtonTypeExtensions
{
    public static string GetValue(this ButtonTypesEnum buttonTypes)
    {
        return buttonTypes switch
        {
            ButtonTypesEnum.Button => "button",
            ButtonTypesEnum.Submit => "submit",
            ButtonTypesEnum.Reset => "reset",
            _ => "button"
        };
    }
}
