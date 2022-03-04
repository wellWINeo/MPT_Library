using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls.Remote;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class BooksViewModel : ViewModelBase
{
    public ObservableCollection<Book> Books { get; }
    public ObservableCollection<Genre> Genres { get; }
    public ObservableCollection<Branch> Branches { get; }
    public ObservableCollection<Author> Authors { get; }
    
    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public int SelectedGenreIdx { get; set; }
    [Reactive] public int SelectedAuthorIdx { get; set; }
    [Reactive] public int SelectedBranchIdx { get; set; }
    
    [Reactive] public string Title { get; set; }
    [Reactive] public int YearOfRelease { get; set; }
    [Reactive] public int Quantity { get; set; }

    private Branch Branch => Branches[SelectedBranchIdx];
    private Author Author => Authors[SelectedAuthorIdx];
    private Genre Genre => Genres[SelectedGenreIdx];
    private Book Book => Books[SelectedIdx];

    public ReactiveCommand<Unit, Unit> GoToAuthors { get; }
    public ReactiveCommand<Unit, Unit> GoToGenres { get; }
    
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public BooksViewModel()
    {
        Books = new (db.Books
            .Include(e => e.Branch)
            .Include(e => e.Genre)
            .Include(e => e.Author));
        Genres = new(db.Genres);
        Branches = new(db.Branches);
        Authors = new(db.Authors);
        
        GoToAuthors = _naviToVM(new AuthorsViewModel());
        GoToGenres = _naviToVM(new GenresViewModel());

        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }
    
    /// <summary>
    /// добавление
    /// </summary>
    private async Task add()
    {
        var book = new Book
        {
            Title = Title,
            YearOfRelease = YearOfRelease,
            Quantity = Quantity,
            Branch = Branch,
            Genre = Genre,
            Author = Author
        };

        await db.Books.AddAsync(book);
        await db.SaveChangesAsync();
        
        Books.Add(book);
    }
    
    /// <summary>
    /// обновление
    /// </summary>
    private async Task update()
    {
        Book.Title = Title;
        Book.YearOfRelease = YearOfRelease;
        Book.Quantity = Quantity;
        Book.Branch = Branch;
        Book.Genre = Genre;
        Book.Author = Author;

        db.Update(Book);
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// удаление
    /// </summary>
    private async Task delete()
    {
        db.Books.Remove(Book);
        await db.SaveChangesAsync();
        Books.RemoveAt(SelectedIdx);
    }
}