namespace hesap_makinesi33.view;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        string savedTheme = Preferences.Default.Get("AppTheme", "System");

        if (savedTheme == "Light")
            LightRadio.IsChecked = true;
        else if (savedTheme == "Dark")
            DarkRadio.IsChecked = true;
        else
            SystemRadio.IsChecked = true;
    }
    private void ThemeChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;

        RadioButton selectedButton = (RadioButton)sender;

        string selectedTheme = selectedButton.Value.ToString();

        Preferences.Default.Set("AppTheme", selectedTheme);

        if (selectedTheme == "Light")
            Application.Current!.UserAppTheme = AppTheme.Light;
        else if (selectedTheme == "Dark")
            Application.Current!.UserAppTheme = AppTheme.Dark;
        else
            Application.Current!.UserAppTheme = AppTheme.Unspecified;
    }
}