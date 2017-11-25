using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Net;

namespace TTi_NextGen
{
    public partial class frmMain : Form
    {
        LocalSettings myLocalSettings;
        Machines myMachines;
        Machine myMachine;
        CNCProgram myCNCProgram;
        bool myNetworkDriveAvailable = true;
        TreeNode[] myToolCallNodes;


        public frmMain()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            checkBox2.CheckState = checkBox1.CheckState;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                comboBox1.SelectedIndex = comboBox2.SelectedIndex;
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Bold);
                checkBox2.Font = new Font(checkBox2.Font, FontStyle.Bold);

                //checkBox1.ForeColor = Color.OrangeRed;
                //checkBox2.ForeColor = Color.OrangeRed;
                //comboBox1.ForeColor = Color.OrangeRed;
                //comboBox2.ForeColor = Color.OrangeRed;
            }
            else
            {
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Regular);
                checkBox2.Font = new Font(checkBox2.Font, FontStyle.Regular);
                //checkBox1.ForeColor = Color.Black;
                //checkBox2.ForeColor = Color.Black;
                //comboBox1.ForeColor = Color.Black;
                //comboBox2.ForeColor = Color.Black;
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            checkBox1.CheckState = checkBox2.CheckState;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                comboBox2.SelectedIndex = comboBox1.SelectedIndex;
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Bold);
                checkBox2.Font = new Font(checkBox2.Font, FontStyle.Bold);
                //checkBox1.ForeColor = Color.OrangeRed;
                //checkBox2.ForeColor = Color.OrangeRed;
                //comboBox1.ForeColor = Color.OrangeRed;
                //comboBox2.ForeColor = Color.OrangeRed;
            }
            else
            {
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Regular);
                checkBox2.Font = new Font(checkBox2.Font, FontStyle.Regular);
                //checkBox1.ForeColor = Color.Black;
                //checkBox2.ForeColor = Color.Black;
                //comboBox1.ForeColor = Color.Black;
                //comboBox2.ForeColor = Color.Black;
            }
        }

        private void timerMainFrm_Tick(object sender, EventArgs e)
        {
            timeStatus.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            try
            {
                using (Ping _Ping = new Ping())
                {
                    PingReply _Replay = _Ping.Send(myMachine.IP, 5);
                    if (_Replay.Status == IPStatus.Success)
                    {
                        toolStripStatusLabel2.ForeColor = Color.DimGray;
                        toolStripStatusLabel2.Text = "= online";
                    }
                    else
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = "= offline";
                    }
                }

            }
            catch (Exception)
            { }
        }

        private void fmrMain_Load(object sender, EventArgs e)
        {
            TempJob.Text = "Init App";

            History_1.NodeMouseClick += (senderX, args) => History_1.SelectedNode = args.Node;  //NodeMouseClick Event, damit Rechtsklick auf Node, diesen auch auswählt...

            WriteHistory(Environment.UserName + " @ " + Dns.GetHostName() + ": " + App.Title() + " " + App.Version() + " gestartet", HistoryMessageType.Information);



            ReadOrInitSettings();

            this.Text = App.Title() + " " + App.Version();

            viewHistory.CheckState = CheckState.Unchecked;
            UpdateControls();

            EnabledCNCProgrammControls();

            if (myLocalSettings.ShowHistory)
            {
                viewHistory.CheckState = CheckState.Checked;
            }


            TempJobClear();

        }

        private void toolStripMenuItem8_CheckStateChanged(object sender, EventArgs e)
        {
            int Y = History_1.Size.Height + 8;

            if (viewHistory.CheckState != CheckState.Checked)
            {
                History_1.Visible = false;
            }
            else
            {
                History_1.Visible = true;
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //if (Interaction.InputBox("Passwort eingeben:", "Anwendungseinstellungen") != "123") { return; }

            frmConfig _frmConfig = new frmConfig(myNetworkDriveAvailable);

            _frmConfig.ShowDialog();

            if (_frmConfig.DialogResult == DialogResult.OK)
            {
                ReadOrInitSettings();
                UpdateControls();
                WriteHistory("Konfiguration editiert", HistoryMessageType.Information);
            }
        }

        private void ReadOrInitSettings()
        {
            myLocalSettings = App.InitLocalSettings();      //lese Lokale Einstellungen
            toolStripStatusLabel1.Text = ""; //status Netzlaufwerk


            if (Path.GetPathRoot(myLocalSettings.PublicSettingsDirectory) != Path.GetPathRoot(Application.StartupPath)) //prüfe, ob Netzlaufwerk verwendet wird
            {
                if (System.IO.Directory.Exists(Path.GetPathRoot(myLocalSettings.PublicSettingsDirectory)))   //prüfe, ob Pfad existiert
                {
                    myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);
                    FileSystem.FileCopy(Path.Combine(myLocalSettings.PublicSettingsDirectory, LocalSettings.PublicSettingsFile),    //Kopie der Maschinen lokal speichern, falls Netzlaufwerk später evtl. nicht verfügbar
                                        Path.Combine(Application.StartupPath, LocalSettings.PublicSettingsFile));
                    FileSystem.FileCopy(Path.Combine(myLocalSettings.PublicSettingsDirectory, "tool_table.template"),
                                        Path.Combine(Application.StartupPath, "tool_table.template"));
                }
                else
                {
                    myMachines = App.InitMachines(Application.StartupPath);
                    myNetworkDriveAvailable = false;

                    toolStripStatusLabel1.Text = "'" + Path.GetPathRoot(myLocalSettings.PublicSettingsDirectory) + "' nicht verfügbar!";
                    toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;

                    WriteHistory("Die öffentlichen Eintellungen (Maschinen) konnten nicht im Netzlaufwerk '" + myLocalSettings.PublicSettingsDirectory + "' geladen werden.", HistoryMessageType.Error, FontStyle.Bold, true, false);
                    WriteHistory("Netzlaufwerk evtl. nicht verfügbar! Es wird ein lokales Backup der Maschinen-Datei verwendet.", HistoryMessageType.Error, FontStyle.Bold, false);

                    MessageBox.Show("Die öffentlichen Eintellungen (Maschinen) konnten nicht im Netzlaufwerk '" + myLocalSettings.PublicSettingsDirectory + "' geladen werden.\n\nEs wird ein lokales Backup der Maschinen-Datei verwendet.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);
            }

            foreach (Machine _Machine in myMachines)
            {
                if (_Machine.Name == myLocalSettings.DefaultMachine)
                {
                    myMachine = _Machine;
                    return;
                }
            }

            WriteHistory("Standardmaschine '" + myLocalSettings.DefaultMachine + "' konnte nicht geladen werden", HistoryMessageType.Error, FontStyle.Bold);

            myMachine = myMachines[0];
            MessageBox.Show("Die Standardmaschine '" +
                myLocalSettings.DefaultMachine + "' konnte nicht geladen werden. Sie ist in den Einstellungen nicht definiert: \n\n" +
                System.IO.Path.Combine(myLocalSettings.PublicSettingsDirectory, LocalSettings.PublicSettingsFile) +
                "\n\nEs wurde die Maschine '" + myMachine.Name + "' geladen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UpdateControls()
        {
            timerMainFrm_Tick(null, null);
            checkBox1.CheckState = CheckState.Checked;
            lblSelectedMachine.Text = myMachine.Name;
            if (myLocalSettings.ShowAllMachines == false || myMachines.Count <= 1)
            {
                lblSelectedMachine.Enabled = false;
            }
            else
            {
                lblSelectedMachine.Enabled = true;
            }


        }

        private void WriteHistory(string text,
            HistoryMessageType type = HistoryMessageType.Information,
            FontStyle style = FontStyle.Regular,
            bool withTime = true,
            bool addSpaceLine = true)
        {

            if (withTime & text != "")
            {
                text = DateTime.Now.ToString("HH:mm:ss ") + text;
            }
            else
            {
                text = "".PadLeft((DateTime.Now.ToString("HH:mm:ss ").Length)) + text;
            }

            TreeNode _tn = new TreeNode(text);

            _tn.NodeFont = new Font("Consolas", 8, style);

            switch (type)
            {
                case HistoryMessageType.Information:
                    _tn.ForeColor = Color.Black;
                    break;
                case HistoryMessageType.Warning:
                    _tn.ForeColor = Color.Orange;
                    break;
                case HistoryMessageType.Error:
                    _tn.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }

            History_1.Nodes.Add(_tn); _tn.EnsureVisible();
            if (addSpaceLine) { History_1.Nodes.Add(""); }

        }

        private void lblSelectedMachine_TextChanged(object sender, EventArgs e)
        {
            string _subString = "";
            if (myMachine.Name == myLocalSettings.DefaultMachine)
            {
                _subString = " (= Standardmaschine)";
            }

            int tmpRangeToolList = comboBox1.SelectedIndex;
            int tmpRangeCNCPorgramm = comboBox2.SelectedIndex;


            int maxToolRange = myMachine.MaxToolRange;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i < maxToolRange; i++)
            {
                comboBox1.Items.Add((i * 1000).ToString() + "..." + ((i * 1000) + 999).ToString());
                comboBox2.Items.Add((i * 1000).ToString() + "..." + ((i * 1000) + 999).ToString());
            }


            if (tmpRangeToolList >= myMachine.MaxToolRange)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = tmpRangeToolList;
            }

            if (tmpRangeToolList >= myMachine.MaxToolRange)
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.SelectedIndex = tmpRangeCNCPorgramm;
            }


            WriteHistory("Maschine '" + myMachine.Name + "' geladen" + _subString, HistoryMessageType.Information);
        }

        private void lblSelectedMachine_Click(object sender, EventArgs e)
        {
            //if (myCNCProgram != null)
            //{
            //    if (MessageBox.Show("CNC-Programm bereits geladen: " + myCNCProgram.File.Name +
            //        "\n\nBei Auswahl einer anderen Maschine wird das CNC-Programm erneut " +
            //        "geladen/aktualisiert.\n\nMöchten Sie fortfahren?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    {
            //        return;
            //    }
            //}

            frmChooseMachine _cm = new frmChooseMachine();
            String _selectedMachine = _cm.ShowDia(myMachine.ToString(), myMachines.ListOfMachines());

            if (_selectedMachine == myMachine.Name)
            {
                return;
            }

            foreach (Machine _Machine in myMachines)
            {
                if (_selectedMachine == _Machine.Name)
                {
                    myMachine = _Machine;
                    UpdateControls();
                    if (myCNCProgram != null)
                    {
                        öffnenToolStripMenuItem1_Click(aktualisierenToolStripMenuItem, null);
                    }
                    return;
                }
            }
        }

        private enum HistoryMessageType
        {
            Information,
            Warning,
            Error,
        }

        private void öffnenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TempJob.Text = "Lädt...";
            this.Update();
            ToolStripMenuItem _tsmi = (ToolStripMenuItem)sender;


            if (_tsmi.Text == "Öffnen")
            {
                OpenFileDialog _ofd = new OpenFileDialog
                {
                    Multiselect = false,
                    Filter = "CNC-Programm (*.h)|*.h"
                };

                if (_ofd.ShowDialog() == DialogResult.OK)
                {
                    myCNCProgram = null;
                    myCNCProgram = new CNCProgram(new FileInfo(_ofd.FileName), myMachine.RestrictivToolNumbers);

                    EnabledCNCProgrammControls();
                    BuildTreeViewCNCProgram(true);
                }
                else
                {
                    TempJobClear();
                    return;
                }
            }
            else //Aktualisieren
            {
                comboBox2.SelectedIndex = comboBox2.SelectedIndex - 1;
                string _file = myCNCProgram.File.FullName;

                myCNCProgram = null;
                try
                {
                    myCNCProgram = new CNCProgram(new FileInfo(_file), myMachine.RestrictivToolNumbers);
                }
                catch (Exception)
                {
                    WriteHistory("CNC-Programm '" + Path.GetFileName(_file) + "' nicht gefunden -> CNC-Programm wird entladen", HistoryMessageType.Error, FontStyle.Bold);
                    schließenToolStripMenuItem1_Click(null, null);
                    TempJobClear();
                    return;
                }
                BuildTreeViewCNCProgram(true);
            }

            //write history



            WriteHistory("CNC-Programm '" + Path.GetFileName(myCNCProgram.File.FullName) + "' geladen/aktualisiert", HistoryMessageType.Information, FontStyle.Bold, true, false);

            if (myCNCProgram.IsToolRangeConsistent != true)
            {
                WriteHistory("" + myCNCProgram.MatchesOfToolCalls.Count + "x '" + CNCProgram.ToolCallString +
                             "' in verschiedenen Tool-Ranges enthalten",
                             HistoryMessageType.Error, FontStyle.Italic, false, false);
            }
            else
            {

                WriteHistory("" + myCNCProgram.MatchesOfToolCalls.Count + "x '" + CNCProgram.ToolCallString +
                             "' in Tool-Range '" + myCNCProgram.OriginalToolRange.ToString() + "' enthalten",
                             HistoryMessageType.Information, FontStyle.Italic, false, false);
            }

            string _line = "[";
            foreach (string _str in myCNCProgram.EachToolCallValues())
            {
                _line += _str.Replace(CNCProgram.ToolCallString, "").Trim() + ", ";
            }
            _line = _line.Remove(_line.Length - 2, 1).Trim() + "]";

            WriteHistory(_line, HistoryMessageType.Information, FontStyle.Italic, false, true);

            //lbl-Text
            label2.Text = "CNC-Programm\n\n" + myCNCProgram.File.Name;

            //set restrictivToolValues

            TempJobClear();
            
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(App.Title() + "\n\n" + App.Version() + " Build: " + Assembly.GetExecutingAssembly().GetName().Version.Build, App.Title());
        }

        private void tOOLCALLInformationenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myCNCProgram.GetNoteText() + "\n\n" + myCNCProgram.ToString(), "Information");
        }

        private void EnabledCNCProgrammControls()
        {
            bool _Enabled = false;

            if (myCNCProgram != null) { _Enabled = true; }

            aktualisierenToolStripMenuItem.Enabled = _Enabled;
            speichernToolStripMenuItem1.Enabled = _Enabled;
            speichernUnterToolStripMenuItem1.Enabled = _Enabled;
            schließenToolStripMenuItem1.Enabled = _Enabled;
            pfadÖffnenToolStripMenuItem3.Enabled = _Enabled;
            dateiÖffnenToolStripMenuItem3.Enabled = _Enabled;
            eigenschaftenToolStripMenuItem1.Enabled = _Enabled;
            speichernÜbertragenToolStripMenuItem.Enabled = _Enabled;
            checkBox2.Enabled = _Enabled;
            button4.Enabled = _Enabled;
            tOOLCALLInformationenToolStripMenuItem.Enabled = _Enabled;
            toolStripMenuItem7.Enabled = _Enabled;
            comboBox2.Enabled = _Enabled;
        }

        private void schließenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            myCNCProgram = null;
            BuildTreeViewCNCProgram(true);
            EnabledCNCProgrammControls();
            label2.Text = "CNC-Programm\n\n*.h";
            WriteHistory("CNC-Programm entladen", HistoryMessageType.Information, FontStyle.Bold);
        }

        private void pfadÖffnenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Process.Start(myCNCProgram.File.DirectoryName);
        }

        private void dateiÖffnenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Process.Start(@"notepad.exe", myCNCProgram.File.FullName);
        }

        private void BuildTreeViewCNCProgram(bool ShowOnlyToolCall)
        {
            if (myCNCProgram != null)
            {
                if (myCNCProgram.OriginalToolRange >= myMachine.MaxToolRange)
                {
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    comboBox2.SelectedIndex = myCNCProgram.OriginalToolRange;
                }

                myToolCallNodes = null;
                myToolCallNodes = new TreeNode[0];


                treeView2.BeginUpdate();
                treeView2.Nodes.Clear();

                string[] _lines = new string[] { };
                _lines = myCNCProgram.FileContent.Split('\n');
                ProgressBar.Maximum = _lines.Length;

                int i = 0;
                foreach (var _line in _lines)
                {

                    ProgressBar.Value = Array.IndexOf(_lines, _line, i);
                    i++;

                    TreeNode _newNode = treeView2.Nodes.Add(_line);
                    if (_line.Contains(CNCProgram.ToolCallString))
                    {
                        _newNode.ForeColor = Color.Blue;
                        _newNode.BackColor = Color.LightBlue;
                        _newNode.NodeFont = new Font(treeView2.Font, FontStyle.Bold);
                        Array.Resize(ref myToolCallNodes, myToolCallNodes.Length + 1);
                        myToolCallNodes[myToolCallNodes.Length - 1] = _newNode;
                    }

                }















                //TreeNode _test = new TreeNode();



                int _test;
                _test = treeView2.Nodes.IndexOf(myToolCallNodes[0]);




                treeView2.Nodes[_test].Text = "";



                treeView2.EndUpdate();
                ProgressBar.Value = 0;

            }
            else
            {
                treeView2.BeginUpdate();
                treeView2.Nodes.Clear();
                treeView2.EndUpdate();
            }
        }

        private void speichernUnterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.ShowDialog();

        }

        private int ExtractInt(string AtString = "0") //aus 1000...1999, 1 extrahieren 
        {
            string[] _tmpStr = new string[] { };

            _tmpStr = AtString.Split(new string[1] { "..." }, 2, StringSplitOptions.None);

            try
            {
                return int.Parse(_tmpStr[0]) / 1000;
            }
            catch (Exception)
            {

                return -1;
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myCNCProgram == null) { return; }

            //if (myCNCProgram.OriginalToolRange != ExtractInt(comboBox2.Text))
            //{
            //    speichernToolStripMenuItem1.Enabled = true;
            //}
            //else
            //{
            //    speichernToolStripMenuItem1.Enabled = false;
            //}

            if (checkBox1.CheckState == CheckState.Checked) //für Sync
            {
                comboBox1.Text = comboBox2.Text;
            }

            if (ExtractInt(comboBox2.Text) == myCNCProgram.OriginalToolRange)
            {
                comboBox2.Font = new Font(comboBox2.Font, FontStyle.Bold);
            }
            else
            {
                comboBox2.Font = new Font(comboBox2.Font, FontStyle.Regular);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myCNCProgram == null) { return; }

            if (checkBox1.CheckState == CheckState.Checked) //für Sync
            {
                comboBox2.Text = comboBox1.Text;
            }

            if (ExtractInt(comboBox1.Text) == myCNCProgram.OriginalToolRange)
            {
                comboBox1.Font = new Font(comboBox1.Font, FontStyle.Bold);
            }
            else
            {
                comboBox1.Font = new Font(comboBox1.Font, FontStyle.Regular);
            }
        }

        private void infoMaschineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProp _frmProp = new frmProp(myMachine);
            _frmProp.ShowDialog();
        }

        private void speichernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            myCNCProgram.ChangeToolRange(ExtractInt(comboBox2.Text), true);
            WriteHistory("CNC-Programm '" + myCNCProgram.File.Name + "': Tool-Range erfolgreich in '" + comboBox2.Text + "' geändert", HistoryMessageType.Information, FontStyle.Bold);
            öffnenToolStripMenuItem1_Click(aktualisierenToolStripMenuItem, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            speichernToolStripMenuItem1_Click(null, null);

            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = @"TNCsync.exe";
            proc.Arguments = @"-I " + myMachine.IP + " MkDir " + Path.GetDirectoryName(myMachine.ProjectDirectory);
            Process.Start(proc);

            proc = null;
            proc = new ProcessStartInfo();
            proc.FileName = @"TNCsync.exe";
            proc.Arguments = @"Put " + myCNCProgram.File.FullName + " " + Path.GetDirectoryName(myMachine.ProjectDirectory) + myCNCProgram.File.Name + " /A" + " -I " + myMachine.IP;
            Process.Start(proc);

        }



        private void verlaufLeerenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                TreeNode node = this.History_1.SelectedNode;
                if (node != null)
                {
                    Clipboard.SetDataObject(node.Text.ToString(), true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void nurTOOLCALLsAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempJob.Text = "Lädt CNC-Programm...";
        }

        private void TempJobClear()
        {
            TempJob.Text = "Bereit";
        }
    }
}