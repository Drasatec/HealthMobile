namespace DrasatHealthMobile.Models.Promotion;

public class PromotionTranslationModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PromotionId { get; set; }
    public string LangCode { get; set; }
}
