using alrahmacare00.Models;
using alrahmacare00.Models.Hospital;
using alrahmacare00.Models.Promotion;

namespace alrahmacare00.Services.Home;

public interface IHomeServices
{
    Task<List<HospitalTranslation>> GetHosNamesAsync(string guidUser, string token);
    Task<PagedResponse<PromotionModel>> GetPromotionModelAsync(string guidUser);
}
