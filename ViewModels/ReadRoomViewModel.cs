using System.Reactive;
using ReactiveUI;

namespace Library.ViewModels;

public class ReadRoomViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, IRoutableViewModel?> GoBack { get; }

    public ReadRoomViewModel()
    {
        GoBack = HostScreen.Router.NavigateBack;
    }
    
}