using System.Reactive;
using ReactiveUI;

namespace Library.ViewModels;

public class LibraryViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> GoToReadRooms { get; }

    public LibraryViewModel()
    {
        GoToReadRooms = _naviToVM(new ReadRoomViewModel());
    }

}