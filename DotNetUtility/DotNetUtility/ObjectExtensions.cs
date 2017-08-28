using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// Object拡張
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// nullであるか検証する
        /// </summary>
        /// <param name="value">検証値</param>
        public static bool IsNull<T>(this T value) 
        {
            return value == null;
        }

        /// <summary>
        /// Null許容型から、非Null許容型に変換する。
        /// 値がNullの場合。T のデフォルト値を返す。
        /// </summary>
        /// <typeparam name="T">プリミティブ型</typeparam>
        public static T ToNonNullable<T>(this T? value)
            where T : struct
        {
            if (value.HasValue)
            {
                return (T)value;
            }

            return default(T);
        }

        /// <summary>
        /// Null許容型から、非Null許容型に変換する。
        /// 値がNullの場合、defaultValueを返す。
        /// </summary>
        /// <typeparam name="T">プリミティブ型</typeparam>
        /// <param name="value">プリミティブ型のValue</param>
        /// <param name="defaultValue">Null時のデフォルト値</param>
        public static T ToNonNullable<T>(this T? value, T defaultValue)
            where T : struct
        {
            if (value.HasValue)
            {
                return (T)value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Null許容型に変換する
        /// </summary>
        /// <typeparam name="T">プリミティブ型</typeparam>
        public static T? ToNullable<T>(this T value)
            where T : struct
        {
            return value;
        }
    }
}
