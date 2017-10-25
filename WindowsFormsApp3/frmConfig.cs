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

namespace WindowsFormsApp3
{
    public partial class frmConfig : Form
    {
        LocalSettings myLocalSettings = new LocalSettings();

        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {

            if (File.Exists(LocalSettings.LocalSettingsFile))
            {
                myLocalSettings = myLocalSettings.DeserializeXML();
            }
            else
            {              
                myLocalSettings.SerializeXML();
            }

            propertyGrid1.SelectedObject = myLocalSettings;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            myLocalSettings.SerializeXML();
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
