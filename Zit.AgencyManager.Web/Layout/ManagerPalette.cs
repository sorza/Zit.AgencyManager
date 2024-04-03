using MudBlazor;
using MudBlazor.Utilities;

namespace Zit.AgencyManager.Web.Layout
{
    public sealed class ManagerPalette : PaletteDark
    {
        private ManagerPalette()
        {
            Primary = new MudColor("#9966FF");
            Secondary = new MudColor("#F6AD31");
            Tertiary = new MudColor("#8AE491");
        }

        public static ManagerPalette CreatePalette => new();
    }
}
