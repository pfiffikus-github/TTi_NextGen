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
                Ping _Ping = new Ping();
                PingReply _Replay = _Ping.Send(myMachine.IP, 5);
                if (_Replay.Status == IPStatus.Success)
                {
                    toolStripStatusLabel2.ForeColor = Color.DimGray;
                    lblSelectedMachine.ForeColor = Color.DimGray;
                    toolStripStatusLabel2.Text = "= online (" + myMachine.IP + ")";
                }
                else
                {
                    toolStripStatusLabel2.ForeColor = Color.Red;
                    lblSelectedMachine.ForeColor = Color.Red;
                    toolStripStatusLabel2.Text = "= offline (" + myMachine.IP + ")";
                }
            }
            catch (Exception)
            { }
        }

        private void fmrMain_Load(object sender, EventArgs e)
        {
            App.ExtractEmbeddedResources();
            ReadOrInitSettings();
            UpdateControls();
        }

        private void toolStripMenuItem8_CheckStateChanged(object sender, EventArgs e)
        {
            int Y = richTextBox1.Size.Height + 8;

            if (toolStripMenuItem8.CheckState != CheckState.Checked)
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

            myLocalSettings.Machines = myMachines;
            myLocalSettings.AvailableMachines = myMachines.ListOfMachines();

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
            toolStripMenuItem8.CheckState = CheckState.Unchecked;
            checkBox1.CheckState = CheckState.Checked;
            lblSelectedMachine.Text = myMachine.Name;   //myLocalSettings.DefaultMachine;
            if (myLocalSettings.ShowAllMachines == false)
            {
                ChooseMachine.Visible = false;
            }
            else
            {
                ChooseMachine.Visible = true;
            }


        }

        private void ChooseMachine_Click(object sender, EventArgs e)
        {
            frmChooseMachine _cm = new frmChooseMachine();
            String _selectedMachine = _cm.ShowDia(myMachine.ToString(), myMachines.ListOfMachines());

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
