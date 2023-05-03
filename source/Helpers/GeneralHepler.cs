namespace DrasatHealthMobile.Helpers;
public static class GeneralHepler
{
    public static void DisplayAlert()
    {
        Shell.Current.DisplayAlert("title", "message", "cancel");
        
    }
}

