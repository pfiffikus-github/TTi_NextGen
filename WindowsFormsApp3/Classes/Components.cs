using System;
using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing.Design;
using System.Text.RegularExpressions;
using System.Collections;

namespace TTi_NextGen
{
    public class LocalSettings
    {
        public LocalSettings()
        {
            ShowMachineList = true;
            ShowHistory = true;
            CloseAppAfterSync = false;
            LocalSettingsDirectory = Application.StartupPath;
            PublicSettingsDirectory = Application.StartupPath;
            DefaultMachineBackground = new string[1];
            DefaultMachineBackground[0] = Machine.DefaultMachineName;
            DefaultMachine = Machine.DefaultMachineName;
            HistorySizeHeight = 130;
        }

        public event EventHandler PublicSettingsDirectoryChanged;

        public const string LocalSettingsFile = "LocalSettings.xml";

        public const string PublicSettingsFile = "PublicSettings.xml";

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Auswahl aller Maschinen anzeigen")]
        public bool ShowMachineList { get; set; }

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Verlauf anzeigen")]
        public bool ShowHistory { get; set; }


        private int myHistorySizeHeight;
        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Höhe des History-Logs (in Pixel >50/<250)")]
        public int HistorySizeHeight
        {
            get { return myHistorySizeHeight; }
            set
            {
                if (value < 50 | value > 250)
                {
                    return;
                }
                myHistorySizeHeight = value;
            }
        }



        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Anwendung nach Datenübertragung schließen")]
        public bool CloseAppAfterSync { get; set; }

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Pfad der loaklen Einstellungsdatei (unveränderbar im Startordner)")]
        public string LocalSettingsDirectory { get; }

        private string myPublicSettingsDirectory;
        [CategoryAttribute("Öffentliche Einstellungen"),
         DescriptionAttribute("Pfad der öffentlichen Einstellungsdatei (Liste aller Maschinen)"),
         Editor(typeof(PropertyGridSelectFolder), typeof(UITypeEditor)),
         TypeConverter(typeof(CancelEditProp))]
        public string PublicSettingsDirectory
        {
            get { return myPublicSettingsDirectory; }
            set
            {
                myPublicSettingsDirectory = value;
                PublicSettingsDirectoryChanged?.Invoke(this, new EventArgs()); //Event auslösen, wenn dieses kunsumiert wird
            }
        }

        [CategoryAttribute("Öffentliche Einstellungen"),
         DescriptionAttribute("Liste der verfügbaren Maschinen zur Wahl der Standardmaschine"),
         XmlIgnoreAttribute]
        public Machines Machines { get; set; }

        private string[] myDefaultMachineBackground;
        [Browsable(false),
         XmlIgnoreAttribute]
        public string[] DefaultMachineBackground
        {
            get { return myDefaultMachineBackground; }
            set { myDefaultMachineBackground = value; }
        }

        [CategoryAttribute("Lokale Einstellungen"),
         DescriptionAttribute("Maschine, welche nach Anwendungsstart automatisch ausgewählt wird"),
         TypeConverter(typeof(MachineTypeConverter))]
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

