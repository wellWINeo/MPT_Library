using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Library.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class AuthorsViewModel : ViewModelBase
{
    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public string Name { get; set; }
    
    public  ObservableCollection<Author> Authors { get; set; }
 
    public ReactiveCommand<Unit, IRoutableViewModel?> GoToBooks { get; }
    
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public AuthorsViewModel()
    {
        Authors = new(db.Authors);
        GoToBooks = HostScreen.Router.NavigateBack;

        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }
    
    /// <summary>
    /// добавление
    /// </summary>
    private async Task add()
    {
        var author = new Author { Name = Name };
        
        Authors.Add(author);
        await db.Authors.AddAsync(author);
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// обновление
    /// </summary>
    private async Task update()
    {
        Authors[SelectedIdx].Name = Name;
        db.Authors.Update(Authors[SelectedIdx]);
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// удаление
    /// </summary>
    private async Task delete()
    {
        db.Authors.Remove(Authors[SelectedIdx]);
        Authors.RemoveAt(SelectedIdx);
        await db.SaveChangesAsync();
    }
    
}