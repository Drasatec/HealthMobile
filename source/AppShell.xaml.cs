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
        Routing.RegisterRoute("BookingByPatient", typeof(BookingByPatientView));

    }
}
