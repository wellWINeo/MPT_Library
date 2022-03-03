using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Library.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class ReadRoomViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, IRoutableViewModel?> GoBack { get; }

    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public int SeatsCount { get; set; }
    [Reactive] public int Number { get; set; }
    
    public  ObservableCollection<ReadingRoom> ReadingRooms { get; }
 
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }
    
    public ReadRoomViewModel()
    {
        ReadingRooms = new(db.ReadingRooms);
        GoBack = HostScreen.Router.NavigateBack;
        
        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }
    

    private async Task add()
    {
        var readingRoom = new ReadingRoom
        {
            Number = Number, 
            SeatsCount = SeatsCount
        };
        
        ReadingRooms.Add(readingRoom);
        await db.ReadingRooms.AddAsync(readingRoom);
        await db.SaveChangesAsync();
    }

    private async Task update()
    {
        ReadingRooms[SelectedIdx].Number = Number;
        ReadingRooms[SelectedIdx].SeatsCount = SeatsCount;
        db.ReadingRooms.Update(ReadingRooms[SelectedIdx]);
        await db.SaveChangesAsync();
    }

    private async Task delete()
    {
        db.ReadingRooms.Remove(ReadingRooms[SelectedIdx]);
        ReadingRooms.RemoveAt(SelectedIdx);
        await db.SaveChangesAsync();
    }
    
}