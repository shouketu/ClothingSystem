using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Page
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParameter
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public long PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}
