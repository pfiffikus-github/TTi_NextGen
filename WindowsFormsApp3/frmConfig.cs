using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            LocalSettings ls = new LocalSettings();
            propertyGrid1.SelectedObject = ls;

            PublicSettings ps = new PublicSettings();
            propertyGrid2.SelectedObject = ps;





        }
    }

}
