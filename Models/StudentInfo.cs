using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    public class StudentInfo
    {
        /// <summary>
        /// 学号
        /// </summary>
        public string StuNo { get; set; }

        /// <summary>
        /// 班级信息
        /// </summary>
        public ClassInfo ClassInfo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string StuName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string StuSex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int StuAge { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string StuPhone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string StuAddress { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string StuRearmk { get; set; }
    }
}
