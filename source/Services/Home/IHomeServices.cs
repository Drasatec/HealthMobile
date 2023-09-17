using DrasatHealthMobile.Models;
using DrasatHealthMobile.Models.Hospital;
using DrasatHealthMobile.Models.Promotion;

namespace DrasatHealthMobile.Services.Home;

public interface IHomeServices
{
    Task<List<HospitalTranslation>> GetHosNamesAsync(string guidUser, string token);
    Task<PagedResponse<PromotionModel>> GetPromotionModelAsync(string guidUser);
}
