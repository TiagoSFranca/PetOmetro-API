using System.Globalization;

namespace PetOmetro.Common.Helpers
{
    public static class ConvertHelper
    {
        public static int? ConvertStringToNullableInt(string stringValue)
        {
            int? numericValue = int.TryParse(stringValue, NumberStyles.Any, new CultureInfo("pt-BR"), out int temp) ? temp : default(int?);

            return numericValue;
        }
    }
}
