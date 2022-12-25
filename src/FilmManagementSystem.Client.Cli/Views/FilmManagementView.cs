namespace FilmManagementSystem.Client.Cli.Views;

public class FilmManagementView : IView
{
    private FilmAddActionPresenter _filmAddActionPresenter;

    public FilmManagementView(FilmAddActionPresenter filmAddActionPresenter)
    {
        _filmAddActionPresenter = filmAddActionPresenter ?? 
            throw new ArgumentNullException(nameof(filmAddActionPresenter));
    }

    public void Invoke()
    {
        
        throw new NotImplementedException();
    }
}
