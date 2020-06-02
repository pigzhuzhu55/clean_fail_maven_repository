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
            this.btnDefault = new System.Windows.Forms.Button();
            this.btn_setDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mavenHomeDirText = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClean = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.btnDefault);
            this.panel1.Controls.Add(this.btn_setDir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mavenHomeDirText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 372);
            this.panel1.TabIndex = 0;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(296, 11);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 4;
            this.btnDefault.Text = "默认目录";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btn_setDir
            // 
            this.btn_setDir.Location = new System.Drawing.Point(215, 12);
            this.btn_setDir.Name = "btn_setDir";
            this.btn_setDir.Size = new System.Drawing.Size(75, 23);
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
            this.mavenHomeDirText.Location = new System.Drawing.Point(12, 43);
            this.mavenHomeDirText.Name = "mavenHomeDirText";
            this.mavenHomeDirText.Size = new System.Drawing.Size(396, 25);
            this.mavenHomeDirText.TabIndex = 2;
            this.mavenHomeDirText.Text = "D:\\User\\Maven\\repository";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(414, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(302, 372);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Administrator\\Desktop\\软件需求";
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(15, 315);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(199, 45);
            this.btnClean.TabIndex = 5;
            this.btnClean.Text = "清理下载失败的jar包";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 372);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "小工具";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox mavenHomeDirText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_setDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnClean;
    }
}

