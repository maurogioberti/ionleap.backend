using System;

namespace Neoris.Ionleap.CrossCutting.Utils.Date
{
    public static class DateTimeManager
    {
        private static readonly string _timestampMask = "yyyyMMddHHmmssffff";
        /// <summary>
        /// Get App Server Date Time.
        /// </summary>
        public static DateTime ApplicationServerDateTime => DateTime.Now;

        public static string ApplicationServerTimeStamp => DateTime.Now.ToString(_timestampMask);

        /// <summary>
        /// Get SQL Server Date Time
        /// </summary>
        public static DateTime SqlServerDateTime
        {
            get
            {
                //TODO: Make the correct query to get the right value.
                return DateTime.Now;
            }
        }

        public static DateTime MinSqlDateTime
        {
            get
            {
                DateTime minSqlDateTime = new DateTime(1753, 01, 01).Date;

                return minSqlDateTime;
            }
        }

        public static string TimeStamp(DateTime date)
        {
            return date.ToString(_timestampMask);
        }

        public static string TimeStamp(string date)
        {
            return Convert.ToDateTime(date).ToString(_timestampMask);
        }

    }
}
