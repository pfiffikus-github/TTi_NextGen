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

namespace WindowsFormsApp3
{
    public partial class fmrMain : Form
    {
        public fmrMain()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            checkBox1.CheckState = cb.CheckState;
            checkBox2.CheckState = cb.CheckState;
        }

        private void timerMainFrm_Tick(object sender, EventArgs e)
        {
            timeStatus.Text = DateTime.Now.ToString();

            Ping isPing = new Ping();

            try
            {
                PingReply reply = isPing.Send("127.0.0.1");
                if (reply.Status == IPStatus.Success)
                {
                    toolStripStatusLabel2.ForeColor = Color.Green;
                    toolStripDropDownButton1.ForeColor = Color.Green;
                    toolStripStatusLabel2.Text = "= online (127.0.0.1)";
                }

            }
            catch (PingException)
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripDropDownButton1.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "= offline (127.0.0.1)";
            }

            timerMainFrm.Interval = 5000;

        }

        private void fmrMain_Load(object sender, EventArgs e)
        {
            toolStripMenuItem8.CheckState = CheckState.Unchecked;

        }

        private void toolStripMenuItem8_CheckStateChanged(object sender, EventArgs e)
        {
            int Y = richTextBox1.Size.Height + 8;

            if (toolStripMenuItem8.CheckState != CheckState.Checked)
            {
                splitContainer1.Size = new Size(splitContainer1.Size.Width, splitContainer1.Size.Height + Y);
            }
            else
            {
                splitContainer1.Size = new Size(splitContainer1.Size.Width, splitContainer1.Size.Height - Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
