using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// IQueryable拡張
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// startからcountの件数分取得する
        /// </summary>
        /// <typeparam name="TSource">TSource</typeparam>
        /// <param name="source"></param>
        /// <param name="start">取得開始番号</param>
        /// <param name="count">取得数</param>
        /// <returns>取得結果</returns>
        public static IQueryable<TSource> Limit<TSource>(this IQueryable<TSource> source, int start, int count)
        {
            if (start == int.MinValue)
                throw new ArgumentOutOfRangeException("start", "start must be greater than Int32.MinValue");

            return source.Skip(start - 1).Take(count);
        }
    }
}
