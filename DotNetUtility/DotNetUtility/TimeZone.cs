using DotNetUtility.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// タイムゾーン
    /// </summary>
    public enum TimeZone
    {
        /// <summary>
        /// Local
        /// </summary>
        [ExDisplayName("Local")]
        Local,

        /// <summary>
        /// UTC
        /// </summary>
        [ExDisplayName("UTC")]
        Utc,

        /// <summary>
        /// Japan/Tokyo
        /// </summary>
        [ExDisplayName("Tokyo Standard Time")]
        Tokyo,
    }
}
