using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility.Attribute
{
    /// <summary>
    /// DisplayName拡張クラス
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public sealed class CustomDisplayNameAttribute : DisplayNameAttribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomDisplayNameAttribute(string displayName) : base(displayName)
        {
        }
     
        /// <summary>
        /// DisplayNameを取得する
        /// </summary>
        public static string Get(ICustomAttributeProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            CustomDisplayNameAttribute[] attributes = provider.GetCustomAttributes(typeof(CustomDisplayNameAttribute), false) as CustomDisplayNameAttribute[];
            return attributes != null && attributes.Any() //// 属性が存在するか
                ? attributes[0].DisplayName //// 属性が存在していた場合、Display Name を返す
                : null; //// 属性が存在しない場合、null を返す
        }

        /// <summary>
        /// DisplayNameを取得する
        /// </summary>
        public static string Get(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            FieldInfo info = type.GetField(name);
            return Get(info);
        }
    }
}
