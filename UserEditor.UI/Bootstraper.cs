using System.Reflection;
using Autofac;
using MvvmElegance;
using UserEditor.Shared;
using UserEditor.ViewModels;

namespace UserEditor.UI;

public class Bootstraper:AutofacBootstrapper<MainViewModel>
{
    protected override void ConfigureServices(ContainerBuilder builder)
    {
        builder.RegisterInstance(new Common()).As<ICommon>();
        
        builder.RegisterAssemblyTypes(typeof(MainViewModel).Assembly)
            .Where(t => t.Name.EndsWith("ViewModel"));
        
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("View"));
    }
}