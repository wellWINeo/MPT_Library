using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Library.ViewModels;

public class EmployeeViewModel : ViewModelBase
{
    public ObservableCollection<Staff> Staves { get; }
    public ObservableCollection<Branch> Branches { get; }
    
    [Reactive] public int SelectedIdx { get; set; }
    [Reactive] public int SelectedBranchIdx { get; set; }
    
    [Reactive] public string Surname { get; set; }
    [Reactive] public string Name { get; set; }
    [Reactive] public string Patronymic { get; set; }
    [Reactive] public string PassportSeries { get; set; }
    [Reactive] public string PassportNumber { get; set; }
    [Reactive] public DateOnly DateOfEmployment { get; set; }
    [Reactive] public string PhoneNumber { get; set; }
    [Reactive] public string Email { get; set; }
    [Reactive] public string Password { get; set; }

    private Branch Branch => Branches[SelectedBranchIdx];
    private Staff Staff => Staves[SelectedIdx];
    
    public ReactiveCommand<Unit, Unit> AddCommand { get; }
    public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public EmployeeViewModel()
    {
        Staves = new(db.Staves.Include(e => e.Branch));
        Branches = new(db.Branches);

        AddCommand = ReactiveCommand.CreateFromTask(add);
        UpdateCommand = ReactiveCommand.CreateFromTask(update);
        DeleteCommand = ReactiveCommand.CreateFromTask(delete);
    }

    /// <summary>
    /// добавление
    /// </summary>
    private async Task add()
    {
        var staff = new Staff
        {
            Surname = Surname,
            Name = Name,
            Patronymic = Patronymic,
            PassportSeries = PassportSeries,
            PassportNumber = PassportNumber,
            DateOfEmployment = DateOfEmployment,
            PhoneNumber = PhoneNumber,
            Email = Email,
            Password = Password,
            Branch = Branch
        };

        await db.Staves.AddAsync(staff);
        await db.SaveChangesAsync();
        
        Staves.Add(staff);
    }
    
    /// <summary>
    /// обновление
    /// </summary>
    private async Task update()
    {
        Staff.Surname = Surname;
        Staff.Name = Name;
        Staff.Patronymic = Patronymic;
        Staff.PassportSeries = PassportSeries;
        Staff.PassportNumber = PassportNumber;
        Staff.DateOfEmployment = DateOfEmployment;
        Staff.PhoneNumber = PhoneNumber;
        Staff.Email = Email;
        Staff.Password = Password;
        Staff.Branch = Branch;

        db.Staves.Update(Staff);
        await db.SaveChangesAsync();
    }
    
    /// <summary>
    /// удаление
    /// </summary>
    private async Task delete()
    {
        db.Staves.Remove(Staff);
        await db.SaveChangesAsync();
        Staves.RemoveAt(SelectedIdx);
    }
    
}