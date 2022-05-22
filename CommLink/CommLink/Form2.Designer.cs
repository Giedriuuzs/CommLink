namespace CommLink
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AnalyzerExamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnalyzerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISAnalystCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnalyzerExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendToAnalyzer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxAnalyzer = new System.Windows.Forms.TextBox();
            this.textBoxIS = new System.Windows.Forms.TextBox();
            this.textBoxAPort = new System.Windows.Forms.TextBox();
            this.textBoxISPort = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxISIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxAIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxAProtocol = new System.Windows.Forms.ComboBox();
            this.textBoxAType = new System.Windows.Forms.ComboBox();
            this.textBoxISType = new System.Windows.Forms.ComboBox();
            this.textBoxISProtocol = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analyzer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Protocol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "IP address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "IS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Protocol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(405, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "IP address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(536, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Port";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(712, 374);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(76, 29);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(709, 58);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(79, 24);
            this.checkBoxActive.TabIndex = 12;
            this.checkBoxActive.Text = "Active?";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnalyzerExamID,
            this.AnalyzerID,
            this.ISExamCode,
            this.ISAnalystCode,
            this.AnalyzerExamCode,
            this.SendToAnalyzer,
            this.Active});
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(694, 320);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded_1);
            // 
            // AnalyzerExamID
            // 
            this.AnalyzerExamID.DataPropertyName = "AnalyzerExamID";
            this.AnalyzerExamID.HeaderText = "AnalyzerExamID";
            this.AnalyzerExamID.MinimumWidth = 6;
            this.AnalyzerExamID.Name = "AnalyzerExamID";
            this.AnalyzerExamID.Visible = false;
            this.AnalyzerExamID.Width = 125;
            // 
            // AnalyzerID
            // 
            this.AnalyzerID.DataPropertyName = "AnalyzerID";
            this.AnalyzerID.HeaderText = "AnalyzerID";
            this.AnalyzerID.MinimumWidth = 6;
            this.AnalyzerID.Name = "AnalyzerID";
            this.AnalyzerID.Visible = false;
            this.AnalyzerID.Width = 125;
            // 
            // ISExamCode
            // 
            this.ISExamCode.DataPropertyName = "ISExamCode";
            this.ISExamCode.HeaderText = "IS exam";
            this.ISExamCode.MinimumWidth = 6;
            this.ISExamCode.Name = "ISExamCode";
            this.ISExamCode.Width = 105;
            // 
            // ISAnalystCode
            // 
            this.ISAnalystCode.DataPropertyName = "ISAnalystCode";
            this.ISAnalystCode.HeaderText = "IS analyst";
            this.ISAnalystCode.MinimumWidth = 6;
            this.ISAnalystCode.Name = "ISAnalystCode";
            this.ISAnalystCode.Width = 105;
            // 
            // AnalyzerExamCode
            // 
            this.AnalyzerExamCode.DataPropertyName = "AnalyzerExamCode";
            this.AnalyzerExamCode.HeaderText = "Analyzer exam";
            this.AnalyzerExamCode.MinimumWidth = 6;
            this.AnalyzerExamCode.Name = "AnalyzerExamCode";
            this.AnalyzerExamCode.Width = 105;
            // 
            // SendToAnalyzer
            // 
            this.SendToAnalyzer.DataPropertyName = "SendToAnalyzer";
            this.SendToAnalyzer.FalseValue = "false";
            this.SendToAnalyzer.HeaderText = "SendToAnalyzer";
            this.SendToAnalyzer.IndeterminateValue = "false";
            this.SendToAnalyzer.MinimumWidth = 6;
            this.SendToAnalyzer.Name = "SendToAnalyzer";
            this.SendToAnalyzer.TrueValue = "true";
            this.SendToAnalyzer.Visible = false;
            this.SendToAnalyzer.Width = 105;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.FalseValue = "false";
            this.Active.HeaderText = "Active";
            this.Active.IndeterminateValue = "false";
            this.Active.MinimumWidth = 6;
            this.Active.Name = "Active";
            this.Active.TrueValue = "true";
            this.Active.Width = 60;
            // 
            // textBoxAnalyzer
            // 
            this.textBoxAnalyzer.Location = new System.Drawing.Point(12, 32);
            this.textBoxAnalyzer.MaxLength = 30;
            this.textBoxAnalyzer.Name = "textBoxAnalyzer";
            this.textBoxAnalyzer.Size = new System.Drawing.Size(125, 27);
            this.textBoxAnalyzer.TabIndex = 14;
            // 
            // textBoxIS
            // 
            this.textBoxIS.Location = new System.Drawing.Point(12, 85);
            this.textBoxIS.MaxLength = 30;
            this.textBoxIS.Name = "textBoxIS";
            this.textBoxIS.Size = new System.Drawing.Size(125, 27);
            this.textBoxIS.TabIndex = 19;
            // 
            // textBoxAPort
            // 
            this.textBoxAPort.Location = new System.Drawing.Point(536, 32);
            this.textBoxAPort.MaxLength = 10;
            this.textBoxAPort.Name = "textBoxAPort";
            this.textBoxAPort.Size = new System.Drawing.Size(125, 27);
            this.textBoxAPort.TabIndex = 24;
            this.textBoxAPort.TextChanged += new System.EventHandler(this.textBoxAPort_TextChanged);
            // 
            // textBoxISPort
            // 
            this.textBoxISPort.Location = new System.Drawing.Point(536, 85);
            this.textBoxISPort.MaxLength = 10;
            this.textBoxISPort.Name = "textBoxISPort";
            this.textBoxISPort.Size = new System.Drawing.Size(125, 27);
            this.textBoxISPort.TabIndex = 26;
            this.textBoxISPort.TextChanged += new System.EventHandler(this.textBoxISPort_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(712, 409);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 29);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxISIPAddress
            // 
            this.textBoxISIPAddress.Location = new System.Drawing.Point(405, 85);
            this.textBoxISIPAddress.MaxLength = 30;
            this.textBoxISIPAddress.Name = "textBoxISIPAddress";
            this.textBoxISIPAddress.Size = new System.Drawing.Size(125, 27);
            this.textBoxISIPAddress.TabIndex = 28;
            this.textBoxISIPAddress.TextChanged += new System.EventHandler(this.textBoxISIPAddress_TextChanged);
            // 
            // textBoxAIPAddress
            // 
            this.textBoxAIPAddress.Location = new System.Drawing.Point(405, 32);
            this.textBoxAIPAddress.MaxLength = 30;
            this.textBoxAIPAddress.Name = "textBoxAIPAddress";
            this.textBoxAIPAddress.Size = new System.Drawing.Size(125, 27);
            this.textBoxAIPAddress.TabIndex = 29;
            this.textBoxAIPAddress.TextChanged += new System.EventHandler(this.textBoxAIPAddress_TextChanged);
            // 
            // textBoxAProtocol
            // 
            this.textBoxAProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxAProtocol.FormattingEnabled = true;
            this.textBoxAProtocol.Items.AddRange(new object[] {
            "",
            "HL7"});
            this.textBoxAProtocol.Location = new System.Drawing.Point(143, 32);
            this.textBoxAProtocol.MaxLength = 30;
            this.textBoxAProtocol.Name = "textBoxAProtocol";
            this.textBoxAProtocol.Size = new System.Drawing.Size(125, 28);
            this.textBoxAProtocol.TabIndex = 30;
            // 
            // textBoxAType
            // 
            this.textBoxAType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxAType.FormattingEnabled = true;
            this.textBoxAType.Items.AddRange(new object[] {
            "",
            "Client",
            "Server"});
            this.textBoxAType.Location = new System.Drawing.Point(274, 32);
            this.textBoxAType.MaxLength = 30;
            this.textBoxAType.Name = "textBoxAType";
            this.textBoxAType.Size = new System.Drawing.Size(125, 28);
            this.textBoxAType.TabIndex = 31;
            // 
            // textBoxISType
            // 
            this.textBoxISType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxISType.FormattingEnabled = true;
            this.textBoxISType.Items.AddRange(new object[] {
            "",
            "Client",
            "Server"});
            this.textBoxISType.Location = new System.Drawing.Point(274, 85);
            this.textBoxISType.MaxLength = 30;
            this.textBoxISType.Name = "textBoxISType";
            this.textBoxISType.Size = new System.Drawing.Size(125, 28);
            this.textBoxISType.TabIndex = 32;
            // 
            // textBoxISProtocol
            // 
            this.textBoxISProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxISProtocol.FormattingEnabled = true;
            this.textBoxISProtocol.Items.AddRange(new object[] {
            "",
            "XML"});
            this.textBoxISProtocol.Location = new System.Drawing.Point(143, 85);
            this.textBoxISProtocol.MaxLength = 30;
            this.textBoxISProtocol.Name = "textBoxISProtocol";
            this.textBoxISProtocol.Size = new System.Drawing.Size(125, 28);
            this.textBoxISProtocol.TabIndex = 33;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxISProtocol);
            this.Controls.Add(this.textBoxISType);
            this.Controls.Add(this.textBoxAType);
            this.Controls.Add(this.textBoxAProtocol);
            this.Controls.Add(this.textBoxAIPAddress);
            this.Controls.Add(this.textBoxISIPAddress);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxISPort);
            this.Controls.Add(this.textBoxAPort);
            this.Controls.Add(this.textBoxIS);
            this.Controls.Add(this.textBoxAnalyzer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Setup communication";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button buttonSave;
        private CheckBox checkBoxActive;
        private DataGridView dataGridView1;
        private TextBox textBoxAnalyzer;
        private TextBox textBoxIS;
        private TextBox textBoxAPort;
        private TextBox textBoxISPort;
        private Button buttonCancel;
        private DataGridViewTextBoxColumn AnalyzerExamID;
        private DataGridViewTextBoxColumn AnalyzerID;
        private DataGridViewTextBoxColumn ISExamCode;
        private DataGridViewTextBoxColumn ISAnalystCode;
        private DataGridViewTextBoxColumn AnalyzerExamCode;
        private DataGridViewCheckBoxColumn SendToAnalyzer;
        private DataGridViewCheckBoxColumn Active;
        private TextBox textBoxISIPAddress;
        private TextBox textBoxAIPAddress;
        private ComboBox textBoxAProtocol;
        private ComboBox textBoxAType;
        private ComboBox textBoxISType;
        private ComboBox textBoxISProtocol;
    }
}