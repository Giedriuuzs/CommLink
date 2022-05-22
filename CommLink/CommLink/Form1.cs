using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using NHapi.Base.Parser;
using NHapi.Model.V231.Message;
using NHapi.Base.Util;
using System.Diagnostics;
using System.Xml;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace CommLink
{
    public partial class Form1 : Form
    {
        private Socket ServerSocket;
        private Socket ClientSocket;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CommLink"].ConnectionString;
        //string[] args;

        HubConnection connection;
        //string user = "GiedriusWinForm";
        //string message = "Hello from WinForm!";
        //static string signalRURL = "https://6f5c-87-247-108-4.eu.ngrok.io/ServerHub";
       // static string signalRURL = "https://localhost:7777/ServerHub";

        private byte[] buffer;
        private bool isClientClosed = true;
        private bool isServerClosed = true;
        private bool initial = true;
        public List<Analyzer> Analyzers = new List<Analyzer>();
        List<Analyzer> AnalyzersCopy = new List<Analyzer>();
        //List<Analyzer> ActiveAnalyzers = new List<Analyzer>();
        Socket[] serverArray;
        Thread[] threadArray;
        StringBuilder[] displayLogs;
        StringBuilder[] fileLogs;


        Form2 dialog;

        UpdateLogTextBox tb1 = new UpdateLogTextBox(updateTextBoxLog);
        UpdateDisplayLogTextBox tb2 = new UpdateDisplayLogTextBox(updateDisplayLog);
        UpdateInfoTextBox tb3 = new UpdateInfoTextBox(updateInfoLog);

        private int port;
        private IPAddress ip;

        private delegate void UpdateLogTextBox(string strMessage, RichTextBox textBox);
        private delegate void UpdateDisplayLogTextBox(string str, RichTextBox textBox);
        private delegate void UpdateInfoTextBox(string str, RichTextBox textBox);


        private readonly IHubContext<ClientHub> _clientHubContext;

        public Form1(IHubContext<ClientHub> clientHubContext)
        {
            _clientHubContext = clientHubContext;

            InitializeComponent();
            loadGridView();

        }

        public Form1()
        {


            //var builder = WebApplication.CreateBuilder(args);


            /*
            connection = new HubConnectionBuilder()
                .WithUrl(signalRURL)
                .WithAutomaticReconnect()
                .Build();

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                richTextBoxLogTest.AppendText("Client received: User: " + user + " Message: " + message + "\r\n");
            });

            connection.On("GiveAllActiveComms", () =>
             {
                 connection.InvokeAsync("ReceiveAllActiveComms", JsonConvert.SerializeObject(Analyzers));
             });

            connection.On("GiveCommLastData", (int analyzerID) =>
            {
                int index = Analyzers.FindIndex(a => a.analyzerID == analyzerID);
                string[] lines = displayLogs[index].ToString().Split("\r\n");
                var LstItems = lines.Skip(Math.Max(0, lines.Length - 15)).Take(15);
                List<string> linesList = new List<string>();
                foreach (var item in LstItems)
                {
                    if (item != "")
                    {
                        linesList.Add(item);
                    }
                }
                connection.InvokeAsync("ReceiveCommLastData", JsonConvert.SerializeObject(linesList));
            });

            connection.On("turnOnOffCommunication", (int analyzerID, bool onOff) =>
            {
                SqlCommand command;
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                string sql = "Update Analyzer set active = @active where AnalyzerID = @analyzerID";
                command = new SqlCommand(sql, cn);
                command.Parameters.AddWithValue("@active", onOff);
                command.Parameters.AddWithValue("@analyzerID", analyzerID);
                command.ExecuteNonQuery();
                cn.Close();
                loadGridView();
            });
            
            connection.Closed += async (error) =>
            {
                await connection.StartAsync();
                ActiveAnalyzers = getActiveAnalyzers(Analyzers);
            };
            
            connection.Reconnecting += error =>
            {
                Debug.Assert(connection.State == HubConnectionState.Reconnecting);
                Invoke(tb3, DateTime.Now.ToString() + " Connection with SignalR middleware was lost. Reconnecting...", InfoTextBox);
                // Notify users the connection was lost and the client is reconnecting.
                // Start queuing or dropping messages.

                return Task.CompletedTask;
            };

            connection.Reconnected += connectionId =>
            {
                Debug.Assert(connection.State == HubConnectionState.Connected);
                Invoke(tb3, DateTime.Now.ToString() + " Connection with SignalR middleware was reestablished.", InfoTextBox);
                // Notify users the connection was reestablished.
                // Start dequeuing messages queued while reconnecting if any.

                return Task.CompletedTask;
            };

            connection.Closed += error =>
            {
                Debug.Assert(connection.State == HubConnectionState.Disconnected);
                Invoke(tb3, DateTime.Now.ToString() + " Connection with SignalR middleware was not established. Please ensure the SignalR midlleware is available and restart the server.", InfoTextBox);
                // Notify users the connection has been closed or manually try to restart the connection.

                return Task.CompletedTask;
            };


            ConnectWithRetryAsync(connection);
            //connectToSignalR();


            //connection.InvokeAsync("SendMessage", user, message);
            //richTextBoxLogTest.AppendText("Client send: User: " + user + " Message: " + message);
            */
        }
        public List<string> GiveCommLastData(int analyzerID)
        {
            int index = Analyzers.FindIndex(a => a.analyzerID == analyzerID);
            string[] lines = displayLogs[index].ToString().Split("\r\n");
            var LstItems = lines.Skip(Math.Max(0, lines.Length - 15)).Take(15);
            List<string> linesList = new List<string>();
            foreach (var item in LstItems)
            {
                if (item != "")
                {
                    linesList.Add(item);
                }
            }
            return linesList;
        }

        public void turnOnOffCommunication(int analyzerID, bool onOff)
        {
                SqlCommand command;
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                string sql = "Update Analyzer set active = @active where AnalyzerID = @analyzerID";
                command = new SqlCommand(sql, cn);
                command.Parameters.AddWithValue("@active", onOff);
                command.Parameters.AddWithValue("@analyzerID", analyzerID);
                command.ExecuteNonQuery();
                cn.Close();
                loadGridView();
        }

        /*
        public async Task<bool> ConnectWithRetryAsync(HubConnection connection)
        {

            int i = 0;
            // Keep trying to until we can start or the token is canceled.
            while (true)
            {
                if (i==5)
                {
                    Task.Factory.StartNew(() =>
                    {
                        MessageBox.Show(DateTime.Now.ToString() + " Connection with SignalR middleware was not established. Please ensure the SignalR midlleware is available and restart the server.", "Warning!");
                    });
                    Invoke(tb3, DateTime.Now.ToString() + " Connection with SignalR middleware was not established. Please ensure the SignalR midlleware is available and restart the server.", InfoTextBox);
                    return true;
                }
                i++;
                try
                {
                    await connection.StartAsync();
                    Debug.Assert(connection.State == HubConnectionState.Connected);
                    Invoke(tb3, DateTime.Now.ToString() + " SignalR middleware connected.", InfoTextBox);
                    return true;
                }
                catch
                {
                    Invoke(tb3, DateTime.Now.ToString() + " Connection with SignalR middleware was not established. Reconnecting...", InfoTextBox);
                    // Failed to connect, trying again in 5000 ms.
                    Debug.Assert(connection.State == HubConnectionState.Disconnected);
                    await Task.Delay(5000);
                }
            }
        }
        */
        /*
        private async void connectToSignalR()
        {
            try
            {
                await connection.StartAsync();
                ActiveAnalyzers = getActiveAnalyzers(Analyzers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        */
        private List<Analyzer> getActiveAnalyzers(List<Analyzer> analyzers)
        {
            
            List<Analyzer> activeAnalyzers = new List<Analyzer>();
            foreach (var analyzer in analyzers)
            {
                if (analyzer.active)
                {
                    activeAnalyzers.Add(analyzer);
                }
            }
            return activeAnalyzers;
        }

        private void getAnalyzersFromDB(out List<Analyzer> analyzers)
        {
            
            SqlConnection cn;
            SqlCommand command;
            SqlDataReader reader;
            string sql;
            analyzers = new List<Analyzer>();
            int i = 0;

            cn = new SqlConnection(connectionString);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Problem with database connection! Recheck CommLink.dll.config connectionStrings.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }


            sql = "Select * from Analyzer where visible = 1";
            command = new SqlCommand(sql, cn);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Analyzer a = new Analyzer();
                a.analyzerID = (int)reader["AnalyzerID"];
                a.analyzerCode = (string)reader["AnalyzerCode"];
                a.analyzerProtocolName = (string)reader["AnalyzerProtocolName"];
                a.analyzerType = (string)reader["AnalyzerType"];
                a.analyzerTCPIP = (string)reader["AnalyzerTCPIP"];
                a.analyzerPort = (string)reader["AnalyzerTCPIPPORT"];
                a.ISCode = (string)reader["ISCode"];
                a.ISProtocolName = (string)reader["ISProtocolName"];
                a.ISType = (string)reader["ISType"];
                a.ISTCPIP = (string)reader["ISTCPIP"];
                a.ISPort = (string)reader["ISTCPIPPORT"];
                a.visible = (bool)reader["Visible"];
                a.active = (bool)reader["Active"];
                if (initial)
                {
                    a.listening = false;
                }
                else
                {
                    if (i < AnalyzersCopy.Count)
                    {
                        a.listening = AnalyzersCopy[i].listening;
                    }
                    else
                    {
                        a.listening = false;
                    }
                }
                analyzers.Add(a);
                i++;
            }
            cn.Close();
        }

        private void getAnalyzerExams(int analyzerID, out List<AnalyzerExam> listExams)
        {
            //string connectionString;
            SqlConnection cn;
            SqlCommand command;
            SqlDataReader reader;
            string sql;
            listExams = new List<AnalyzerExam>();


            cn = new SqlConnection(connectionString);
            cn.Open();

            sql = "Select * from AnalyzerExam where analyzerID = " + analyzerID.ToString();
            command = new SqlCommand(sql, cn);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                AnalyzerExam a = new AnalyzerExam();
                a.analyzerExamID = (int)reader["AnalyzerExamID"];
                a.analyzerID = (int)reader["AnalyzerID"];
                a.ISExamCode = (string)reader["ISExamCode"];
                a.ISAnalystCode = (string)reader["ISAnalystCode"];
                a.AnalyzerExamCode = (string)reader["AnalyzerExamCode"];
                a.SendToAnalyzer = (bool)reader["SendToAnalyzer"];
                a.Active = (bool)reader["Active"];
                listExams.Add(a);
            }
            cn.Close();
        }
        private static void updateTextBoxLog(string data, RichTextBox box)
        {
            box.Text += data + "\r\n";
        }

        private static void updateDisplayLog(string data, RichTextBox box)
        {
            box.Text = (data + "\r\n");
        }
        private static void updateInfoLog(string data, RichTextBox box)
        {
            box.Text += (data + "\r\n");
        }
        private void CommLink_Load(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {

                    if (radioButton1.Checked == true)
                    {
                        buttonConnectTest.Text = "Connect";
                        buttonDisconnectTest.Text = "Disconnect";
                        labelConnectedDisconectedTest.Text = "Disconected";
                        disconnect();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        buttonConnectTest.Text = "Start";
                        buttonDisconnectTest.Text = "Stop";
                        labelConnectedDisconectedTest.Text = "Offline";
                        disconnect();

                    }
                }
            }
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

        private void buttonConnectTest_Click(object sender, EventArgs e)
        {

            if (IsValidateIP(textBox1.Text))
            {
                ip = IPAddress.Parse(textBox1.Text);
            }
            else 
            {
                Invoke(tb1, DateTime.Now.ToString() + " IP address is incorrect", richTextBoxLogTest);
                return;
            }

            if (int.TryParse(textBox2.Text, out port))
            {

            } else
            {
                Invoke(tb1, DateTime.Now.ToString() + " Port is incorrect", richTextBoxLogTest);
                return;
            }
            //MessageBox.Show(ip.ToString()+":"+port.ToString(),"");

            if (radioButton1.Checked == true) //Client
            {
                try
                {
                    ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    var endPoint = new IPEndPoint(ip, port);
                    ClientSocket.BeginConnect(endPoint, ConnectCallback, null);
                    isClientClosed = false;
                }
                catch (SocketException ex)
                {
                    this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
                catch (ObjectDisposedException ex)
                {
                    this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
            }
            else if (radioButton2.Checked == true) //Server
            {
                try
                {
                    ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ServerSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                    ServerSocket.Listen(1);
                    ServerSocket.BeginAccept(AcceptCallBack, null);
                    UpdateButtonsStates(true);
                    //labelConnectedDisconectedTest.Text = "Online";
                    isServerClosed = false;
                    Invoke(tb1, DateTime.Now.ToString() + " Waiting for connection...", richTextBoxLogTest);
                }
                catch (SocketException ex)
                {
                    this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
                catch (ObjectDisposedException ex)
                {
                    this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
            }
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndConnect(ar);
                buffer = new byte[ClientSocket.ReceiveBufferSize];
                UpdateButtonsStates(true);
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
                Invoke(tb1, DateTime.Now.ToString() + " Client connected.", richTextBoxLogTest);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
        }

        private void ConnectCallback2(IAsyncResult ar)
        {

            StateObject so = (StateObject)ar.AsyncState;
            if (!Analyzers[so.index].active)
            { return; }
                try
            {
                Socket client = so.workSocket;
                client.EndConnect(ar);
                byte[] buffer = new byte[client.ReceiveBufferSize];
                so.buffer = buffer;
                //UpdateButtonsStates(true);
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback2, so);
                string sendString = DateTime.Now.ToString() + " Client connected. \r\n";
                displayLogs[so.index].Append(sendString);
                if (_clientHubContext != null)
                {
                    _clientHubContext.Clients.All.SendAsync("newData", sendString, so.analyzer.analyzerID);
                    //connection.InvokeAsync("newData", sendString, so.analyzer.analyzerID);
                }
                fileLogs[so.index].Append(sendString);
                if (dataGridView1.CurrentCell != null)
                {
                    if (so.index == dataGridView1.CurrentCell.RowIndex)
                    {
                        Invoke(tb2, displayLogs[so.index].ToString(), richTextBoxDisplayLog);
                        //richTextBoxDisplayLog.Text = displayLogs[dataGridView1.CurrentCell.RowIndex].ToString();
                    }
                }

            }
            catch (SocketException ex)
            {
                //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                string sendString = DateTime.Now.ToString() + " " + ex.Message + "\r\n";
                displayLogs[so.index].Append(sendString);
                if (_clientHubContext != null)
                {
                    _clientHubContext.Clients.All.SendAsync("newData", sendString, so.analyzer.analyzerID);
                    //connection.InvokeAsync("newData", sendString, so.analyzer.analyzerID);
                }
                fileLogs[so.index].Append(sendString);
                if (dataGridView1.CurrentCell != null)
                {
                    if (so.index == dataGridView1.CurrentCell.RowIndex)
                    {
                        Invoke(tb2, displayLogs[so.index].ToString(), richTextBoxDisplayLog);
                        //richTextBoxDisplayLog.Text = displayLogs[dataGridView1.CurrentCell.RowIndex].ToString();
                    }
                }

                    Task.Delay(120000).Wait();
                    //Task.Delay(2000).Wait();
                    so.workSocket.Close();
                    //so.workSocket.Shutdown(SocketShutdown.Both);
                    var endPoint = new IPEndPoint(IPAddress.Parse(so.analyzer.analyzerTCPIP), int.Parse(so.analyzer.analyzerPort));
                    Socket newWorkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    so.workSocket = newWorkSocket;
                    serverArray[so.index] = newWorkSocket;
                    newWorkSocket.BeginConnect(endPoint, ConnectCallback2, so);

            }
            catch (ObjectDisposedException ex)
            {
                //his.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
        }


        private void AcceptCallBack(IAsyncResult ar)
        {
            try
            {
                ClientSocket = ServerSocket.EndAccept(ar);
                buffer = new byte[ClientSocket.ReceiveBufferSize];

                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
                Invoke(tb1, DateTime.Now.ToString() + " Client connected.", richTextBoxLogTest);
                isClientClosed = false;
                ServerSocket.BeginAccept(AcceptCallBack, null);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                //this.Invoke(tb1, ex.Message, richTextBoxLogTest);
            }
        }

        private void AcceptCallBack2(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState; //added
            try
            {
                Socket server = so.workSocket;
                Socket client = server.EndAccept(ar);
                StateObject so2 = new StateObject();
                so2.listAnalyzerExams = so.listAnalyzerExams;
                so2.workSocket = client;
                so2.index = so.index;
                so2.analyzer = so.analyzer;
                //Socket server = (Socket)ar.AsyncState;
                //Socket client = server.EndAccept(ar);
                byte[] buffer = new byte[client.ReceiveBufferSize];
                so2.buffer = buffer;
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback2, so2);
                string sendString = DateTime.Now.ToString() + " Client connected. \r\n";
                displayLogs[so.index].Append(sendString);
                if (_clientHubContext != null)
                {
                    _clientHubContext.Clients.All.SendAsync("newData", sendString, so.analyzer.analyzerID);
                    //connection.InvokeAsync("newData", sendString, so.analyzer.analyzerID);
                }
                fileLogs[so.index].Append(sendString);
                if (dataGridView1.CurrentCell != null)
                {
                    if (so.index == dataGridView1.CurrentCell.RowIndex)
                    {
                        Invoke(tb2, displayLogs[so.index].ToString(), richTextBoxDisplayLog);
                    }
                }
                //isClientClosed = false;
                server.BeginAccept(AcceptCallBack2, so);
            }
            catch (SocketException ex)
            {
                //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                //this.Invoke(tb1, ex.Message, richTextBoxLogTest);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                ClientSocket.EndSend(AR);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
        }
        private void SendCallback2(IAsyncResult AR)
        {
            StateObject so = (StateObject)AR.AsyncState;
            try
            {
                so.workSocket.EndSend(AR);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                // Socket exception will raise here when client closes, as this sample does not
                // demonstrate graceful disconnects for the sake of simplicity.
                int received = ClientSocket.EndReceive(AR);

                if (received == 0)
                {
                    if (radioButton1.Checked) //Client
                    {
                        Invoke(tb1, DateTime.Now.ToString() + " Server disconnected.", richTextBoxLogTest);
                        UpdateButtonsStates(false);
                    }
                    if (radioButton2.Checked) //Server
                    {
                        Invoke(tb1, DateTime.Now.ToString() + " Client disconnected.", richTextBoxLogTest);
                    }
                    return;
                }

                // The received data is encoded
                byte[] recBuf = new byte[received];
                Array.Copy(buffer, recBuf, received);
                string text = Encoding.ASCII.GetString(recBuf);
                Invoke(tb1, DateTime.Now.ToString() + " Received: " + text, richTextBoxLogTest);

                // Start receiving data again.
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                //this.Invoke(tb1, ex.Message, richTextBoxLogTest);
            }
        }

        private void ReceiveCallback2(IAsyncResult AR)
        {
            StateObject so = (StateObject)AR.AsyncState;
            Socket s = so.workSocket;
            // byte[] buffer;
            try
            {
                int received = s.EndReceive(AR);


                byte[] recBuf = new byte[received];
                Array.Copy(so.buffer, recBuf, received);
                PipeParser parser = new PipeParser();
                Terser terser;

                //displayLogs[so.index].Append(so.START_OF_BLOCK);
                so.sb += (Encoding.UTF8.GetString(recBuf, 0, received));
                var start = so.sb.IndexOf(so.START_OF_BLOCK);

                if (start >= 0)
                {
                    var end = so.sb.IndexOf(so.END_OF_BLOCK);
                    if (end >= start)
                    {
                        var hl7string = so.sb.Substring(start + 1, end - start);
                        var hl7message = parser.Parse(hl7string);
                        if (hl7message.GetStructureName() == "ORU_R01")
                        {
                            var oruMsg = hl7message as ORU_R01;
                            /*
                            foreach (var observation in oruMsg.GetPATIENT_RESULT().ORDER_OBSERVATIONs)
                            {
                                foreach (var item in observation.OBSERVATIONs)
                                {
                                    item.OBX.GetObservationValue();
                                } 
                            }
                            */
                            int i, j, k;
                            i = j = k = 0;
                            List<Results> resultsList = new List<Results>();
                            terser = new Terser(hl7message);
                            foreach (var patient in oruMsg.PATIENT_RESULTs)
                            {
                                foreach (var orderObservation in patient.ORDER_OBSERVATIONs)
                                {
                                    foreach (var observation in orderObservation.OBSERVATIONs)
                                    {
                                        Results result = new Results();
                                        result.barcode = terser.Get("/.ORDER_OBSERVATION(" + j.ToString() + ")/OBR-3");
                                        result.exam = "";
                                        result.analyst = terser.Get("/.ORDER_OBSERVATION(" + j.ToString() + ")/OBSERVATION(" + i.ToString() + ")/OBX-3-2");
                                        result.result = terser.Get("/.ORDER_OBSERVATION(" + j.ToString() + ")/OBSERVATION(" + i.ToString() + ")/OBX-5");
                                        result.units = terser.Get("/.ORDER_OBSERVATION(" + j.ToString() + ")/OBSERVATION(" + i.ToString() + ")/OBX-6");
                                        result.referenceRange = terser.Get("/.ORDER_OBSERVATION(" + j.ToString() + ")/OBSERVATION(" + i.ToString() + ")/OBX-7");

                                        resultsList.Add(result);
                                        i++;
                                    }

                                    j++;
                                }
                                k++;
                            }
                            // Varies[] results = oruMsg.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION().OBX.GetObservationValue();
                            // ST st = oruMsg.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION().OBX.ObservationIdentifier.Text;
                            /*
                            foreach (var result in results)
                            {
                                result.Data.ToString();
                            }
                            */
                            taskWriteXml(resultsList, so.listAnalyzerExams);

                            string sendString = DateTime.Now.ToString() + " Received results. Sample number: " + resultsList[0].barcode + "\r\n";
                            displayLogs[so.index].Append(sendString);
                            if (_clientHubContext != null)
                            {
                                _clientHubContext.Clients.All.SendAsync("newData", sendString, so.analyzer.analyzerID);
                                //connection.InvokeAsync("newData", sendString, so.analyzer.analyzerID);
                            }

                            fileLogs[so.index].Append(DateTime.Now.ToString() + " Receive: " + hl7string + "\r\n");
                            if (dataGridView1.CurrentCell != null)
                            {
                                if (so.index == dataGridView1.CurrentCell.RowIndex)
                                {
                                    Invoke(tb2, displayLogs[so.index].ToString(), richTextBoxDisplayLog);
                                }
                            }
                            var ackMessage = MessageFactory.CreateMessage("ACK", hl7message);

                            var ackMessageString = so.START_OF_BLOCK + parser.Encode(ackMessage) + so.END_OF_BLOCK + so.CARRIAGE_RETURN;
                            var sendData = Encoding.UTF8.GetBytes(ackMessageString);
                            so.workSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback2, so);
                            so.sb = "";
                            fileLogs[so.index].Append(DateTime.Now.ToString() + " Transmit: " + ackMessageString + "\r\n");
                            //Invoke(tb1, DateTime.Now.ToString() + " Send: " + richTextBoxInputMessage.Text, richTextBoxLogTest);
                        }
                    }
                }
                if (so.sb.IndexOf(so.STX) >= 0)
                {
                    var sendData = Encoding.UTF8.GetBytes(so.ACK.ToString());
                    so.workSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback2, so);
                    so.sb = null;
                }
                if (received != 0)
                {
                    if (Analyzers[so.index].active)
                    {
                        s.BeginReceive(so.buffer, 0, so.buffer.Length, SocketFlags.None, ReceiveCallback2, so);
                    }
                    else s.Close();
                }
                else
                {
                    //Invoke(tb2, DateTime.Now.ToString() + " Client disconnected.\r\n", richTextBoxDisplayLog);
                   
                    if (so.analyzer.analyzerType == "Client")
                    {
                        string sendString = DateTime.Now.ToString() + " Connection with server was lost.\r\n";
                        displayLogs[so.index].Append(sendString);
                        if (_clientHubContext != null)
                        {
                            _clientHubContext.Clients.All.SendAsync("newData", sendString, so.analyzer.analyzerID);
                            //connection.InvokeAsync("newData", sendString, so.analyzer.analyzerID);
                        }

                        fileLogs[so.index].Append(sendString);
                        if (dataGridView1.CurrentCell != null)
                        {
                            if (so.index == dataGridView1.CurrentCell.RowIndex)
                            {
                                Invoke(tb2, displayLogs[so.index].ToString(), richTextBoxDisplayLog);
                            }
                        }

                        so.workSocket.Close();
                        //so.workSocket.Shutdown(SocketShutdown.Both);
                        var endPoint = new IPEndPoint(IPAddress.Parse(so.analyzer.analyzerTCPIP), int.Parse(so.analyzer.analyzerPort));
                        Socket newWorkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        so.workSocket = newWorkSocket;
                        serverArray[so.index] = newWorkSocket;
                        newWorkSocket.BeginConnect(endPoint, ConnectCallback2, so);
                    }
                    else if (so.analyzer.analyzerType =="Server")
                    {
                        string sendString = DateTime.Now.ToString() + " Client disconnected.\r\n";
                        displayLogs[so.index].Append(sendString);
                        if (_clientHubContext != null)
                        {
                            _clientHubContext.Clients.All.SendAsync("newData", sendString, so.analyzer.analyzerID);
                            //connection.InvokeAsync("newData", sendString, so.analyzer.analyzerID);
                        }

                        fileLogs[so.index].Append(sendString);
                        if (dataGridView1.CurrentCell != null)
                        {
                            if (so.index == dataGridView1.CurrentCell.RowIndex)
                            {
                                Invoke(tb2, displayLogs[so.index].ToString(), richTextBoxDisplayLog);
                            }
                        }
                    }
                }

                    


            }
            catch (SocketException ex)
            {
                ///this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }

        }

        private static void taskWriteXml(List<Results> resultsList, List<AnalyzerExam> exams)
        {
            foreach (var result in resultsList)
            {
                foreach (var exam in exams)
                {
                    if (result.analyst == exam.AnalyzerExamCode)
                    {
                        result.exam = exam.ISExamCode;
                        result.analyst = exam.ISAnalystCode;
                    }
                }
            }

            string directoryPath = Directory.GetCurrentDirectory() + @"\SendToHostXmls\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string filePath = directoryPath + resultsList[0].barcode + ".xml";
            int i = 0;
            while (File.Exists(filePath))
            {
                i++;
                filePath = directoryPath + resultsList[0].barcode + "_" + i.ToString() + ".xml";
            }

            var sts = new XmlWriterSettings()
            {
                Indent = true,
            };

            XmlWriter writer = XmlWriter.Create(filePath, sts);

            writer.WriteStartDocument();

            writer.WriteStartElement("root");

            writer.WriteStartElement("barcode");
            writer.WriteValue(resultsList[0].barcode);
            writer.WriteEndElement();

            writer.WriteStartElement("results");

            foreach (var item in resultsList)
            {
                writer.WriteStartElement("analyst");

                writer.WriteStartElement("examCode");
                writer.WriteValue(item.exam);
                writer.WriteEndElement();

                writer.WriteStartElement("analystCode");
                writer.WriteValue(item.analyst);
                writer.WriteEndElement();

                writer.WriteStartElement("result");
                writer.WriteValue(item.result);
                writer.WriteEndElement();

                writer.WriteStartElement("units");
                writer.WriteValue(item.units);
                writer.WriteEndElement();

                writer.WriteStartElement("n.v.");
                writer.WriteValue(item.referenceRange);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void buttonDisconnectTest_Click(object sender, EventArgs e)
        {
            disconnect();
        }

        private void UpdateButtonsStates(bool toggle)
        {
            Invoke((Action)delegate
            {
                buttonSendTest.Enabled = toggle;
                buttonDisconnectTest.Enabled = toggle;
                buttonConnectTest.Enabled = !toggle;
                if (toggle && radioButton1.Checked)
                {
                    labelConnectedDisconectedTest.Text = "Connected";
                }
                else if (toggle && radioButton2.Checked)
                {
                    labelConnectedDisconectedTest.Text = "Online";
                }
                else if (!toggle && radioButton1.Checked)
                {
                    labelConnectedDisconectedTest.Text = "Disconnected";
                }
                else if (!toggle && radioButton2.Checked)
                {
                    labelConnectedDisconectedTest.Text = "Offline";
                }
            });
        }
        private void disconnect()
        {
            try
            {
                if (!isClientClosed)
                {
                    ClientSocket.Close();
                    this.Invoke(tb1, DateTime.Now.ToString() + " Client disconnected.", richTextBoxLogTest);
                    isClientClosed = true;
                    //ClientSocket = null;
                }
                if (!isServerClosed)
                {
                    ServerSocket.Close();
                    this.Invoke(tb1, DateTime.Now.ToString() + " Server stopped.", richTextBoxLogTest);
                    isServerClosed = true;
                    //ServerSocket = null;
                }
                // ServerSocket.Close();
                UpdateButtonsStates(false);
                //labelConnectedDisconectedTest.Text = "Offline";
                // this.Invoke(tb1, "Server stopped.", richTextBoxLogTest);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
        }
        private void richTextBoxLogTest_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLogTest.SelectionStart = richTextBoxLogTest.Text.Length;
            richTextBoxLogTest.ScrollToCaret();
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            if (richTextBoxLogTest.Text == "")
            {
                return;
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            string filename = "";

            saveDialog.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            saveDialog.DefaultExt = "*.txt";
            saveDialog.FilterIndex = 2;
            saveDialog.Title = "Save log";

            DialogResult show = saveDialog.ShowDialog();
            if (show == DialogResult.OK)
            {
                filename = saveDialog.FileName;
            }
            else
            {
                return;
            }

            RichTextBoxStreamType stream_type;
            if (saveDialog.FilterIndex == 2)
            {
                stream_type = RichTextBoxStreamType.PlainText;
            }
            else
            {
                stream_type = RichTextBoxStreamType.RichText;
            }
            //richTextBoxLogTest.SaveFile(textBoxSave.FileName);

            richTextBoxLogTest.SaveFile(filename, stream_type);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLogTest.Clear();
        }

        private void buttonSendTest_Click(object sender, EventArgs e)
        {
            try
            {
                var sendData = Encoding.ASCII.GetBytes(richTextBoxInputMessage.Text);
                ClientSocket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, SendCallback, null);
                Invoke(tb1, DateTime.Now.ToString() + " Send: " + richTextBoxInputMessage.Text, richTextBoxLogTest);
            }
            catch (SocketException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
            catch (ObjectDisposedException ex)
            {
                this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
            }
        }

        private void buttonAddServer_Click(object sender, EventArgs e)
        {
            dialog = new Form2();
            dialog.updateInsertBool(true);
            dialog.ShowDialog();
            /*
            getAnalyzersFromDB(out Analyzers);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Analyzers.Count; i++)
            {
                //dataGridView1.Items.Add(Analyzers[i].analyzerCode);
                dataGridView1.Rows.Add(Analyzers[i].analyzerID, Analyzers[i].analyzerCode, Analyzers[i].analyzerPort, Analyzers[i].active);
            }
            */
        }

        private void buttonSetupServer_Click(object sender, EventArgs e)
        {
            dialog = new Form2();
            dialog.updateInsertBool(false);
            dialog.getAnalyzerInfo((int)dataGridView1.SelectedRows[0].Cells[0].Value);
            dialog.ShowDialog();
        }

        private void buttonDeleteServer_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You really want to delete " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                SqlConnection cn;
                SqlCommand command;
                string sql;


                cn = new SqlConnection(connectionString);
                cn.Open();

                sql = "Update Analyzer set visible = 0 where AnalyzerID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                command = new SqlCommand(sql, cn);
                command.ExecuteNonQuery();
                cn.Close();


                //kill threads!!!!
                if (serverArray[dataGridView1.SelectedRows[0].Index] != null)
                {
                    serverArray[dataGridView1.SelectedRows[0].Index].Close();
                }

                //serverArray[index].Dispose();
                if (threadArray[dataGridView1.SelectedRows[0].Index]!=null)
                {
                    threadArray[dataGridView1.SelectedRows[0].Index].Join();
                }

                loadGridView();
            }
        }
        public void listenThread(Socket socket, int threadNo, Analyzer analyzer)
        {
            List<AnalyzerExam> listExams = new List<AnalyzerExam>();
            StateObject state = new StateObject();
            getAnalyzerExams(analyzer.analyzerID, out listExams);
            state.listAnalyzerExams = listExams;
            state.analyzer = analyzer;
            state.index = threadNo;
            state.workSocket = socket;
            if (analyzer.analyzerType == "Client")
            {
                try
                {
                    var endPoint = new IPEndPoint(IPAddress.Parse(analyzer.analyzerTCPIP), int.Parse(analyzer.analyzerPort));
                    state.workSocket.BeginConnect(endPoint, ConnectCallback2, state);
                    analyzer.listening = true;
                }
                catch (SocketException ex)
                {
                    //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
                catch (ObjectDisposedException ex)
                {
                    //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
            }
            else if (analyzer.analyzerType == "Server")
            {
                try
                {

                    //socket.Listen(100);
                    //socket..BeginAccept(AcceptCallBack2, state);

                    state.workSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(analyzer.analyzerPort)));
                    state.workSocket.Listen(100);
                    state.workSocket.BeginAccept(AcceptCallBack2, state);
                    analyzer.listening = true;
                    string sendString = DateTime.Now.ToString() + " Waiting for connection...\r\n";
                    displayLogs[threadNo].Append(sendString);
                    if (_clientHubContext !=null)
                    {
                        _clientHubContext.Clients.All.SendAsync("newData", sendString, analyzer.analyzerID);
                        //connection.InvokeAsync("newData", sendString, analyzer.analyzerID);
                    }
                    fileLogs[threadNo].Append(sendString);
                    if (dataGridView1.CurrentCell != null)
                    {
                        if (threadNo == dataGridView1.CurrentCell.RowIndex)
                        {
                            Invoke(tb2, displayLogs[threadNo].ToString(), richTextBoxDisplayLog);
                        }
                    }
                    //sock.BeginAccept()
                    //UpdateButtonsStates(true);
                    //labelConnectedDisconectedTest.Text = "Online";
                    //isServerClosed = false;
                    //Invoke(tb1, DateTime.Now.ToString() + " Waiting for connection...", richTextBoxLogTest);
                }
                catch (SocketException ex)
                {
                    //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
                catch (ObjectDisposedException ex)
                {
                    //this.Invoke(tb1, DateTime.Now.ToString() + " " + ex.Message, richTextBoxLogTest);
                }
            }
        }
        public void loadGridView()
        {
            try
            {
                if (initial)
                {
                    dataGridView1.Rows.Clear();
                }
                else if (!initial)
                {
                    dataGridView1.Invoke(new Action(delegate ()
                    {
                        dataGridView1.Rows.Clear();
                    }));
                }

            }
            catch (Exception ex)
            {
            }

            getAnalyzersFromDB(out Analyzers);
            AnalyzersCopy = new List<Analyzer>(Analyzers);
            //ActiveAnalyzers = getActiveAnalyzers(Analyzers);
            //serversList = new Socket[Analyzers.Count];
            if (initial)
            {
                serverArray = new Socket[Analyzers.Count];
                threadArray = new Thread[Analyzers.Count];
                displayLogs = new StringBuilder[Analyzers.Count];
                fileLogs = new StringBuilder[Analyzers.Count];
                // states = new StateObject[Analyzers.Count];
            }
            else if (!initial)
            {
                Array.Resize<Socket>(ref serverArray, Analyzers.Count);
                Array.Resize<Thread>(ref threadArray, Analyzers.Count);
                Array.Resize<StringBuilder>(ref displayLogs, Analyzers.Count);
                Array.Resize<StringBuilder>(ref fileLogs, Analyzers.Count);
                //Array.Resize<StateObject>(ref states, Analyzers.Count);
            }

            for (int i = 0; i < Analyzers.Count; i++)
            {
                var index = i;
                if (displayLogs[i] == null)
                {
                    displayLogs[i] = new StringBuilder();
                }
                if (fileLogs[i] == null)
                {
                    fileLogs[i] = new StringBuilder();
                }
                if (initial)
                {
                    dataGridView1.Rows.Add(Analyzers[index].analyzerID, Analyzers[index].analyzerCode, Analyzers[index].analyzerTCPIP + ":" + Analyzers[index].analyzerPort, Analyzers[index].active);
                }
                else if (!initial)
                {
                    if (_clientHubContext != null)
                    {
                        _clientHubContext.Clients.All.SendAsync("turnOnOffClient", Analyzers[index].analyzerID, Analyzers[index].active);
                    }
                    dataGridView1.Invoke(new Action(delegate () {
                        dataGridView1.Rows.Add(Analyzers[index].analyzerID, Analyzers[index].analyzerCode, Analyzers[index].analyzerTCPIP + ":" + Analyzers[index].analyzerPort, Analyzers[index].active);
                    }));
                }

                //dataGridView1.Items.Add(Analyzers[i].analyzerCode);


                if (Analyzers[index].active == true && Analyzers[index].listening == false)
                {

                    //serversList.Add(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
                    //serversList[i].Bind(new IPEndPoint(IPAddress.Any, int.Parse(Analyzers[i].analyzerPort)));

                    serverArray[index] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    /*
                    var endpoint = new IPEndPoint(IPAddress.Parse(Analyzers[i].analyzerTCPIP), int.Parse(Analyzers[i].analyzerPort));
                    if (Analyzers[i].analyzerType == "Server")
                    {
                       serverArray[index].Bind(new IPEndPoint(IPAddress.Any, endpoint.Port)); 
                    }
                    else if (Analyzers[i].analyzerType == "Client")
                    {

                    }
                    */
                    //serverArray[index].Bind(new IPEndPoint(IPAddress.Any, int.Parse(Analyzers[i].analyzerPort))); 
                    //Thread thread = new Thread(listenThread);
                    threadArray[index] = new Thread(() => listenThread(serverArray[index], index, Analyzers[index]));
                    threadArray[index].Start();
                    //Analyzers[index].listening = true;
                }
                else if ((Analyzers[index].active == false && Analyzers[index].listening == true) || (Analyzers[index].analyzerType != "Server" && Analyzers[index].analyzerType != "Client"))
                {
                    if (serverArray[index] != null)
                    {
                        serverArray[index].Close();
                        // serverArray[index].Dispose();
                        threadArray[index].Join();
                    }

                    Analyzers[index].listening = false;

                    string sendString = DateTime.Now.ToString() + " Connections closed! \r\n";
                    displayLogs[index].Append(sendString);
                    if (_clientHubContext != null)
                    {
                        //HubContext.SendAsync
                        _clientHubContext.Clients.All.SendAsync("newData", sendString, Analyzers[index].analyzerID);
                        //connection.InvokeAsync("newData", sendString, Analyzers[index].analyzerID);
                    }
                    fileLogs[index].Append(sendString);
                    if (dataGridView1.CurrentCell != null)
                    {
                        if (index == dataGridView1.CurrentCell.RowIndex)
                        {
                            Invoke(tb2, displayLogs[index].ToString(), richTextBoxDisplayLog);
                        }
                    }
                }
            }
            /*
            if (initial)
            {
                dataGridView1.CurrentCell = dataGridView1[1, 0];
            }
            */
            if (_clientHubContext != null)
            { 
                _clientHubContext.Clients.All.SendAsync("ReceiveAllActiveComms", JsonConvert.SerializeObject(Analyzers));
            }
                

            initial = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.Invoke(tb2, displayLogs[dataGridView1.CurrentCell.RowIndex].ToString(), richTextBoxDisplayLog);
            //richTextBoxDisplayLog.Text = displayLogs[dataGridView1.CurrentCell.RowIndex].ToString();
            //richTextBoxDisplayLog.Invoke(new Action(() => richTextBoxDisplayLog.Text = displayLogs[dataGridView1.CurrentCell.RowIndex].ToString()));
        }

        private void buttonSaveLogServer_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Logs\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + Analyzers[dataGridView1.CurrentCell.RowIndex].analyzerCode + ".txt";
            File.AppendAllText(path, fileLogs[dataGridView1.CurrentCell.RowIndex].ToString());
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", path);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = IsValidateIP(textBox1.Text) ? Color.Black : Color.Red;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool valid = int.TryParse(textBox2.Text, out int value);
            textBox2.ForeColor = valid ? Color.Black : Color.Red;
        }

        private void labelConnectedDisconectedTest_TextChanged(object sender, EventArgs e)
        {
            bool valid = false;
            if (labelConnectedDisconectedTest.Text == "Connected" || labelConnectedDisconectedTest.Text == "Online")
            {
                valid = true;
            }
            else if (labelConnectedDisconectedTest.Text == "Disconnected" || labelConnectedDisconectedTest.Text == "Offline")
            {
                valid = false;
            }
            labelConnectedDisconectedTest.ForeColor = valid ? Color.Green : Color.Red;
        }
    }
}