
namespace DrasatHealthMobile.Helpers;
public static class AppPreferences
{
    public static int GetUserId()
    {
        return  Helper.GetValue<int>("userId", 0);
    }
}
