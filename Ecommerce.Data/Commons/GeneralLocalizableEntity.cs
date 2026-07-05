using System.Globalization;

namespace Ecommerce.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string textEN, string textAr)
        {
            CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
            if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEN;
        }
    }
}
