using System.Reactive;
using ReactiveUI;

namespace Library.ViewModels;

public class BranchViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> GoToReadRooms { get; }

    public BranchViewModel()
    {
        GoToReadRooms = _naviToVM(new ReadRoomViewModel());
    }
}