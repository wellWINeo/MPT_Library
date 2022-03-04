using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class IssueCertificateViewModel : ViewModelBase
{
    public ObservableCollection<IssueCertificate> IssueCertificates { get; }
    public ObservableCollection<Client> Clients { get; }
    public ObservableCollection<Book> Books { get; }
    
    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public int SelectedClientIdx { get; set; }
    [Reactive] public int SelectedBookIdx { get; set; }
    
    [Reactive] public DateOnly DateOfIssue { get; set; }
    [Reactive] public DateOnly DateOfDelivery { get; set; }
    [Reactive] public bool IsReturned { get; set; } = false;

    private IssueCertificate IssueCertificate => IssueCertificates[SelectedIdx];
    private Client Client => Clients[SelectedClientIdx];
    private Book Book => Books[SelectedBookIdx];
    
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }
    
    /// <summary>
    /// ctor
    /// </summary>
    public IssueCertificateViewModel()
    {
        IssueCertificates = new(db.IssueCertificates
            .Include(e => e.Client)
            .Include(e => e.Book));
        Clients = new(db.Clients);
        Books = new(db.Books);

        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }

    /// <summary>
    /// добавление
    /// </summary>
    private async Task add()
    {
        var issueCert = new IssueCertificate
        {
            DateOfIssue = DateOfIssue,
            DateOfDelivery = DateOfDelivery,
            IsReturned = IsReturned,
            Client = Client,
            Book = Book
        };

        await db.IssueCertificates.AddAsync(issueCert);
        await db.SaveChangesAsync();
        
        IssueCertificates.Add(issueCert);
    }
    
    /// <summary>
    /// обновление
    /// </summary>
    private async Task update()
    {
        IssueCertificate.DateOfIssue = DateOfIssue;
        IssueCertificate.DateOfDelivery = DateOfDelivery;
        IssueCertificate.IsReturned = IsReturned;
        IssueCertificate.Client = Client;
        IssueCertificate.Book = Book;

        db.IssueCertificates.Update(IssueCertificate);
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// удаление
    /// </summary>
    private async Task delete()
    {
        db.IssueCertificates.Remove(IssueCertificate);
        IssueCertificates.RemoveAt(SelectedIdx);
    }
}