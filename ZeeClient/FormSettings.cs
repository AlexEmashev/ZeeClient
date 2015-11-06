using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeeClient
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            numericUpDownDeadZone.Value = Properties.Settings.Default.DeadZone;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DeadZone = decimal.ToInt32(numericUpDownDeadZone.Value);
            Properties.Settings.Default.Save();
        }


    }
}
