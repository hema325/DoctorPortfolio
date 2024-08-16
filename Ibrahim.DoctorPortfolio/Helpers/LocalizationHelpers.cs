using System.Globalization;

namespace Ibrahim.DoctorPortfolio.Helpers
{
    public static class LocalizationHelpers
    {
        public static string Localize(string textAr, string textEn)
        {
            var cultureInfo = CultureInfo.CurrentCulture;

            if (cultureInfo.Name.StartsWith("ar"))
                return textAr;

            return textEn;
        }
    }
}
