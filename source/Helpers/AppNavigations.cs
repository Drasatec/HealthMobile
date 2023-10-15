namespace DrasatHealthMobile.Helpers;

public static class AppNavigations
{
    public async static void GoToMainPage(bool animate = false)
    {
        await Shell.Current.GoToAsync("///main", animate);
    }
    
    public async static void GoToLoginPage(bool animate = true)
    {
        await Shell.Current.GoToAsync("LoginView", true);
    }
    public async static Task GoToAsync(string page, bool animate = false)
    {
        try
        {
            await Shell.Current.GoToAsync(page, animate);
        }
        catch (Exception ex)
        {
            await Alerts.ToastAlert(ex.Message);
        }
    }

    public async static void GoTo(string page, bool animate = false)
    {
        try
        {
            await Shell.Current.GoToAsync(page, animate);
        }
        catch (Exception ex)
        {
            await Alerts.ToastAlert(ex.Message);
        }
    }

}
