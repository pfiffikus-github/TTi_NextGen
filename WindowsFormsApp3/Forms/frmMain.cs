﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
using System.Reflection;
using Microsoft.VisualBasic;

namespace TTi_NextGen
{
    public partial class frmMain : Form
    {
        LocalSettings myLocalSettings;
        Machines myMachines;
        Machine myMachine;
        CNCProgram myCNCProgram;

        public frmMain()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            checkBox2.CheckState = checkBox1.CheckState;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                myNumericUpDown1.Value = myNumericUpDown2.Value;
                checkBox1.ForeColor = Color.OrangeRed;
                checkBox2.ForeColor = Color.OrangeRed;
                myNumericUpDown1.ForeColor = Color.OrangeRed;
                myNumericUpDown2.ForeColor = Color.OrangeRed;
            }
            else
            {
                checkBox1.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                myNumericUpDown1.ForeColor = Color.Black;
                myNumericUpDown2.ForeColor = Color.Black;
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            checkBox1.CheckState = checkBox2.CheckState;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                myNumericUpDown2.Value = myNumericUpDown1.Value;
                checkBox1.ForeColor = Color.OrangeRed;
                checkBox2.ForeColor = Color.OrangeRed;
                myNumericUpDown1.ForeColor = Color.OrangeRed;
                myNumericUpDown2.ForeColor = Color.OrangeRed;
            }
            else
            {
                checkBox1.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                myNumericUpDown1.ForeColor = Color.Black;
                myNumericUpDown2.ForeColor = Color.Black;
            }
        }

        private void timerMainFrm_Tick(object sender, EventArgs e)
        {
            timeStatus.Text = DateTime.Now.ToString("dd.MM.yyyy hh:mm");

            try
            {
                using (Ping _Ping = new Ping())
                {
                    PingReply _Replay = _Ping.Send(myMachine.IP, 5);
                    if (_Replay.Status == IPStatus.Success)
                    {
                        toolStripStatusLabel2.ForeColor = Color.DimGray;
                        toolStripStatusLabel2.Text = "= online (" + myMachine.IP + ")";
                    }
                    else
                    {
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        toolStripStatusLabel2.Text = "= offline (" + myMachine.IP + ")";
                    }
                }

            }
            catch (Exception)
            { }
        }

        private void fmrMain_Load(object sender, EventArgs e)
        {
            ReadOrInitSettings();

            this.Text = App.Title() + " " + App.Version();

            viewHistory.CheckState = CheckState.Unchecked;
            UpdateControls();
            

        }

        private void toolStripMenuItem8_CheckStateChanged(object sender, EventArgs e)
        {
            int Y = treeView3.Size.Height + 8;

            if (viewHistory.CheckState != CheckState.Checked)
            {
                splitContainer1.Size = new Size(splitContainer1.Size.Width, splitContainer1.Size.Height + Y);
            }
            else
            {
                splitContainer1.Size = new Size(splitContainer1.Size.Width, splitContainer1.Size.Height - Y);
            }
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (Interaction.InputBox("Passwort eingeben:", "Anwendungseinstellungen") != "123") { return; }

            WriteHistory("Konfiguration geöffnet", StatusBox.Both, HistoryMessageType.Warning, false, false);

            frmConfig _frmConfig = new frmConfig();

            _frmConfig.ShowDialog();

            if (_frmConfig.DialogResult == DialogResult.OK)
            {
                ReadOrInitSettings();
                UpdateControls();
                WriteHistory("Konfiguration editiert", StatusBox.Both, HistoryMessageType.Warning, false, false);
            }
        }

        private void ReadOrInitSettings()
        {
            myLocalSettings = App.InitLocalSettings();
            myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);

            foreach (Machine _Machine in myMachines)
            {
                if (_Machine.Name == myLocalSettings.DefaultMachine)
                {
                    myMachine = _Machine;
                    return;
                }
            }

            WriteHistory("Standardmaschine '" + myLocalSettings.DefaultMachine + "' konnte nicht geladen werden", StatusBox.Both, HistoryMessageType.Error, false, false);

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
            lblSelectedMachine.Text = "Gewählte Maschine: " + myMachine.Name;
            if (myLocalSettings.ShowAllMachines == false || myMachines.Count <= 1)
            {
                lblSelectedMachine.Enabled = false;
            }
            else
            {
                lblSelectedMachine.Enabled = true;
            }


        }

        private void WriteHistory(string text, StatusBox statusBox, HistoryMessageType type, bool bold, bool subLine)
        {
            string subString = "";
            int insertPos = 0;

            if (subLine == true)
            {
                subString = subString.PadLeft((DateTime.Now.ToString("hh:mm:ss @ ") + System.Net.Dns.GetHostName()).Length + 2);
                insertPos = 1;
            }
            else
            {
                subString = DateTime.Now.ToString("hh:mm:ss @ ") + System.Net.Dns.GetHostName() + ": ";
            }



            text = subString + text;




            TreeNode _tn = new TreeNode(text);

            if (bold == true) { _tn.NodeFont = new Font("Consolas", 8, FontStyle.Bold); }

            switch (type)
            {
                case HistoryMessageType.Information:
                    _tn.ForeColor = Color.DimGray;
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

            switch (statusBox)
            {
                case StatusBox.Left:
                    treeView3.Nodes.Insert(insertPos, _tn);
                    break;
                case StatusBox.Right:
                    treeView4.Nodes.Insert(insertPos, _tn);
                    break;
                case StatusBox.Both:
                    treeView3.Nodes.Insert(insertPos, _tn);
                    TreeNode _tn2 = (TreeNode)_tn.Clone();
                    treeView4.Nodes.Insert(insertPos, _tn2);
                    break;
                default:
                    break;
            }


        }

        private void lblSelectedMachine_TextChanged(object sender, EventArgs e)
        {
            string _subString = "";
            if (myMachine.Name == myLocalSettings.DefaultMachine)
            {
                _subString = " (= Standardmaschine)";
            }

            WriteHistory("'" + myMachine.Name + "'" + _subString + " geladen", StatusBox.Both, HistoryMessageType.Information, false, false);
        }

        private void lblSelectedMachine_Click(object sender, EventArgs e)
        {
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
                    return;
                }
            }
        }

        private void myNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                myNumericUpDown2.Value = myNumericUpDown1.Value;
            }
        }

        private void myNumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                myNumericUpDown1.Value = myNumericUpDown2.Value;
            }
        }

        private enum HistoryMessageType
        {
            Information,
            Warning,
            Error,
        }

        private enum StatusBox
        {
            Left,
            Right,
            Both,
        }

        private void öffnenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog _ofd = new OpenFileDialog();

            _ofd.Multiselect = false;
            _ofd.Filter = "CNC-Programm (*.h)|*.h";
            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                myCNCProgram = new CNCProgram(new FileInfo(_ofd.FileName));

                string[] _lines = new string[] { };

                _lines = myCNCProgram.Lines();      //--> .Lines als Property in CNCProgramm implementieren!!!

                foreach (var _line in _lines)
                {
                    treeView2.Nodes.Add(_line);
                }

                label2.Text = "CNC-Programm\n\n" + myCNCProgram.File.Name;
                tOOLCALLInformationenToolStripMenuItem.Enabled = true;
                WriteHistory("CNC-Programm '" + Path.GetFileName(_ofd.FileName) + "' geladen", StatusBox.Right, HistoryMessageType.Information, true, false);
                WriteHistory("(" + myCNCProgram.MatchesOfToolCalls.Count + "x '" + CNCProgram.ToolCallString  + "' enthalten)" , StatusBox.Right, HistoryMessageType.Information, true, true);
            }


        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(App.Title() + "\n\n" + App.Version() + " Build: " + Assembly.GetExecutingAssembly().GetName().Version.Build, App.Title());
        }

        private void tOOLCALLInformationenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myCNCProgram.GetNoteText() + "\n\n" + myCNCProgram.ToString(), "Information");
        }
    }
}
