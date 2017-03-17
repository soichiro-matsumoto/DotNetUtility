using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetUtility.Attribute;

namespace DotNetUtility
{
    /// <summary>
    /// タイムゾーン
    /// </summary>
    public enum TimeZone
    {
        /// <summary>
        /// Local
        /// </summary>
        [CustomDisplayName("Local")]
        Local,

        /// <summary>
        /// UTC
        /// </summary>
        [CustomDisplayName("UTC")]
        Utc,

        /// <summary>
        /// Japan/Tokyo
        /// </summary>
        [CustomDisplayName("Tokyo Standard Time")]
        Tokyo,
    }

    /// <summary>
    /// システム時間
    /// </summary>
    public static class SystemDateTime
    {
        /// <summary>
        /// タイムゾーンを指定して時刻を取得する
        /// </summary>
        /// <param name="zone">タイムゾーン</param>
        /// <returns>タイムゾーンの時刻</returns>
        public static DateTime Get(TimeZone zone)
        {
            if (zone == TimeZone.Local)
            {
                return DateTime.Now;
            }

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zone.DisplayName());
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
        }

        /// <summary>
        /// タイムゾーンを指定して時刻を取得する
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="zone">TimeZone</param>
        /// <returns>タイムゾーンの時刻</returns>
        public static DateTime Get(this DateTime dt, TimeZone zone)
        {
            return Get(zone);
        }
    }
}
