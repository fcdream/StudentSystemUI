using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// SQLServer数据库操作类
    /// </summary>
    class SQLHelper
    {
        //定义对象
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;
        private static DataSet ds = null;
        private static SqlDataAdapter sda = null;

        //定义连接字符串
        private static string connStr = "server=.;database=studentdb;uid=sa;pwd=123456";

        /// <summary>
        /// 查询多行多列
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="parameters">sql所需要的参数</param>
        /// <returns>数据集</returns>
        public static DataSet Search(string sql, params SqlParameter[] parameters)
        {
            try
            {
                //创建连接对象
                using (conn = new SqlConnection(connStr))
                {
                    //如果是连接的
                    if (conn.State == ConnectionState.Broken)
                    {
                        //关闭
                        conn.Close();
                    }
                    //打开
                    conn.Open();
                    //创建命令对象
                    cmd = new SqlCommand(sql, conn);
                    //循环添加参数
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    //创建适配器
                    sda = new SqlDataAdapter(cmd);
                    //创建数据集
                    ds = new DataSet();
                    //填充数据
                    sda.Fill(ds);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
