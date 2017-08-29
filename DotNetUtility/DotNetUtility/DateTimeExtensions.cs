using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetUtility.Attribute;

namespace DotNetUtility
{
    /// <summary>
    /// DateTime拡張
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// タイムゾーンを指定して時刻を取得する
        /// </summary>
        /// <param name="zone">タイムゾーン</param>
        /// <returns>タイムゾーンの時刻</returns>
        public static DateTime GetTimeZone(TimeZone zone)
        {
            if (zone == TimeZone.Local)
            {
                return DateTime.Now;
            }

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zone.DisplayName());
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
        }

        /// <summary>
        /// パラメータの日付を基に、年齢を算出する
        /// </summary>
        /// <param name="dt">生年月日</param>
        /// <param name="now">今日日付</param>
        /// <returns>年齢</returns>
        public static int GetAge(this DateTime dt, DateTime now)
        {
            if (now.Month < dt.Month || //// 誕生月を超えていない
                (now.Month == dt.Month && now.Day < dt.Day)) //// 誕生月であるが、誕生日を超えていない
            {
                return now.Year - dt.Year - 1;
            }

            return now.Year - dt.Year;
        }

        /// <summary>
        /// DateTimeからIntに変換する
        /// 例：2005/01/10 → 20050110
        /// </summary>
        /// <param name="value">DateTime</param>
        /// <returns>Int</returns>
        public static int ToInt(this DateTime value)
        {
            int year = value.Year * 10000;
            int month = value.Month * 100;
            int day = value.Day;

            return year + month + day;
        }
        
        /// <summary>
        /// 月末日を取得する
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>月末日指定されたDateTime</returns>
        public static DateTime MonthLastDay(this DateTime dt)
        {
            var days = DateTime.DaysInMonth(dt.Year, dt.Month);
            return new DateTime(dt.Year, dt.Month, days);
        }

        /** 
         * TODO : 祝日関連の実装
         * 
         * パラメータの日付が祝日かどうか判定するメソッド。
         * 指定月の祝日（DateTime）の一覧を取得するメソッド。
         * 振替休日も考慮。
         * 
         * 課題点：
         *  祝日の管理方法。ハードコーディングか？ＤＢのマスタから取得するか？
         *  ハードコーディングしてしまうと、その都度コードをメンテナンスをしなければならない。
         *  DBのマスタから取得する場合、マスタがないと実行できない。
         *  
         */
        
    }
}
