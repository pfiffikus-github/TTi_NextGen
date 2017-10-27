using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;

namespace WindowsFormsApp3
{
    public class LocalSettings
    {

        public LocalSettings()
        {

            ShowAllMachines = true;
            CloseAppAfterSync = false;
            LocalSettingsDirectory = Application.StartupPath;
            PublicSettingsDirectory = Application.StartupPath;
            DefaultMachine = Machine.DefaultMachineName;
        }

        public const string LocalSettingsFile = "LocalSettings.xml";

        public const string PublicSettingsFile = "PublicSettings.xml";

        public bool ShowAllMachines { get; set; }

        public bool CloseAppAfterSync { get; set; }

        public string LocalSettingsDirectory { get; }

        public string PublicSettingsDirectory { get; set; }

        public string DefaultMachine { get; set; }

        public void SerializeXML()
        {
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (StreamWriter sw = new StreamWriter(LocalSettingsFile))
            {
                xs.Serialize(sw, this);
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }

        }

        public LocalSettings DeserializeXML()
        {
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (StreamReader sr = new StreamReader(LocalSettingsFile))
            {
                return (LocalSettings)xs.Deserialize(sr);
            }
        }

    }

    public class Machines : List<Machine>
    {
        public Machines() : base() { }

        public Machines(ICollection<Machine> collection) : base(collection) { }

        public void SerializeXML(string path)
        {
            if (!File.Exists(Path.Combine(path, LocalSettings.PublicSettingsFile)))
            {
                Directory.CreateDirectory(path);
                XmlSerializer xs = new XmlSerializer(this.GetType());
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, LocalSettings.PublicSettingsFile), true))
                {
                    xs.Serialize(sw, this);
                    sw.Flush();
                    sw.Dispose();
                    sw.Close();
                }
            }


        }

        public Machines DeserializeXML(string path)
        {
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (StreamReader sr = new StreamReader(Path.Combine(path, LocalSettings.PublicSettingsFile)))
            {
                return (Machines)xs.Deserialize(sr);
            }
        }
    }

    public class Machine
    {
        public Machine()
        {
            Name = DefaultMachineName;
            IP = "127.0.0.1";
            ToolTable = @"TNC:\Tool.t";
            InvalideToolNameCharakters = @"/\* ()[]{}+!§=?<>;:^°|²³äöü";
            InvalideToolNumbers = new int[] { 1, 2, 3 };
            ProjectDirectory = @"TNC:\Bauteile\";
            DisableToolRangeSelection = false;
        }

        public const string DefaultMachineName = "Default_Machine";

        public string Name { get; set; }

        public string IP { get; set; }

        public string ToolTable { get; set; }

        public string InvalideToolNameCharakters { get; set; }

        public int[] InvalideToolNumbers { get; set; }

        public bool DisableToolRangeSelection { get; set; }

        public string ProjectDirectory { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class App
    {

        public static LocalSettings InitLocalSettings()
        {
            LocalSettings myLocalSettings = new LocalSettings();
            
            if (File.Exists(LocalSettings.LocalSettingsFile))
            {
                myLocalSettings = myLocalSettings.DeserializeXML();
            }
            else
            {
                myLocalSettings.SerializeXML();
            }

            return myLocalSettings;
        }

        public static Machines InitMachines(string path)
        {
            Machines myMachines = new Machines();

            if (File.Exists(Path.Combine(path, LocalSettings.PublicSettingsFile)))
            {
                myMachines = myMachines.DeserializeXML(path);
            }
            else
            {
                myMachines.Add(new Machine());
                myMachines.SerializeXML(path);
            }

            return myMachines;
        }

        public static void ExtractEmbeddedResources()
        {
            string[] _Resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            string[] Exes;

            foreach (var _Resource in _Resources)
            {
                if (_Resource.Contains(".exe"))
                {
                    Exes = _Resource.Split('.');

                    String _FileName = Exes[Exes.Length - 2] + Path.GetExtension(_Resource);

                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_Resource))
                    {
                        if (!File.Exists(_FileName))
                        {
                            FileStream fileStream = new FileStream(_FileName, FileMode.Create);
                            for (int i = 0; i < stream.Length; i++)
                                fileStream.WriteByte((byte)stream.ReadByte());
                            fileStream.Close();
                        }
                    }
                }
            }
        }

    }

}
