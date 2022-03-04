using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.Models;
using Library.ViewModels;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class AuthorsView : ReactiveUserControl<AuthorsViewModel>
{
    
    /// <summary>
    /// ctor
    /// </summary>
    public AuthorsView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToBooks, view => view.GoToBooksButton)
                .DisposeWith(d);

            this.BindCommand(ViewModel, vm => vm.AddCommand, view => view.AddButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.UpdateCommand, view => view.ChangeButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.DeleteCommand, view => view.RemoveButton)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.SelectedIdx, view => view.Grid.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Name, view => view.Name.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Authors, view => view.Grid.Items,
                    value => value as IEnumerable<Author>,
                    value => value as ObservableCollection<Author>)
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
        Name.Text = (this.Grid.SelectedItem as Author).Name ?? "";
    }
}