using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Page
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T> : PageParameter
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public long PageCount { get; set; }

        /// <summary>
        /// 当前页数据
        /// </summary>
        public ICollection<T> Items { get; set; }
    }
}
