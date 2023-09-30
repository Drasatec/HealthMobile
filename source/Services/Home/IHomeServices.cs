using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Hospital;
using DrasatHealthMobile.Models.Promotion;

namespace DrasatHealthMobile.Services.Home;

public interface IHomeServices
{
    Task<List<Models.Hospital.HospitalTranslation>> GetHosNamesAsync(string guidUser, string token);
    Task<PagedResponse<PromotionModel>> GetPromotionModelAsync(string guidUser);
}
