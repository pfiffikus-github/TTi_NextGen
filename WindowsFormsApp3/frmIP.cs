using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace TTi_NextGen
{
    public partial class frmIP : Form
    {
        String myIP;

        public frmIP()
        {
            InitializeComponent();
        }

        public String ShowDia(string ip)
        {
            txtBxIP.Text = ip;
            myIP = ip;
            btnPing.Text = "Ping " + myIP;
            ShowDialog();
            return myIP;
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtBxIP_TextChanged(null, null);
        }

        private void txtBxIP_TextChanged(object sender, EventArgs e)
        {
            myIP = txtBxIP.Text.Replace(" ", "");
            Text = "IP-Adresse: " + myIP;
            btnPing.Text = "Ping: " + myIP;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    Ping _Ping = new Ping();
                    _Ping.Send(myIP, 5);
                }
                catch (Exception)
                {
                    ShowInvalidAddressErr();
                    e.Cancel = true;
                }
            }
        }

        private void ShowInvalidAddressErr()
        {
            MessageBox.Show("Ungültige IP-Adresse!", "Ungültige IP-Adresse!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            try
            {
                Ping _Ping = new Ping();
                PingReply _Replay = _Ping.Send(myIP, 5);
                if (_Replay.Status == IPStatus.Success)
                {
                    MessageBox.Show("Host " + myIP + " erreichbar.", myIP + " - Abfrage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Host " + myIP + " nicht erreichbar.", myIP + " - Abfrage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {
                ShowInvalidAddressErr();
            }
        }
    }
}
