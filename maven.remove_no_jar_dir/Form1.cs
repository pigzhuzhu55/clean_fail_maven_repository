using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace maven.remove_no_jar_dir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_setDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;

                if (!System.IO.Directory.Exists(path))
                {
                    MessageBox.Show("目录不存在");
                    return;
                }

                mavenHomeDirText.Text = path;
            }
        }

        private delegate void RichBoxDelegate(RichTextBox tb, string text, bool isAppend = true);

        private void BindRichBox(RichTextBox tb, string text, bool isAppend = true)
        {
            if (tb.InvokeRequired)
            {
                RichBoxDelegate aaa = BindRichBox;
                Invoke(aaa, tb, text, isAppend);
            }
            else
            {
                if (isAppend)
                    tb.AppendText(text + "\r\n");
                else
                {
                    tb.Text = text;
                }
            }
        }

        private delegate void SetEnabledDelegate(Control tb, bool enabled);

        private void SetEnabled(Control tb, bool enabled)
        {
            if (!tb.InvokeRequired)
            {
                tb.Enabled = enabled;
            }
            else
            {
                SetEnabledDelegate de = SetEnabled;
                Invoke(de, tb, enabled);
            }
        }


        private void btnDefault_Click(object sender, EventArgs e)
        {
            mavenHomeDirText.Text = @"C:\Users\Administrator\.m2\repository";
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            string path = mavenHomeDirText.Text;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("目录不存在");
                return;
            }

            if (path.LastIndexOf("repository") < 0)
            {
                //防止误删
                MessageBox.Show("不是有效的maven仓库目录");
                return;
            }

            new Thread(RunThreadCleanNoJarDir).Start( path );
        }

        private void RunThreadCleanNoJarDir(object obj)
        {
            SetEnabled(btnClean, false);
            string path = obj as string;

            BindRichBox(richTextBox1, "开始清理下载失败的jar文件夹...\r\n",false);

            //获取目录下的所有文件

            loopCleanDir(path);

            SetEnabled(btnClean, true);
        }

        private void loopCleanDir(string path)
        {
           String[] childrenDirs = Directory.GetDirectories(path);

            if (childrenDirs.Length > 0)
            {
                foreach(string dir in childrenDirs)
                {
                    loopCleanDir(dir);
                }
            }
            else
            {
                String[] files = Directory.GetFiles(path);

                bool hasJar =false;
                foreach(String file in files)
                {
                    string extension = Path.GetExtension(file);
                    if (extension.ToLower() == ".jar")
                    {
                        hasJar = true;
                        break;
                    }
                }
                if (!hasJar)
                {
                    Directory.Delete(path,true);
                    BindRichBox(richTextBox1, path + "......已删除...\r\n");
                }
            }
        }
    }
}
