namespace InstanceManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.button1 = new System.Windows.Forms.Button ();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog ();
            this.button2 = new System.Windows.Forms.Button ();
            this.ConfigFilePath = new System.Windows.Forms.TextBox ();
            this.label1 = new System.Windows.Forms.Label ();
            this.label2 = new System.Windows.Forms.Label ();
            this.AuroraPath = new System.Windows.Forms.TextBox ();
            this.button3 = new System.Windows.Forms.Button ();
            this.panel1 = new System.Windows.Forms.Panel ();
            this.panel2 = new System.Windows.Forms.Panel ();
            this.label3 = new System.Windows.Forms.Label ();
            this.initoGenerateName = new System.Windows.Forms.TextBox ();
            this.button4 = new System.Windows.Forms.Button ();
            this.listBox1 = new System.Windows.Forms.ListBox ();
            this.label4 = new System.Windows.Forms.Label ();
            this.button7 = new System.Windows.Forms.Button ();
            this.RegionsDir = new System.Windows.Forms.TextBox ();
            this.panel3 = new System.Windows.Forms.Panel ();
            this.button9 = new System.Windows.Forms.Button ();
            this.label5 = new System.Windows.Forms.Label ();
            this.HTTPPort = new System.Windows.Forms.TextBox ();
            this.tabControl1 = new System.Windows.Forms.TabControl ();
            this.tabPage1 = new System.Windows.Forms.TabPage ();
            this.tabPage2 = new System.Windows.Forms.TabPage ();
            this.textBox1 = new System.Windows.Forms.TextBox ();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox ();
            this.groupBox1 = new System.Windows.Forms.GroupBox ();
            this.button10 = new System.Windows.Forms.Button ();
            this.button8 = new System.Windows.Forms.Button ();
            this.button6 = new System.Windows.Forms.Button ();
            this.button5 = new System.Windows.Forms.Button ();
            this.button11 = new System.Windows.Forms.Button ();
            this.listBox2 = new System.Windows.Forms.ListBox ();
            this.AutoRestartInstances = new System.Windows.Forms.CheckBox ();
            this.panel1.SuspendLayout ();
            this.panel2.SuspendLayout ();
            this.panel3.SuspendLayout ();
            this.tabControl1.SuspendLayout ();
            this.tabPage1.SuspendLayout ();
            this.tabPage2.SuspendLayout ();
            this.groupBox1.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point (227, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size (75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Migrate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler (this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point (146, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size (75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler (this.button2_Click);
            // 
            // ConfigFilePath
            // 
            this.ConfigFilePath.Location = new System.Drawing.Point (2, 19);
            this.ConfigFilePath.Name = "ConfigFilePath";
            this.ConfigFilePath.ReadOnly = true;
            this.ConfigFilePath.Size = new System.Drawing.Size (138, 20);
            this.ConfigFilePath.TabIndex = 2;
            this.ConfigFilePath.Text = "C:\\\\AuroraConfig";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point (2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (138, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "New Configuration File Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point (2, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size (83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aurora.exe Path";
            // 
            // AuroraPath
            // 
            this.AuroraPath.Location = new System.Drawing.Point (2, 68);
            this.AuroraPath.Name = "AuroraPath";
            this.AuroraPath.ReadOnly = true;
            this.AuroraPath.Size = new System.Drawing.Size (138, 20);
            this.AuroraPath.TabIndex = 5;
            this.AuroraPath.Text = "C:\\\\Aurora";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point (146, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size (75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler (this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add (this.AuroraPath);
            this.panel1.Controls.Add (this.label2);
            this.panel1.Controls.Add (this.button1);
            this.panel1.Controls.Add (this.button2);
            this.panel1.Controls.Add (this.button3);
            this.panel1.Controls.Add (this.ConfigFilePath);
            this.panel1.Controls.Add (this.label1);
            this.panel1.Location = new System.Drawing.Point (6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size (310, 92);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add (this.label3);
            this.panel2.Controls.Add (this.initoGenerateName);
            this.panel2.Controls.Add (this.button4);
            this.panel2.Location = new System.Drawing.Point (6, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size (310, 140);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point (3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size (133, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Generate new instance file";
            // 
            // initoGenerateName
            // 
            this.initoGenerateName.Location = new System.Drawing.Point (6, 16);
            this.initoGenerateName.Name = "initoGenerateName";
            this.initoGenerateName.Size = new System.Drawing.Size (215, 20);
            this.initoGenerateName.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point (227, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size (75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Generate";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler (this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point (3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size (120, 95);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler (this.listBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point (129, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size (110, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Set Regions Directory";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point (129, 43);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size (75, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = "Update";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler (this.button7_Click);
            // 
            // RegionsDir
            // 
            this.RegionsDir.Location = new System.Drawing.Point (129, 20);
            this.RegionsDir.Name = "RegionsDir";
            this.RegionsDir.Size = new System.Drawing.Size (100, 20);
            this.RegionsDir.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add (this.AutoRestartInstances);
            this.panel3.Controls.Add (this.button9);
            this.panel3.Controls.Add (this.label5);
            this.panel3.Controls.Add (this.HTTPPort);
            this.panel3.Controls.Add (this.listBox1);
            this.panel3.Controls.Add (this.RegionsDir);
            this.panel3.Controls.Add (this.button7);
            this.panel3.Controls.Add (this.label4);
            this.panel3.Location = new System.Drawing.Point (321, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size (388, 124);
            this.panel3.TabIndex = 15;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point (256, 42);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size (75, 23);
            this.button9.TabIndex = 17;
            this.button9.Text = "Update";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler (this.button9_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point (253, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size (58, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "HTTP Port";
            // 
            // HTTPPort
            // 
            this.HTTPPort.Location = new System.Drawing.Point (256, 20);
            this.HTTPPort.Name = "HTTPPort";
            this.HTTPPort.Size = new System.Drawing.Size (100, 20);
            this.HTTPPort.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add (this.tabPage1);
            this.tabControl1.Controls.Add (this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point (0, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size (720, 305);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add (this.panel1);
            this.tabPage1.Controls.Add (this.panel3);
            this.tabPage1.Controls.Add (this.panel2);
            this.tabPage1.Location = new System.Drawing.Point (4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding (3);
            this.tabPage1.Size = new System.Drawing.Size (712, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Set Up";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add (this.textBox1);
            this.tabPage2.Controls.Add (this.richTextBox1);
            this.tabPage2.Controls.Add (this.groupBox1);
            this.tabPage2.Controls.Add (this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point (4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding (3);
            this.tabPage2.Size = new System.Drawing.Size (712, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consoles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point (132, 256);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size (574, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler (this.textBox1_KeyDown);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point (132, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size (574, 250);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add (this.button10);
            this.groupBox1.Controls.Add (this.button8);
            this.groupBox1.Controls.Add (this.button6);
            this.groupBox1.Controls.Add (this.button5);
            this.groupBox1.Controls.Add (this.button11);
            this.groupBox1.Location = new System.Drawing.Point (8, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size (118, 164);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point (6, 94);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size (106, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "Mono Start (32 bit)";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler (this.button10_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point (6, 44);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size (106, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Start (32 bit)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler (this.button8_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point (6, 119);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size (106, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "Remove";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler (this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point (6, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size (106, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler (this.button5_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point (6, 69);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size (106, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "Mono Start";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler (this.button11_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point (6, 6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size (120, 95);
            this.listBox2.TabIndex = 10;
            this.listBox2.SelectedIndexChanged += new System.EventHandler (this.listBox2_SelectedIndexChanged);
            // 
            // AutoRestartInstances
            // 
            this.AutoRestartInstances.AutoSize = true;
            this.AutoRestartInstances.Checked = true;
            this.AutoRestartInstances.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoRestartInstances.Location = new System.Drawing.Point (132, 81);
            this.AutoRestartInstances.Name = "AutoRestartInstances";
            this.AutoRestartInstances.Size = new System.Drawing.Size (134, 17);
            this.AutoRestartInstances.TabIndex = 16;
            this.AutoRestartInstances.Text = "Auto Restart Instances";
            this.AutoRestartInstances.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (718, 328);
            this.Controls.Add (this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler (this.Form1_Load);
            this.panel1.ResumeLayout (false);
            this.panel1.PerformLayout ();
            this.panel2.ResumeLayout (false);
            this.panel2.PerformLayout ();
            this.panel3.ResumeLayout (false);
            this.panel3.PerformLayout ();
            this.tabControl1.ResumeLayout (false);
            this.tabPage1.ResumeLayout (false);
            this.tabPage2.ResumeLayout (false);
            this.tabPage2.PerformLayout ();
            this.groupBox1.ResumeLayout (false);
            this.ResumeLayout (false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ConfigFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AuroraPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox initoGenerateName;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox RegionsDir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox HTTPPort;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.CheckBox AutoRestartInstances;
    }
}

