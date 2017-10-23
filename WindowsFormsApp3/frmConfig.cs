﻿using System;
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
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {

        }

        private void saveLocalSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LocalSettings));
            FileStream fs = new FileStream(LocalSettings.LocalSettingsFile, FileMode.Create);
            TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
            //serializer.Serialize(writer, myLocalSettings);
            writer.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            saveLocalSettings();
            Close();
        }

        private void InitLocalSettings()
        {
            if (File.Exists(LocalSettings.LocalSettingsFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LocalSettings));

                using (Stream reader = new FileStream(LocalSettings.LocalSettingsFile, FileMode.Open))
                {
                    //myLocalSettings = (LocalSettings)serializer.Deserialize(reader);
                }
            }
            else
            {
                //myLocalSettings = new LocalSettings();
                saveLocalSettings();
            }

        }
    }
}
