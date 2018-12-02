﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 项目信息编辑模型
    /// </summary>
    public class ProjectInfoEditDto : ProjectInfoAddDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
    }
}
