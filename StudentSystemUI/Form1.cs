using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Models;
using BLL;

namespace StudentSystemUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //创建业务逻辑对象
        ClassManager cmanager = new ClassManager();
        StudentManager stuManager = new StudentManager();

        private void Form1_Load(object sender, EventArgs e)
        {
            //得到所有的班级信息
            List<ClassInfo> cList = cmanager.GetClassInfo();

            //绑定到TreeView
            //1.创建根
            TreeNode rootNode = new TreeNode("班级信息");

            //2.创建“班级”节点
            foreach (ClassInfo c in cList)
            {
                //创建节点
                TreeNode cNode = new TreeNode(c.ClassName);
                cNode.Tag = c.ClassName;
                //添加到根
                rootNode.Nodes.Add(cNode);
            }
            //添加到控件
            this.tvwClassInfo.Nodes.Add(rootNode);
            //展开所有节点
            this.tvwClassInfo.ExpandAll();
        }

        /// <summary>
        /// 联动 ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwClassInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //清空所有项及所有列
            this.lvwStudentInfo.Items.Clear();
            this.lvwStudentInfo.Columns.Clear();

            //创建集合 
            List<StudentInfo> stuList = new List<StudentInfo>();

            //判断根
            if (this.tvwClassInfo.SelectedNode.Level == 0)
            {
                //查询所有学生
                stuList = stuManager.GetStudentInfo();
            }
            else
            { 
                //得到选中的班级名称
                string className = this.tvwClassInfo.SelectedNode.Tag.ToString();

                //查询指定班级的学生
                stuList = stuManager.GetStudentByclassName(className);
            }

            //设置视图方式
            this.lvwStudentInfo.View = View.Details;
            //显示网格
            this.lvwStudentInfo.GridLines = true;

            //创建列
            this.lvwStudentInfo.Columns.Add("学号");
            this.lvwStudentInfo.Columns.Add("姓名");
            this.lvwStudentInfo.Columns.Add("所在班级");
            this.lvwStudentInfo.Columns.Add("性别");
            this.lvwStudentInfo.Columns.Add("年龄");
            this.lvwStudentInfo.Columns.Add("联系电话");
            this.lvwStudentInfo.Columns.Add("家庭地址");
            this.lvwStudentInfo.Columns.Add("备注");

            //绑定到控件
            foreach (StudentInfo stu in stuList)
            {
                //创建一个项
                ListViewItem item = new ListViewItem(stu.StuNo);
                //添加子项
                item.SubItems.Add(stu.StuName);
                item.SubItems.Add(stu.ClassInfo.ClassName);
                item.SubItems.Add(stu.StuSex);
                item.SubItems.Add(stu.StuAge.ToString());
                item.SubItems.Add(stu.StuPhone);
                item.SubItems.Add(stu.StuAddress);
                item.SubItems.Add(stu.StuRearmk);
                //添加到控件中
                this.lvwStudentInfo.Items.Add(item);
            }
        }
    }
}
