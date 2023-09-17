namespace DrasatHealthMobile.Helpers;
public static class Helper
{
    public static string Language
    {
        get => "ar";
    }
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

    public async static Task NavigationToAsync(string page, bool animate = false)
    {
        await Shell.Current.GoToAsync(page, animate);
    }

    public static string BuildQueryString(System.Collections.Generic.Dictionary<string, object> queryParams)
    {
        try
        {
            if (queryParams.Count == 0)
                return "";

            var query = new System.Text.StringBuilder("?");
            foreach (var param in queryParams)
            {
                query.Append(Uri.EscapeDataString(param.Key));
                query.Append("=");
                query.Append(Uri.EscapeDataString((string)param.Value));
                query.Append("&");
            }
            Console.WriteLine(query.ToString().TrimEnd('&'));
            return query.ToString().TrimEnd('&');
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("BuildQueryString", ex.Message, "cancel");
            return string.Empty;
        }
    }

    public static async Task<string> BuildQueryString(System.Collections.Generic.Dictionary<string, string> queryParams)
    {
        try
        {
            if (queryParams.Count == 0)
                return "";

            var query = new System.Text.StringBuilder("?");
            foreach (var param in queryParams)
            {
                query.Append(Uri.EscapeDataString(param.Key));
                query.Append("=");
                query.Append(Uri.EscapeDataString((string)param.Value));
                query.Append("&");
            }
            Console.WriteLine(query.ToString().TrimEnd('&'));
            return query.ToString().TrimEnd('&');
        }
        catch (Exception ex)
        {
            await DisplayAlert(nameof(Helper), nameof(BuildQueryString), ex.Message);
            return string.Empty;
        }
    }
}

