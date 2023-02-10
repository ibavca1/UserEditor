using Avalonia.Controls;
using Material.Dialog;
using Material.Dialog.Enums;
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

    private void LoginDialog()
    {
        var result = DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams
        {
            ContentHeader = "Authentication required.",
            SupportingText = "Please login before any action.",
            StartupLocation = WindowStartupLocation.CenterOwner,
            Borderless = true,
            Width = 400,
            TextFields = new[]
            {
                new TextFieldBuilderParams
                {
                    HelperText = "* Required",
                    Classes = "outline clearButton",
                    Label = "Account",
                    MaxCountChars = 24,
                    Validater = ValidateAccount,
                },
                new TextFieldBuilderParams
                {
                    HelperText = "* Required",
                    Classes = "outline",
                    Label = "Password",
                    MaxCountChars = 24,
                    MaskChar = '*',
                    FieldKind = TextFieldKind.Masked,
                    Validater = ValidatePassword,
                }
            },
            DialogButtons = new []
            {
                new DialogResultButton
                {
                    Content = "CANCEL",
                    Result = "cancel",
                },
                new DialogResultButton
                {
                    Content = "LOGIN",
                    Result = "login",
                }
            }
        });
    }

    private Tuple<bool, string> ValidateAccount(string text)
    {
        var result = text.Length >= 1;
        return new Tuple<bool, string>(result, result ? "" : "Too few account name.");
    }

    private Tuple<bool, string> ValidatePassword(string text)
    {
        var result = text.Length >= 1;
        return new Tuple<bool, string>(result, result ? "" : "Field should be filled.");
    }
    public void ShowLoginDialog()
    {
        
    }
}