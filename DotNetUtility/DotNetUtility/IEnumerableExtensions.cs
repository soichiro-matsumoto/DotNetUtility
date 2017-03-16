using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUtility
{
    /// <summary>
    /// IEnumerable拡張
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// T のコレクションがNullまたは空であるか
        /// </summary>
        /// <typeparam name="TSource">Source</typeparam>
        /// <param name="instance">コレクション</param>
        /// <returns>「Null」または「空」の場合、true。それ以外はfalse</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> instance)
        {
            if (instance == null)
            {
                return true;
            }

            if (instance.Count() == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 次の要素を返す。存在しない場合は、null を返す ※参照型のみ
        /// </summary>
        /// <typeparam name="TSource">class</typeparam>
        /// <param name="source">IListを継承したコレクション</param>
        /// <param name="currnet">基準の要素</param>
        /// <returns>次の要素</returns>
        public static TSource Next<TSource>(this IList<TSource> source, TSource currnet)
            where TSource : class
        {
            // パラメータの要素がリストに存在しない
            if (!source.Contains(currnet))
            {
                return null;
            }

            // パラメータが最後の要素である
            if (source.Last().Equals(currnet))
            {
                return null;
            }

            int curIndex = source.IndexOf(currnet);
            return source[curIndex + 1];
        }

        /// <summary>
        /// 前の要素を返す。存在しない場合は、null を返す ※参照型のみ
        /// </summary>
        /// <typeparam name="TSource">class</typeparam>
        /// <param name="source">IListを継承したコレクション</param>
        /// <param name="currnet">基準の要素</param>
        /// <returns>前の要素</returns>
        public static TSource Prev<TSource>(this IList<TSource> source, TSource currnet)
            where TSource : class
        {
            // パラメータの要素がリストに存在しない
            if (!source.Contains(currnet))
            {
                return null;
            }

            // パラメータが最初の要素である
            if (source.First().Equals(currnet))
            {
                return null;
            }

            int curIndex = source.IndexOf(currnet);
            return source[curIndex - 1];
        }
    }
}
