using System.Globalization;

namespace Identity.CrossCutting;

public static class GlobalSettings
{
    public static void Apply()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("pt-BR");
    }
}