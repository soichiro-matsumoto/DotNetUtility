using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility.Attribute
{
    /// <summary>
    /// CustomDisplayNameAttribute拡張メソッド
    /// </summary>
    public static class CustomDisplayNameAttributeExtensions
    {
        /// <summary>
        /// DisplayNameを取得する
        /// </summary>
        public static string DisplayName(this ICustomAttributeProvider provider)
        {
            return CustomDisplayNameAttribute.Get(provider);
        }

        /// <summary>
        /// DisplayNameを取得する
        /// </summary>
        public static string DisplayName(this Enum value)
        {
            return CustomDisplayNameAttribute.Get(value);
        }
    }
}
