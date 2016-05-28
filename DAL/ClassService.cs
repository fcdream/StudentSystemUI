using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 班级数据访问类
    /// </summary>
   public class ClassService
    {
        /// <summary>
        /// 查询所有班级
        /// </summary>
        /// <returns>班级集合</returns>
        public List<ClassInfo> GetClassInfo()
        {
            try
            {
                //查询加数据集中
                DataSet ds = SQLHelper.Search("select * from ClassInfo");
                //创建集合
                List<ClassInfo> cList = new List<ClassInfo>();
                //循环转换数据
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //创建对象
                    ClassInfo c = new ClassInfo();
                    c.ClassId = Convert.ToInt32(dr[0]);
                    c.ClassName = dr[1].ToString();
                    //添加到集合中
                    cList.Add(c);
                }
                return cList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 根据班级编号查询
        /// </summary>
        /// <param name="classId">班级编号</param>
        /// <returns>班级对象</returns>
        public ClassInfo GetClassInfoByClassId(int classId)
        {
            try
            {
                string sql = "select * from ClassInfo where classId=@id";
                SqlParameter p = new SqlParameter("@id", classId);
                //查询加数据集中
                DataSet ds = SQLHelper.Search(sql, p);

                //创建对象
                ClassInfo c = new ClassInfo();
                c.ClassId = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                c.ClassName = ds.Tables[0].Rows[0][1].ToString();

                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
