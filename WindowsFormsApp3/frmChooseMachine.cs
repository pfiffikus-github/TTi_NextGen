﻿using System;
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
    public partial class frmChooseMachine : Form
    {
        String myMachines;

        public frmChooseMachine()
        {
            InitializeComponent();
        }

        public String ShowDia(string tempMachine, string[] machines)
        {
            cmbBoxMachines.Items.AddRange(machines);
            cmbBoxMachines.Text = tempMachine;
            ShowDialog();
            return myMachines;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
            {
                myMachines = cmbBoxMachines.Text;
            }
            else
            {
                myMachines = null;
            }
        }
      
    }
}