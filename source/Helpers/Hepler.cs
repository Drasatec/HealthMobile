namespace DrasatHealthMobile.Helpers;
public static class Hepler
{
    public static string Language
    {
        get => "ar";
    }
    public static void DisplayAlert()
    {
        Shell.Current.DisplayAlert("title", "message", "cancel");

    }
}

