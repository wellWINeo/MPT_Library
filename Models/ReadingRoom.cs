using System.ComponentModel;

namespace Library.Models;

public class ReadingRoom : INotifyPropertyChanged
{
    public int ReadingRoomId { get; set; }
    public int Number { get; set; }
    public int SeatsCount { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}