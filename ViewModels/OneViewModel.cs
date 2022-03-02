using System.Reactive;
using System.Reactive.Linq;
using JetBrains.Annotations;
using ReactiveUI;

namespace Library.ViewModels;

public class OneViewModel : ViewModelBase
{
    public string MessageOne => "Hi, from one";
    public ReactiveCommand<Unit, Unit> GoToSecond { get; }
    public ReactiveCommand<Unit, Unit> GoToThird { get; }

    public OneViewModel()
    {
        GoToSecond = ReactiveCommand.CreateFromTask(async ()
            => await HostScreen.Router.Navigate.Execute(new SecondViewModel())
                .Select(_ => Unit.Default)
        );

        GoToThird = ReactiveCommand.CreateFromTask(async ()
            => await HostScreen.Router.Navigate.Execute(new ThirdViewModel())
                .Select(_ => Unit.Default)
        );

    }
}