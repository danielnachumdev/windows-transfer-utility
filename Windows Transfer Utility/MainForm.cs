using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Windows_Transfer_Utility
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        Thread secondaryThread;
        int copied = 0, replaced = 0, skipped = 0, failed = 0;
        string currentFile = "", currentDir = "";
        bool[] canStart = new bool[2] { false, false };
        bool stopped = true;
        List<string[]> errors = new List<string[]>();
        List<string> replacedlog = new List<string>();
        Stopwatch stopwatch = new Stopwatch();
        //string[] dirlist;

        private void smartTransfer(string path, int depth)
        {
            cFilePath = "";
            try
            {
                if (Directory.Exists(path))
                {
                    string dirA = textBox1.Text;
                    currentDir = path.Substring(dirA.Length);
                    string dirB = textBox2.Text;
                    string[] files = Directory.GetFiles(path);
                    string[] directories = Directory.GetDirectories(path);
                    string relativePath = path.Substring(dirA.Length);
                    relativePath = checkForMerge(relativePath);
                    if (!Directory.Exists(dirB + relativePath))//if a directory doesnt exsist just copy it as it is
                    {
                        transferDirectoryIfDoesntExsist(path, dirA, dirB, relativePath);
                        return;
                    }
                    else
                    {
                        transferFiles(files, relativePath, depth, dirB);//if you have a file in current directory compare and copy if nescceseray
                        bool first = true;
                        transferDirectories(directories, first, depth);//if there are sub directories in current directory recursivly check them
                        checkIfStop(path, dirA);
                    }
                }
                else return;

            }
            catch (Exception e)
            {
                handleException(e);
            }
        }



        private int recursivlyCountFiles(string path)
        {
            int result = Directory.GetFiles(path).Length;
            foreach (string dir in Directory.GetDirectories(path))
                result += recursivlyCountFiles(dir);
            return result;
        }
        private void onFolderSelection(string path, int index)
        {
            RichTextBox[] richTextBoxes = new RichTextBox[2] { richTextBox1, richTextBox2 };
            richTextBoxes[index - 1].Text = "";

            if (Directory.Exists(path))
            {
                if (index == 1)
                {
                    progressBar1.Maximum = recursivlyCountFiles(path);
                    progressLabel.Text = "0 / " + progressBar1.Maximum;
                }
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);
                TextBox[] textBoxes = new TextBox[2] { textBox1, textBox2 };
                textBoxes[index - 1].Text = path;
                foreach (string dir in dirs)
                    richTextBoxes[index - 1].Text += "--- " + Path.GetFileName(dir) + " ---\n";
                foreach (string file in files)
                    richTextBoxes[index - 1].Text += Path.GetFileName(file) + "\n";
                canStart[index - 1] = true;
                bool ok = true;
                foreach (bool myBool in canStart)
                    if (!myBool)
                        ok = false;
                if (ok)
                    actionPanel.Enabled = true;
            }
        }
        List<string> displayQueue = new List<string>();
        private void stop()
        {
            optionsPanel.Enabled = true;
            browserPanel.Enabled = true;
            startButton.Enabled = true;
            progressLabel.Text = progressBar1.Value + "/" + progressBar1.Maximum;
            progressBar1.Value = progressBar1.Maximum;
            statusLabel.Text = "Status: Finished!";
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (errors.Count > 1)
            {
                errors.RemoveAt(errors.Count - 1);
                string[] errorlog = new string[errors.Count];
                for (int i = 0; i < errors.Count; i++)
                {
                    string[] error = errors[i];
                    errorlog[i] = i + ": -----" + error[0] + "\n\n" + error[1];
                }
                string filename = Path.GetFileName(textBox1.Text).ToUpper() + " - ERROR LOG", fileextention = ".txt";
                string errorlogpath = Path.Combine(textBox2.Text, filename + fileextention);
                int count = 0;
                while (File.Exists(errorlogpath))
                {
                    count++;
                    errorlogpath = Path.Combine(textBox2.Text, filename + count + fileextention);
                }
                File.WriteAllLines(errorlogpath, errorlog);
            }

            if (replacedlog.Count > 0)
            {
                string fileName = "REPLACED FILE LOG", fileExtention = ".txt";
                string replacedLogPath = Path.Combine(textBox2.Text, fileName + fileExtention);
                int count = 0;
                while (File.Exists(replacedLogPath))
                {
                    count++;
                    replacedLogPath = Path.Combine(textBox2.Text, fileName + count + fileExtention);
                }
                File.WriteAllLines(replacedLogPath, replacedlog.ToArray());
            }
            stopwatch.Stop();
            stopped = true;
        }
        //List<int> SelectedIndices;
        //int selectedIndex = 0;
        private void seconderayThreadMain()
        {
            if (Directory.Exists(textBox1.Text))
            {
                stopwatch.Start();
                //for (int i = 0; i < SelectedIndices.Count; i++)
                //{
                //    selectedIndex = SelectedIndices[i];
                //    smartTransfer(dirlist[SelectedIndices[i]]);
                //}
                smartTransfer(textBox1.Text, 0);
                if (cutRadioButton.Checked && Directory.GetDirectories(textBox1.Text).Length == 0 && Directory.GetFiles(textBox1.Text).Length == 0)
                    Directory.Delete(textBox1.Text);
            }
        }
        private string calcFileSize(long byteLength)
        {
            double MB = byteLength / 1000000;
            if (MB > 1000)
                return (MB / 1000) + "GB";
            if (MB < 1)
                return (MB * 1000) + "KB";
            return MB + "MB";
        }
        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                if (skipEmptyDirectoriesCheckBox.Checked)
                {
                    if (dir.GetFiles().Length > 0 || dir.GetDirectories().Length > 0)
                        CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));


                    if (deleteEmptyFoldersCheckBox.Checked&&dir.GetDirectories().Length==0&&dir.GetFiles().Length==0)
                        dir.Delete();
                }
                else
                    CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            }
            currentDir = source.FullName.Substring(textBox1.Text.Length);
            foreach (FileInfo file in source.GetFiles())
            {
                currentFile = Path.GetFileName(file.FullName) + " \n" + calcFileSize(file.Length);
                if (cutRadioButton.Checked)
                    file.MoveTo(Path.Combine(target.FullName, file.Name));
                else if (copyRadioButton.Checked)
                    file.CopyTo(Path.Combine(target.FullName, file.Name));
                copied++;
            }
        }
        private bool checkRelativePath(string path)
        {
            string root = Path.GetDirectoryName(path);
            if (root == "\\")
            {
                int i = path.Length - 1;
                for (; i >= 0; i--)
                    if (path[i] == ' ')//||path[i]=='\\')
                        break;
                if (i < 0)
                    return false;
                string end = path.Substring(i);
                if (end.Contains('(') && end.Contains(')') && end.Contains(' '))
                    return true;
            }
            else
            {
                var splits = root.Split('\\');
                root = splits[0] == "" ? splits[1] : splits[0];
                //if (root.Count(s => s == '\\') > 1)
                //    root = Path.GetFileName(Directory.GetParent(root).FullName);
                //while (Path.GetDirectoryName(path) != "\\")
                //    root = Path.GetPathRoot(path);
                int i = root.Length - 1;
                for (; i >= 0; i--)
                    if (root[i] == ' ')//||path[i]=='\\')
                        break;
                if (i < 0)
                    return false;
                string end = path.Substring(i);
                if (end.Contains('(') && end.Contains(')') && end.Contains(' '))
                    return true;
            }
            return false;
        }
        string cFilePath = "";

        private void checkIfStop(string path, string dirA)
        {
            if (/*useSelection ? path == dirlist[selectedIndex] : */path == dirA)
            {

                timer1.Stop();
                secondaryThread.Abort();
            }
        }
        private void handleException(Exception e)
        {
            string exceptionName = e.GetType().Name;
            //var exceptionType = e.GetType();
            if (exceptionName != "PlatformNotSupportedException")
            {
                errors.Add(new string[2] { cFilePath, e.ToString() });
                failed++;
            }
        }
        private void transferDirectories(string[] directories, bool first, int depth)
        {
            if (directories.Length > 0)
            {
                if (copyRadioButton.Checked)
                {
                    for (int i = 0; i < directories.Length; i++)
                    {
                        string dir = directories[i];
                        //var df = dir.Split('\\');
                        //if (df.Length > 2 && df[2] == "ביטוח מקצועי")
                        //    df = new string[2];
                        if (skipEmptyDirectoriesCheckBox.Checked)
                        {
                            if (Directory.GetFiles(dir).Length > 0 || Directory.GetDirectories(dir).Length > 0)
                                smartTransfer(dir, depth + 1);
                        }
                        else
                            smartTransfer(dir, depth + 1);
                        if (deleteEmptyFoldersCheckBox.Checked)
                            if (Directory.Exists(dir) && Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                                Directory.Delete(dir);
                        if (depth == 1)
                            displayQueue.Add("--- " + Path.GetFileName(dir) + " ---");
                    }
                }
                else
                {
                    for (int i = 0; i > (first ? -1 : 0); i--)
                    {
                        string dir = directories[i];
                        //var df = dir.Split('\\');
                        //if (df.Length > 2 && df[2] == "ביטוח מקצועי")
                        //    df = new string[2];
                        if (skipEmptyDirectoriesCheckBox.Checked)
                        {
                            if (Directory.GetFiles(dir).Length > 0 || Directory.GetDirectories(dir).Length > 0)
                                smartTransfer(dir, depth + 1);
                        }
                        else
                            smartTransfer(dir, depth + 1);
                        if (deleteEmptyFoldersCheckBox.Checked)
                            if (Directory.Exists(dir) && Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                                Directory.Delete(dir);
                        if (first)
                        {
                            first = false;
                            i = directories.Length;
                        }
                        if (depth == 1)
                            displayQueue.Add("--- " + Path.GetFileName(dir) + " ---");
                    }
                }
            }
        }
        private string checkForMerge(string relativePath)
        {
            if (relativePath != "" && mergeCheckBox.Checked && checkRelativePath(relativePath))
            {
                string root = Path.GetDirectoryName(relativePath);
                if (root == "\\")
                {
                    int i = relativePath.Length - 1;
                    for (; i > 0; i--)
                        if (relativePath[i] == ' ')
                            break;
                    relativePath = relativePath.Substring(0, i);
                }
                else
                {
                    var splits = root.Split('\\');
                    string preroot = splits[0] == "" ? splits[1] : splits[0];
                    root = splits[0] == "" ? splits[1] : splits[0];
                    //if (root.Count(s => s == '\\') > 1)
                    //    root = "\\" + Path.GetFileName(Directory.GetParent(root).FullName);
                    if (!root.Contains('(') || !root.Contains(')'))
                        return relativePath;
                    string subDirs = relativePath.Substring(root.Length);
                    int i = root.Length - 1;
                    for (; i > 0; i--)
                        if (root[i] == ' ')
                            break;
                    root = root.Substring(0, i);
                    relativePath = relativePath.Replace(preroot, root);
                    //relativePath = root + subDirs;
                }
            }
            return relativePath;
        }
        private void transferFiles(string[] files, string relativePath, int depth, string dirB)
        {
            foreach (var file in files)
            {
                cFilePath = file;
                string filename = Path.GetFileName(file);
                currentFile = filename + " \n" + calcFileSize(new FileInfo(file).Length);
                string bFile = dirB + "/" + relativePath + "/" + filename;
                if (!File.Exists(bFile))
                {
                    if (cutRadioButton.Checked)
                        File.Move(file, bFile);
                    else if (copyRadioButton.Checked)
                        File.Copy(file, bFile);
                    copied++;
                    if (depth == 1)
                        displayQueue.Add(Path.GetFileName(file));
                }
                else
                {

                    DateTime aLastWrite = File.GetLastWriteTime(file);
                    DateTime bLastWrite = File.GetLastWriteTime(bFile);
                    var res = DateTime.Compare(aLastWrite, bLastWrite);
                    //string[] results = new string[3] { "date1 is earlier than date2", "date1 is the same as date2", "date1 is later than date2" };
                    if (res > 0)
                    {
                        replacedlog.Add(file);
                        if (backupCheckBox.Checked)
                            File.Move(bFile, dirB + relativePath + "\\" + Path.GetFileNameWithoutExtension(bFile) + ".backup");
                        else
                            File.Delete(bFile);

                        if (cutRadioButton.Checked)
                        {
                            File.Move(file, bFile);
                            copied++;
                        }
                        else if (copyRadioButton.Checked)
                        {
                            File.Copy(file, bFile);
                            replaced++;
                        }

                    }
                    else
                    {
                        if (cutRadioButton.Checked)
                            File.Delete(file);
                        skipped++;
                    }

                }
            }
        }
        private void transferDirectoryIfDoesntExsist(string path, string dirA, string dirB, string relativePath)
        {
            Directory.CreateDirectory(dirB + relativePath);
            CopyFilesRecursively(new DirectoryInfo(dirA + path.Substring(dirA.Length)), new DirectoryInfo(dirB + relativePath));
            if (deleteEmptyFoldersCheckBox.Checked&&Directory.GetDirectories(path).Length==0&&Directory.GetFiles(path).Length==0)
                Directory.Delete(path);
            //copied += Directory.GetFiles(dirB + relativePath, "*.*", SearchOption.AllDirectories).Count();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            optionsPanel.Enabled = false;
            browserPanel.Enabled = false;
            startButton.Enabled = false;
            skipped = 0;
            replaced = 0;
            copied = 0;
            failed = 0;
            errors = new List<string[]>();
            replacedlog = new List<string>();
            displayQueue = new List<string>();
            progressBar1.Value = 0;
            skippedLabel.Text = "Skipped: " + skipped;
            replacedLabel.Text = "Replaced: " + replaced;
            copiedLabel.Text = "Copied:" + copied;
            failedLabel.Text = "Failed: " + failed;
            statusLabel.Text = "Status: Working..";
            //SelectedIndices = new List<int>();
            stopwatch.Reset();
            //progressBar1.Maximum = 0;
            //progressBar1.Value = 0;
            //try
            //{
            //    foreach (var item in listBox1.SelectedIndices)
            //    {
            //        int index = int.Parse(item.ToString());
            //        SelectedIndices.Add(index);
            //        progressBar1.Maximum += recursivlyCountFiles(dirlist[index]);
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //progressLabel.Text = "0 / " + progressBar1.Maximum;
            //listItems = ;

            secondaryThread = new Thread(seconderayThreadMain);
            timer1.Start();
            stopped = false;
            secondaryThread.Start();
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            stopWatchLabel.Text = "Elapsed Time: " + stopwatch.Elapsed.ToString();
            skippedLabel.Text = "Skipped: " + skipped;
            replacedLabel.Text = "Replaced: " + replaced;
            copiedLabel.Text = "Copied: " + copied;
            failedLabel.Text = "Failed: " + failed;
            cFileLabel.Text = currentFile;
            cDirLabel.Text = currentDir;
            //for (int i = displayQueue.Count - 1; i >= 0; i--)
            //{
            //    string s = displayQueue[i];
            //    richTextBox2.Text += s + "\n";
            //    displayQueue.RemoveAt(i);
            //}
            progressLabel.Text = (skipped + copied + failed + replaced) + "/" + progressBar1.Maximum;
            if (progressBar1.Maximum > copied + failed + skipped + replaced)
                progressBar1.Value = copied + failed + skipped + replaced;
            if (!timer1.Enabled && !stopped)
                stop();
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Name.Substring(0, 3) == "cut")
            {
                deleteEmptyFoldersCheckBox.Checked = true;
                deleteEmptyFoldersCheckBox.Enabled = false;
            }
            else
            {
                deleteEmptyFoldersCheckBox.Checked = false;
                deleteEmptyFoldersCheckBox.Enabled = true;
            }
        }
        private void mergeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mergeCheckBox.Checked)
            {
                skipEmptyDirectoriesCheckBox.Checked = true;
                skipEmptyDirectoriesCheckBox.Enabled = false;
            }
            else
            {
                skipEmptyDirectoriesCheckBox.Checked = false;
                skipEmptyDirectoriesCheckBox.Enabled = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            skippedLabel.Text = "Skipped: " + skipped;
            replacedLabel.Text = "Replaced: " + replaced;
            copiedLabel.Text = "Copied: " + copied;
            failedLabel.Text = "Failed: " + failed;
        }
        private void selectFolderButtons_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                int index = int.Parse(b.Name.Substring(b.Name.Length - 1));
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                TextBox[] textBoxes = new TextBox[2] { textBox1, textBox2 };
                fbd.SelectedPath = textBoxes[index - 1].Text != "" ? textBoxes[index - 1].Text + "\\" : "";
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    string path = fbd.SelectedPath;
                    onFolderSelection(path, index);
                }
                fbd.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void createDirectoryButton_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(textBox2.Text, Path.GetFileName(textBox1.Text)));
            onFolderSelection(textBox2.Text, 2);
        }

        private void goUpButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int index = int.Parse(b.Name.Substring(b.Name.Length - 1));
            index -= 1;
            TextBox[] textBoxes = new TextBox[2] { textBox1, textBox2 };
            if (textBoxes[index].Text != "" && Directory.GetParent(textBoxes[index].Text) != null)
            {
                textBoxes[index].Text = Directory.GetParent(textBoxes[index].Text).FullName;
                onFolderSelection(textBoxes[index].Text, index + 1);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void switchDirectoriesButton_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = t;

            onFolderSelection(textBox1.Text, 1);
            onFolderSelection(textBox2.Text, 2);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndices.Count > 0)
            //    useSelection = true;
            //else
            //    useSelection = false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            infoLabel.Text = "Directory: \nCurrent FIle: \nFile Size: ";
            cDirLabel.Text = "";
            string path = "D:/Clouds/OneDrive/am.arc/OneDrive/AM";
            //path = "E:/copy";

            if (Directory.Exists(path))
                onFolderSelection(path, 1);
            path = "E:\\AM";

            //path = "E:/AM/AM_1 צור הדסה";
            if (Directory.Exists(path))
                onFolderSelection(path, 2);
        }
    }
}
