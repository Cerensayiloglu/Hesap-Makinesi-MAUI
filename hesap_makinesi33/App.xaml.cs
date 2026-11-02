using Microsoft.Extensions.DependencyInjection;
namespace hesap_makinesi33;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        string savedTheme = Preferences.Default.Get("AppTheme", "System");

        if (savedTheme == "Light")
        {
            UserAppTheme = AppTheme.Light;
        }
        else if (savedTheme == "Dark")
        {
            UserAppTheme = AppTheme.Dark;
        }
        else
        {
            UserAppTheme = AppTheme.Unspecified;
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
