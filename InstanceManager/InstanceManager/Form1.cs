using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace InstanceManager
{
    public partial class Form1 : Form
    {
        private List<string> list = new List<string> ();
        private string m_selectedInstance = "";
        private static string DefaultInstanceText = @"[Startup]
AutoRestartOnCrash = false
[Console]
Console = GUIConsole
[Network]
http_listener_port = 9000
[RegionStartup]
Default = RegionLoaderFileSystem
RegionsDirectory = Regions";
        private volatile bool listLocked = false;
        private bool m_formLoaded = false;
        private static List<string> toAppend = new List<string> ();
        private string m_selectedConsoleInstance = "";
        private string m_previousSelectedConsoleInstance = "";
        private Dictionary<string, Process> m_processes = new Dictionary<string, Process> ();
        private Thread consoleTracker = null;
        private bool closing = false;
        private bool ResetTextBox = false;
        private Dictionary<string, string> m_otherConsoles = new Dictionary<string, string> ();

        public Form1 ()
        {
            InitializeComponent ();
        }

        protected override void WndProc (ref Message m)
        {
            base.WndProc (ref m);
            if (!m_formLoaded)
                return;
            if (listLocked)
                return;
            listLocked = true;

            if (ResetTextBox)
            {
                m_otherConsoles[m_previousSelectedConsoleInstance] = richTextBox1.Text;
                richTextBox1.Clear ();
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret ();
                ResetTextBox = false;
                m_previousSelectedConsoleInstance = m_selectedConsoleInstance;
                if (m_otherConsoles.ContainsKey (m_selectedConsoleInstance))
                {
                    richTextBox1.Text = m_otherConsoles[m_selectedConsoleInstance];
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret ();
                }
            }
            string[] copy;
            lock (toAppend)
            {
                copy = new string[toAppend.Count];
                toAppend.CopyTo (copy);
                toAppend.Clear ();
            }
            if (copy.Length > 0)
            {
                foreach (string line in copy)
                    richTextBox1.AppendText (line);
            }

            listLocked = false;
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            m_formLoaded = true;
            LoadFromConfig ();
            RegenerateList ();
            this.FormClosing += new FormClosingEventHandler (Form1_FormClosing);
        }

        void Form1_FormClosing (object sender, FormClosingEventArgs e)
        {
            closing = true;
        }

        private void LoadFromConfig ()
        {
            if (!File.Exists ("Settings.txt"))
                return;

            if (File.Exists (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini")))
                File.Delete (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini"));
            File.WriteAllText (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini"), DefaultInstanceText);

            string[] lines = File.ReadAllLines ("Settings.txt");
            foreach (string line in lines)
            {
                string[] split = line.Split ('=');
                switch (split[0])
                {
                    case "AuroraPath":
                        AuroraPath.Text = split[1];
                        break;
                    case "ConfigFilePath":
                        ConfigFilePath.Text = split[1];
                        break;
                    case "Instances":
                        list.AddRange (split[1].Split (','));
                        break;
                    default:
                        break;
                }
            }
        }

        private void SaveToConfig ()
        {
            List<string> lines = new List<string> ();
            lines.Add ("AuroraPath=" + AuroraPath.Text);
            lines.Add ("ConfigFilePath=" + ConfigFilePath.Text);
            lines.Add ("Instances=" + string.Join(",", list.ToArray()));

            File.WriteAllLines ("Settings.txt", lines.ToArray());
        }

        private void button2_Click (object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = ConfigFilePath.Text;
            if (!Directory.Exists (ConfigFilePath.Text))
                Directory.CreateDirectory (ConfigFilePath.Text);
            DialogResult result = folderBrowserDialog1.ShowDialog ();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ConfigFilePath.Text = folderBrowserDialog1.SelectedPath;
                SaveToConfig ();
            }
        }

        private void button3_Click (object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = AuroraPath.Text;
            if (!Directory.Exists (AuroraPath.Text))
                Directory.CreateDirectory (AuroraPath.Text);
            DialogResult result = folderBrowserDialog1.ShowDialog ();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                AuroraPath.Text = folderBrowserDialog1.SelectedPath;
                SaveToConfig ();
            }
        }

        private void button1_Click (object sender, EventArgs e)
        {
            if (!Directory.Exists (AuroraPath.Text))
            {
                MessageBox.Show ("Wrong Aurora path");
                return;
            }

            #region Migrate the configs

            string SourcePath = AuroraPath.Text;
            string DestinationPath = ConfigFilePath.Text;
            
            //Copy all the files
            foreach (string newPath in Directory.GetFiles (SourcePath, "*.ini", SearchOption.AllDirectories))
            {
                string dir = Path.GetDirectoryName (newPath.Replace (SourcePath, DestinationPath));
                if (!Directory.Exists (dir))
                    Directory.CreateDirectory (dir);
                File.Copy (newPath, newPath.Replace (SourcePath, DestinationPath), true);
            }

            #endregion
        }

        private void button4_Click (object sender, EventArgs e)
        {
            string fileName = initoGenerateName.Text;
            if (fileName != "")
            {
                File.Copy (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini"), Path.Combine (ConfigFilePath.Text, fileName));
                list.Add (fileName);
                SaveToConfig ();
                RegenerateList ();
            }
        }

        private void RegenerateList ()
        {
            listBox1.Items.Clear ();
            foreach (string i in list)
            {
                if (File.Exists (Path.Combine (ConfigFilePath.Text, i)))
                    listBox1.Items.Add (i);
            }
            listBox2.Items.Clear ();
            foreach (string i in list)
            {
                if (File.Exists (Path.Combine (ConfigFilePath.Text, i)))
                    listBox2.Items.Add (i);
            }
        }

        private void button7_Click (object sender, EventArgs e)
        {
            if (m_selectedInstance == null)
            {
                MessageBox.Show ("Select an instance first");
                return;
            }

            //Update regions dir
            if (!Directory.Exists (RegionsDir.Text))
                Directory.CreateDirectory (RegionsDir.Text);

            string[] lines = File.ReadAllLines (Path.Combine (ConfigFilePath.Text, m_selectedInstance));
            List<string> newLines = new List<string> (lines.Length);
            foreach (string line in lines)
            {
                string newLine = line;
                if (line.Contains ("RegionsDirectory = "))
                    newLine = "RegionsDirectory = " + RegionsDir.Text;
                newLines.Add (newLine);
            }
            File.WriteAllLines (Path.Combine (ConfigFilePath.Text, m_selectedInstance), newLines.ToArray ());
        }

        private void button9_Click_1 (object sender, EventArgs e)
        {
            if (m_selectedInstance == null)
            {
                MessageBox.Show ("Select an instance first");
                return;
            }

            //Update regions dir
            if (!Directory.Exists (RegionsDir.Text))
                Directory.CreateDirectory (RegionsDir.Text);

            string[] lines = File.ReadAllLines (Path.Combine (ConfigFilePath.Text, m_selectedInstance));
            List<string> newLines = new List<string> (lines.Length);
            foreach (string line in lines)
            {
                string newLine = line;
                if (line.Contains ("http_listener_port = "))
                    newLine = "http_listener_port = " + HTTPPort.Text + "";
                newLines.Add (newLine);
            }
            File.WriteAllLines (Path.Combine (ConfigFilePath.Text, m_selectedInstance), newLines.ToArray ());
        }

        private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                RegionsDir.Text = "";
                HTTPPort.Text = "";
                m_selectedInstance = "";
            }
            else
            {
                m_selectedInstance = listBox1.SelectedItem.ToString ();
                string[] lines = File.ReadAllLines (Path.Combine (ConfigFilePath.Text, m_selectedInstance));
                List<string> newLines = new List<string> (lines.Length);
                foreach (string line in lines)
                {
                    if (line.Contains ("RegionsDirectory = "))
                        RegionsDir.Text = line.Replace ("RegionsDirectory = ", "");
                    if (line.Contains ("http_listener_port = "))
                        HTTPPort.Text = line.Replace ("http_listener_port = ", "");
                }
            }
        }

        private void listBox2_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                m_selectedConsoleInstance = "";
            }
            else
            {
                m_selectedConsoleInstance = listBox2.SelectedItem.ToString ();
            }
        }

        private void button6_Click (object sender, EventArgs e)
        {
            if (m_selectedConsoleInstance != "")
            {
                list.Remove (m_selectedConsoleInstance);
                File.Delete (Path.Combine (ConfigFilePath.Text, m_selectedConsoleInstance));
                m_selectedConsoleInstance = null;
                SaveToConfig ();
                RegenerateList ();
            }
        }

        private void button5_Click (object sender, EventArgs e)
        {
            StartAurora ("Aurora.exe");
        }
        
        private void button8_Click (object sender, EventArgs e)
        {
            StartAurora ("Aurora32bitLaunch.exe");
        }

        private void StartAurora (string name)
        {
            ProcessStartInfo info = new ProcessStartInfo (Path.Combine (AuroraPath.Text, name));
            info.Arguments = "-mainIniDirectory=" + ConfigFilePath.Text + " -secondaryIniFileName=" + m_selectedConsoleInstance;
            info.UseShellExecute = true;
            info.CreateNoWindow = true;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            Process p = Process.Start (info);
            m_processes.Add (m_selectedConsoleInstance, p);
            if (consoleTracker == null)
            {
                consoleTracker = new Thread (ConsoleTracker);
                consoleTracker.Start ();
            }
        }

        private void ConsoleTracker ()
        {
            string currentInstance = "";
            while (true)
            {
                if (closing)
                {
                    foreach (Process p in m_processes.Values)
                    {
                        if(!p.HasExited)
                            p.Kill ();
                    }
                    break;
                }
                if (m_selectedConsoleInstance != "")
                {
                    if (m_processes.ContainsKey (m_selectedConsoleInstance))
                    {
                        if (currentInstance != m_selectedConsoleInstance)
                        {
                            ResetTextBox = true;
                            currentInstance = m_selectedConsoleInstance;
                        }
                        char[] buff = new char[1];
                        m_processes[currentInstance].StandardOutput.Read (buff, 0, 1);
                        string line = new string (buff);
                        if (line == null || m_processes[currentInstance].HasExited)
                        {
                            m_processes.Remove (currentInstance);
                            continue;
                        }
                        if (buff[0] == (char)0)
                            continue;
                        toAppend.Add (line);
                    }
                }
            }
        }

        private void button9_Click ()
        {
            if (m_selectedConsoleInstance != "")
            {
                if (m_processes.ContainsKey (m_selectedConsoleInstance))
                {
                    m_processes[m_selectedConsoleInstance].StandardInput.WriteLine (textBox1.Text);
                    textBox1.Text = "";
                }
            }
        }

        private void textBox1_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button9_Click ();
        }

        private void button11_Click (object sender, EventArgs e)
        {
            StartAurora ("mono Aurora.exe");
        }

        private void button10_Click (object sender, EventArgs e)
        {
            StartAurora ("mono Aurora32bitLaunch.exe");
        }
    }
}
