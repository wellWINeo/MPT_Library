using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace Library.ViewModels;

public class GenresViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, IRoutableViewModel?> GoToBooks { get; }

    public GenresViewModel()
    {
        GoToBooks = HostScreen.Router.NavigateBack;
    }
}