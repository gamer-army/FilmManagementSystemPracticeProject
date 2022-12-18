namespace FilmManagementSystem.Core;

public static class ExtensionHelperMethods
{
    public static bool IsAlphanumeric(this string val)
    {
        return Regex.IsMatch(val, "^[A-Za-z0-9]{1,}$");
    }
}
