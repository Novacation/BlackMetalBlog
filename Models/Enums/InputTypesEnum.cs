namespace BlackMetalBlog.Models.Enums;

public enum InputTypesEnum
{
    Text,
    Password,
    Number,
    Hidden
}

public static class InputTypesEnumExtensions
{
    public static string GetValue(this InputTypesEnum inputTypes)
    {
        return inputTypes switch
        {
            InputTypesEnum.Text => "text",
            InputTypesEnum.Password => "password",
            InputTypesEnum.Number => "number",
            InputTypesEnum.Hidden => "hidden",
            _ => "text"
        };
    }
}
