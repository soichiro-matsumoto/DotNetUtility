using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// String拡張
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// string.IsNullOrEmpty
        /// </summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 文字列からDateTime型に変換する
        /// </summary>
        public static DateTime ToDateTime(this string value)
        {
            DateTime parsed;

            if (DateTime.TryParse(value, out parsed))
            {
                return parsed;
            }

            throw new InvalidProgramException("Not String Datetime Format");
        }
    }
}
