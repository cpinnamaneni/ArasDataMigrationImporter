using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aras.IOM;
using System.Web;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace ArasDataMigrationImporter
{
    public partial class TextFileToAras : UserControl
    {
        #region Golbal Variables
        //List of Global Variablles
        static System.IO.StreamWriter log_file;
        static System.IO.StreamWriter tech_log;
        static System.IO.StreamWriter error_File;


        static bool is_error = false;

        //static Item ItemtypeObject = null;

        Item parentItemtypeObject = null;
        Item childItemtypeObject = null;


        static Innovator inn = null;
        static bool hasNative = false;
        static int indexofNativeFile = 0;
        static bool LineHasError = false;

        //Configuration data
        String ParentType = null,
               ChildType = null,
               //ParentStructure = null,
               //ChildStructure = null,
               ParentChildRelation = null,
               ParentFileRelation = null,
               ChildFileRelation = null,
               FilesFolder = null,
               delimiter = null,
               //Delete_Files_OnRevise = null,
               dateformat = null
            //null_properties = null,
            //efault_properties = null
            ;

        bool Delete_Files_OnRevise_bool = false;

        HttpServerConnection conn = null;
        #endregion

        public TextFileToAras()
        {
            InitializeComponent();
            updateLoginDialog();
        }

        public void updateLog(String logData) // update all the Log files...
        {
            log_file.WriteLine(logData);
            updateStatusBox(logData);
            tech_log.WriteLine(logData);
        }

        public void updateStatusBox(String stringdata)
        {

            if (statusTextBox.InvokeRequired == true)
                statusTextBox.Invoke((MethodInvoker)delegate {

                    statusTextBox.AppendText(stringdata);
                    statusTextBox.ScrollToCaret();
                    statusTextBox.AppendText("\n");
                });

            else
            {
                //statusTextBox.Text = "Invoke was NOT needed";

                statusTextBox.AppendText("\n");
                statusTextBox.AppendText(stringdata);
            }
        }

        public void updateTechLog(String logData)
        {
            tech_log.WriteLine(logData);
        }

        private void updateLoginDialog()
        {
            toolStripStatusLabel1.Text = "";
            string value = ConfigurationManager.AppSettings["url"];
            urlBox.Text = value;
            string Userid = ConfigurationManager.AppSettings["userid"];
            userTextBox.Text = Userid;
            string Database = ConfigurationManager.AppSettings["database"];
            dbList.Text = Database;


            //ConfigurationManager.OpenExeConfiguration();
        }
        internal static HttpServerConnection login(string arasURL, string dataBaseName, string userid, string userPass)
        {
            String[] urlarray = arasURL.Split('/');

            String protocal = urlarray[0];
            String ServerName = urlarray[2];
            String Site = urlarray[3];

            String url = @protocal + "//" + ServerName + "/" + Site;
            //String url = ArasURL;
            String db = dataBaseName;
            String user = userid;
            String password = userPass;
            HttpServerConnection conn = IomFactory.CreateHttpServerConnection(url, db, user, password);
            Item login_result = conn.Login();
            if (login_result.isError())
            {
                //return null;
                MessageBox.Show(login_result.getErrorString().Replace("SOAP-ENV:ServerAuthentication failed for admin", ""), "Login Failed");
                return null;
                //throw new Exception("Login failed :-" + login_result.getErrorString());
            }

            return conn;
        }

        private void getDBListButton_Click(object sender, EventArgs e)
        {
            dbList.Text = "";
            //Form actfrm = this.ActiveForm;
            toolStripStatusLabel1.Text = "Connecting ...";
            //var currcursor = actfrm.Cursor;
            //actfrm.Cursor = System.Windows.Forms.Cursors.AppStarting;

            try
            {
                errorProvider1.Clear();
                if (conn != null)
                {
                    conn.Logout();
                }
                dbList.Items.Clear();
                String ArasURL = urlBox.Text;
                if (String.IsNullOrEmpty(ArasURL))
                {
                    MessageBox.Show("Enter URL...");
                    return;
                }
                String[] urlarray = ArasURL.Split('/');

                String protocall = urlarray[0];
                String ServerName = urlarray[2];
                String Site = urlarray[3];

                String urlval = @protocall + "//" + ServerName + "/" + Site;
                toolStripStatusLabel1.Text = "Connecting to " + urlval + " ...";
                HttpServerConnection conn1 = IomFactory.CreateHttpServerConnection(urlval);
                String[] DBNames = conn1.GetDatabases();
                toolStripStatusLabel1.Text = "Updating Database list ...";

                //toolStripProgressBar1.Maximum = DBNames.Length;
                foreach (String DBName in DBNames)
                {
                    //  toolStripProgressBar1.Increment(1);
                    dbList.Items.Add(DBName);

                    //for (int i = 0; i < 15; i++)
                    //{
                    //    statusTextBox.AppendText("\n");
                    //    statusTextBox.AppendText(DBName);
                    //}
                }
                //toolStripProgressBar1.Value = 0;
                toolStripStatusLabel1.Text = "";
            }
            catch (Exception ex)
            {
                //actfrm.Cursor = currcursor;
                errorProvider1.SetError(urlBox, "Error while getting DBs for this URL \n" + ex.Message.ToString());
                toolStripStatusLabel1.Text = ex.Message.ToString();
                //throw ex;
            }
            //actfrm.Cursor = currcursor;
        }

        void startProcessbaarasMarquee(bool start)
        {
            progressBar1.Visible = start;
            if (start)
            {

                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 40;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Form1.ActiveForm.Enabled = false;
            //var currcursor = Form1.ActiveForm.Cursor;
            //Form1.ActiveForm.Cursor = System.Windows.Forms.Cursors.AppStarting;
            toolStripStatusLabel1.Text = "Connecting...";
            startProcessbaarasMarquee(true);
            string ArasURL = urlBox.Text;
            String userid = userTextBox.Text;
            string DataBaseName = dbList.Text;
            String usePass = passwordTextBox.Text;
            if (String.IsNullOrEmpty(ArasURL) || String.IsNullOrEmpty(DataBaseName) || String.IsNullOrEmpty(usePass) || String.IsNullOrEmpty(userid))
            {
                MessageBox.Show("Please provide all the information to login");
                startProcessbaarasMarquee(false);
                return;
            }

            conn = login(ArasURL, DataBaseName, userid, usePass);
            if (conn != null)
            {
                ////monthCalendar1.Visible = true;
                //button1.Visible = true;
                //ok_btn.Visible = true;
                //refresh_btn.Visible = true;
                ////userlabel.Visible = true;
                ////userlist.Visible = true;
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["url"].Value = urlBox.Text;
                config.AppSettings.Settings["database"].Value = dbList.Text;
                config.AppSettings.Settings["userid"].Value = userTextBox.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                toolStripStatusLabel1.Text = "Login successful...";

                inn = IomFactory.CreateInnovator(conn);

                //ConfigurationManager.AppSettings["url"] = url.Text;
                //ConfigurationManager.AppSettings["database"] = database.Text;
                //ConfigurationManager.AppSettings["userid"] = user_id.Text;
            }
            //Form1.ActiveForm.Enabled = true;

            //Form1.ActiveForm.Cursor = currcursor;
            startProcessbaarasMarquee(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null)
            {
                conn.Logout(true);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                conn.Logout(true);
            }

            if (log_file != null)
            {
                log_file.Close();
            }

            if (tech_log != null)
            {
                tech_log.Close();
            }

            if (error_File != null)
            {
                error_File.Close();
            }

            this.ParentForm.Close();
        }

        private void InputFileExplore_Click(object sender, EventArgs e)
        {
            DialogResult textFileDialogResult = inputTextFileDialog.ShowDialog();

            if (textFileDialogResult == DialogResult.OK)
            {
                InputTextFilePath.Text = inputTextFileDialog.FileName;
            }


        }

        private void logFileExplore_Click(object sender, EventArgs e)
        {
            DialogResult logFileDialogResult = logFileDialog.ShowDialog();

            if (logFileDialogResult == DialogResult.OK)
            {
                logFilePath.Text = logFileDialog.FileName;
            }
            logFileDialog.Dispose();
        }

        private void repeteFileExploreButton_Click(object sender, EventArgs e)
        {
            DialogResult repeatFileDialogResult = logFileDialog.ShowDialog();

            if (repeatFileDialogResult == DialogResult.OK)
            {
                repeatFilePath.Text = logFileDialog.FileName;
            }

            logFileDialog.Dispose();
        }

        private void techLogFileExploreButton_Click(object sender, EventArgs e)
        {
            DialogResult techlogFileDialogResult = logFileDialog.ShowDialog();

            if (techlogFileDialogResult == DialogResult.OK)
            {
                techLogFilePath.Text = logFileDialog.FileName;
            }
            logFileDialog.Dispose();
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            validateTheFormDetails();

        }

        private bool validateTheFormDetails()
        {
            //Check if Login to Aras is Completed
            if (conn == null)
            {
                MessageBox.Show("Please Login First");
                toolStripStatusLabel1.Text = "Please Login First";

                return false;
            }

            //Validating the File Details..
            //InPut File
            if (String.IsNullOrEmpty(InputTextFilePath.Text))
            {
                MessageBox.Show("Please Provide the Input File");
                toolStripStatusLabel1.Text = "Please Provide the Input File";

                return false;
            }

            if (String.IsNullOrEmpty(logFilePath.Text))
            {
                MessageBox.Show("Please Provide the Log File");
                toolStripStatusLabel1.Text = "Please Provide the Log File";

                return false;
            }

            if (String.IsNullOrEmpty(techLogFilePath.Text))
            {
                MessageBox.Show("Please Provide the Technical Log File");
                toolStripStatusLabel1.Text = "Please Provide the Technical Log File";

                return false;
            }

            if (String.IsNullOrEmpty(repeatFilePath.Text))
            {
                MessageBox.Show("Please Provide the Repeat File");
                toolStripStatusLabel1.Text = "Please Provide the Repeat File";

                return false;
            }

            //Check if Delimiter is Provided

            if (String.IsNullOrEmpty(delimiterField.Text))
            {

            }

            //Check if the Header is having correct format

            //Check if the Header contains ItemNumber,Revision Values

            //Check the Config File data
            //
            return true;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                MessageBox.Show("Please login to Aras Before Opening");
                return;
            }

            ArasConfigFile arasConfigFile = new ArasConfigFile(conn);

            arasConfigFile.ShowDialog(this);
        }

        private void cadImportButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Validating...";

            bool valdate = validateTheFormDetails();

            if (!valdate)
            {
                return;
            }
            toolStripStatusLabel1.Text = "Validation Completed...";

            Thread threadtoExecuteMigration = new Thread(startImportIntoArasFromTextFile);
            threadtoExecuteMigration.Start();
            //EnbleControls(this);
            // startImportIntoArasFromTextFile();
        }

        public void startImportIntoArasFromTextFile()
        {

            DisableControls(this);

            DateTime startDate = DateTime.Now;


            //getting the FilePaths

            String techlogfilePath = techLogFilePath.Text;
            String logfile = logFilePath.Text;
            String errorfile = repeatFilePath.Text;
            String input_file_Path = InputTextFilePath.Text;


            if (!File.Exists(techlogfilePath))
            {
                tech_log = new StreamWriter(techlogfilePath);
            }
            else
            {
                tech_log = File.AppendText(techlogfilePath);
            }

            if (!File.Exists(logfile))
            {
                log_file = new StreamWriter(logfile);
            }
            else
            {
                log_file = File.AppendText(logfile);
            }

            //if (!File.Exists(errorfile))
            {
                error_File = new StreamWriter(errorfile);
            }
            toolStripStatusLabel1.Text = "Reading Configuration ...";

            readConfigurationData();

            toolStripStatusLabel1.Text = "Configuration completed...";


            parentItemtypeObject = GetItemType(ParentType);
            childItemtypeObject = GetItemType(ChildType);

            toolStripStatusLabel1.Text = "Starting the Import Process...";


            processImportingData(input_file_Path);



            DateTime endDate = DateTime.Now;
            var seconds = System.Math.Abs((startDate - endDate).TotalSeconds);

            updateLog("Time taken for process -- " + seconds + " seconds");

            log_file.Close();
            error_File.Close();
            tech_log.Close();

            if (!is_error)
            {
                if (File.Exists(errorfile))
                {
                    File.Delete(errorfile);
                }
            }

            toolStripStatusLabel1.Text = "Completed..";
            EnbleControls(this);


        }

        private Item GetItemType(String ItemType)
        {
            Item result = inn.newItem();
            String AMLStr = "<AML>" +
                  "<Item type='ItemType' action='get' where=\"[ItemType].name='" + ItemType + "'\" select='*'>" +
                    "<Relationships>" +
                      "<Item type='Property' action='get' select='name,data_type,data_source'>" +
                      "</Item>" +
                      "<Item type='RelationshipType' action='get' select='*'>" +
                        "<related_id>" +
                          "<Item type='ItemType' action='get' select='*'>" +
                            "<Relationships>" +
                              "<Item type='Property' action='get' select='name,data_type,data_source'>" +
                              "</Item>" +
                            "</Relationships>" +
                          "</Item>" +
                        "</related_id>" +
                      "</Item>" +
                    "</Relationships>" +
                  "</Item>" +
                "</AML>";

            result = inn.applyAML(AMLStr);

            return result;
        }

        private void readConfigurationData()
        {
            updateTechLog("<<<<<<<------ Starting of readConfigurationData ------->>>>>>>>");

            updateLog("Reading config data");

            ParentType = ConfigurationManager.AppSettings["ParentType"];
            updateLog("ParentType --> " + ParentType);

            ChildType = ConfigurationManager.AppSettings["ChildType"];
            updateLog("ChildType --> " + ChildType);

            ParentChildRelation = ConfigurationManager.AppSettings["ParentChildRelation"];
            updateLog("ParentChildRelation --> " + ParentChildRelation);


            ParentFileRelation = ConfigurationManager.AppSettings["ParentFileRelation"];
            updateLog("ParentFileRelation --> " + ParentFileRelation);

            ChildFileRelation = ConfigurationManager.AppSettings["ChildFileRelation"];
            updateLog("ChildFileRelation --> " + ChildFileRelation);

            FilesFolder = ConfigurationManager.AppSettings["FilesFolder"];
            updateLog("FilesFolder --> " + FilesFolder);

            delimiter = ConfigurationManager.AppSettings["delimiter"];
            if (delimiter == null || delimiter == "")
            {
                delimiter = "~";
            }
            updateLog("delimiter --> " + delimiter);

            String Delete_Files_OnRevise = ConfigurationManager.AppSettings["Delete_Files_OnRevise"];
            if (Delete_Files_OnRevise == "f" || Delete_Files_OnRevise == "false" || Delete_Files_OnRevise == "0")
            {
                Delete_Files_OnRevise_bool = false;
            }
            if (Delete_Files_OnRevise == "t" || Delete_Files_OnRevise == "true" || Delete_Files_OnRevise == "1")
            {
                Delete_Files_OnRevise_bool = true;
            }
            updateLog("Delete_Files_OnRevise_bool --> " + Delete_Files_OnRevise_bool);

            dateformat = ConfigurationManager.AppSettings["date_format"];
            updateLog("dateformat --> " + dateformat);

            updateTechLog("<<<<<<<------ End  of readConfigurationData ------->>>>>>>>");
        }

        Hashtable common_Columns, parent_Columns, child_Columns,rel_Columns;

        private void processImportingData(String inputfile)
        {
            updateTechLog("<<<<<<<------ Starting of ProcessImportData ------->>>>>>>>");

            int LINE_COUNT = 0;
            int Error_COUNT = 0;

            try
            {
                string[] columns = null;
                string[] lines = System.IO.File.ReadAllLines(inputfile);

                // Display the file contents by using a foreach loop.
                updateLog("Reading Input File.....");

                //progressBar1.InvokeRequired

                setupProgressbar(progressBar1, lines.Length, true);

                char delimiterchar = delimiter.ToCharArray()[0];
                foreach (string line in lines)
                {
                    LineHasError = false;
                    // Use a tab to indent each line of the file.
                    //Console.WriteLine("\t" + line);
                    if (LINE_COUNT == 0)
                    {
                        updateLog("reading the header info... ");

                        updateLog("\t" + line);

                        Hashtable tempChlid_columns = new Hashtable(), tempParent_columns = new Hashtable();

                        common_Columns = new Hashtable();
                        parent_Columns = new Hashtable();
                        child_Columns = new Hashtable();
                        rel_Columns = new Hashtable();

                        columns = line.Split(delimiterchar);
                        error_File.WriteLine(line);
                        int index = 0;
                        foreach (String columnname in columns)
                        {
                            if (columnname.IndexOf("P:") >= 0)
                            {

                                tempParent_columns.Add(columnname.Replace("P:", ""), index);
                            }
                            else if (columnname.IndexOf("C:") >= 0)
                            {
                                tempChlid_columns.Add(columnname.Replace("C:", ""), index);
                            }
                            else if (columnname.IndexOf("R:") >= 0)
                            {
                                rel_Columns.Add(columnname.Replace("R:", ""), index);
                            }
                            else
                            {
                                common_Columns.Add(columnname, index);
                            }

                            hasNative = columnname.Contains("native_file");
                            if (hasNative)
                            {
                                indexofNativeFile = index;
                            }

                            index++;
                        }
                        parent_Columns = appendHasTable(common_Columns, tempParent_columns);
                        child_Columns = appendHasTable(common_Columns, tempChlid_columns);


                    }
                    else
                    {
                        try
                        {
                            processbarPerformStep(progressBar1);
                            toolStripStatusLabel1.Text = "Processing [" + LINE_COUNT + "/" + lines.Length + "]";

                            updateLog("\t[" + LINE_COUNT + "]" + line);

                            string[] values = line.Split(delimiterchar);
                            processValues(columns, values);
                        }
                        catch (Exception ex)
                        {
                            updateStatusBox(ex.Message);

                            is_error = true;
                            error_File.WriteLine(line);
                            Error_COUNT++;
                            LineHasError = false;
                        }

                        if (LineHasError)
                        {
                            error_File.WriteLine(line);
                            Error_COUNT++;
                        }
                    }

                    LINE_COUNT++;
                }
            }
            catch (Exception ex)
            {
                updateLog(ex.Message);
            }

            setupProgressbar(progressBar1, 100, false);
            updateLog("No of Lines Processed :- " + LINE_COUNT);

            updateLog("No of Lines Failes :- " + Error_COUNT);

            updateTechLog("<<<<<<<------ End  of ProcessImportData ------->>>>>>>>");

        }

        private void processbarPerformStep(ProgressBar progressBar)
        {
            if (progressBar.InvokeRequired == true)
            {
                progressBar.Invoke((MethodInvoker)delegate {
                    progressBar.PerformStep();
                });
            }
            else
            {
                progressBar.PerformStep();
            }
        }

        private void setupProgressbar(ProgressBar progressBar, int Maximum, bool visability)
        {
            if (progressBar.InvokeRequired == true)
            {
                progressBar.Invoke((MethodInvoker)delegate {
                    progressBar.Visible = visability;
                    progressBar.Maximum = Maximum;
                    progressBar.Style = ProgressBarStyle.Continuous;

                });
            }
            else
            {
                progressBar.Visible = visability;
                progressBar.Maximum = Maximum;
                progressBar.Style = ProgressBarStyle.Continuous;
            }
        }

        private Hashtable appendHasTable(Hashtable first, Hashtable second)
        {
            Hashtable table = new Hashtable();

            foreach (DictionaryEntry e in first)
            {
                table.Add(e.Key, e.Value);
            }

            foreach (DictionaryEntry e in second)
            {
                if (!table.ContainsKey(e))
                    table.Add(e.Key, e.Value);
            }

            return table;
        }

        private void processValues(string[] columns, string[] values)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. processValues >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            try
            {

                //int itemnumberIndx = Array.IndexOf(columns, "item_number");
                //int revisionIndx = Array.IndexOf(columns, "major_rev");

                String itemNumber = "";//values[itemnumberIndx];
                String revision = "";//values[revisionIndx];


                Item parentItem = getItemByQueryByLine(ParentType, itemNumber, revision, common_Columns, parent_Columns, columns, values);
                if (!parentItem.isError() && parentItem.getItemCount() > 0)
                {
                    Item childItem = getItemByQueryByLine(ChildType, itemNumber, revision, common_Columns, child_Columns, columns, values);

                    if (!childItem.isError() && childItem.getItemCount() > 0)
                    {
                        checkAndAddRelationBtwParentAndChildItems(parentItem, childItem, values);
                    }
                    else
                    {
                        updateLog("\t\t\t Error While Query Child Item");
                        LineHasError = true;
                    }
                }
                else
                {
                    updateLog("\t\t\t Error While Query Parent Item");
                    LineHasError = true;
                }

            }
            catch (Exception ex)
            {

                updateLog("\t\t\t Exception while Queryng the Item" + ex.Message);
                LineHasError = true;
            }

            updateTechLog("<<<<<<<<<<<<<<<<<< End of the Function .. processValues >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }


        private void DisableControls(Control container)
        {
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.InvokeRequired == true)
                {
                    textBox.Invoke((MethodInvoker)delegate {
                        textBox.ReadOnly = true;
                    });
                }
                else
                {
                    textBox.ReadOnly = true;
                }
            }

            foreach (var textBox in this.Controls.OfType<Button>())
            {
                if (textBox.InvokeRequired == true)
                {
                    textBox.Invoke((MethodInvoker)delegate {
                        textBox.Enabled = false;
                    });
                }
                else
                {
                    textBox.Enabled = false;
                }
            }

            foreach (var textBox in this.Controls.OfType<ComboBox>())
            {

                if (textBox.InvokeRequired == true)
                {
                    textBox.Invoke((MethodInvoker)delegate {
                        textBox.Enabled = false;
                    });
                }
                else
                {
                    textBox.Enabled = false;
                }
            }


            //foreach (var textBox in this.Controls.OfType<ToolStripTextBox>())
            //    textBox.ReadOnly = true;

            //foreach (var textBox in this.Controls.OfType<ToolStripButton>())
            //    textBox.Enabled = false;

            //foreach (var textBox in this.Controls.OfType<ToolStripComboBox>())
            //    textBox.Enabled = false;

            foreach (var textBox in this.Controls.OfType<ComboBox>())
            {

                if (this.toolStrip1.InvokeRequired == true)
                {
                    this.toolStrip1.Invoke((MethodInvoker)delegate {
                        this.toolStrip1.Enabled = false;
                    });
                }
                else
                {
                    this.toolStrip1.Enabled = false;
                }
            }

            //this.toolStrip1.Enabled = false;

            //this.exitButton.Enabled = true;


        }

        private void EnbleControls(Control con)
        {

            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.InvokeRequired == true)
                {
                    textBox.Invoke((MethodInvoker)delegate {
                        textBox.ReadOnly = false;
                    });
                }
                else
                {
                    textBox.ReadOnly = false;
                }
            }

            foreach (var textBox in this.Controls.OfType<Button>())
            {
                if (textBox.InvokeRequired == true)
                {
                    textBox.Invoke((MethodInvoker)delegate {
                        textBox.Enabled = true;
                    });
                }
                else
                {
                    textBox.Enabled = true;
                }
            }

            foreach (var textBox in this.Controls.OfType<ComboBox>())
            {

                if (textBox.InvokeRequired == true)
                {
                    textBox.Invoke((MethodInvoker)delegate {
                        textBox.Enabled = true;
                    });
                }
                else
                {
                    textBox.Enabled = true;
                }
            }

            foreach (var textBox in this.Controls.OfType<ComboBox>())
            {

                if (this.toolStrip1.InvokeRequired == true)
                {
                    this.toolStrip1.Invoke((MethodInvoker)delegate {
                        this.toolStrip1.Enabled = true;
                    });
                }
                else
                {
                    this.toolStrip1.Enabled = true;
                }
            }

            //foreach (var textBox in this.Controls.OfType<TextBox>())
            //    textBox.ReadOnly = false;

            //foreach (var textBox in this.Controls.OfType<Button>())
            //    textBox.Enabled = true;
            //foreach (var textBox in this.Controls.OfType<ComboBox>())
            //    textBox.Enabled = true;

            //this.toolStrip1.Enabled = true;
        }

        private void checkAndAddRelationBtwParentAndChildItems(Item parentItem, Item childItem, String[] values)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<<<<< Started checkAndAddRelationBtwParentAndChildItems >>>>>>>>>>>>>>>>>>>>>");
            try
            {
                String parentItemId = parentItem.getID();

                String childItemId = childItem.getID();
                String childConfigId = childItem.getProperty("config_id", childItemId);
                String isParentCurrent = childItem.getProperty("is_current", "1");

                String sql4Relation = "select * from innovator.[" + ParentChildRelation.Replace(" ", "_") + "] where source_id='" + parentItemId + "' and related_id='" + childItemId + "'";
                //String sql2getOldrevision = "select * from innovator.[" + ParentChildRelation.Replace(" ", "_") + "] where source_id='" + parentItemId + "' and related_id in ('" + childItemId + ")'";

                String sql2getOldrevision = "select * from innovator.[" + ParentChildRelation.Replace(" ", "_") + "] where SOURCE_ID ='" + parentItemId + "' and RELATED_ID in (select id from innovator.[CAD] WHERE CONFIG_ID ='" + childConfigId + "' and IS_CURRENT='0')";

                Item parentOldChildRel = inn.applySQL(sql2getOldrevision);

                for (int oldRevindex = 0; oldRevindex < parentOldChildRel.getItemCount(); oldRevindex++)
                {
                    try
                    {
                        String relID = parentOldChildRel.getItemByIndex(oldRevindex).getID();

                        String deleteAML = "<AML>"
                            + "<Item type='" + ParentChildRelation + "' id='" + relID + "' action='delete'></Item>"
                            + "</AML>";

                        Item deleteResult = inn.applyAML(deleteAML);

                        if (deleteResult.isError())
                        {
                            updateLog("Error while Deleting the relationship --> " + deleteResult.getErrorString());
                            LineHasError = true;
                        }

                    }
                    catch (Exception ex)
                    {

                        updateLog("Error while Deleting the relationship --> " + ex.Message);
                        LineHasError = true;
                    }
                }


                Item relationItem = inn.applySQL(sql4Relation);

                if (relationItem.getItemCount() <= 0)
                {
                    Item newRelationship = inn.newItem(ParentChildRelation, "add");
                    newRelationship.setProperty("source_id", parentItemId);
                    newRelationship.setProperty("related_id", childItemId);


                    string state = "";

                    List<string> filesList = null;
                    String setprop = "";

                    UpdateNewItem(newRelationship, ParentChildRelation, ParentChildRelation, common_Columns, rel_Columns, values, out state, out filesList, out setprop);

                    newRelationship = newRelationship.apply();
                }
            }
            catch (Exception ex)
            {

                updateLog("\t\t\t Failed to add Child Item to Parent Item" + ex.Message);
                LineHasError = true;
            }
            updateTechLog("<<<<<<<<<<<<<<<<<<<<< End checkAndAddRelationBtwParentAndChildItems >>>>>>>>>>>>>>>>>>>>>");

        }

        private Item getItemByQueryByLine(string itemType, string itemNumber, string revision, Hashtable common_Columns, Hashtable item_Columns, string[] columns, string[] values)
        {
            Item endItem = inn.newItem();


            int itemnumberIndx = (int)item_Columns["item_number"];
            int revisionIndx = (int)item_Columns["major_rev"];

             itemNumber = values[itemnumberIndx];
             revision = values[revisionIndx];


            #region Code related to Native File


            String SQLnativefileExt = "";
            if (item_Columns.ContainsKey("native_file") || common_Columns.ContainsKey("native_file"))
            {
                String NativefileExt = "";
                //
                String nativefileName = values[indexofNativeFile];
                if (!string.IsNullOrEmpty(nativefileName))
                {
                    int fileext = nativefileName.LastIndexOf('.');

                    if (File.Exists(nativefileName))
                    {
                        updateTechLog("Nativefile exist with the path as --> " + nativefileName);
                        NativefileExt = Path.GetExtension(nativefileName);

                    }
                    else if (File.Exists(Path.Combine(FilesFolder, nativefileName)))
                    {
                        updateTechLog("Nativefile exist with the path as --> " + Path.Combine(FilesFolder, nativefileName));

                        NativefileExt = Path.GetExtension(Path.Combine(FilesFolder, nativefileName));

                    }
                    else
                    {
                        NativefileExt = nativefileName.Substring(fileext);
                    }

                    updateTechLog("Nativefile Extension --> " + NativefileExt);
                    SQLnativefileExt = "and native_file in (select id from innovator.[file] where [FILENAME] like '%" + NativefileExt + "')";
                    updateTechLog("SQLnativefileExt --> " + SQLnativefileExt);
                }
            }

            #endregion


            //Query to get all the Part revisions with Item Number 

            String getItemSQL = "Select * from innovator.[" + itemType + "] where item_number = '" + itemNumber + "' and IS_CURRENT is not null " + SQLnativefileExt + "order by MODIFIED_ON desc";

            updateTechLog("getItemSQL --> " + getItemSQL);

            Item Result = inn.applySQL(getItemSQL);

            if (Result.isError())
            {
                updateLog("Exception while Queryng the Item" + Result.getErrorString());
                is_error = true;
                LineHasError = true;
            }

            //Check if the Part exist with Item number and revision

            Item Result_Items = Result.getItemsByXPath("//Result/Item[major_rev='" + revision + "']");

            //Update the Part if the revision Exist

            if (Result_Items.getItemCount() > 0)
            {
                endItem = updateExistingRevision(Result_Items, itemType, common_Columns, item_Columns, columns, values);
            }

            // Revise the part to get the required revision
            else if (Result.getItemCount() > 0 && Result_Items.getItemCount() <= 0)
            {
                endItem = createNewRevision(Result, itemType, common_Columns, item_Columns, columns, values);
            }

            //Create the Part if the Item Number do not exist.

            else
            {
                endItem = createNewItem(itemType, common_Columns, item_Columns, values);
                //String getItemAML 
            }

            return endItem;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private Item updateExistingRevision(Item Result_Items, string itemType, Hashtable commonColumns, Hashtable item_Columns, string[] columns, string[] values)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. UpdateExistingRevision >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");


            try
            {
                String defaultPropSQL = "", RelationType = "";

                if (itemType == ParentType)
                {
                    RelationType = ParentFileRelation;
                }

                else if (itemType == ChildType)
                {
                    RelationType = ChildFileRelation;
                }

                Item CurrRevision = Result_Items.getItemByIndex(0);
                String ItemID = CurrRevision.getProperty("id");

                String UpdateSQL = "Update innovator.[" + itemType + "] set";
                String setprop = "";

                updateTechLog("------------------------");
                updateTechLog("No of Item Columns -->" + item_Columns.Count);
                updateTechLog("No of values  -->" + values.Length);
                updateTechLog("------------------------");

                //for (int inx = 1; inx < columns.Length; inx++)
                foreach (DictionaryEntry column in item_Columns)
                {
                    int inx = Convert.ToInt32(column.Value);
                    string PropertyName = column.Key.ToString();
                    bool isFileProperty = false;
                    string PropertyValue = getPropertyRealValue(itemType, PropertyName, values[inx], FilesFolder, out isFileProperty);
                    updateTechLog("PropertyValue --<" + PropertyValue + "> with length <" + PropertyValue.Length + ">");
                    if (PropertyValue != null && PropertyValue != "" && PropertyValue.Length > 0)
                    {
                        if (PropertyName.ToLower() == "state")
                        {
                            string currState = CurrRevision.getProperty("state");
                            if (!string.IsNullOrEmpty(currState) && currState != PropertyValue)
                            {
                                try
                                {
                                    Item PromoteItem = CurrRevision.promote(PropertyValue, "Promoted while Migration");
                                    if (PromoteItem.isError())
                                    {

                                        is_error = true;

                                        updateLog("\t\tError while Promoting to  " + PropertyValue + " \n \t\t" + PromoteItem.getErrorString());
                                        LineHasError = true;
                                    }
                                }
                                catch (Exception ex)
                                {

                                    updateLog("\t\tError while Promoting to  " + PropertyValue + " \n \t\t");

                                    is_error = true;
                                    LineHasError = true;
                                    throw ex;
                                }

                            }
                        }
                        else if (!PropertyName.ToLower().Contains("file") || (isFileProperty && PropertyName.ToLower().Contains("file")))
                        {
                            if (setprop == "")
                            {
                                setprop = PropertyName + " = '" + PropertyValue + "'";
                            }
                            else
                            {
                                setprop += ", " + PropertyName + "= '" + PropertyValue + "'";
                            }
                        }
                        else if (!isFileProperty && PropertyName.ToLower().Contains("file"))
                        {
                            updateFiles(CurrRevision, RelationType, FilesFolder, PropertyValue);

                        }
                    }


                }

                UpdateSQL += " " + setprop + defaultPropSQL + " where id='" + ItemID + "'";
                updateTechLog("updating the values using update statement -->\nUpdateSQL <--> " + UpdateSQL);
                Item SQLResult = inn.applySQL(UpdateSQL);
                if (SQLResult.isError())
                {
                    updateStatusBox("Failed to update the record .. " + SQLResult.getErrorString());
                    is_error = true;
                    LineHasError = true;

                    updateLog("\t\tError while Updating the Properties");

                    //throw new Exception();
                }
                else
                {


                }

            }
            catch (Exception ex)
            {

                updateLog("Error while updating the Line" + ex.Message);
                is_error = true;
                LineHasError = true;
                throw ex;
            }

            updateTechLog("<<<<<<<<<<<<<<<<<< End the Function .. UpdateExistingRevision >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            return Result_Items;
        }



        private Item createNewRevision(Item parentResult, string ItemType, Hashtable common_Columns, Hashtable item_Columns, string[] columns, string[] values)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. ReviseTheItem >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            Item NewRevision = inn.newItem();

            try
            {
                String //defaultPropSQL = "", 
                    RelationType = "";

                if (ItemType == ParentType)
                {
                    RelationType = ParentFileRelation;
                }

                else if (ItemType == ChildType)
                {
                    RelationType = ChildFileRelation;
                }

                // Item Current_Items = Result.getItemsByXPath("//Result/Item[is_cuurent='1']");
                Item CurrRevision = parentResult.getItemByIndex(0);
                String ItemID = CurrRevision.getProperty("id");

                Item Current_Item = inn.getItemById(ItemType, ItemID);

                //Item NewRevision = Current_Item.setAction("Revise");
                // Version and unlock the item
                NewRevision = Current_Item.apply("version");
                if (!NewRevision.isError())
                    NewRevision = NewRevision.apply("unlock");

                if (NewRevision != null && NewRevision.getItemCount() > 0)
                {
                    if (Delete_Files_OnRevise_bool)
                    {
                        RemoveFiles(NewRevision, RelationType);
                    }

                    updateExistingRevision(NewRevision, ItemType, common_Columns, item_Columns, columns, values);
                }
                else if (NewRevision.isError())
                {
                    is_error = true;
                    LineHasError = true;
                    updateLog("\t\tError while revising the Item.." + NewRevision.getErrorString());
                    throw new Exception();
                }

                //return resItem; 

            }
            catch (Exception ex)
            {
                updateLog(ex.Message);

                is_error = true;
                LineHasError = true;

                throw ex;
            }
            updateTechLog("<<<<<<<<<<<<<<<<<< End the Function .. ReviseTheItem >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            return NewRevision;
        }

        private Item createNewItem(string ItemType, Hashtable common_Columns, Hashtable item_Columns, string[] values)
        // private static void AddNewItem(string ItemType, string RelationType, string FilesFolder, string[] columns, string[] values, string defaultPropSQL)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. AddNewItem >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            Item NewItem = inn.newItem();

            try
            {
                String defaultPropSQL = "", RelationType = "";

                if (ItemType == ParentType)
                {
                    RelationType = ParentFileRelation;
                }

                else if (ItemType == ChildType)
                {
                    RelationType = ChildFileRelation;
                }

                string state = "";

                List<string> filesList = null;

                NewItem = inn.newItem(ItemType, "add");
                NewItem.setProperty("item_number", values[0]);
                String setprop = "";

                UpdateNewItem(NewItem, ItemType, RelationType, common_Columns, item_Columns, values, out state, out filesList, out setprop);

                NewItem = NewItem.apply();

                if (NewItem.getItemCount() > 0)
                {

                    if (NewItem.getItemCount() == 1)
                    {
                        String updateSQLScript = "update innovator.[" + ItemType + "] set " + defaultPropSQL + setprop + " where id='" + NewItem.getID() + "'";

                        updateTechLog("updateSQLScript  --> " + updateSQLScript);

                        Item sqlRes = inn.applySQL(updateSQLScript);

                        if (sqlRes.isError())
                        {
                            is_error = true;
                            LineHasError = true;
                            updateLog("Error while Updating the Major Revision as " + values[1] + "  " + sqlRes.getErrorString());
                        }
                    }

                    //UpdateExistingRevision(NewItem, ItemType, RelationType, FilesFolder, columns, values);
                }
                else if (NewItem.isError())
                {
                    is_error = true;
                    LineHasError = true;
                    updateLog("\t\tError while Creating the Item.." + NewItem.getErrorString());
                    throw new Exception();
                }

                if (!string.IsNullOrEmpty(state))
                {
                    string currState = NewItem.getProperty("state");
                    if (!string.IsNullOrEmpty(currState) && currState != state)
                    {
                        Item PromoteItem = NewItem.promote(state, "Promoted while Migration");
                        if (PromoteItem.isError())
                        {

                            is_error = true;

                            updateLog("\t\tError while Promoting to  " + state + " \n \t\t" + PromoteItem.getErrorString());
                            LineHasError = true;
                        }
                    }
                }


                foreach (string filename in filesList)
                {
                    updateFiles(NewItem, RelationType, FilesFolder, filename);
                }
            }
            catch (Exception ex)
            {
                updateLog(ex.Message);

                is_error = true;
                LineHasError = true;
            }
            updateTechLog("<<<<<<<<<<<<<<<<<< End the Function .. AddNewItem >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            return NewItem;
        }

        private void UpdateNewItem(Item newItem, string ItemType, string relationType, Hashtable common_Columns, Hashtable item_Columns, string[] values, out string stateValue, out List<string> filearray, out string setprop)
        //private static void UpdateNewItem(Item Result, string ItemType, string RelationType, string FilesFolder, string[] columns, string[] values, out string stateValue, out List<string> filearray, out string setprop)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. UpdateNewItem >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            stateValue = null;
            filearray = new List<string>();
            try
            {
                //Item CurrRevision = Result.getItemByIndex(0);
                //String ItemID = CurrRevision.getProperty("id");

                //String UpdateSQL = "Update innovator.[" + ItemType + "] set";
                setprop = "";

                updateTechLog("------------------------");
                updateTechLog("No of Columns -->" + item_Columns.Count);
                updateTechLog("No of values  -->" + values.Length);
                updateTechLog("------------------------");

                //for (int inx = 1; inx < item_Columns.Count; inx++)
                //{
                foreach (DictionaryEntry column in item_Columns)
                {
                    int inx = Convert.ToInt32(column.Value);
                    string PropertyName = column.Key.ToString();

                    bool isFileProperty = false;
                    string PropertyValue = getPropertyRealValue(ItemType, PropertyName, values[inx], FilesFolder, out isFileProperty);
                    updateTechLog("PropertyValue --<" + PropertyValue + "> with length <" + PropertyValue.Length + ">");
                    if (PropertyValue != null && PropertyValue != "" && PropertyValue.Length > 0)
                    {
                        if (PropertyName.ToLower() == "state")
                        {
                            stateValue = PropertyValue;
                        }
                        else if (!PropertyName.ToLower().Contains("file") || (isFileProperty && PropertyName.ToLower().Contains("file")))
                        {
                            newItem.setProperty(PropertyName, PropertyValue);
                            if (setprop == "")
                            {
                                setprop = PropertyName + " = '" + PropertyValue + "'";
                            }
                            else
                            {
                                setprop += ", " + PropertyName + "= '" + PropertyValue + "'";
                            }
                        }
                        else if (!isFileProperty && PropertyName.ToLower().Contains("file"))
                        {
                            filearray.Add(PropertyValue);
                            //updateFiles(CurrRevision, RelationType, FilesFolder, PropertyValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                updateLog("Error while updating the Line" + ex.Message);
                is_error = true;
                LineHasError = true;
                throw ex;
            }

            updateTechLog("<<<<<<<<<<<<<<<<<< End the Function .. UpdateNewItem >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

        }

        private void RemoveFiles(Item NewRevision, string RelationType)
        {
            try
            {
                Item Deleteitems = inn.newItem(RelationType, "get");
                Deleteitems.setProperty("source_id", NewRevision.getID());
                Deleteitems = Deleteitems.apply();

                for (int i = 0; i < Deleteitems.getItemCount(); i++)
                {
                    Item Deleteitem = Deleteitems.getItemByIndex(i);
                    Deleteitem.setAction("delete");
                    Deleteitem = Deleteitem.apply();
                    if (Deleteitem.isError())
                    {
                        is_error = true;
                        updateLog("\t\tError whle removing files.." + Deleteitem.getErrorString());
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                updateLog(ex.Message);
                throw ex;
            }
        }

        private string getPropertyRealValue(string ItemType, string propertyName, string columnValue, string FilesFolder, out bool isFileProperty)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. getPropertyRealValue >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            updateTechLog("propertyName -->" + propertyName);
            updateTechLog("columnValue -->" + columnValue);
            isFileProperty = false;

            string finalPropertyValue = "";

            Item ItemtypeObject = inn.newItem();

            if (ItemType == ParentType)
            {
                ItemtypeObject = parentItemtypeObject;
            }
            else
            {
                ItemtypeObject = childItemtypeObject;

            }

            string itemId = ItemtypeObject.getID();
            //Item PropertyItem = inn.applySQL("select * from innovator.[Property] where name ='" + propertyName + "' and source_id='" + itemId + "'");
            //string xpathstr = "//Item[@type='Property' and name='" + propertyName + "' and source_id='" + itemId + "']";
            string xpathstr = "//Item[@type='ItemType' and name='" + ItemType + "']/Relationships/Item[@type='Property' and name='" + propertyName + "' and source_id='" + itemId + "']";

            Item PropertyObject = ItemtypeObject.getItemsByXPath(xpathstr);
            if (PropertyObject.getItemCount() > 0 && !string.IsNullOrEmpty(columnValue))
            {
                string propType = PropertyObject.getItemByIndex(0).getProperty("data_type");
                string propSource = PropertyObject.getItemByIndex(0).getProperty("data_source");

                updateTechLog("propType -->" + propType);
                updateTechLog("propSource -->" + propSource);



                if (!string.IsNullOrEmpty(propType))
                {
                    if (propType.ToLower().Contains("item"))
                    {
                        String DataSourceTypeName = PropertyObject.getItemByIndex(0).getPropertyAttribute("data_source", "name");
                        updateTechLog("DataSourceTypeName -->" + DataSourceTypeName);

                        if (!string.IsNullOrEmpty(DataSourceTypeName) && DataSourceTypeName.ToLower() != "file")
                        {
                            Item datasourceItem = inn.getItemByKeyedName(DataSourceTypeName, columnValue);
                            if (datasourceItem.getItemCount() > 0)
                            {
                                finalPropertyValue = datasourceItem.getItemByIndex(0).getID();
                            }
                        }
                        if (!string.IsNullOrEmpty(DataSourceTypeName) && DataSourceTypeName.ToLower() == "file")
                        {
                            isFileProperty = true;
                            string fileid = createFileObject(columnValue, FilesFolder);

                            finalPropertyValue = fileid;
                        }
                    }
                    else if (propType == "date")
                    {
                        DateTime _date;

                        _date = DateTime.ParseExact(columnValue, dateformat, new CultureInfo("en-US"));//("5/13/2012");
                        finalPropertyValue = _date.ToString("yyyy-MM-dd HH':'mm':'ss");

                        //inn.getI18NSessionContext().ConvertToNeutral(utcDt, "date", ""yyyy-MM-dd HH':'mm':'ss"");
                    }
                    else if (propType == "list")
                    {
                        //String listName = PropertyObject.getItemByIndex(0).getPropertyAttribute("data_source", "name");
                        // String listid = PropertyObject.getItemByIndex(0).getPropertyAttribute("data_source", "id");



                        finalPropertyValue = getRealValueFromList(propSource, columnValue);
                    }
                    else
                    {
                        finalPropertyValue = columnValue;
                    }

                }

                //Console.WriteLine("New Condole");
            }
            else
            {
                finalPropertyValue = columnValue;
            }

            //
            //throw new NotImplementedException();
            updateTechLog("finalPropertyValue -->" + finalPropertyValue);

            updateTechLog("<<<<<<<<<<<<<<<<<< End the Function .. getPropertyRealValue >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            return finalPropertyValue;
        }

        private static string getRealValueFromList(string listid, string columnValue)
        {
            string listValue = columnValue;

            String sqlStr = "select * from innovator.[VALUE] where source_id ='" + listid + "' and (VALUE ='" + columnValue + "' or LABEL='" + columnValue + "')";

            Item listVauleItem = inn.applySQL(sqlStr);

            if (!listVauleItem.isError())
            {
                listValue = listVauleItem.getItemByIndex(0).getProperty("value", columnValue);
            }

            return listValue;
        }

        private string createFileObject(string FileName, string FilesFolder)
        {
            string realFileName = "";
            string filePath = "";
            updateTechLog("FilesFolder -->" + FilesFolder);
            updateTechLog("FileName   -->" + FileName);

            if (File.Exists(FileName))
            {
                updateTechLog("file exist with the path as --> " + FileName);
                realFileName = Path.GetFileName(FileName);
                filePath = Path.GetFullPath(FileName);
            }
            else if (File.Exists(Path.Combine(FilesFolder, FileName)))
            {
                updateTechLog("file exist with the path as --> " + Path.Combine(FilesFolder, FileName));

                realFileName = Path.GetFileName(Path.Combine(FilesFolder, FileName));
                filePath = Path.GetFullPath(Path.Combine(FilesFolder, FileName));
            }
            else
            {
                is_error = true;
                LineHasError = true;
                updateLog("File not found with the propert value as " + FileName + " in folder Path " + FilesFolder);
                //return;
            }

            updateTechLog("filePath --> " + filePath);
            updateTechLog("realFileName --> " + realFileName);

            Item fileObj = inn.newItem("File", "add");
            fileObj.setProperty("filename", realFileName);
            fileObj.attachPhysicalFile(filePath);
            fileObj = fileObj.apply();
            if (fileObj.isError())
            {

                is_error = true;
                LineHasError = true;
                updateLog("\t\tError while adding file '" + realFileName + "'.." + fileObj.getErrorString());

                //throw new Exception();
            }
            string fileid = fileObj.getID();

            return fileid;
        }

        private void updateFiles(Item CurrRevision, string RelationType, string FilesFolder, string FileName)
        {
            updateTechLog("<<<<<<<<<<<<<<<<<< Start the Function .. updateFiles >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            string realFileName = "";
            string filePath = "";
            updateTechLog("FilesFolder -->" + FilesFolder);
            updateTechLog("FileName   -->" + FileName);

            if (File.Exists(FileName))
            {
                updateTechLog("file exist with the path as --> " + FileName);
                realFileName = Path.GetFileName(FileName);
                filePath = Path.GetFullPath(FileName);
            }
            else if (File.Exists(Path.Combine(FilesFolder, FileName)))
            {
                updateTechLog("file exist with the path as --> " + Path.Combine(FilesFolder, FileName));

                realFileName = Path.GetFileName(Path.Combine(FilesFolder, FileName));
                filePath = Path.GetFullPath(Path.Combine(FilesFolder, FileName));
            }
            else
            {
                is_error = true;
                LineHasError = true;
                updateLog("File not found with the propert value as " + FileName + " in folder Path " + FilesFolder);
                return;
            }

            updateTechLog("filePath --> " + filePath);
            updateTechLog("realFileName --> " + realFileName);

            Item fileObj = inn.newItem("File", "add");
            fileObj.setProperty("filename", realFileName);
            fileObj.attachPhysicalFile(filePath);
            fileObj = fileObj.apply();
            if (fileObj.isError())
            {
                is_error = true;
                LineHasError = true;
                updateLog("\t\tError while adding file '" + realFileName + "'.." + fileObj.getErrorString());

                //throw new Exception();
            }

            if (fileObj.getItemCount() == 1)
            {

                Item fileRelation = inn.newItem(RelationType, "add");
                fileRelation.setProperty("source_id", CurrRevision.getProperty("id"));
                fileRelation.setPropertyItem("attached_file", fileObj);
                //fileRelation.setRelatedItem(fileObj);
                fileRelation = fileRelation.apply();

                if (fileRelation.isError())
                {
                    is_error = true;
                    LineHasError = true;
                    updateLog("\t\tError while attaching  file to relationship'" + realFileName + "'.." + fileRelation.getErrorString());


                    //throw new Exception();
                }
            }
            updateTechLog("<<<<<<<<<<<<<<<<<< End the Function .. updateFiles >>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

        }


    }
}
