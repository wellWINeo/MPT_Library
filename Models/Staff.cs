using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class Staff
{
    public int StaffId { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string PassportSeries { get; set; }
    public string PassportNumber { get; set; }
    public DateOnly DateOfEmployment { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual Branch? Branch { get; set; }
}