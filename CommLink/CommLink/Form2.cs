using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CommLink
{
    public partial class Form2 : Form
    {
        Analyzer currentAnalyzer;
        public Analyzer newAnalyzer;
        List<AnalyzerExam> listAnalyzerExams = new List<AnalyzerExam>();
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CommLink"].ConnectionString;
        string sqlExams;
        // List

        SqlCommandBuilder cmdBuilder;
        DataSet ds = new DataSet();
        DataSet changes;
        SqlDataAdapter adapter;
        bool isInsert = true;
        Control ctrl;
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            SqlCommand command;
            SqlCommand commandAddExams;
            SqlDataReader reader;
            string sql;

            cn = new SqlConnection(connectionString);
            cn.Open();

            IPAddress ip;
            string errorString = "";
            int value;


            if (textBoxAIPAddress.Text == "")
            {
                errorString += "Analyzer IP address is mandatory! \r\n";
            }
            else if (!IsValidateIP(textBoxAIPAddress.Text))
            {
                errorString += "Analyzer IP address is invalid! \r\n";
            }

            if (textBoxAPort.Text == "")
            {
                errorString += "Analyzer port is mandatory! \r\n";
            }
            else if (!int.TryParse(textBoxAPort.Text, out value))
            {
                errorString += "Analyzer port is invalid! \r\n";
            }

            if (textBoxISIPAddress.Text == "")
            {
                errorString += "Information system IP address is mandatory! \r\n";
            }
            else if (!IsValidateIP(textBoxISIPAddress.Text))
            {
                errorString += "Information system IP address is invalid! \r\n";
            }

            if (textBoxISPort.Text == "")
            {
                errorString += "Information system port is mandatory! \r\n";
            }
            else if (!int.TryParse(textBoxISPort.Text, out value))
            {
                errorString += "Information system port is invalid! \r\n";
            }

            if (errorString != "")
            {
                MessageBox.Show(errorString);
                return;
            }

            if (isInsert)
            {
                newAnalyzer = new Analyzer();
                sql = "Insert into Analyzer output inserted.AnalyzerID values ('" + textBoxAnalyzer.Text + "', '" + textBoxAProtocol.Text + "', '" + textBoxAType.Text + "', '" + textBoxAIPAddress.Text + "', '"
                    + textBoxAPort.Text + "', '" + textBoxIS.Text + "', '" + textBoxISProtocol.Text + "', '" + textBoxISType.Text + "', '" + textBoxISIPAddress.Text + "', '"
                    + textBoxISPort.Text + "', 1,";

                if (checkBoxActive.Checked)
                {
                    sql += "1)";
                }
                else
                {
                    sql += "0)";
                }

                command = new SqlCommand(sql, cn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newAnalyzer.analyzerID = (int)reader["AnalyzerID"];
                    newAnalyzer.analyzerCode = textBoxAnalyzer.Text;
                    newAnalyzer.analyzerProtocolName = textBoxAProtocol.Text;
                    newAnalyzer.analyzerType = textBoxAType.Text;
                    newAnalyzer.analyzerTCPIP = textBoxAIPAddress.Text;
                    newAnalyzer.analyzerPort = textBoxAPort.Text;
                    newAnalyzer.ISCode = textBoxIS.Text;
                    newAnalyzer.ISProtocolName = textBoxISProtocol.Text;
                    newAnalyzer.ISType = textBoxISType.Text;
                    newAnalyzer.ISTCPIP = textBoxISIPAddress.Text;
                    newAnalyzer.ISPort = textBoxISPort.Text;
                    newAnalyzer.visible = true;
                    newAnalyzer.active = checkBoxActive.Checked;

                }
                reader.Close();


                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    //sqlExams = new string();
                    sqlExams = "Insert INTO AnalyzerExam values ('" + newAnalyzer.analyzerID + "', '" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "', '"
                        + dataGridView1.Rows[i].Cells[3].Value.ToString() + "', '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "', 1 , ";
                    if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "false")
                        sqlExams += "0)";
                    else
                        sqlExams += "1)";
                    commandAddExams = new SqlCommand(sqlExams, cn);
                    commandAddExams.ExecuteNonQuery();
                    //MessageBox.Show(sqlExams); 
                }
                // command.ExecuteNonQuery();
                // CommLink.getAnalyzersFromDB()

            }
            else if (!isInsert)
            {

                sql = "Update Analyzer set AnalyzerCode = @analyzerCode, AnalyzerProtocolName = @analyzerProtocolName, AnalyzerType = @analyzerType, AnalyzerTCPIP = @analyzerTCPIP, "
                    + "AnalyzerTCPIPPORT = @analyzerPort, ISCode = @iSCode, ISProtocolName = @iSProtocolName, ISType = @iSType, ISTCPIP = @iSTCPIP, ISTCPIPPORT = @iSPORT, "
                    + "Visible = @visible, Active = @active where AnalyzerID = @analyzerID";

                command = new SqlCommand(sql, cn);
                command.Parameters.AddWithValue("@analyzerCode", textBoxAnalyzer.Text);
                command.Parameters.AddWithValue("@analyzerProtocolName", textBoxAProtocol.Text);
                command.Parameters.AddWithValue("@analyzerType", textBoxAType.Text);
                command.Parameters.AddWithValue("@analyzerTCPIP", textBoxAIPAddress.Text);
                command.Parameters.AddWithValue("@analyzerPort", textBoxAPort.Text);
                command.Parameters.AddWithValue("@iSCode", textBoxIS.Text);
                command.Parameters.AddWithValue("@iSProtocolName", textBoxISProtocol.Text);
                command.Parameters.AddWithValue("@iSType", textBoxISType.Text);
                command.Parameters.AddWithValue("@iSTCPIP", textBoxISIPAddress.Text);
                command.Parameters.AddWithValue("@iSPORT", textBoxISPort.Text);
                command.Parameters.AddWithValue("@visible", "1");
                command.Parameters.AddWithValue("@active", checkBoxActive.Checked);
                command.Parameters.AddWithValue("@analyzerID", currentAnalyzer.analyzerID.ToString());
                command.ExecuteNonQuery();

                cmdBuilder = new SqlCommandBuilder(adapter);

                changes = ds.GetChanges();
                if (changes != null)
                {
                    for (int i = 0; i < changes.Tables[0].Rows.Count; i++)
                    {
                        if (changes.Tables[0].Rows[i].RowState.ToString() != "Deleted")
                        {
                            changes.Tables[0].Rows[i][1] = currentAnalyzer.analyzerID.ToString();
                        }
                    }
                    if (changes != null)
                    {
                        adapter.Update(changes);
                    }
                }
            }

            cn.Close();
            Form1 frm = (Form1)Application.OpenForms["Form1"];
            frm.loadGridView();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void getAnalyzerInfo(int selectedID)
        {
            SqlConnection cn;
            SqlCommand command;
            SqlDataReader reader;
            string sql;
            currentAnalyzer = new Analyzer();

            cn = new SqlConnection(connectionString);
            cn.Open();

            sql = "Select * from Analyzer where analyzerID = " + selectedID.ToString();
            command = new SqlCommand(sql, cn);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                currentAnalyzer.analyzerID = (int)reader["AnalyzerID"];
                currentAnalyzer.analyzerCode = (string)reader["AnalyzerCode"];
                currentAnalyzer.analyzerProtocolName = (string)reader["AnalyzerProtocolName"];
                currentAnalyzer.analyzerType = (string)reader["AnalyzerType"];
                currentAnalyzer.analyzerTCPIP = (string)reader["AnalyzerTCPIP"];
                currentAnalyzer.analyzerPort = (string)reader["AnalyzerTCPIPPORT"];
                currentAnalyzer.ISCode = (string)reader["ISCode"];
                currentAnalyzer.ISProtocolName = (string)reader["ISProtocolName"];
                currentAnalyzer.ISType = (string)reader["ISType"];
                currentAnalyzer.ISTCPIP = (string)reader["ISTCPIP"];
                currentAnalyzer.ISPort = (string)reader["ISTCPIPPORT"];
                currentAnalyzer.visible = (bool)reader["Visible"];
                currentAnalyzer.active = (bool)reader["Active"];
            }

            reader.Close();

            textBoxAnalyzer.Text = currentAnalyzer.analyzerCode;
            textBoxAProtocol.Text = currentAnalyzer.analyzerProtocolName;
            textBoxAType.Text = currentAnalyzer.analyzerType;
            textBoxAIPAddress.Text = currentAnalyzer.analyzerTCPIP;
            textBoxAPort.Text = currentAnalyzer.analyzerPort;
            textBoxIS.Text = currentAnalyzer.ISCode;
            textBoxISProtocol.Text = currentAnalyzer.ISProtocolName;
            textBoxISType.Text = currentAnalyzer.ISType;
            textBoxISIPAddress.Text = currentAnalyzer.ISTCPIP;
            textBoxISPort.Text = currentAnalyzer.ISPort;
            checkBoxActive.Checked = currentAnalyzer.active;

            //getAnalyzerExams(currentAnalyzer.analyzerID, out listAnalyzerExams);
            sqlExams = "SELECT * FROM AnalyzerExam where analyzerID = " + currentAnalyzer.analyzerID.ToString();
            adapter = new SqlDataAdapter(sqlExams, cn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //PopulateDataGridView(currentAnalyzer.analyzerID);
            /*
            for (int i = 0; i < listAnalyzerExams.Count; i++)
            {
                dataGridView1.Rows.Add(listAnalyzerExams[i].analyzerExamID, listAnalyzerExams[i].ISExamCode, listAnalyzerExams[i].ISAnalystCode, listAnalyzerExams[i].ISExamCode, listAnalyzerExams[i].Active);
            }
            */
            cn.Close();

        }

        public void updateInsertBool(bool isInsert)
        {

            this.isInsert = isInsert;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (ctrl is TextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
            }
        }

        private void dataGridView1_DefaultValuesNeeded_1(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = "";
            e.Row.Cells[3].Value = "";
            e.Row.Cells[4].Value = "";
            e.Row.Cells[5].Value = 0;
            e.Row.Cells[6].Value = 1;
        }

        private void textBoxAPort_TextChanged(object sender, EventArgs e)
        {
            bool valid = int.TryParse(textBoxAPort.Text, out int value);
            textBoxAPort.ForeColor = valid ? Color.Black : Color.Red;
        }

        private void textBoxISPort_TextChanged(object sender, EventArgs e)
        {
            bool valid = int.TryParse(textBoxISPort.Text, out int value);
            textBoxISPort.ForeColor = valid ? Color.Black : Color.Red;
        }

        private void textBoxAIPAddress_TextChanged(object sender, EventArgs e)
        {
            textBoxAIPAddress.ForeColor = IsValidateIP(textBoxAIPAddress.Text) ? Color.Black : Color.Red;
        }

        private void textBoxISIPAddress_TextChanged(object sender, EventArgs e)
        {   
            textBoxISIPAddress.ForeColor = IsValidateIP(textBoxISIPAddress.Text) ? Color.Black : Color.Red;
        }
        public bool IsValidateIP(string Address)
        {
            //Match pattern for IP address    
            string Pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //Regular Expression object    
            Regex check = new Regex(Pattern);

            //check to make sure an ip address was provided    
            if (string.IsNullOrEmpty(Address))
                //returns false if IP is not provided    
                return false;
            else
                //Matching the pattern    
                return check.IsMatch(Address, 0);
        }
    }
}
