using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class BranchViewModel : ViewModelBase
{
    public ObservableCollection<Branch> Branches { get; set; }
    public ObservableCollection<Models.Library> Libraries { get; set; }

    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public int SelectedLibraryIdx { get; set; }
    
    [Reactive] public string Address { get; set; }
    [Reactive] public int Number { get; set; }
    [Reactive] public TimeOnly OpenTime { get; set; }
    [Reactive] public TimeOnly CloseTime { get; set; }
    public Models.Library Library => Libraries[SelectedLibraryIdx];
    public ReactiveCommand<Unit, Unit> GoToReadRooms { get; }
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public BranchViewModel()
    {
        Branches = new(db.Branches.Include(e => e.Library));
        Libraries = new(db.Libraries);
        
        GoToReadRooms = _naviToVM(new ReadRoomViewModel());
        
        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }

    private async Task add()
    {
        var branch = new Branch
        {
            Address = Address,
            Number = Number,
            OpenTime = OpenTime,
            CloseTime = CloseTime,
            Library = Library
        };

        branch.Library = Library;
        
        await db.Branches.AddAsync(branch);
        await db.SaveChangesAsync();
        Branches.Add(branch);
    }
    
    private async Task update()
    {
        Branches[SelectedIdx].Address = Address;
        Branches[SelectedIdx].Number = Number;
        Branches[SelectedIdx].OpenTime = OpenTime;
        Branches[SelectedIdx].CloseTime = CloseTime;
        Branches[SelectedIdx].Library = Library;

        db.Branches.Update(Branches[SelectedIdx]);
        await db.SaveChangesAsync();
    }
    
    private async Task delete()
    {
        db.Branches.Remove(Branches[SelectedIdx]);
        await db.SaveChangesAsync();

        Branches.RemoveAt(SelectedIdx);
    }
}