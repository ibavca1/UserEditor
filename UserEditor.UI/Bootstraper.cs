using System.Reflection;
using Autofac;
using MvvmElegance;
using UserEditor.Shared;
using UserEditor.UI.Views;
using UserEditor.ViewModels;

namespace UserEditor.UI;

public class Bootstraper:AutofacBootstrapper<MainViewModel>
{
    private MainViewModel? ViewModel;
    private MainView? View;
    protected override void ConfigureServices(ContainerBuilder builder)
    {
        builder.RegisterInstance(new Common()).As<ICommon>();
        builder.RegisterAssemblyTypes(typeof(MainViewModel).Assembly)
            .Where(t => t.Name.EndsWith(nameof(ViewModel)));
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith(nameof(View)));
    }
}