using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing.Design;
using System.ComponentModel.Design;


namespace TTi_NextGen
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

        private EventHandler _PublicSettingsDirectoryChanged;

        public event EventHandler PublicSettingsDirectoryChanged
        {
            add { _PublicSettingsDirectoryChanged += value; }
            remove { _PublicSettingsDirectoryChanged -= value; }
        }

        public const string LocalSettingsFile = "LocalSettings.xml";

        public const string PublicSettingsFile = "PublicSettings.xml";

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Auswahl aller Maschinen anzeigen")]
        public bool ShowAllMachines { get; set; }

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Anwendung nach Datenübertragung schließen")]
        public bool CloseAppAfterSync { get; set; }

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Pfad der loaklen Einstellungsdatei")]
        public string LocalSettingsDirectory { get; }

        private string myPublicSettingsDirectory;
        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Pfad der öffentlichen Einstellungsdatei (Liste aller Maschinen)"),
         Editor(typeof(PropertyGridSelectFolder), typeof(UITypeEditor)),
         TypeConverter(typeof(CancelEditProp))]
        public string PublicSettingsDirectory
        {
            get { return myPublicSettingsDirectory; }
            set
            {
                myPublicSettingsDirectory = value;
                if (_PublicSettingsDirectoryChanged != null)
                {
                    this._PublicSettingsDirectoryChanged(this, new EventArgs());
                }
            }
        }

        private string[] myAvailableMachines;
        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Liste der verfügbaren Maschinen zur Wahl der Standardmaschine"),
         XmlIgnoreAttribute]
        public string[] AvailableMachines
        {
            get { return myAvailableMachines; }
            set
            {
                myAvailableMachines = value;
            }
        }

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Maschine, welche nach Anwendungsstart automatisch ausgewählt wird"),
         ReadOnlyAttribute(true)]
        public String DefaultMachine { get; set; }

        [CategoryAttribute("Öffentliche Einstellungen"),
         DescriptionAttribute("Liste der verfügbaren Maschinen zur Wahl der Standardmaschine"),
         XmlIgnoreAttribute]
        public Machines Machines { get; set; }

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

    public class Machines : Collection<Machine>
    {
        public Machines() : base() { }

        public string[] ListOfMachines()
        {
            string[] _tmp = new string[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                _tmp[i] = base[i].ToString();
            }
            return _tmp;
        }

        protected override void InsertItem(int index, Machine insertItem)
        {
            foreach (var item in this)
            {
                if (item.Name == insertItem.Name)
                {
                    return;
                }
            }
            base.InsertItem(index, insertItem);
        }

        protected override void ClearItems()
        {
            if (Count == 1)
            {
                return;
            }
            base.ClearItems();
        }

        public void SerializeXML(string path)
        {
            Directory.CreateDirectory(path);
            XmlSerializer xs = new XmlSerializer(this.GetType());
            using (StreamWriter sw = new StreamWriter(Path.Combine(path, LocalSettings.PublicSettingsFile)))
            {
                xs.Serialize(sw, this);
                sw.Flush();
                sw.Dispose();
                sw.Close();
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

        public override string ToString()
        {
            return "Liste über " + this.Count + " Maschine/n";
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

        public Machine(String name) : this()
        {
            Name = name;
        }

        public const string DefaultMachineName = "Machine";

        public string Name { get; set; }

        [CategoryAttribute("Kommunikation"),
         DescriptionAttribute("Die IP-Adresse der Maschine"),
         Editor(typeof(TypEditorEditIP), typeof(UITypeEditor)),
         TypeConverter(typeof(CancelEditProp))]
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
            string[] _Exes;

            foreach (var _Resource in _Resources)
            {
                if (_Resource.Contains(".exe"))
                {
                    _Exes = _Resource.Split('.');

                    String _FileName = _Exes[_Exes.Length - 2] + Path.GetExtension(_Resource);

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

    public class PropertyGridSelectFolder : UITypeEditor
    {
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            if ((context != null) && (context.Instance != null))
            {
                return UITypeEditorEditStyle.Modal;
            }
            return UITypeEditorEditStyle.None;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            FolderBrowserDialog myDialog = new FolderBrowserDialog();

            myDialog.Description = "";

            if (Directory.Exists(value.ToString()))
            {
                myDialog.SelectedPath = value.ToString();
            }

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                return myDialog.SelectedPath;
            }
            else
            {
                return value;
            }
        }
    }

    public class TypEditorEditIP : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
            }
            return UITypeEditorEditStyle.None;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            frmIP _frmIP = new frmIP();
            string _diaResult = _frmIP.ShowDia(value.ToString());
            if (_diaResult != null)
            {
                return _diaResult;
            }
            else
            {
                return value;
            }
        }
    }

    public class CancelEditProp : StringConverter
    {
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }




    









}