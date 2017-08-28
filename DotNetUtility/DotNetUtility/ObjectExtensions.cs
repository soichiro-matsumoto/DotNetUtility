﻿using System;
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
        public static bool IsNull(this object value)
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

        /// <summary>
        /// T に変換する
        /// 変換ができない場合、T のデフォルト値を返す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">変換前値</param>
        public static T To<T>(this IConvertible value)
            where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                // TODO : catchしてそのままデフォルトを返すのは検討
                return default(T);
            }
        }
    }
}
