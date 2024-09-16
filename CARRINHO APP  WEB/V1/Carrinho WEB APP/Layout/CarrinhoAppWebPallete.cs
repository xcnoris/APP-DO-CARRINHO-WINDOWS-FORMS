using MudBlazor;
using MudBlazor.Utilities;

namespace Carrinho_WEB_APP.Layout
{
    public class CarrinhoAppWebPallete : PaletteDark
    {
        public CarrinhoAppWebPallete()
        {
            Primary = new MudColor("#9966FF");
            Secondary = new MudColor("#F6AD31");
            Tertiary = new MudColor("#8AE491");
        }

        public static CarrinhoAppWebPallete CreatePallete => new();
    }
}
