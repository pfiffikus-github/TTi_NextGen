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
        bool myNetworkDriveAvailable;

        public frmConfig(bool networkDriveAvailable)
        {
            InitializeComponent();
            myNetworkDriveAvailable = networkDriveAvailable;
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

            if (myNetworkDriveAvailable == false)
            {
                MessageBox.Show("Das Netzlaufwerk '" + Path.GetPathRoot(myLocalSettings.PublicSettingsDirectory) + "' ist nicht verfügbar, weshalb die öffentlichen Einstellungen (Maschinen) nicht gespeichert werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                foreach (var machine in myMachines)
                {
                    if (machine.ControlVersion == Machine.TNCVersions.ab_TNC640)
                    {
                        MessageBox.Show("Das Verwenden der Einstellung 'ab_TNC640' setzt folgendes Paket voraus:\n\n'Microsoft Visual C++ 2010 Redistributable Package (x64)'", "Informtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                myMachines.SerializeXML(myLocalSettings.PublicSettingsDirectory);
            }

            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
