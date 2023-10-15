using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace DrasatHealthMobile.Helpers;

public static class Alerts
{
    public async static Task DisplayAlert(string classname, string methodName, string message)
    {
        try
        {
            await Shell.Current.DisplayAlert(classname + ": method: " + methodName, message, "cancel");
        }
        catch (Exception)
        {
        }
    }

    public async static Task ToastAlert(string message)
    {
        try
        {
            CancellationTokenSource cancellationTokenSource = new();
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 14;

            var toast = Toast.Make(message, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
        catch (Exception)
        {
        }
    }
}
