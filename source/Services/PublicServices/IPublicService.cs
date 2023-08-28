using alrahmacare00.Models;
using alrahmacare00.Models.MedicalSpecialty;

namespace alrahmacare00.Services.PublicServices;

public interface IPublicService
{
    Task<PagedResponse<SpecialtyModel>> GetAllSpecialtiesAsync(string guidUser);
}
