using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Models;

namespace DAL
{
    /// <summary>
    /// 学生数据访问类
    /// </summary>
    public class StudentService
    {
        ClassService cService = new ClassService();
        /// <summary>
        /// 查询所有学生信息
        /// </summary>
        /// <returns>学生集合</returns>
        public List<StudentInfo> GetStudentInfo()
        {
            try
            {
                //查询所有数据到数据集中
                DataSet ds = SQLHelper.Search("select * from studentinfo");
                //创建数据集
                List<StudentInfo> stuList = new List<StudentInfo>();
                //循环转换数据
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //创建对象
                    StudentInfo stu = new StudentInfo();
                    stu.StuNo = dr["stuNo"].ToString();
                    stu.StuName = dr["stuname"].ToString();
                    stu.StuSex = dr["stusex"].ToString();
                    stu.StuAge = Convert.ToInt32(dr["stuage"]);
                    stu.StuPhone = dr["stuphone"].ToString();
                    stu.StuAddress = dr["stuaddress"].ToString();
                    stu.StuRearmk = dr["stureamrk"].ToString();
                    //取班级
                    stu.ClassInfo = cService.GetClassInfoByClassId(Convert.ToInt32(dr["clasId"]));
                    //添加集合中
                    stuList.Add(stu);
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
