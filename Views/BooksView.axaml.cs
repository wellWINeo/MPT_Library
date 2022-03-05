using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Controls.Mixins;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Library.Models;
using Library.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertyChanged;
using ReactiveUI;

namespace Library.Views;

[DoNotNotify]
public partial class BooksView : ReactiveUserControl<BooksViewModel>
{

    /// <summary>
    /// ctor
    /// </summary>
    public BooksView()
    {
        InitializeComponent();

        this.WhenActivated(d =>
        {
            this.BindCommand(ViewModel, vm => vm.GoToAuthors, view => view.AuthorsButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.GoToGenres, view => view.GenresButton)
                .DisposeWith(d);

            this.BindCommand(ViewModel, vm => vm.AddCommand, view => view.AddButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.UpdateCommand, view => view.ChangeButton)
                .DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.DeleteCommand, view => view.RemoveButton)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.SelectedIdx, view => view.Grid.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedAuthorIdx, view => view.Author.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedBranchIdx, view => view.Branch.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.SelectedGenreIdx, view => view.Genre.SelectedIndex)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Title, view => view.Title.Text)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.YearOfRelease, view => view.ReleaseYear.Value)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Quantity, view => view.Quantity.Value)
                .DisposeWith(d);

            this.Bind(ViewModel, vm => vm.Branches, view => view.Branch.Items,
                    value => value as IEnumerable<Branch>,
                    value => value as ObservableCollection<Branch>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Authors, view => view.Author.Items,
                    value => value as IEnumerable<Author>,
                    value => value as ObservableCollection<Author>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Genres, view => view.Genre.Items,
                    value => value as IEnumerable<Genre>,
                    value => value as ObservableCollection<Genre>)
                .DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Books, view => view.Grid.Items,
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
        var book = Grid.SelectedItem as Book;
        Title.Text = book.Title;
        ReleaseYear.Value = book.YearOfRelease;
        Quantity.Value = book.Quantity;
    }
}