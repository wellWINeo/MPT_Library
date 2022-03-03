using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Library.Models;

public class Author : INotifyPropertyChanged
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}