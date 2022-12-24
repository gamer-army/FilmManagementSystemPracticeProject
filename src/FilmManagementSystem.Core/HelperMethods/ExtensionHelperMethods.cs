namespace FilmManagementSystem.Core;

public static class ExtensionHelperMethods
{
    public static string WithPreceeding0s(this int num, ushort zeroes)
    {
        string numStr = $"{num}";
        string preceeding0s = new string('0', zeroes - numStr.Length);
        return preceeding0s + numStr;
    }

    // public static TimeOnly EndTime(this Screening screening, Film){
    //     return null;
    // }
}
