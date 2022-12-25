namespace FilmManagementSystem.Client.Cli;

public abstract class PromptScreen
{
    public abstract void Prompt();

    protected string PromptInput(string promptMessage)
    {
        Console.Write($"{promptMessage} :");
        string? strInput = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(strInput))
        {
            throw new Exception();
        }

        return strInput;
    }
}
