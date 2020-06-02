using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

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

            if (MessageBox.Show("确认删除吗", "提示", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }
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

            BindRichBox(richTextBox2, "开始清理lastupdated文件...\r\n", false);

            //获取目录下的所有文件

            loopCleanDir(path);



            SetEnabled(btnClean, true);
        }

        private void loopCleanDir(string path,bool isClean=true)
        {
           String[] childrenDirs = Directory.GetDirectories(path);

            if (childrenDirs.Length > 0)
            {
                foreach(string dir in childrenDirs)
                {
                    loopCleanDir(dir,isClean);
                }
            }
            else
            {
                String[] files = Directory.GetFiles(path);

                foreach(String file in files)
                {
                    string extension = Path.GetExtension(file);
                    if (extension.ToLower() == ".lastupdated")
                    {
                        if (isClean)
                        {
                            File.Delete(file);
                            BindRichBox(richTextBox2, file + "......已删");
                        }
                        else
                        {
                            BindRichBox(richTextBox1, file);
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

            new Thread(RunThreadSearchNoJarDir).Start(path);
        }
        private void RunThreadSearchNoJarDir(object obj)
        {
            SetEnabled(btnSearch, false);
            string path = obj as string;

            BindRichBox(richTextBox1, "开始查找下载失败的jar文件夹...\r\n", false);

            //获取目录下的所有文件

            loopCleanDir(path,false);

            SetEnabled(btnSearch, true);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                int begin = richTextBox1.GetFirstCharIndexOfCurrentLine();
                string endString = richTextBox1.Text.Substring(begin);
                string text = endString;
                int rtIndex = endString.IndexOf("\n");

                if (rtIndex >= 0)
                {
                    text = endString.Substring(0, rtIndex);
                }

                DirectoryInfo info = new DirectoryInfo(text);
                text = info.Parent.FullName;
                if (Directory.Exists(text))
                {
                    System.Diagnostics.Process.Start("explorer.exe", text);
                }
            }
            catch
            {

            }
        }


        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                int begin = richTextBox1.GetFirstCharIndexOfCurrentLine();
                string endString = richTextBox1.Text.Substring(begin);
                string text = endString;
                int rtIndex = endString.IndexOf("\n");

                if (rtIndex == -1)
                {
                    rtIndex = endString.Length;
                }
                else
                {
                    text = endString.Substring(0, rtIndex);
                }

                richTextBox1.SelectionStart = begin;
                richTextBox1.SelectionLength = rtIndex;

                DirectoryInfo info = new DirectoryInfo(text);
                text = info.Parent.FullName;
                if (!Directory.Exists(text))
                {
                    return;
                }


                string str = text.Replace(mavenHomeDirText.Text, "");
                string[] strs = str.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);


                if (strs.Length < 3)
                {
                    return;
                }

                int len = strs.Length;
                string groupId = strs[0];
                string artifactId = strs[len - 2];
                string version = strs[len - 1];

                if ("0123456789".IndexOf(version[0].ToString()) == -1)
                {
                    BindRichBox(richTextBox3, "所选jar不符合规则", false);
                    return;
                }


                dependency dy = new dependency();
                dy.groupId = groupId;
                dy.artifactId = artifactId;
                dy.version = version;
                string xml = dependency.JsonToXmlString(dy);

                BindRichBox(richTextBox3, xml, false);

            }
            catch
            {

            }

        }

        private void btnReDownJar_Click(object sender, EventArgs e)
        {
            try
            {
                int begin = richTextBox1.GetFirstCharIndexOfCurrentLine();
                string endString = richTextBox1.Text.Substring(begin);
                string text = endString;
                int rtIndex = endString.IndexOf("\n");

                if (rtIndex >= 0)
                {
                    text = endString.Substring(0, rtIndex);
                }
                new Thread(threadDownJar).Start(new String[] { text , mavenHomeDirText .Text});
            }
            catch
            {

            }
        }

        private void threadDownJar(object obj)
        {
            try
            {
                SetEnabled(btnReDownJar, false);
                string[] paths = obj as string[];

                string path = paths[0];
                string mavenHomeDir = paths[1];

                DirectoryInfo info = new DirectoryInfo(path);
                path = info.Parent.FullName;

                if (!Directory.Exists(path))
                {
                    SetEnabled(btnReDownJar, true);
                    return;
                }


                //mvn dependency:get -DremoteRepositories=http://repo1.maven.org/maven2/ -DgroupId=org.freemarker -DartifactId=freemarker -Dversion=2.3.29

                string str = path.Replace(mavenHomeDir, "");


                string[] strs = str.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);


                if (strs.Length < 3)
                {
                    BindRichBox(richTextBox3, "所选jar不符合规则", false);
                }

                int len = strs.Length;
                string groupId = strs[0];
                string artifactId = strs[len - 2];
                string version = strs[len - 1];


                if ("0123456789".IndexOf(version[0].ToString()) == -1)
                {
                    BindRichBox(richTextBox3, "所选jar不符合规则", false);
                }

                
                for (int i = 1; i < len - 2; i++)
                {
                    groupId += "." + strs[i];
                }

                string cmdStr = string.Format(@"mvn dependency:get -DremoteRepositories={0} -DgroupId={1} -DartifactId={2} -Dversion={3}",
                    "http://repo1.maven.org/maven2/", groupId, artifactId, version
                    );

                BindRichBox(richTextBox2, cmdStr + "\n", false);

                ExecuteInCmd(cmdStr);

                SetEnabled(btnReDownJar, true);
            }
            catch
            {
                SetEnabled(btnReDownJar, true);
            }

        }

        /// <summary>
        /// 执行内部命令（cmd.exe 中的命令）
        /// </summary>
        /// <param name="cmdline">命令行</param>
        /// <returns>执行结果</returns>
        public  void ExecuteInCmd(string cmdline)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;


                process.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmdline + "&exit");

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
                process.Close();

            }
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                // 4. 异步调用，需要invoke
                this.Invoke(ReadStdOutput, new object[] { e.Data + "ss" + e.Data.Length });
            }
        }
        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(ReadErrOutput, new object[] { e.Data });
            }
        }

        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);

        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;

        private  void ReadStdOutputAction(string result)
        {
            BindRichBox(richTextBox2, result , true);
        }
        private  void ReadErrOutputAction(string result)
        {
            BindRichBox(richTextBox2, result , true);
        }


        /// <summary>
        /// 执行外部命令
        /// </summary>
        /// <param name="argument">命令参数</param>
        /// <param name="application">命令程序路径</param>
        /// <returns>执行结果</returns>
        public static string ExecuteOutCmd(string argument, string applocaltion)
        {
            using (var process = new Process())
            {
                process.StartInfo.Arguments = argument;
                process.StartInfo.FileName = applocaltion;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine("exit");

                //获取cmd窗口的输出信息  
                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                process.Close();

                return output;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //3.将相应函数注册到委托事件中
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);
        }



        public class dependency
        {
            public string groupId { get; set; }
            public string artifactId { get; set; }
            public string version { get; set; }

            public static string JsonToXmlString(dependency obj)
            {
                XmlDocument document = new XmlDocument();
                StringBuilder sb = new StringBuilder(); string serialized = string.Empty;
                using (TextWriter tw = new StringWriter(sb))
                {
                    var xmlS = new XmlSerializer(typeof(dependency));
                    xmlS.Serialize(tw, obj);
                    serialized = sb.ToString();
                    serialized = serialized.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "");
                    serialized = serialized.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ", "");
                    serialized = serialized.Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                    
                }

                return serialized.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mavenHomeDirText.Text = @"D:\User\Maven\repository";
        }
    }
}
