
namespace DrasatHealthMobile.Helpers;
public static class FlowDirectionManager
{
    public static FlowDirection CurentFlowDirection
    {
        get
        {
            if (Helper.Language == "ar")
                return  FlowDirection.RightToLeft;
            else
                return  FlowDirection.LeftToRight;
        }
    }
}
