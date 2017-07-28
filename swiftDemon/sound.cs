using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swiftDemon
{
    public partial class sound : Form
    {
        public sound()
        {
            InitializeComponent();
        }

        private void sound_Load(object sender, EventArgs e)
        {
            bool value = (reestr.getParam("sound") == "True") ? true:false;
            ch_on.Checked = value;
        }

        private void ch_on_CheckedChanged(object sender, EventArgs e)
        {
            reestr.setParam("", "sound", ch_on.Checked.ToString());
        }
    }
}
