using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using DAL;

namespace BLL
{
    /// <summary>
    /// 学生业务逻辑类
    /// </summary>
    public class StudentManager
    {
        StudentService stuService = new StudentService();

        /// <summary>
        /// 查询所有学生信息
        /// </summary>
        /// <returns>学生集合</returns>
        public List<StudentInfo> GetStudentInfo()
        {
            try
            {
                return stuService.GetStudentInfo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

     /// <summary>
     /// 查询指定班级的学生
     /// </summary>
     /// <param name="className">班级名称</param>
     /// <returns></returns>
        public List<StudentInfo> GetStudentByclassName(string className)
        {
            try
            {
                //查询所有学生
                List<StudentInfo> All =  stuService.GetStudentInfo();
                //定义集合存放指定班级的学生
                List<StudentInfo> stuList = new List<StudentInfo>();

                //过滤数据
                foreach (StudentInfo stu in All)
                {
                    if (stu.ClassInfo.ClassName == className)
                    {
                        stuList.Add(stu);
                    }
                }

                return stuList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
