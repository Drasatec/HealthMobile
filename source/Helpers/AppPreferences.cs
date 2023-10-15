
namespace DrasatHealthMobile.Helpers;
public static class AppPreferences
{
    public static int UserId => GetValue<int>("userId", -1);
    public static string UserEmail=> GetValue<string>("userEmail", "");

    public static bool IsLogin => (UserId > 0);

    public static int GetUserId()
    {
        return GetValue<int>("userId", -1);
    }
    public static string GetUserPhoneNumber()
    {
        return GetValue<string>("phoneNumber", "0");
    }

    public static string GetToken()
    {
        return GetValue<string>("token", "");
    }

    public static bool ClearAll()
    {
        SetValue("token", string.Empty);
        SetValue("userName", string.Empty);
        SetValue<int>("userId", -1);
        SetValue("userEmail", "");
        return true;
    }

    public static bool SetValue<T>(string key, T value)
    {
        try
        {
            Preferences.Default.Set<T>(key, value);
            return true;
        }
        catch (Exception ex)
        {
            Alerts.ToastAlert(ex.Message).Wait();
            return false;
        }
    }

    public static T GetValue<T>(string key, T def = default)
    {
        try
        {
            return Preferences.Default.Get<T>(key, def);
        }
        catch (Exception ex)
        {
            Alerts.ToastAlert(ex.Message).Wait();
            return default;
        }
    }
}
