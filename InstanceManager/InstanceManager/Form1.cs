using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace InstanceManager
{
    public partial class Form1 : Form
    {
        private List<string> list = new List<string> ();
        private string m_selectedInstance = "";
        private static string DefaultInstanceText = @"[RegionStartup]
Default = RegionLoaderFileSystem
RegionsDirectory = Regions";

        public Form1 ()
        {
            InitializeComponent ();
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            LoadFromConfig ();
            RegenerateList ();
        }

        private void LoadFromConfig ()
        {
            if (!File.Exists ("Settings.txt"))
                return;
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

            if (File.Exists (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini")))
                File.Delete (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini"));
            File.WriteAllText (Path.Combine (ConfigFilePath.Text, "DefaultInstance.ini"), DefaultInstanceText);
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
                listBox1.Items.Add (i);
            }
        }

        private void initoGenerateName_TextChanged (object sender, EventArgs e)
        {

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
                    newLine = "RegionsDirectory = \"" + RegionsDir.Text + "\"";
                newLines.Add (newLine);
            }
            File.WriteAllLines (Path.Combine (ConfigFilePath.Text, m_selectedInstance), newLines.ToArray ());
        }

        private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                RegionsDir.Text = "";
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
                }
            }
        }

        private void button6_Click (object sender, EventArgs e)
        {
            if (m_selectedInstance != "")
            {
                list.Remove (m_selectedInstance);
                File.Delete (Path.Combine (ConfigFilePath.Text, m_selectedInstance));
                m_selectedInstance = null;
                SaveToConfig ();
                RegenerateList ();
            }
        }

        private void button5_Click (object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo (Path.Combine(AuroraPath.Text, "Aurora.exe"));
            info.Arguments = "-mainIniDirectory=" + ConfigFilePath.Text + " -secondaryIniFileName=" + m_selectedInstance;
            info.UseShellExecute = true;
            Process.Start (info);
        }

        private void button8_Click (object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo (Path.Combine (AuroraPath.Text, "Aurora32bitLaunch.exe"));
            info.Arguments = "-mainIniDirectory=" + ConfigFilePath.Text + " -secondaryIniFileName=" + m_selectedInstance;
            info.UseShellExecute = true;
            Process.Start (info);
        }
    }
}
