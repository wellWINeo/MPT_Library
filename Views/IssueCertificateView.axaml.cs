using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
public partial class IssueCertificateView : ReactiveUserControl<IssueCertificateViewModel>
{
    
    /// <summary>
    /// ctor
    /// </summary>
    public IssueCertificateView()
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
            this.Bind(ViewModel, vm => vm.SelectedClientIdx, view => view.Client.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedBookIdx, view => view.Book.SelectedIndex)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.DateOfIssue, view => view.IssueDate.SelectedDate,
                    vmToViewConverterOverride: new DateOnlyToDateTimeOffsetBindingConverter(),
                    viewToVMConverterOverride: new DateTimeOffsetToDateOnlyBindingConverter())
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.DateOfDelivery, view => view.ReturnDate.SelectedDate,
                    vmToViewConverterOverride: new DateOnlyToDateTimeOffsetBindingConverter(),
                    viewToVMConverterOverride: new DateTimeOffsetToDateOnlyBindingConverter())
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.IsReturned, view => view.ReturnDate.SelectedDate,
                    x => x ? DateTime.Now : (DateTimeOffset?) null,
                    x => x != null)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.IssueCertificates, view => view.Grid.Items,
                    value => value as IEnumerable<IssueCertificate>,
                    value => value as ObservableCollection<IssueCertificate>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Clients, view => view.Client.Items,
                    value => value as IEnumerable<Client>,
                    value => value as ObservableCollection<Client>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Books, view => view.Book.Items,
                    value => value as IEnumerable<Book>,
                    value => value as ObservableCollection<Book>)
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
        var issueCert = Grid.SelectedItem as IssueCertificate;
        IssueDate.SelectedDate = issueCert.DateOfIssue.ToDateTime(TimeOnly.Parse("12:00"));
        ReturnDate.SelectedDate = issueCert.DateOfDelivery.ToDateTime(TimeOnly.Parse("12:00"));
    }
}