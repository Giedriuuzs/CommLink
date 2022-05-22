namespace CommLink
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ServersTab = new System.Windows.Forms.TabPage();
            this.richTextBoxDisplayLog = new System.Windows.Forms.RichTextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSaveLogServer = new System.Windows.Forms.Button();
            this.buttonSetupServer = new System.Windows.Forms.Button();
            this.buttonDeleteServer = new System.Windows.Forms.Button();
            this.buttonAddServer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.labelServers = new System.Windows.Forms.Label();
            this.TestingTab = new System.Windows.Forms.TabPage();
            this.buttonSendTest = new System.Windows.Forms.Button();
            this.richTextBoxInputMessage = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLogTest = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelInputMessageTest = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelLogTest = new System.Windows.Forms.Label();
            this.labelConnectedDisconectedTest = new System.Windows.Forms.Label();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonDisconnectTest = new System.Windows.Forms.Button();
            this.buttonConnectTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelPortTest = new System.Windows.Forms.Label();
            this.labelIPAddressTest = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ServersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TestingTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServersTab
            // 
            this.ServersTab.Controls.Add(this.richTextBoxDisplayLog);
            this.ServersTab.Controls.Add(this.buttonOpen);
            this.ServersTab.Controls.Add(this.buttonSaveLogServer);
            this.ServersTab.Controls.Add(this.buttonSetupServer);
            this.ServersTab.Controls.Add(this.buttonDeleteServer);
            this.ServersTab.Controls.Add(this.buttonAddServer);
            this.ServersTab.Controls.Add(this.dataGridView1);
            this.ServersTab.Controls.Add(this.labelServers);
            this.ServersTab.Location = new System.Drawing.Point(4, 29);
            this.ServersTab.Name = "ServersTab";
            this.ServersTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServersTab.Size = new System.Drawing.Size(672, 418);
            this.ServersTab.TabIndex = 1;
            this.ServersTab.Text = "Servers";
            this.ServersTab.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDisplayLog
            // 
            this.richTextBoxDisplayLog.Location = new System.Drawing.Point(6, 226);
            this.richTextBoxDisplayLog.Name = "richTextBoxDisplayLog";
            this.richTextBoxDisplayLog.Size = new System.Drawing.Size(560, 185);
            this.richTextBoxDisplayLog.TabIndex = 7;
            this.richTextBoxDisplayLog.Text = "";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(572, 102);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(94, 29);
            this.buttonOpen.TabIndex = 6;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSaveLogServer
            // 
            this.buttonSaveLogServer.Location = new System.Drawing.Point(572, 67);
            this.buttonSaveLogServer.Name = "buttonSaveLogServer";
            this.buttonSaveLogServer.Size = new System.Drawing.Size(94, 29);
            this.buttonSaveLogServer.TabIndex = 5;
            this.buttonSaveLogServer.Text = "Save log";
            this.buttonSaveLogServer.UseVisualStyleBackColor = true;
            this.buttonSaveLogServer.Click += new System.EventHandler(this.buttonSaveLogServer_Click);
            // 
            // buttonSetupServer
            // 
            this.buttonSetupServer.Location = new System.Drawing.Point(572, 35);
            this.buttonSetupServer.Name = "buttonSetupServer";
            this.buttonSetupServer.Size = new System.Drawing.Size(94, 26);
            this.buttonSetupServer.TabIndex = 4;
            this.buttonSetupServer.Text = "Setup";
            this.buttonSetupServer.UseVisualStyleBackColor = true;
            this.buttonSetupServer.Click += new System.EventHandler(this.buttonSetupServer_Click);
            // 
            // buttonDeleteServer
            // 
            this.buttonDeleteServer.Location = new System.Drawing.Point(174, 6);
            this.buttonDeleteServer.Name = "buttonDeleteServer";
            this.buttonDeleteServer.Size = new System.Drawing.Size(33, 26);
            this.buttonDeleteServer.TabIndex = 3;
            this.buttonDeleteServer.Text = "-";
            this.buttonDeleteServer.UseVisualStyleBackColor = true;
            this.buttonDeleteServer.Click += new System.EventHandler(this.buttonDeleteServer_Click);
            // 
            // buttonAddServer
            // 
            this.buttonAddServer.Location = new System.Drawing.Point(135, 6);
            this.buttonAddServer.Name = "buttonAddServer";
            this.buttonAddServer.Size = new System.Drawing.Size(33, 26);
            this.buttonAddServer.TabIndex = 2;
            this.buttonAddServer.Text = "+";
            this.buttonAddServer.UseVisualStyleBackColor = true;
            this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(560, 185);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "AnalyzerID";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Visible = false;
            this.Column4.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Analyzer";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IP Address";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Active";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 50;
            // 
            // labelServers
            // 
            this.labelServers.AutoSize = true;
            this.labelServers.Location = new System.Drawing.Point(6, 12);
            this.labelServers.Name = "labelServers";
            this.labelServers.Size = new System.Drawing.Size(123, 20);
            this.labelServers.TabIndex = 0;
            this.labelServers.Text = "Communications:";
            // 
            // TestingTab
            // 
            this.TestingTab.Controls.Add(this.buttonSendTest);
            this.TestingTab.Controls.Add(this.richTextBoxInputMessage);
            this.TestingTab.Controls.Add(this.richTextBoxLogTest);
            this.TestingTab.Controls.Add(this.textBox2);
            this.TestingTab.Controls.Add(this.textBox1);
            this.TestingTab.Controls.Add(this.labelInputMessageTest);
            this.TestingTab.Controls.Add(this.buttonClear);
            this.TestingTab.Controls.Add(this.labelLogTest);
            this.TestingTab.Controls.Add(this.labelConnectedDisconectedTest);
            this.TestingTab.Controls.Add(this.buttonSaveLog);
            this.TestingTab.Controls.Add(this.buttonDisconnectTest);
            this.TestingTab.Controls.Add(this.buttonConnectTest);
            this.TestingTab.Controls.Add(this.groupBox1);
            this.TestingTab.Controls.Add(this.labelPortTest);
            this.TestingTab.Controls.Add(this.labelIPAddressTest);
            this.TestingTab.Location = new System.Drawing.Point(4, 29);
            this.TestingTab.Name = "TestingTab";
            this.TestingTab.Padding = new System.Windows.Forms.Padding(3);
            this.TestingTab.Size = new System.Drawing.Size(672, 418);
            this.TestingTab.TabIndex = 0;
            this.TestingTab.Text = "Testing";
            this.TestingTab.UseVisualStyleBackColor = true;
            // 
            // buttonSendTest
            // 
            this.buttonSendTest.Location = new System.Drawing.Point(575, 382);
            this.buttonSendTest.Name = "buttonSendTest";
            this.buttonSendTest.Size = new System.Drawing.Size(94, 29);
            this.buttonSendTest.TabIndex = 14;
            this.buttonSendTest.Text = "Send";
            this.buttonSendTest.UseVisualStyleBackColor = true;
            this.buttonSendTest.Click += new System.EventHandler(this.buttonSendTest_Click);
            // 
            // richTextBoxInputMessage
            // 
            this.richTextBoxInputMessage.Location = new System.Drawing.Point(339, 121);
            this.richTextBoxInputMessage.Name = "richTextBoxInputMessage";
            this.richTextBoxInputMessage.Size = new System.Drawing.Size(330, 290);
            this.richTextBoxInputMessage.TabIndex = 13;
            this.richTextBoxInputMessage.Text = "";
            // 
            // richTextBoxLogTest
            // 
            this.richTextBoxLogTest.Location = new System.Drawing.Point(6, 121);
            this.richTextBoxLogTest.Name = "richTextBoxLogTest";
            this.richTextBoxLogTest.Size = new System.Drawing.Size(330, 290);
            this.richTextBoxLogTest.TabIndex = 12;
            this.richTextBoxLogTest.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 27);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "7777";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "127.0.0.1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelInputMessageTest
            // 
            this.labelInputMessageTest.AutoSize = true;
            this.labelInputMessageTest.Location = new System.Drawing.Point(342, 98);
            this.labelInputMessageTest.Name = "labelInputMessageTest";
            this.labelInputMessageTest.Size = new System.Drawing.Size(108, 20);
            this.labelInputMessageTest.TabIndex = 11;
            this.labelInputMessageTest.Text = "Input message:";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(242, 89);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 29);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelLogTest
            // 
            this.labelLogTest.AutoSize = true;
            this.labelLogTest.Location = new System.Drawing.Point(24, 98);
            this.labelLogTest.Name = "labelLogTest";
            this.labelLogTest.Size = new System.Drawing.Size(37, 20);
            this.labelLogTest.TabIndex = 9;
            this.labelLogTest.Text = "Log:";
            // 
            // labelConnectedDisconectedTest
            // 
            this.labelConnectedDisconectedTest.AutoSize = true;
            this.labelConnectedDisconectedTest.Location = new System.Drawing.Point(430, 46);
            this.labelConnectedDisconectedTest.Name = "labelConnectedDisconectedTest";
            this.labelConnectedDisconectedTest.Size = new System.Drawing.Size(99, 20);
            this.labelConnectedDisconectedTest.TabIndex = 8;
            this.labelConnectedDisconectedTest.Text = "Disconnected";
            this.labelConnectedDisconectedTest.TextChanged += new System.EventHandler(this.labelConnectedDisconectedTest_TextChanged);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(554, 82);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(94, 29);
            this.buttonSaveLog.TabIndex = 7;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonDisconnectTest
            // 
            this.buttonDisconnectTest.Location = new System.Drawing.Point(554, 47);
            this.buttonDisconnectTest.Name = "buttonDisconnectTest";
            this.buttonDisconnectTest.Size = new System.Drawing.Size(94, 29);
            this.buttonDisconnectTest.TabIndex = 6;
            this.buttonDisconnectTest.Text = "Disconnect";
            this.buttonDisconnectTest.UseVisualStyleBackColor = true;
            this.buttonDisconnectTest.Click += new System.EventHandler(this.buttonDisconnectTest_Click);
            // 
            // buttonConnectTest
            // 
            this.buttonConnectTest.Location = new System.Drawing.Point(554, 14);
            this.buttonConnectTest.Name = "buttonConnectTest";
            this.buttonConnectTest.Size = new System.Drawing.Size(94, 29);
            this.buttonConnectTest.TabIndex = 5;
            this.buttonConnectTest.Text = "Connect";
            this.buttonConnectTest.UseVisualStyleBackColor = true;
            this.buttonConnectTest.Click += new System.EventHandler(this.buttonConnectTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(242, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Server";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.CommLink_Load);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Client";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.CommLink_Load);
            // 
            // labelPortTest
            // 
            this.labelPortTest.AutoSize = true;
            this.labelPortTest.Location = new System.Drawing.Point(67, 50);
            this.labelPortTest.Name = "labelPortTest";
            this.labelPortTest.Size = new System.Drawing.Size(38, 20);
            this.labelPortTest.TabIndex = 1;
            this.labelPortTest.Text = "Port:";
            // 
            // labelIPAddressTest
            // 
            this.labelIPAddressTest.AutoSize = true;
            this.labelIPAddressTest.Location = new System.Drawing.Point(24, 17);
            this.labelIPAddressTest.Name = "labelIPAddressTest";
            this.labelIPAddressTest.Size = new System.Drawing.Size(81, 20);
            this.labelIPAddressTest.TabIndex = 0;
            this.labelIPAddressTest.Text = "IP Address:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TestingTab);
            this.tabControl1.Controls.Add(this.ServersTab);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CommLink";
            this.ServersTab.ResumeLayout(false);
            this.ServersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TestingTab.ResumeLayout(false);
            this.TestingTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage ServersTab;
        private RichTextBox richTextBoxDisplayLog;
        private Button buttonOpen;
        private Button buttonSaveLogServer;
        private Button buttonSetupServer;
        private Button buttonDeleteServer;
        private Button buttonAddServer;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewCheckBoxColumn Column3;
        private Label labelServers;
        private TabPage TestingTab;
        private Button buttonSendTest;
        private RichTextBox richTextBoxInputMessage;
        private RichTextBox richTextBoxLogTest;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label labelInputMessageTest;
        private Button buttonClear;
        private Label labelLogTest;
        private Label labelConnectedDisconectedTest;
        private Button buttonSaveLog;
        private Button buttonDisconnectTest;
        private Button buttonConnectTest;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label labelPortTest;
        private Label labelIPAddressTest;
        private TabControl tabControl1;
    }
}