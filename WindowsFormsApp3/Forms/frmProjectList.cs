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
    public partial class frmProjectList : Form
    {
        private Machine myMachine;

        public frmProjectList(Machine _machine)
        {
            InitializeComponent();
            myMachine = _machine;
        }

        private void frmProjectList_Load(object sender, EventArgs e)
        {
            projectsBindingSource.DataSource = myMachine.Projects ;
        }
    }
}
