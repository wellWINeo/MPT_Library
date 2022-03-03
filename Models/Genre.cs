using System.ComponentModel;

namespace Library.Models;

public class Genre : INotifyPropertyChanged
{
    public int GenreId { get; set; }
    public string Name { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
}