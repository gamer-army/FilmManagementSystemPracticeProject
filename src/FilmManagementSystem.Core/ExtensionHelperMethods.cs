namespace FilmManagementSystem.Core;

public static class ExtensionHelperMethods
{
    public static bool IsAlphanumeric(this string val)
    {
        return Regex.IsMatch(val, "^[A-Za-z0-9]{1,}$");
    }

    public static bool IsValidName(this string val)
    {
        return (val.Length > 2 && val.Length < 101) && 
            Regex.IsMatch(val, "^[A-Z][A-Za-z]{1,}( [A-Z][A-Za-z]{1,}){0,}$");
    }

    public static bool IsPast(this DateOnly date)
    {
        return date < DateOnly.FromDateTime(DateTime.Now);
    }
}
