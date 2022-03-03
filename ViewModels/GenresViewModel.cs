using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Library.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class GenresViewModel : ViewModelBase
{
    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public string Name { get; set; }
    
    public  ObservableCollection<Genre> Genres { get; }
 
    public ReactiveCommand<Unit, IRoutableViewModel?> GoToBooks { get; }
    
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public GenresViewModel()
    {
        Genres = new(db.Genres);
        GoToBooks = HostScreen.Router.NavigateBack;

        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }

    private async Task add()
    {
        var genre = new Genre { Name = Name };
        
        Genres.Add(genre);
        await db.Genres.AddAsync(genre);
        await db.SaveChangesAsync();
    }

    private async Task update()
    {
        Genres[SelectedIdx].Name = Name;
        db.Genres.Update(Genres[SelectedIdx]);
        await db.SaveChangesAsync();
    }

    private async Task delete()
    {
        db.Genres.Remove(Genres[SelectedIdx]);
        Genres.RemoveAt(SelectedIdx);
        await db.SaveChangesAsync();
    }
}