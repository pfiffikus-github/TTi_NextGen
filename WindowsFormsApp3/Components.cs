using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


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
            DefaultMachine = PublicSettings.DefaultMachineName;
        }

        public const string LocalSettingsFile = "LocalSettings.xml";

        public const string PublicSettingsFile = "PublicSettings.xml";

        public bool ShowAllMachines { get; set; }

        public bool CloseAppAfterSync { get; set; }

        public string LocalSettingsDirectory { get; }

        public string PublicSettingsDirectory { get; set; }

        public string DefaultMachine { get; set; }
    }

    public class PublicSettings
    {
        public PublicSettings()
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
