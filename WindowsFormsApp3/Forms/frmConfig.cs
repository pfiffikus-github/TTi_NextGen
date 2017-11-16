using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

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

            myLocalSettings.PublicSettingsDirectoryChanged += MyLocalSettings_PublicSettingsDirectoryChanged; //Event konsumieren

            MyLocalSettings_PublicSettingsDirectoryChanged(null, null);

            PropGrid.SelectedObject = myLocalSettings;
        }

        private void MyLocalSettings_PublicSettingsDirectoryChanged(object sender, EventArgs e)
        {
            myLocalSettings = App.InitLocalSettings();      //lese Lokale Einstellungen

            if (Path.GetPathRoot(myLocalSettings.PublicSettingsDirectory) != Path.GetPathRoot(Application.StartupPath))   //prüfe, ob Netzlaufwerk verwendet wird
            {
                if (System.IO.Directory.Exists(Path.GetPathRoot(myLocalSettings.PublicSettingsDirectory)))      //prüfe, ob Pfad existiert
                {
                    myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);
                }
                else
                {
                    myMachines = App.InitMachines(Application.StartupPath);

                }
            }
            else
            {
                myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);
            }
            
            myLocalSettings.Machines = myMachines;
            myLocalSettings.DefaultMachineBackground = myMachines.ListOfMachines();
            
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
