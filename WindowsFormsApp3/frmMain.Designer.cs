namespace WindowsFormsApp3
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("1  STOP");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("2  ;Spindel bei T20, bei der Positionierung ausschalten -> Bettspuelduesen");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("7  BLK FORM 0.1 Z  X-55  Y-132.5  Z-160");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("8  BLK FORM 0.2  X+459.7  Y+132.5  Z+130");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("9  TOOL CALL 38 Z S0");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("10 * - TOOL 38 MESSTASTER");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("NH9_0.t", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("T       NAME             L           R           DL       DR       R2          PL" +
        "C ");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("1001    Test-TTi         +172.300    +006.000    +0       -000.018 +0          %0" +
        "0000000");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("1001    Test-TTi         +172.300    +006.000    +0       -000.018 +0          %0" +
        "0000000");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("HY3_0.t", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.doppelteWerkzeugeMarkierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pfadÖffnenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktuelisierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.schließenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pfadÖffnenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiÖffnenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.eigenschaftenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.werkzeugeImCNCProgrammSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.contextRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pfadÖffenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateiÖffnenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nurTOOLCALLsAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.contextMachine = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.protokolleAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.spinnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cTXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dMU50eVoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c42UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.timeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerMainFrm = new System.Windows.Forms.Timer(this.components);
            this.pfadÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextLeft.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.contextRight.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMachine.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox2);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox2);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown2);
            this.splitContainer1.Panel2.Controls.Add(this.treeView2);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(634, 336);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 247);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(306, 86);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "NH9_0.t erfolgreich geladen\n54564\n564\n654\n654\n654\n654\n6546\n354\n654\n45";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(59, 222);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Synchron";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericUpDown1.Location = new System.Drawing.Point(3, 219);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(159, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Werkzeugliste übertragen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextLeft;
            this.treeView1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(3, 53);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "Knoten1";
            treeNode5.Text = "1  STOP";
            treeNode6.Name = "Knoten3";
            treeNode6.Text = "2  ;Spindel bei T20, bei der Positionierung ausschalten -> Bettspuelduesen";
            treeNode7.Name = "Knoten4";
            treeNode7.Text = "7  BLK FORM 0.1 Z  X-55  Y-132.5  Z-160";
            treeNode8.Name = "Knoten5";
            treeNode8.Text = "8  BLK FORM 0.2  X+459.7  Y+132.5  Z+130";
            treeNode9.Name = "Knoten6";
            treeNode9.Text = "9  TOOL CALL 38 Z S0";
            treeNode10.Name = "Knoten7";
            treeNode10.Text = "10 * - TOOL 38 MESSTASTER";
            treeNode11.Name = "Knoten0";
            treeNode11.Text = "NH9_0.t";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(306, 159);
            this.treeView1.TabIndex = 3;
            // 
            // contextLeft
            // 
            this.contextLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contextLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator6,
            this.doppelteWerkzeugeMarkierenToolStripMenuItem,
            this.toolStripSeparator5,
            this.pfadÖffnenToolStripMenuItem1,
            this.dateiÖffnenToolStripMenuItem});
            this.contextLeft.Name = "contextRight";
            this.contextLeft.Size = new System.Drawing.Size(281, 104);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(280, 22);
            this.toolStripMenuItem2.Text = "Werkzeuge im CNC-Programm suchen";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(277, 6);
            // 
            // doppelteWerkzeugeMarkierenToolStripMenuItem
            // 
            this.doppelteWerkzeugeMarkierenToolStripMenuItem.Checked = true;
            this.doppelteWerkzeugeMarkierenToolStripMenuItem.CheckOnClick = true;
            this.doppelteWerkzeugeMarkierenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doppelteWerkzeugeMarkierenToolStripMenuItem.Name = "doppelteWerkzeugeMarkierenToolStripMenuItem";
            this.doppelteWerkzeugeMarkierenToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.doppelteWerkzeugeMarkierenToolStripMenuItem.Text = "Doppelte Werkzeuge markieren";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(277, 6);
            // 
            // pfadÖffnenToolStripMenuItem1
            // 
            this.pfadÖffnenToolStripMenuItem1.Name = "pfadÖffnenToolStripMenuItem1";
            this.pfadÖffnenToolStripMenuItem1.Size = new System.Drawing.Size(280, 22);
            this.pfadÖffnenToolStripMenuItem1.Text = "Pfad öffnen";
            // 
            // dateiÖffnenToolStripMenuItem
            // 
            this.dateiÖffnenToolStripMenuItem.Name = "dateiÖffnenToolStripMenuItem";
            this.dateiÖffnenToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.dateiÖffnenToolStripMenuItem.Text = "Datei öffnen";
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.ansichtToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip3.Location = new System.Drawing.Point(0, 26);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip3.Size = new System.Drawing.Size(202, 24);
            this.menuStrip3.TabIndex = 2;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.aktuelisierenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.speichernUnterToolStripMenuItem,
            this.toolStripSeparator1,
            this.schließenToolStripMenuItem,
            this.toolStripSeparator2,
            this.pfadÖffnenToolStripMenuItem2,
            this.dateiÖffnenToolStripMenuItem2,
            this.toolStripSeparator7,
            this.eigenschaftenToolStripMenuItem,
            this.toolStripSeparator8,
            this.beendenToolStripMenuItem});
            this.toolStripMenuItem4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem4.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            // 
            // aktuelisierenToolStripMenuItem
            // 
            this.aktuelisierenToolStripMenuItem.Name = "aktuelisierenToolStripMenuItem";
            this.aktuelisierenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aktuelisierenToolStripMenuItem.Text = "Aktualisieren";
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.speichernUnterToolStripMenuItem.Text = "Speichern unter";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // schließenToolStripMenuItem
            // 
            this.schließenToolStripMenuItem.Name = "schließenToolStripMenuItem";
            this.schließenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.schließenToolStripMenuItem.Text = "Schließen";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // pfadÖffnenToolStripMenuItem2
            // 
            this.pfadÖffnenToolStripMenuItem2.Enabled = false;
            this.pfadÖffnenToolStripMenuItem2.Name = "pfadÖffnenToolStripMenuItem2";
            this.pfadÖffnenToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
            this.pfadÖffnenToolStripMenuItem2.Text = "Pfad öffnen";
            // 
            // dateiÖffnenToolStripMenuItem2
            // 
            this.dateiÖffnenToolStripMenuItem2.Enabled = false;
            this.dateiÖffnenToolStripMenuItem2.Name = "dateiÖffnenToolStripMenuItem2";
            this.dateiÖffnenToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
            this.dateiÖffnenToolStripMenuItem2.Text = "Datei öffnen";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(154, 6);
            // 
            // eigenschaftenToolStripMenuItem
            // 
            this.eigenschaftenToolStripMenuItem.Name = "eigenschaftenToolStripMenuItem";
            this.eigenschaftenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.eigenschaftenToolStripMenuItem.Text = "Eigenschaften";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(154, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1});
            this.ansichtToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // doppelteWerkzeugeMarkierenToolStripMenuItem1
            // 
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1.Checked = true;
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1.CheckOnClick = true;
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1.Name = "doppelteWerkzeugeMarkierenToolStripMenuItem1";
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.doppelteWerkzeugeMarkierenToolStripMenuItem1.Text = "Doppelte Werkzeuge markieren";
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.werkzeugeImCNCProgrammSuchenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // werkzeugeImCNCProgrammSuchenToolStripMenuItem
            // 
            this.werkzeugeImCNCProgrammSuchenToolStripMenuItem.Name = "werkzeugeImCNCProgrammSuchenToolStripMenuItem";
            this.werkzeugeImCNCProgrammSuchenToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.werkzeugeImCNCProgrammSuchenToolStripMenuItem.Text = "Werkzeuge im CNC-Programm suchen";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Werkzeugliste\r\n\r\nNH9_0g.t";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 247);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(312, 86);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "HY3_0.t erfolgreich geladen\n";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(165, 218);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "CNC-Programm übertragen";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox2.Location = new System.Drawing.Point(59, 222);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(71, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Synchron";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckStateChanged += new System.EventHandler(this.checkBox2_CheckStateChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numericUpDown2.Location = new System.Drawing.Point(3, 219);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.ContextMenuStrip = this.contextRight;
            this.treeView2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView2.Location = new System.Drawing.Point(3, 53);
            this.treeView2.Name = "treeView2";
            treeNode12.Name = "Knoten1";
            treeNode12.Text = "T       NAME             L           R           DL       DR       R2          PL" +
    "C ";
            treeNode13.Name = "Knoten2";
            treeNode13.Text = "1001    Test-TTi         +172.300    +006.000    +0       -000.018 +0          %0" +
    "0000000";
            treeNode14.Name = "Knoten4";
            treeNode14.Text = "1001    Test-TTi         +172.300    +006.000    +0       -000.018 +0          %0" +
    "0000000";
            treeNode15.Name = "Knoten0";
            treeNode15.Text = "HY3_0.t";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView2.Size = new System.Drawing.Size(312, 159);
            this.treeView2.TabIndex = 4;
            // 
            // contextRight
            // 
            this.contextRight.BackColor = System.Drawing.Color.DimGray;
            this.contextRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripSeparator3,
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem,
            this.toolStripSeparator4,
            this.pfadÖffenToolStripMenuItem,
            this.dateiÖffnenToolStripMenuItem1});
            this.contextRight.Name = "contextRight";
            this.contextRight.Size = new System.Drawing.Size(274, 104);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(273, 22);
            this.toolStripMenuItem7.Text = "TOOL CALL\'s in Werkzeugliste suchen";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(270, 6);
            // 
            // doppelteTOOLCALLsMarkierenToolStripMenuItem
            // 
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem.Checked = true;
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem.CheckOnClick = true;
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem.Name = "doppelteTOOLCALLsMarkierenToolStripMenuItem";
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem.Text = "Doppelte TOOL CALL\'s markieren";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(270, 6);
            // 
            // pfadÖffenToolStripMenuItem
            // 
            this.pfadÖffenToolStripMenuItem.Name = "pfadÖffenToolStripMenuItem";
            this.pfadÖffenToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.pfadÖffenToolStripMenuItem.Text = "Pfad öffen";
            // 
            // dateiÖffnenToolStripMenuItem1
            // 
            this.dateiÖffnenToolStripMenuItem1.Name = "dateiÖffnenToolStripMenuItem1";
            this.dateiÖffnenToolStripMenuItem1.Size = new System.Drawing.Size(273, 22);
            this.dateiÖffnenToolStripMenuItem1.Text = "Datei öffnen";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ansichtToolStripMenuItem1,
            this.extrasToolStripMenuItem1,
            this.infoToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 26);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip2.Size = new System.Drawing.Size(202, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem1.Text = "Datei";
            // 
            // ansichtToolStripMenuItem1
            // 
            this.ansichtToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1,
            this.nurTOOLCALLsAnzeigenToolStripMenuItem});
            this.ansichtToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ansichtToolStripMenuItem1.Name = "ansichtToolStripMenuItem1";
            this.ansichtToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem1.Text = "Ansicht";
            // 
            // doppelteTOOLCALLsMarkierenToolStripMenuItem1
            // 
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1.Checked = true;
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1.CheckOnClick = true;
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1.Name = "doppelteTOOLCALLsMarkierenToolStripMenuItem1";
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1.Size = new System.Drawing.Size(250, 22);
            this.doppelteTOOLCALLsMarkierenToolStripMenuItem1.Text = "Doppelte TOOL CALL\'s markieren";
            // 
            // nurTOOLCALLsAnzeigenToolStripMenuItem
            // 
            this.nurTOOLCALLsAnzeigenToolStripMenuItem.Checked = true;
            this.nurTOOLCALLsAnzeigenToolStripMenuItem.CheckOnClick = true;
            this.nurTOOLCALLsAnzeigenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nurTOOLCALLsAnzeigenToolStripMenuItem.Name = "nurTOOLCALLsAnzeigenToolStripMenuItem";
            this.nurTOOLCALLsAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.nurTOOLCALLsAnzeigenToolStripMenuItem.Text = "Nur TOOL CALL\'s anzeigen";
            // 
            // extrasToolStripMenuItem1
            // 
            this.extrasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem});
            this.extrasToolStripMenuItem1.Name = "extrasToolStripMenuItem1";
            this.extrasToolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem1.Text = "Extras";
            // 
            // tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem
            // 
            this.tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem.Name = "tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem";
            this.tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem.Text = "TOOL CALL\'s in Werkzeugliste suchen";
            // 
            // infoToolStripMenuItem1
            // 
            this.infoToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.infoToolStripMenuItem1.Name = "infoToolStripMenuItem1";
            this.infoToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem1.Text = "Info";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "CNC-Programm\r\n\r\nHY3_0.t";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ContextMenuStrip = this.contextMachine;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1,
            this.timeStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // contextMachine
            // 
            this.contextMachine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem8,
            this.protokolleAnzeigenToolStripMenuItem,
            this.backupsToolStripMenuItem,
            this.toolStripMenuItem9});
            this.contextMachine.Name = "contextMachine";
            this.contextMachine.Size = new System.Drawing.Size(161, 114);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem5.Text = "Konfigurieren";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Checked = true;
            this.toolStripMenuItem8.CheckOnClick = true;
            this.toolStripMenuItem8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem8.Text = "Verlauf anzeigen";
            this.toolStripMenuItem8.CheckStateChanged += new System.EventHandler(this.toolStripMenuItem8_CheckStateChanged);
            // 
            // protokolleAnzeigenToolStripMenuItem
            // 
            this.protokolleAnzeigenToolStripMenuItem.Name = "protokolleAnzeigenToolStripMenuItem";
            this.protokolleAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.protokolleAnzeigenToolStripMenuItem.Text = "Protokolle";
            // 
            // backupsToolStripMenuItem
            // 
            this.backupsToolStripMenuItem.Name = "backupsToolStripMenuItem";
            this.backupsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.backupsToolStripMenuItem.Text = "Backups";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem9.Text = "Info";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spinnerToolStripMenuItem,
            this.cTXToolStripMenuItem,
            this.dMU50eVoToolStripMenuItem,
            this.c42UToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(90, 20);
            this.toolStripDropDownButton1.Text = "\"MASCHINE\"";
            // 
            // spinnerToolStripMenuItem
            // 
            this.spinnerToolStripMenuItem.Name = "spinnerToolStripMenuItem";
            this.spinnerToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.spinnerToolStripMenuItem.Text = "Spinner";
            // 
            // cTXToolStripMenuItem
            // 
            this.cTXToolStripMenuItem.Name = "cTXToolStripMenuItem";
            this.cTXToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.cTXToolStripMenuItem.Text = "CTX";
            // 
            // dMU50eVoToolStripMenuItem
            // 
            this.dMU50eVoToolStripMenuItem.Name = "dMU50eVoToolStripMenuItem";
            this.dMU50eVoToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dMU50eVoToolStripMenuItem.Text = "DMU 50eVo";
            // 
            // c42UToolStripMenuItem
            // 
            this.c42UToolStripMenuItem.Name = "c42UToolStripMenuItem";
            this.c42UToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.c42UToolStripMenuItem.Text = "C42U";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabel2.Text = "= online (127.0.0.1)";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(250, 16);
            // 
            // timeStatus
            // 
            this.timeStatus.ForeColor = System.Drawing.Color.DimGray;
            this.timeStatus.Name = "timeStatus";
            this.timeStatus.Size = new System.Drawing.Size(89, 17);
            this.timeStatus.Spring = true;
            this.timeStatus.Text = "D/T";
            this.timeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerMainFrm
            // 
            this.timerMainFrm.Enabled = true;
            this.timerMainFrm.Interval = 500;
            this.timerMainFrm.Tick += new System.EventHandler(this.timerMainFrm_Tick);
            // 
            // pfadÖffnenToolStripMenuItem
            // 
            this.pfadÖffnenToolStripMenuItem.Name = "pfadÖffnenToolStripMenuItem";
            this.pfadÖffnenToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.pfadÖffnenToolStripMenuItem.Text = "Pfad öffnen";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.fmrMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextLeft.ResumeLayout(false);
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.contextRight.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMachine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem spinnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cTXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dMU50eVoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c42UToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel timeStatus;
        private System.Windows.Forms.Timer timerMainFrm;
        private System.Windows.Forms.ContextMenuStrip contextRight;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktuelisierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem eigenschaftenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem schließenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextLeft;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMachine;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem doppelteWerkzeugeMarkierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doppelteTOOLCALLsMarkierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pfadÖffenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiÖffnenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem pfadÖffnenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem pfadÖffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem doppelteWerkzeugeMarkierenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem doppelteTOOLCALLsMarkierenToolStripMenuItem1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ToolStripMenuItem nurTOOLCALLsAnzeigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pfadÖffnenToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dateiÖffnenToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem werkzeugeImCNCProgrammSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tOOLCALLsInWerkzeuglisteSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernUnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protokolleAnzeigenToolStripMenuItem;
    }
}

