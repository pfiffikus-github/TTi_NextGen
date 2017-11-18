using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTi_NextGen
{
    public partial class frmProp : Form
    {
        object myObject = new object();

        public frmProp(object _obj)
        {
            InitializeComponent();
            myObject = _obj;
        }

        private void frmProp_Load(object sender, EventArgs e)
        {
            Machine _machine = new Machine();
            _machine = (Machine)myObject;
            Text = _machine.Name;

            propertyGrid1.SelectedObject = myObject;
        }
    }
}
