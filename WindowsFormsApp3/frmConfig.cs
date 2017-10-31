using System;
using System.Windows.Forms;


namespace TTi_NextGen
{
    public partial class frmConfig : Form
    {
        LocalSettings myLocalSettings = new LocalSettings();
        Machines myMachines = new Machines();

        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            myLocalSettings = App.InitLocalSettings();

            myLocalSettings.PublicSettingsDirectoryChanged += new EventHandler(UpdateMembers);
            
            UpdateMembers(null, null);

            PropGrid.SelectedObject = myLocalSettings;
        }

        private void UpdateMembers(object sender, EventArgs e)
        {            
            myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);
            myLocalSettings.Machines = myMachines;
            myLocalSettings.AvailableMachines = myMachines.ListOfMachines();
        }
        
        private void OK_Click(object sender, EventArgs e)
        {
            myLocalSettings.SerializeXML();

            myMachines.SerializeXML(myLocalSettings.PublicSettingsDirectory);

            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


    }

}
