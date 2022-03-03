using System;

namespace Library.Models;

public class Library
{
    public int LibraryId { get; set; }
    public string Address { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public string PhoneNumber { get; set; }
    public virtual ReadingRoom ReadingRoom { get; set; }
}