using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

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

            //if (File.Exists(LocalSettings.LocalSettingsFile))
            //{
            //    myLocalSettings = myLocalSettings.DeserializeXML();
            //}
            //else
            //{
            //    myLocalSettings.SerializeXML();
            //}

            //if (File.Exists(Path.Combine(myLocalSettings.PublicSettingsDirectory, LocalSettings.PublicSettingsFile)))
            //{
            //    myMachines = myMachines.DeserializeXML(myLocalSettings.PublicSettingsDirectory);
            //}
            //else
            //{
            //    myMachines.Add(new Machine());
            //    myMachines.SerializeXML(myLocalSettings.PublicSettingsDirectory);
            //}

            #region InitAppAndSettings

            App.ExtractEmbeddedResources();
            myLocalSettings = App.InitLocalSettings();
            myMachines = App.InitMachines(myLocalSettings.PublicSettingsDirectory);

            myLocalSettings.Machines = myMachines;
            myLocalSettings.AvailableMachines = myMachines.ListOfMachines();

            #endregion


            propertyGrid1.SelectedObject = myLocalSettings;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            myLocalSettings.SerializeXML();
            myMachines.SerializeXML(myLocalSettings.PublicSettingsDirectory);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
