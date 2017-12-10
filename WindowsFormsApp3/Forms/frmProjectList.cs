using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTi_NextGen
{
    public partial class frmProjectList : Form
    {
        private Machine myMachine;
        private Machines myMachines;
        private LocalSettings myLocalSettings;


        public frmProjectList(string machineName, bool readOnlyMode)
        {
            InitializeComponent();

            myLocalSettings = App.InitLocalSettings();
            string path = myLocalSettings.PublicSettingsDirectory;

            if (readOnlyMode)
            {
                MessageBox.Show("Das Netzlaufwerk ist nicht verfügbar, weshalb keine Änderungen an der Maschinen-Projekt-Liste vorgenommen werden können.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button2.Enabled = false;
                OK.Enabled = false;
                path = Application.StartupPath;
            }

            myMachines = App.InitMachines(path);

            foreach (var item in myMachines)
            {
                if (item.Name == machineName)
                {
                    myMachine = item;
                    Text = Text + myMachine.Name;
                    break;
                }
            }

            dataGridView1.DataSource = myMachine.Projects;
        }

        private void frmProjectList_Load(object sender, EventArgs e)
        {

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            toolRangeDataGridViewTextBoxColumn.Visible = false;
            //toolRangeDataGridViewTextBoxColumn.ReadOnly = true;

            toolRangeTextDataGridViewTextBoxColumn.ReadOnly = true;
            toolRangeTextDataGridViewTextBoxColumn.HeaderText = "ToolRange";
            toolRangeTextDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;
            toolRangeTextDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            toolTBackupDataGridViewTextBoxColumn.ReadOnly = true;
            toolTBackupDataGridViewTextBoxColumn.HeaderText = "Backup Tool.t";
            toolTBackupDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;
            toolTBackupDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            projectNameDataGridViewTextBoxColumn.HeaderText = "Werkzeugliste / Projektname";
            projectNameDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;
            projectNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            commentDataGridViewTextBoxColumn.HeaderText = "Kommentar";
            commentDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            changedDataGridViewTextBoxColumn.ReadOnly = true;
            changedDataGridViewTextBoxColumn.HeaderText = "Übertragen am";
            changedDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;
            changedDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            myMachines.SerializeXML(myLocalSettings.PublicSettingsDirectory);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                myMachine.Projects[0] = new Project(0);
            }
            else
            {
                myMachine.Projects[dataGridView1.CurrentCell.RowIndex] = new Project(dataGridView1.CurrentCell.RowIndex);
            }

            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}
