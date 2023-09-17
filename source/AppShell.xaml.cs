using DrasatHealthMobile.Views;
using DrasatHealthMobile.Views;

namespace DrasatHealthMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		FlowDirection = FlowDirection.RightToLeft;

        Routing.RegisterRoute("SearchView", typeof(SearchView));
        Routing.RegisterRoute("SpecialtiesView", typeof(SpecialtiesView));
        Routing.RegisterRoute("DoctorDetailsView", typeof(DoctorDetailsView));
        Routing.RegisterRoute("BookingByPatient", typeof(AddBookingView));
        Routing.RegisterRoute("BookingDetailsView", typeof(BookingDetailsView));
        Routing.RegisterRoute("BookingsView", typeof(BookingsView));
        Routing.RegisterRoute("DoctorsView", typeof(DoctorsView));
        Routing.RegisterRoute("ProfileView", typeof(ProfileView));
        Routing.RegisterRoute("DoSomethingView", typeof(DoSomethingView));
        Routing.RegisterRoute("AddMemberView", typeof(AddMemberView));
        Routing.RegisterRoute("MembersView", typeof(MembersView));
        Routing.RegisterRoute("MedicalServicesView", typeof(MedicalServicesView));
        Routing.RegisterRoute("NotificationsView", typeof(NotificationsView));
        Routing.RegisterRoute("LoginView", typeof(RegisterView));
    }
}
