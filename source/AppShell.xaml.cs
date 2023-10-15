using DrasatHealthMobile.Views;
namespace DrasatHealthMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("AddBookingView", typeof(AddBookingView));
        Routing.RegisterRoute("AddMemberView", typeof(AddMemberView));
        Routing.RegisterRoute("BookingDetailsView", typeof(BookingDetailsView));
        Routing.RegisterRoute("BookingsView", typeof(BookingsView));
        Routing.RegisterRoute("DoctorDetailsView", typeof(DoctorDetailsView));
        Routing.RegisterRoute("DoctorsView", typeof(DoctorsView));
        Routing.RegisterRoute("DoSomethingView", typeof(DoSomethingView));
        Routing.RegisterRoute("LoginView", typeof(LoginView));
        Routing.RegisterRoute("MedicalServicesView", typeof(MedicalServicesView));
        Routing.RegisterRoute("MembersView", typeof(MembersView));
        Routing.RegisterRoute("NotificationsView", typeof(NotificationsView));
        Routing.RegisterRoute("ProfileView", typeof(ProfileView));
        Routing.RegisterRoute("RegisterView", typeof(RegisterView));
        Routing.RegisterRoute("SearchView", typeof(SearchView));
        Routing.RegisterRoute("SpecialtiesView", typeof(SpecialtiesView));
        Routing.RegisterRoute("PrivacyPolicyView", typeof(PrivacyPolicyView));
    }
}
