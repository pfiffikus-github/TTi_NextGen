using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection;

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
            #region SaveLocalSettings

            myLocalSettings.SerializeXML();

            if (myLocalSettings.UseProjectManagement)
            {
                if (MessageBox.Show("Das Verwenden der Projektliste setzt folgendes Paket voraus:\n\n'Microsoft Access Database Engine 2010 Redistributable'\n\nSoll dieses jetzt installiert werden?", "Informtion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    App.ExtractEmbeddedResources("AccessDatabaseEngine.exe", myLocalSettings.LocalSettingsDirectory);
                    try
                    {
                        Process.Start(Path.Combine(myLocalSettings.LocalSettingsDirectory, "AccessDatabaseEngine.exe"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, MethodInfo.GetCurrentMethod().Name);  //Vorgang mit Benutzerkontensteuerung abgebrochen --> Exeption
                    }
                }
            }

            #endregion

            #region SavePublicSettings

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
                        if (MessageBox.Show("Das Verwenden der Einstellung 'ab_TNC640' setzt folgendes Paket voraus:\n\n'Microsoft Visual C++ 2010 Redistributable Package (x64)'\n\nSoll dieses jetzt installiert werden?", "Informtion",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            App.ExtractEmbeddedResources("vcredist_x64.exe", myLocalSettings.LocalSettingsDirectory);
                            try
                            {
                                Process.Start(Path.Combine(myLocalSettings.LocalSettingsDirectory, "vcredist_x64.exe"));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, MethodInfo.GetCurrentMethod().Name);  //Vorgang mit Benutzerkontensteuerung abgebrochen --> Exeption
                            }
                        }
                        break;
                    }
                }
                myMachines.SerializeXML(myLocalSettings.PublicSettingsDirectory);
            }

            DialogResult = DialogResult.OK;
        }
        #endregion

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
