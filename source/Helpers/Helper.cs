using System.Globalization;
using System.Text.RegularExpressions;

namespace DrasatHealthMobile.Helpers;
public static class Helper
{
    public static string Language
    {
        get 
        { 
            var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            if (lang == "ar" || lang == "en" || lang == "fr")
                return lang;
            else
                return "en";
        } 
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
                query.Append('=');
                query.Append(Uri.EscapeDataString((string)param.Value));
                query.Append('&');
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
                query.Append('=');
                query.Append(Uri.EscapeDataString((string)param.Value));
                query.Append('&');
            }
            Console.WriteLine(query.ToString().TrimEnd('&'));
            return query.ToString().TrimEnd('&');
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(Helper), nameof(BuildQueryString), ex.Message);
            return string.Empty;
        }
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        //var emailValidation = new EmailAddressAttribute();
        //return emailValidation.IsValid(email);

        // Define a regular expression pattern for a valid email address
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Create a Regex object and use it to match the email address
        Regex regex = new(pattern);
        return regex.IsMatch(email);
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;
        // Define a regex pattern for a valid US phone number
        string pattern = @"^[0-9]+$";

        // Create a Regex object and use it to match the phone number
        Regex regex = new(pattern);
        return regex.IsMatch(phoneNumber);
    }
}

