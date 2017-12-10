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


        public frmProjectList(string machineName)
        {
            InitializeComponent();

            myLocalSettings = App.InitLocalSettings();
            myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);

            foreach (var item in myMachines)
            {
                if (item.Name == machineName)
                {
                    myMachine = item;
                    break;
                }
            }
            dataGridView1.DataSource = myMachine.Projects;


        }

        private void frmProjectList_Load(object sender, EventArgs e)
        {

            //toolRangeDataGridViewTextBoxColumn.Visible = false;
            toolRangeDataGridViewTextBoxColumn.ReadOnly = true;

            toolRangeTextDataGridViewTextBoxColumn.ReadOnly = true;
            toolRangeTextDataGridViewTextBoxColumn.HeaderText = "ToolRange";
            toolRangeTextDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;

            toolTBackupDataGridViewTextBoxColumn.ReadOnly = true;
            toolTBackupDataGridViewTextBoxColumn.HeaderText = "Backup Tool.t";
            toolTBackupDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;

            projectNameDataGridViewTextBoxColumn.ReadOnly = true;
            projectNameDataGridViewTextBoxColumn.HeaderText = "Werkzeugliste / Projektname";
            projectNameDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;

            commentDataGridViewTextBoxColumn.HeaderText = "Kommentar";

            changedDataGridViewTextBoxColumn.ReadOnly = true;
            changedDataGridViewTextBoxColumn.HeaderText = "Übertragen am";
            changedDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.LightGray;

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
            DataGridViewSelectedRowCollection _rows = dataGridView1.SelectedRows ;



            foreach (var item in _rows)
            {

            }


        }
    }
}
