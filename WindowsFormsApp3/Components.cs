using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp3
{
    public class LocalSettings
    {
        public LocalSettings()
        {
            ShowAllMachines = true;
            CloseAppAfterSync = false;
            LocalSettingsDirectory = Path.Combine(Application.StartupPath, LocalSettingsFile);
            PublicSettingsDirectory = Path.Combine(Application.StartupPath, PublicSettingsFile);
            DefaultMachine = MachineItem.DefaultMachineName;
        }

        public const string LocalSettingsFile = "LocalSettings.xml";

        public const string PublicSettingsFile = "PublicSettings.xml";

        public bool ShowAllMachines { get; set; }

        public bool CloseAppAfterSync { get; set; }

        public string LocalSettingsDirectory { get; }

        public string PublicSettingsDirectory { get; set; }

        public string DefaultMachine { get; set; }

        public static LocalSettings Instance { get; private set; }
        


        public void Save()
        {
            var serializer = new XmlSerializer(typeof(LocalSettings));

            using (var fStream = new FileStream(LocalSettings.LocalSettingsFile, FileMode.Create))
                serializer.Serialize(fStream, this);
        }
        
        public static void Load()
        {
            var serializer = new XmlSerializer(typeof(LocalSettings));

            using (var fStream = new FileStream(LocalSettings.LocalSettingsFile, FileMode.Open))
                LocalSettings.Instance = (LocalSettings)serializer.Deserialize(fStream);
        }
        
    }

    public class PublicSettings
    {
        public MachineItem myMachineItems { get; set; }

        public string myString { get; set; }

    }

    public class MachineItem
    {    
        public MachineItem()
        {
            MachineName = DefaultMachineName;
            IP = "127.0.0.1";
            ToolTable = @"TNC:\Tool.t";
            InvalideToolNameCharakters = @"/\* ()[]{}+!§=?<>;:^°|²³äöü";
            InvalideToolNumbers = new int[] { 1, 2, 3 };
            ProjectDirectory = @"TNC:\Bauteile\";
        }

        public const string DefaultMachineName = "Machine";

        public string MachineName { get; set; }

        public string IP { get; set; }

        public string ToolTable { get; set; }

        public string InvalideToolNameCharakters { get; set; }

        public int[] InvalideToolNumbers { get; set; }

        public bool DisableToolRangeSelection { get; set; }

        public string ProjectDirectory { get; set; }
    }
}
