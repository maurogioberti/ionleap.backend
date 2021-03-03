using System.Globalization;

namespace Neoris.Ionleap.CrossCutting.Utils.Date
{
    public static class Culture
    {
        public static string DateTimeFormat = "dd-MM-yyyy hh:mm:ss";
        public static string DateFormat = "dd-MM-yyyy";
        public static string FileDateFormat = "yyyyMMdd";
        public static string UtcDateTimeFormat = "yyyy-MM-dd hh:mm:ss";
        public static string TimeFormat = "hh:mm:ss";
        public static string DataBaseDateFormat = "yyyy-MM-dd";

        public static CultureInfo Info = CultureInfo.InvariantCulture;
    }
}
