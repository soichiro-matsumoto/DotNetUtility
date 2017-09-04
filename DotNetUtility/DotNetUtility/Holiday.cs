using DotNetUtility.Attribute;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// 祝日クラス
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// 引数なしコンストラクタ禁止
        /// </summary>
        private Holiday() { }

        public Holiday(string name, HolidayKind kind, DateTime date)
        {
            this.Name = name;
            this.Kind = kind;
            this.Date = date;
        }

        public Holiday(string name, HolidayKind kind, int year, int month, int weekNumber, DayOfWeek dayOfWeek)
        {
            this.Name = name;
            this.Kind = kind;

            if(weekNumber < 1)
            {
                throw new ArgumentException("weekNumber は 1以上を指定してください");
            }

            DateTime dt = new DateTime(year, month, 1);

            //月初日と月末日
            var firstDay = dt.FirstDayOfMonth();
            var lastDay = dt.LastDayOfMonth();
            
            var week = Math.Max(1, weekNumber);
            var day = 0;
            
            do
            {
                /**
                 * 日付の計算(日曜=0, 土曜=6の時の計算式)
                 * 月初日の曜日と、引数の曜日の大小関係で計算方法が変わります。
                 * 日付が末日を超える限り計算を続けます。
                 */
                if (dayOfWeek >= firstDay.DayOfWeek)
                {
                    day = 7 * (week - 1) + ((int)dayOfWeek - (int)firstDay.DayOfWeek) + 1;
                }
                else
                {
                    day = 7 * week + ((int)dayOfWeek - (int)firstDay.DayOfWeek) + 1;
                }

                week--;

            } while (day > lastDay.Day);

            this.Date =  new DateTime(year, month, day);
        }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 祝日区分
        /// </summary>
        public HolidayKind Kind { get; private set; }

        /// <summary>
        /// 日付
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// 祝日の一覧を取得する
        /// </summary>
        /// <param name="year">対象年</param>
        /// <param name="springEquinoxDay">春分の日</param>
        /// <param name="autumnalEquinoxDay">秋分の日</param>
        /// <returns>祝日のコレクション</returns>
        public static IEnumerable<Holiday> Create(int year, int springEquinoxDay, int autumnalEquinoxDay)
        {
            var holidays = new List<Holiday> ()
            {
                new Holiday("元旦", HolidayKind.NationalPublicHoliday, new DateTime(year, 1, 1)),
                new Holiday("成人の日", HolidayKind.NationalPublicHoliday, year, 1, 2, DayOfWeek.Monday),
                new Holiday("建国記念の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 2, 11)),
                new Holiday("春分の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 3, springEquinoxDay)),
                new Holiday("昭和の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 4, 29)),
                new Holiday("憲法記念日", HolidayKind.NationalPublicHoliday, new DateTime(year, 5, 3)),
                new Holiday("みどりの日", HolidayKind.NationalPublicHoliday, new DateTime(year, 5, 4)),
                new Holiday("こどもの日", HolidayKind.NationalPublicHoliday, new DateTime(year, 5, 5)),
                new Holiday("海の日", HolidayKind.NationalPublicHoliday, year, 7, 3, DayOfWeek.Monday),
                new Holiday("山の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 8, 11)),
                new Holiday("敬老の日", HolidayKind.NationalPublicHoliday, year, 9, 3, DayOfWeek.Monday),
                new Holiday("秋分の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 9, autumnalEquinoxDay)),
                new Holiday("体育の日", HolidayKind.NationalPublicHoliday, year, 10, 2, DayOfWeek.Monday),
                new Holiday("文化の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 11, 3)),
                new Holiday("勤労感謝の日", HolidayKind.NationalPublicHoliday, new DateTime(year, 11, 23)),
                new Holiday("天皇誕生日", HolidayKind.NationalPublicHoliday, new DateTime(year, 12, 23)),
            };

            /**
             * [国民の祝日に関する法律第３条第２項に規定する休日の例]
             *  国民の祝日が日曜日の場合、次の日を振替休日となります。（ハッピーマンデー制度）
             */
            foreach (var h in holidays.ToArray())
            {

                if (h.Kind == HolidayKind.NationalPublicHoliday
                    && h.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    var insertIdx = holidays.IndexOf(h) + 1;
                    var sbustituteHoliday = new Holiday("振替休日", HolidayKind.SubstituteHoliday, new DateTime(h.Date.Year, h.Date.Month, h.Date.Day).AddDays(1));
                    holidays.Insert(insertIdx, sbustituteHoliday);
                }
            }

            /**
             * [国民の祝日に関する法律第３条第３項に規定する休日の例]
             * 前日と翌日の両方を「国民の祝日」に挟まれた平日は休日となります。
             */
            foreach (var h in holidays.ToArray())
            {
                //// 2日後の祝日を検索
                var holiday2days = holidays.SingleOrDefault(nh => nh.Date == h.Date.AddDays(2));

                if(!holiday2days.IsNull()
                    && holiday2days.Kind == HolidayKind.NationalPublicHoliday)
                {
                    var insertIdx = holidays.IndexOf(h) + 1;
                    var holiday1days = new Holiday("国民の休日", HolidayKind.NationalHoliday, h.Date.AddDays(1));
                    holidays.Insert(insertIdx, holiday1days);
                }
            }

            return holidays;
        }
     }
}
