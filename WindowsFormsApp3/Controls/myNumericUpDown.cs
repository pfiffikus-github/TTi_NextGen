using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTi_NextGen
{
    class myNumericUpDown : NumericUpDown 
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (this.Value == this.Minimum) return;
                this.Value -= 1;
            }
            else if (e.Delta > 0)
            {
                if (this.Value == this.Maximum) return;
                this.Value += 1;
            }
        }

    }
}