        public void SerializeXML(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                XmlSerializer xs = new XmlSerializer(this.GetType());
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, LocalSettings.PublicSettingsFile)))
                {
                    if (this.Count == 0)
                    {
                        Add(new Machine());
                    }

                    xs.Serialize(sw, this);
                    sw.Flush();
                    sw.Dispose();
                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw;
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
            PathToolTable = @"TNC:\Tool.t";
            InvalidToolNameCharakters = @"/\* ()[]{}+!§=?<>;:^°|²³äöü";
            ProjectDirectory = @"TNC:\Bauteile\";
            MaxToolRange = 32;
            RestrictivToolNumbers = "0,1,2,3,4,5,6,7,8,9,10";
            BlockedToolNumbers = "";
            ControlVersion = TNCVersions.bis_iTNC530;
        }

        public const string DefaultMachineName = "DefaultMachine";

        private string myName;
        [CategoryAttribute("Allgemein + Verbindung"),
         DescriptionAttribute("Name")]
        public string Name
        {
            get { return myName; }
            set
            {
                if (value.Trim().Replace(" ", "") == "")
                {
                    return;
                }
                myName = value.Trim().Substring(0, Math.Min(24, value.Length));
            }
        }

        [CategoryAttribute("Allgemein + Verbindung"),
         DescriptionAttribute("IP-Adresse"),
         Editor(typeof(TypEditorEditIP), typeof(UITypeEditor)),
         TypeConverter(typeof(CancelEditProp))]
        public string IP { get; set; }

        [CategoryAttribute("Einstellungen Werkzeugliste"),
         DescriptionAttribute("Pfad + Dateiname der Werkzeugtabelle")]
        public string PathToolTable { get; set; }

        [CategoryAttribute("Einstellungen Werkzeugliste"),
         DescriptionAttribute("Ungültige Zeichen in Spalte 'Name'")]
        public string InvalidToolNameCharakters { get; set; }

        private int myMaxToolRange;
        [CategoryAttribute("Einstellungen Werkzeugliste"),
         DescriptionAttribute("Tool-Range Max. ((i)TNC = 32)")]
        public int MaxToolRange
        {
            get { return myMaxToolRange; }
            set
            {
                if (value < 1 | value > 32)
                {
                    return;
                }
                myMaxToolRange = value;
            }
        }

        [CategoryAttribute("Einstellungen Werkzeugliste"),
         DescriptionAttribute("Werkzeugnummern, die von Tool-Range-Änderung ignoriert werden (")]
        public string RestrictivToolNumbers { get; set; }

        [CategoryAttribute("Einstellungen CNC-Programm"),
         DescriptionAttribute("Projekt-/Programmverzeichnis auf Steuerung")]
        public string ProjectDirectory { get; set; }

        [CategoryAttribute("Allgemein + Verbindung"),
         DescriptionAttribute("Version der Steuerung (für korrekte Datenübertrgaung)")]
        public TNCVersions ControlVersion { get; set; }

        [CategoryAttribute("Einstellungen Werkzeugliste"),
         DescriptionAttribute("Werkzeugnummern, die statisch niemals auf Steuerung überschrieben werden (≙ Standardwerkzeug)")]
        public string BlockedToolNumbers { get; set; }

        public enum TNCVersions
        {
            bis_iTNC530,
            ab_TNC640,
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class App
    {
        public static LocalSettings InitLocalSettings()
        {
            try
            {
                LocalSettings myLocalSettings = new LocalSettings();

                App.ExtractEmbeddedResources("TNCSync.exe", Application.StartupPath);

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
            catch (Exception)
            {
                return null;
            }
        }

        public static Machines InitMachines(string path)
        {
            try
            {
                Machines myMachines = new Machines();

                App.ExtractEmbeddedResources(".template", path);

                if (File.Exists(Path.Combine(path, LocalSettings.PublicSettingsFile)))
                {
                    myMachines = myMachines.DeserializeXML(path);
                }
                else
                {
                    myMachines.Add(new Machine());
                    myMachines.SerializeXML(path);
                }

                foreach (var machine in myMachines)
                {
                    if (machine.ControlVersion == Machine.TNCVersions.ab_TNC640)
                    {
                        //MessageBox.Show("Das Verwenden der Einstellung 'ab_TNC640' setzt folgendes Paket voraus:\n\n'Microsoft Visual C++ 2010 Redistributable Package (x64)'", "Informtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        App.ExtractEmbeddedResources(".dll", Application.StartupPath);
                        App.ExtractEmbeddedResources("TNCSyncPlus.exe", Application.StartupPath);
                        break;
                    }
                }

                return myMachines;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ExtractEmbeddedResources(string files, string path)
        {
            string[] _Resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            string[] _File;

            foreach (var _Resource in _Resources)
            {
                if (_Resource.Contains(files))
                {
                    _File = _Resource.Split('.');

                    String _FileName = _File[_File.Length - 2] + Path.GetExtension(_Resource);

                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_Resource))
                    {
                        if (!File.Exists(Path.Combine(path, _FileName)))
                        {
                            Directory.CreateDirectory(path);
                            FileStream fileStream = new FileStream(Path.Combine(path, _FileName), FileMode.Create);
                            for (int i = 0; i < stream.Length; i++)
                                fileStream.WriteByte((byte)stream.ReadByte());
                            fileStream.Close();
                        }
                    }
                }
            }
        }

        public static string Title()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;

        }

        public static string Version()
        {
            return "V" + Assembly.GetExecutingAssembly().GetName().Version.Major +
                   "." + Assembly.GetExecutingAssembly().GetName().Version.Minor; // +
                                                                                  //" Rev." + Assembly.GetExecutingAssembly().GetName().Version.MinorRevision;
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
            FolderBrowserDialog myDialog = new FolderBrowserDialog
            {
                Description = ""
            };

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

    public class MachineTypeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (context.Instance is LocalSettings _LocalSettings) return new StandardValuesCollection(_LocalSettings.Machines);  //DefaultMachineBackground

            return base.GetStandardValues(context);
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------

    public class CNCProgram
    {
        public const string ToolCallString = "TOOL CALL";

        public CNCProgram(FileInfo file, string restrictivToolNumber)
        {
            File = file;
            CountOfRestrictiveToolValues = 0;   //in DetectIsToolRangeConsistent() neu initalisiert
            OriginalToolRange = 0;              //in DetectIsToolRangeConsistent() neu initalisiert
            FirstNotRestrictiveToolValue = 0;   //in DetectIsToolRangeConsistent() neu initalisiert
            OnlyRestrictiveToolValues = false;  //in DetectIsToolRangeConsistent() neu initalisiert

            if (restrictivToolNumber.Trim() != "")
            {
                int[] _RestrictivToolNumbers = new int[0];
                string[] _rtn = restrictivToolNumber.Split(',');

                foreach (string item in _rtn)
                {
                    Array.Resize(ref _RestrictivToolNumbers, _RestrictivToolNumbers.Length + 1);

                    try
                    {
                        _RestrictivToolNumbers[_RestrictivToolNumbers.Length - 1] = int.Parse(item.Trim());
                    }
                    catch (Exception)
                    { }
                }
                RestrictivToolNumbers = _RestrictivToolNumbers;
            }

            FileContent = System.IO.File.ReadAllText(File.FullName);
            MatchesOfToolCalls = GetDetectMatchesOfToolCalls();
            IsToolRangeConsistent = DetectIsToolRangeConsistent();
        }

        public int OriginalToolRange { get; private set; }
        public MatchCollection MatchesOfToolCalls { get; private set; }

        private string myFileContent;
        public string FileContent
        {
            get { return myFileContent; }

            private set
            {
                myFileContent = value;
            }
        }

        public FileInfo File { get; private set; }
        public bool IsToolRangeConsistent { get; private set; }
        public bool OnlyRestrictiveToolValues { get; private set; }
        public int FirstNotRestrictiveToolValue { get; private set; }
        public int CountOfRestrictiveToolValues { get; private set; }
        public int[] RestrictivToolNumbers { get; set; }

        private MatchCollection GetDetectMatchesOfToolCalls()
        {
            var rgx = new Regex(@"TOOL\s+CALL\s+(\d+)");

            MatchCollection matches = rgx.Matches(FileContent);

            return matches;
        }

        private bool DetectIsToolRangeConsistent()
        {
            decimal[] ToolCallValues = new decimal[0];
            decimal CalcConsistency = 0;
            OnlyRestrictiveToolValues = true;

            foreach (Match m in MatchesOfToolCalls)
            {
                ToolCall tc = new ToolCall(m);

                //Continue ForEach by Restriction
                if (IsRestrictiveToolValue(tc.OrgToolCallValue - tc.OrgToolRangeValue))
                {
                    this.CountOfRestrictiveToolValues++;
                    continue;
                }
                else if (OnlyRestrictiveToolValues)
                {
                    OnlyRestrictiveToolValues = false;
                    FirstNotRestrictiveToolValue = tc.OrgToolCallValue - Int32.Parse(tc.OrgToolRangeValue.ToString());
                }

                if (m.Groups.Count > 1)
                {
                    Array.Resize(ref ToolCallValues, ToolCallValues.Length + 1);
                    ToolCallValues[ToolCallValues.Length - 1] = System.Math.Floor(decimal.Parse(m.Groups[1].ToString()) / 1000);
                    CalcConsistency = CalcConsistency + ToolCallValues[ToolCallValues.Length - 1];
                }
            }

            if (ToolCallValues.Length > 0)
            {
                OriginalToolRange = Int32.Parse(ToolCallValues[0].ToString());

                if (CalcConsistency / ToolCallValues.Length != ToolCallValues[0])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public void ChangeToolRange(int newRange, bool showErrAtInconsistency)
        {
            if (IsToolRangeConsistent == false && showErrAtInconsistency)
            {
                DialogResult result = MessageBox.Show(GetNoteText() + "\n" + "\n" + this.ToString() + "\n\n" + "Neuen ToolRange dennoch in '" + newRange.ToString() + "' ändern?", "HINWEIS... " + App.Title(),
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No) { return; }
            }

            var newFileContent = FileContent;
            string newToolCallString;
            int newToolCallValue;

            foreach (Match m in MatchesOfToolCalls)
            {
                var tc = new ToolCall(m);

                //Continue ForEach by Restriction
                if (IsRestrictiveToolValue(tc.OrgToolCallValue - tc.OrgToolRangeValue)) { continue; }

                newToolCallValue = (Int32.Parse(tc.OrgToolCallString.Replace(ToolCallString + " ", "")) -
                                   Int32.Parse(tc.OrgToolRangeValue.ToString())) +
                                   (newRange * 1000);

                newToolCallString = tc.OrgToolCallString.Replace(tc.OrgToolCallValue.ToString(), newToolCallValue.ToString());

                newFileContent = newFileContent.Replace(tc.OrgToolCallString, newToolCallString);
            }
            System.IO.File.WriteAllText(System.IO.Path.Combine(File.DirectoryName, File.Name), newFileContent);
        }

        public override string ToString()
        {
            var ToolCallsToString = "";
            var SubString = "";

            foreach (Match m in MatchesOfToolCalls)
            {
                ToolCall tc = new ToolCall(m);

                if (!IsRestrictiveToolValue(tc.OrgToolCallValue - tc.OrgToolRangeValue))
                {
                    SubString = "";
                }
                else
                {
                    SubString = "   (≙ Standardwerkzeug)";
                }

                ToolCallsToString = ToolCallsToString + "• " + m.Value + SubString + "\n";
            }

            return ToolCallsToString + "\n-------------- INFORMATION --------------" +
                   "\n• " + this.MatchesOfToolCalls.Count.ToString() + "x '" + ToolCallString + "' insgesamt" +
                   "\n• " + (this.MatchesOfToolCalls.Count - this.CountOfRestrictiveToolValues).ToString() + "x veränderbare '" + ToolCallString + "'" +
                   "\n• " + this.CountOfRestrictiveToolValues.ToString() + "x Standardwerkzeuge";
        }

        public string GetNoteText()
        {
            string nt = "CNC-Programm '" + Path.GetFileName(File.Name) + "': ";

            if (this.MatchesOfToolCalls.Count == 0)
            {
                return nt + "(" + this.MatchesOfToolCalls.Count + "x '" + CNCProgram.ToolCallString + "' enthalten)";
            }

            if (this.OnlyRestrictiveToolValues)
            {
                return nt + "(" + this.MatchesOfToolCalls.Count + "x ausschließlich Standardwerkzeuge enthalten)";
            }

            if (this.IsToolRangeConsistent)
            {
                return nt + "(" + this.MatchesOfToolCalls.Count + "x '" + CNCProgram.ToolCallString + "' in Tool-Range " + this.OriginalToolRange.ToString() + " gefunden)";
            }
            else
            {
                return nt + "(" + this.MatchesOfToolCalls.Count + "x nicht übereinstimmende '" + CNCProgram.ToolCallString + "' gefunden)";
            }
        }

        public string[] Lines()
        {
            return System.IO.File.ReadAllLines(File.FullName);
        }

        private bool IsRestrictiveToolValue(decimal toolValue)
        {
            if (RestrictivToolNumbers != null)
            {
                foreach (int item in RestrictivToolNumbers)
                {
                    if (toolValue == item)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public string[] EachToolCallValues()
        {
            string[] _str = new string[0];

            foreach (Match m in MatchesOfToolCalls)
            {
                ToolCall tc = new ToolCall(m);

                Array.Resize(ref _str, _str.Length + 1);
                _str[_str.Length - 1] = m.Value;

            }

            return _str;
        }


    }

    public class ToolCall
    {
        public ToolCall(Match m)
        {
            OrgToolCallString = m.Value + " ";
            OrgToolRangeValue = System.Math.Floor(decimal.Parse(m.Groups[1].ToString()) / 1000) * 1000;
            OrgToolCallValue = (Int32.Parse(OrgToolCallString.Replace(CNCProgram.ToolCallString + " ", "")));
        }

        public String OrgToolCallString { get; private set; }
        public decimal OrgToolRangeValue { get; private set; }
        public int OrgToolCallValue { get; private set; }
    }





















}