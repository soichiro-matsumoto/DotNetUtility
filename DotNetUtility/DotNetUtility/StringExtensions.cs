using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <param name="value">検証文字列</param>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 文字列からDateTime型に変換する
        /// </summary>
        /// <param name="value">検証文字列</param>
        public static DateTime ToDateTime(this string value)
        {
            DateTime parsed;

            if (DateTime.TryParse(value, out parsed))
            {
                return parsed;
            }

            throw new InvalidProgramException("Not Datetime Format");
        }

        /// <summary>
        /// パラメータの検証文字列が含まれているか
        /// </summary>
        /// <param name="value">検証文字列</param>
        /// <param name="param">対象文字列</param>
        public static bool Contains(this string value, params string[] param)
        {
            foreach(var p in param)
            {
                if (!value.Contains(p))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 文字列を正規表現で検証する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        public static bool IsMatch(this string value, string pattern)
        {
            return Regex.IsMatch(value, pattern);
        }
    }
}
