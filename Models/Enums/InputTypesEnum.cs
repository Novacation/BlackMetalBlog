namespace BlackMetalBlog.Models.Enums;

public enum InputTypesEnum
{
    Text, // Maps to "text"
    Password, // Maps to "password"
    Number // Maps to "number"
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
            _ => "text"
        };
    }
}
