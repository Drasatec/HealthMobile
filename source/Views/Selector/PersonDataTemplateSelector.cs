namespace DrasatHealthMobile.Views.Selector;

public class PersonDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate ValidTemplate { get; set; }
    public DataTemplate InvalidTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        return ((string)item) == "" ? ValidTemplate : InvalidTemplate;
    }
}