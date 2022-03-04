using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.Helper;
using Library.Models;
using Library.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class EmployeeView : ReactiveUserControl<EmployeeViewModel>
{
    /// <summary>
    /// ctor
    /// </summary>
    public EmployeeView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.AddCommand, view => view.AddButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.UpdateCommand, view => view.ChangeButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.DeleteCommand, view => view.RemoveButton)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.SelectedIdx, view => view.Grid.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedBranchIdx, view => view.Branch.SelectedIndex)
                .DisposeWith(d);
            
            this.Bind(ViewModel, vm => vm.PhoneNumber, view => view.PhoneNumber.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Surname, view => view.Surname.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Name, view => view.NameBox.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Patronymic, view => view.Patronymic.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.PassportSeries, view => view.PassportSeries.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.PassportNumber, view => view.PassportNumber.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.DateOfEmployment, view => view.EmployeeDate.SelectedDate,
                    vmToViewConverterOverride: new DateOnlyToDateTimeOffsetBindingConverter(),
                    viewToVMConverterOverride: new DateTimeOffsetToDateOnlyBindingConverter())
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Email, view => view.Email.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Password, view => view.Password.Text)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.Branches, view => view.Branch.Items,
                    value => value as IEnumerable<Branch>,
                    value => value as ObservableCollection<Branch>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Staves, view => view.Grid.Items,
                    value => value as IEnumerable<Staff>,
                    value => value as ObservableCollection<Staff>)
                .DisposeWith(d);
        });
    }

    /// <summary>
    /// изменение значений при выборе записи в таблице
    /// </summary>
    /// <param name="sender">Event raiser</param>
    /// <param name="e">Arguments</param>
    private void Grid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Grid.SelectedItem == null) return;
        var employee = Grid.SelectedItem as Staff;
        PhoneNumber.Text = employee.PhoneNumber;
        Surname.Text = employee.Surname;
        NameBox.Text = employee.Name;
        Patronymic.Text = employee.Patronymic;
        PassportSeries.Text = employee.PassportSeries;
        PassportNumber.Text = employee.PassportNumber;
        EmployeeDate.SelectedDate = (DateTimeOffset) employee.DateOfEmployment
            .ToDateTime(TimeOnly.Parse("12:00"));
        Email.Text = employee.Email;
        Password.Text = employee.Password;
    }
}