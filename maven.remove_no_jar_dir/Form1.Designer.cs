namespace maven.remove_no_jar_dir
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.btnReDownJar = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btn_setDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mavenHomeDirText = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.richTextBox3);
            this.panel1.Controls.Add(this.btnReDownJar);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.btnDefault);
            this.panel1.Controls.Add(this.btn_setDir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mavenHomeDirText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 199);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox3.Location = new System.Drawing.Point(535, 0);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(503, 199);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "";
            // 
            // btnReDownJar
            // 
            this.btnReDownJar.Location = new System.Drawing.Point(301, 98);
            this.btnReDownJar.Name = "btnReDownJar";
            this.btnReDownJar.Size = new System.Drawing.Size(224, 38);
            this.btnReDownJar.TabIndex = 8;
            this.btnReDownJar.Text = "重新下载所选jar";
            this.btnReDownJar.UseVisualStyleBackColor = true;
            this.btnReDownJar.Click += new System.EventHandler(this.btnReDownJar_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(301, 152);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(224, 37);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "打开所选jar目录";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(15, 99);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(280, 37);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查找所有无效的lastupdated文件";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(15, 152);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(280, 37);
            this.btnClean.TabIndex = 5;
            this.btnClean.Text = "删除所有无效的lastupdated文件";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(15, 43);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(123, 37);
            this.btnDefault.TabIndex = 4;
            this.btnDefault.Text = "默认目录";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btn_setDir
            // 
            this.btn_setDir.Location = new System.Drawing.Point(155, 43);
            this.btn_setDir.Name = "btn_setDir";
            this.btn_setDir.Size = new System.Drawing.Size(123, 37);
            this.btn_setDir.TabIndex = 3;
            this.btn_setDir.Text = "设置目录";
            this.btn_setDir.UseVisualStyleBackColor = true;
            this.btn_setDir.Click += new System.EventHandler(this.btn_setDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "maven repository path:";
            // 
            // mavenHomeDirText
            // 
            this.mavenHomeDirText.Location = new System.Drawing.Point(211, 12);
            this.mavenHomeDirText.Name = "mavenHomeDirText";
            this.mavenHomeDirText.Size = new System.Drawing.Size(318, 25);
            this.mavenHomeDirText.TabIndex = 2;
            this.mavenHomeDirText.Text = "C:\\Users\\Administrator\\.m2\\repository";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Administrator\\Desktop\\软件需求";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 199);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1038, 404);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1030, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查找结果";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1024, 369);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(871, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "操作日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(865, 568);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "我的自定义目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 603);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "小工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox mavenHomeDirText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_setDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnReDownJar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button button1;
    }
}

