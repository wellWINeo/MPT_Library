using System;
using System.ComponentModel;

namespace Library.Models;

public class Library : INotifyPropertyChanged
{
    public int LibraryId { get; set; }
    public string Address { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public string PhoneNumber { get; set; }
    public virtual ReadingRoom ReadingRoom { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}