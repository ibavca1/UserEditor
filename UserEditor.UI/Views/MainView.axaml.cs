using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UserEditor.ViewModels;

namespace UserEditor.UI.Views;

public partial class MainView : Window
{
    protected override void OnInitialized()
    {
        base.OnInitialized();
        var builder = new ContainerBuilder();
        var container = builder.Build();
        using (var scope = container.BeginLifetimeScope())
        {
            var mv = scope.Resolve<MainViewModel>();
        }
    }

    public MainView()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
}