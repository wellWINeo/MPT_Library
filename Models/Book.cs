using System.ComponentModel;

namespace Library.Models;

public class Book : INotifyPropertyChanged
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int YearOfRelease { get; set; }
    public int Quantity { get; set; }
    public virtual Branch Branch { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual Author Author { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}