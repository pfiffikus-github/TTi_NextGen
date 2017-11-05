using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;

namespace TTi_NextGen
{
    public partial class frmMain : Form
    {
        LocalSettings myLocalSettings;
        Machines myMachines;
        Machine myMachine;

        public frmMain()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            checkBox2.CheckState = checkBox1.CheckState;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                numericUpDown1.Value = numericUpDown2.Value;
                checkBox1.ForeColor = Color.OrangeRed;
                checkBox2.ForeColor = Color.OrangeRed;
                numericUpDown1.ForeColor = Color.OrangeRed;
                numericUpDown2.ForeColor = Color.OrangeRed;
            }
            else
            {
                checkBox1.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                numericUpDown1.ForeColor = Color.Black;
                numericUpDown2.ForeColor = Color.Black;
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            checkBox1.CheckState = checkBox2.CheckState;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                numericUpDown2.Value = numericUpDown1.Value;
                checkBox1.ForeColor = Color.OrangeRed;
                checkBox2.ForeColor = Color.OrangeRed;
                numericUpDown1.ForeColor = Color.OrangeRed;
                numericUpDown2.ForeColor = Color.OrangeRed;
            }
            else
            {
                checkBox1.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                numericUpDown1.ForeColor = Color.Black;
                numericUpDown2.ForeColor = Color.Black;
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
            App.ExtractEmbeddedResources();
            ReadOrInitSettings();
            this.Text = App.AppTitle();

            viewHistory.CheckState = CheckState.Unchecked;
            UpdateControls();
        }

        private void toolStripMenuItem8_CheckStateChanged(object sender, EventArgs e)
        {
            int Y = richTextBox1.Size.Height + 8;

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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                numericUpDown2.Value = numericUpDown1.Value;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                numericUpDown1.Value = numericUpDown2.Value;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            frmConfig _frmConfig = new frmConfig();

            _frmConfig.ShowDialog();

            if (_frmConfig.DialogResult == DialogResult.OK)
            {
                ReadOrInitSettings();
                UpdateControls();
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

        private void WriteHistoryToolList(string Text, HistoryMessageType type)
        {
            richTextBox1.Text = DateTime.Now.ToString("hh:mm:ss ") + Text + "\n" + richTextBox1.Text;
        }

        private void WriteHistoryCNC(string Text, HistoryMessageType type)
        {
            richTextBox2.Text = DateTime.Now.ToString("hh:mm:ss ") + Text + "\n" + richTextBox2.Text;
        }

        private enum HistoryMessageType
        {
            Information,
            Warning,
            Error,
        }

        private void lblSelectedMachine_TextChanged(object sender, EventArgs e)
        {
            WriteHistoryToolList("'" + myMachine.Name + "' geladen", HistoryMessageType.Information);
            WriteHistoryCNC("'" + myMachine.Name + "' geladen", HistoryMessageType.Information);
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
    }
}
