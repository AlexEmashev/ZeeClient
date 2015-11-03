using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsInput;

namespace ZeeClient
{
    public partial class FormKeySetup : Form
    {
        public string HotKeys = "";
        private string Ctrl = "CONTROL";
        private string Shift = "SHIFT";
        private string Alt = "MENU";
        List<string> keyValues;

        public FormKeySetup(string currentSetting)
        {
            InitializeComponent();
            // Exclude modifiers
            List<string> excludeKeys = new List<string>();
            excludeKeys.Add("SHIFT");
            excludeKeys.Add("CONTROL");
            excludeKeys.Add("MENU");
            excludeKeys.Add("LMENU");
            excludeKeys.Add("RMENU");
            excludeKeys.Add("LSHIFT");
            excludeKeys.Add("RSHIFT");
            excludeKeys.Add("LCONTROL");
            excludeKeys.Add("RCONTROL");



            keyValues = new List<string>();
            keyValues.Add(""); // Add empty value
            // Load keys
            foreach (VirtualKeyCode key in Enum.GetValues(typeof(VirtualKeyCode)))
            {
                if (!excludeKeys.Contains(key.ToString()))
                    keyValues.Add(key.ToString());
            }

            // Add mouse wheel workaround
            foreach (MouseInputSimulator.MouseControls mouseCtrl in Enum.GetValues(typeof(MouseInputSimulator.MouseControls)))
            {
                if (!excludeKeys.Contains(mouseCtrl.ToString()))
                {
                    keyValues.Add(mouseCtrl.ToString());
                }
            }

            comboBoxKey.DataSource = keyValues;

            RestoreSettings(currentSetting);
        }

        private void RestoreSettings(string setting)
        {
            string[] keys = setting.Split(';');
            foreach (string key in keys)
            {
                if (key == Ctrl)
                    cbCtrl.Checked = true;

                if (key == Shift)
                    cbShift.Checked = true;

                if (key == Alt)
                    cbAlt.Checked = true;

                if (key != "" && keyValues.Contains(key))
                    comboBoxKey.SelectedIndex = keyValues.IndexOf(key);
            }
        }

        private void FormKeySetup_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (cbCtrl.Checked)
                HotKeys += "CONTROL;";

            if (cbAlt.Checked)
                HotKeys += "MENU;";

            if (cbShift.Checked)
                HotKeys += "SHIFT;";

            HotKeys += (string)comboBoxKey.SelectedItem;

        }
    }
}
