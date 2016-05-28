using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using DAL;

namespace BLL
{
    /// <summary>
    /// 班级业务逻辑类
    /// </summary>
    public class ClassManager
    {
        ClassService classService = new ClassService();

        /// <summary>
        /// 查询所有班级
        /// </summary>
        /// <returns>班级集合</returns>
        public List<ClassInfo> GetClassInfo()
        {
            try
            {
               return classService.GetClassInfo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
