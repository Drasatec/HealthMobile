namespace DrasatHealthMobile.Models.Promotion;

public class PromotionModel
{
    public int Id { get; set; }
    public string Photo { get; set; }
    public int Position { get; set; }
    public string Link { get; set; }
    public List<PromotionTranslationModel> PromotionsTranslations { get; set; }
    public string ImageUrl
    {
        get
        {
            if (this.Photo != null)
                return "https://api.alrahmavip.com/images/medium/" + this.Photo;
            return null;
        }
    }
}
