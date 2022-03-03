using System;
using System.ComponentModel;

namespace Library.Models;

public class IssueCertificate : INotifyPropertyChanged
{
    public int IssueCertificateId { get; set; }
    public DateOnly DateOfIssue { get; set; }
    public DateOnly DateOfDelivery { get; set; }
    public bool IsReturned { get; set; } = false;
    public virtual Client Client { get; set; }
    public virtual Book Book { get; set; }
    
    public event PropertyChangedEventHandler? PropertyChanged;
}