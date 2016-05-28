namespace StudentSystemUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvwClassInfo = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwStudentInfo = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvwClassInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 528);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "班级信息";
            // 
            // tvwClassInfo
            // 
            this.tvwClassInfo.BackColor = System.Drawing.Color.White;
            this.tvwClassInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwClassInfo.Location = new System.Drawing.Point(3, 17);
            this.tvwClassInfo.Name = "tvwClassInfo";
            this.tvwClassInfo.Size = new System.Drawing.Size(194, 508);
            this.tvwClassInfo.TabIndex = 0;
            this.tvwClassInfo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwClassInfo_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvwStudentInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(200, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 528);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生信息";
            // 
            // lvwStudentInfo
            // 
            this.lvwStudentInfo.BackColor = System.Drawing.Color.White;
            this.lvwStudentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwStudentInfo.Location = new System.Drawing.Point(3, 17);
            this.lvwStudentInfo.Name = "lvwStudentInfo";
            this.lvwStudentInfo.Size = new System.Drawing.Size(555, 508);
            this.lvwStudentInfo.TabIndex = 0;
            this.lvwStudentInfo.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 528);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学员信息管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvwClassInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvwStudentInfo;
    }
}

