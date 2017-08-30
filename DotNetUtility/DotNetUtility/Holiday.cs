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

            this.Date =  new DateTime(firstDay.Year, firstDay.Month, day);
        }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 祝日区分
        /// </summary>
        public HolidayKind Kind { get; set; }

        /// <summary>
        /// 日付
        /// </summary>
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
