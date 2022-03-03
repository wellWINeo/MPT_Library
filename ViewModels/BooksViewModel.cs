using System.Reactive;
using ReactiveUI;

namespace Library.ViewModels;

public class BooksViewModel : ViewModelBase
{
    
    public ReactiveCommand<Unit, Unit> GoToAuthors { get; }
    public ReactiveCommand<Unit, Unit> GoToGenres { get; }

    public BooksViewModel()
    {
        GoToAuthors = _naviToVM(new AuthorsViewModel());
        GoToGenres = _naviToVM(new GenresViewModel());
    }
}