using System;
using System.ComponentModel;

namespace Library.Models;

public class Branch : INotifyPropertyChanged
{
    public int BranchId { get; set; }
    public string Address { get; set; }
    public int Number { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public virtual Library Library { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}