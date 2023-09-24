using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.ApplicationModel.Communication;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DrasatHealthMobile.Helpers;
public static class Helper
{
    public static string Language
    {
        get => "ar";
    }
    public static bool SetValue(string key, string value)
    {
        Preferences.Default.Set(key, value);
        return true;
    }
    
    public static string GetValue(string key)
    {
        return Preferences.Default.Get<string>(key,"no");
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
    
    public async static Task ToastAlert(string message)
    {
        try
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(message, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
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

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        //var emailValidation = new EmailAddressAttribute();
        //return emailValidation.IsValid(email);

        // Define a regular expression pattern for a valid email address
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Create a Regex object and use it to match the email address
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;
        // Define a regex pattern for a valid US phone number
        string pattern = @"^[0-9]+$";

        // Create a Regex object and use it to match the phone number
        Regex regex = new Regex(pattern);
        return regex.IsMatch(phoneNumber);
    }
}

