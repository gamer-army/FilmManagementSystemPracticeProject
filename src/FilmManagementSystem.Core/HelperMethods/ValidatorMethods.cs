namespace FilmManagementSystem.Core;

public static class ValidatorMethods
{
    public static bool IsAlphanumeric(this string val)
        => Regex.IsMatch(val, "^[A-Za-z0-9]{1,}$");
    

    public static bool IsValidName(this string val)
        => (val.Length > 2 && val.Length < 101) && 
            Regex.IsMatch(val, "^[A-Z][A-Za-z]{1,}( [A-Z][A-Za-z]{1,}){0,}$");

    public static bool IsPast(this DateOnly date)
        => date < DateOnly.FromDateTime(DateTime.Now);

    public static bool IsValidFilmID(this string val)
        => val.Length == 4 && val.IsAlphanumeric();
}
