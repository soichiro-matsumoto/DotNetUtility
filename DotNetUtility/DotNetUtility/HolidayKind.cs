using DotNetUtility.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// 祝日区分
    /// </summary>
    public enum HolidayKind
    {
        /// <summary>
        /// 平日
        /// </summary>
        [ExDisplayName("平日")]
        Weekday = 0,

        /// <summary>
        /// 国民の祝日
        /// </summary>
        [ExDisplayName("国民の祝日")]
        NationalPublicHoliday = 1,

        /// <summary>
        /// 振替休日
        /// </summary>
        [ExDisplayName("振替休日")]
        SubstituteHoliday = 2,

        /// <summary>
        /// 国民の休日
        /// </summary>
        [ExDisplayName("国民の休日")]
        NationalHoliday = 3,
    }
}
