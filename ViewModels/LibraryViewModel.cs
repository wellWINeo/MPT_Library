using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Library.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class LibraryViewModel : ViewModelBase
{
    public ObservableCollection<Models.Library> Libraries { get; }
    public ObservableCollection<ReadingRoom> ReadingRooms { get; }
    
    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public int SelectedReadingRoomIdx { get; set; }

    [Reactive] public string Address { get; set; }
    [Reactive] public TimeOnly OpenTime { get; set; }
    [Reactive] public TimeOnly CloseTime { get; set; }
    [Reactive] public string PhoneNumber { get; set; }
    public ReadingRoom ReadingRoom => ReadingRooms[SelectedReadingRoomIdx];

    public ReactiveCommand<Unit, Unit> GoToReadRooms { get; }
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public LibraryViewModel()
    {
        Libraries = new(db.Libraries);
        ReadingRooms = new(db.ReadingRooms);
        
        GoToReadRooms = _naviToVM(new ReadRoomViewModel());

        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }

    private async Task add()
    {
        var library = new Models.Library
        {
            Address = Address,
            OpenTime = OpenTime,
            CloseTime = CloseTime,
            PhoneNumber = PhoneNumber,
            ReadingRoom = ReadingRoom
        };

        await db.Libraries.AddAsync(library);
        await db.SaveChangesAsync();
    }
    
    private async Task update()
    {
        Libraries[SelectedIdx].Address = Address;
        Libraries[SelectedIdx].OpenTime = OpenTime;
        Libraries[SelectedIdx].CloseTime = CloseTime;
        Libraries[SelectedIdx].PhoneNumber = PhoneNumber;
        Libraries[SelectedIdx].ReadingRoom = ReadingRoom;
        db.Libraries.Update(Libraries[SelectedIdx]);
        await db.SaveChangesAsync();

    }
    
    private async Task delete()
    {
        db.Libraries.Remove(Libraries[SelectedIdx]);
        Libraries.RemoveAt(SelectedIdx);
        await db.SaveChangesAsync();
    }

}