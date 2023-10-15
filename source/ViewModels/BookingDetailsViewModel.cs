using CommunityToolkit.Mvvm.ComponentModel;
using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using DrasatHealthMobile.Services.PublicServices;
using System.Windows.Input;

namespace DrasatHealthMobile.ViewModels;

public class BookingDetailsViewModel : ObservableObject, IQueryAttributable
{
    public BookingDetailsViewModel(IPublicService publicService) => this.publicService = publicService;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        try
        {
            query.TryGetValue("bookingId", out bookingId);
            query.TryGetValue("bookingDetailsModel", out bookingDetailsModel);
            if (bookingDetailsModel != null)
            {
                Booking = bookingDetailsModel as BookingModel;
                OnPropertyChanged(nameof(Booking));
            }
            else
            {
                GetBooingById((int)bookingId);
            }
        }
        catch (Exception) { }
    }

    public ICommand CancelBooningCommand => new Command(CancelBooningEX);
    public ICommand RefreshingCommand => new Command(() => IsRefreshing = false);

    public BookingModel Booking { get; set; }
    public bool IsRefreshing { get => isRefreshing; set => SetProperty(ref isRefreshing, value); }
    private bool isRefreshing = false;
    private readonly IPublicService publicService;
    private object bookingDetailsModel = null;
    private object bookingId = null;

    async void CancelBooningEX()
    {
        try
        {
            if (Booking.BookingStatusId == 3)
            {
                await Alerts.ToastAlert("it was Canceled");
                return;
            }

            IsRefreshing = true;
            if (Booking == null) return;
            var queryParam = $"bookingId={Booking.Id}&statusId=3";
            var result = await publicService.CancelBooning("Booking/edit-status", queryParam);
            if (result != null && result.Success)
            {
                GetBooingById(Booking.Id);
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(BookingDetailsViewModel), nameof(GetBooingById), ex.Message);
        }
    }

    private async void GetBooingById(int id)
    {
        try
        {
            IsRefreshing = true;
            var queryParam = $"lang={Helper.Language}&id={id}";
            var result = await publicService.GetBookingByIdAsync("Booking/get-id", queryParam);
            if (result != null)
            {
                Booking = result;
                OnPropertyChanged(nameof(Booking));
            }
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(BookingDetailsViewModel), nameof(GetBooingById), ex.Message);
        }
        IsRefreshing = false;
    }
}
