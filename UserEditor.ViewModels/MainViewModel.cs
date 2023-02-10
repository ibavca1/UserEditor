using UserEditor.Shared;

namespace UserEditor.ViewModels;

public class MainViewModel
{
    public string Gretting => "AVALONIA";

    private ICommon _common;
    public MainViewModel(ICommon common)
    {
        _common = common;
    }
}