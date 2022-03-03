using System.Reactive;
using ReactiveUI;

namespace Library.ViewModels;

public class AuthorsViewModel : ViewModelBase
{
    
    public ReactiveCommand<Unit, IRoutableViewModel?> GoToBooks { get; }

    public AuthorsViewModel()
    {
        GoToBooks = HostScreen.Router.NavigateBack;
    }
    
}