using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;
using WindowsInput;
using System.Runtime.InteropServices;

namespace ZeeClient
{
    public partial class FormClient : Form
    {
        /// <summary>
        /// Class for parsing messages from Zeemote.
        /// </summary>
        private ZeemoteKeysParser zeemoteKeysParser;

        #region Zeemote Keys (used uint, since added workaround for mouse events)
        /// <summary>
        /// Hotkeys for button A
        /// </summary>
        List<uint> hkA;
        /// <summary>
        /// Hotkeys for button B
        /// </summary>
        List<uint> hkB;
        /// <summary>
        /// Hotkeys for button C
        /// </summary>
        List<uint> hkC;
        /// <summary>
        /// Hotkeys for button D
        /// </summary>
        List<uint> hkD;
        /// <summary>
        /// Hotkeys for joystick left
        /// </summary>
        List<uint> hkLeft;
        /// <summary>
        /// Hotkeys for joystick right
        /// </summary>
        List<uint> hkRight;
        /// <summary>
        /// Hotkeys for joystick up
        /// </summary>
        List<uint> hkUp;
        /// <summary>
        /// Hotkeys for joystick down
        /// </summary>
        List<uint> hkDown;
        #endregion

        /// <summary>
        /// To simulate mouse inputs
        /// </summary>
        MouseInputSimulator mouseInput;

        public FormClient()
        {
            InitializeComponent();
            LoadButtonsSettings();
            zeemoteKeysParser = new ZeemoteKeysParser();
            zeemoteKeysParser.NewMessage += new ZeemoteKeysParser.MessageEventHandler(hotKeys_NewMessage);
            zeemoteKeysParser.KeyDown += zeemoteKeysParser_KeyDown;
            zeemoteKeysParser.KeyUp += zeemoteKeysParser_KeyUp;

            mouseInput = new MouseInputSimulator();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            ZeemoteListener zeemoteListener = new ZeemoteListener();
            //zeemoteListener.ErrorOccured += new ZeemoteListener.ErrorOccuredEventHandler(zeemoteListener_ErrorOccured);
            zeemoteListener.NewMessage += new ZeemoteListener.MessageEventHandler(zeemoteListener_NewMessage);
            zeemoteListener.Connect();
        }

        /// <summary>
        /// Zeemote key down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains key information</param>
        void zeemoteKeysParser_KeyDown(object sender, ZeemoteKeysArgs e)
        {
            if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeA)
            {
                HotKeyDown(hkA);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeB)
            {
                HotKeyDown(hkB);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeC)
            {
                HotKeyDown(hkC);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeD)
            {
                HotKeyDown(hkD);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyLeft)
            {
                HotKeyDown(hkLeft);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyRight)
            {
                HotKeyDown(hkRight);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyUp)
            {
                HotKeyDown(hkUp);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyDown)
            {
                HotKeyDown(hkDown);
            }
        }

        /// <summary>
        /// Zeemote key up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains key information</param>
        void zeemoteKeysParser_KeyUp(object sender, ZeemoteKeysArgs e)
        {
            if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeA)
            {
                HotKeyUp(hkA);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeB)
            {
                HotKeyUp(hkB);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeC)
            {
                HotKeyUp(hkC);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeD)
            {
                HotKeyUp(hkD);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyLeft)
            {
                HotKeyUp(hkLeft);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyRight)
            {
                HotKeyUp(hkRight);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyUp)
            {
                HotKeyUp(hkUp);
            }
            else if (e.ZeemoteKeyCode == ZeemoteKeys.KeyCodeJoyDown)
            {
                HotKeyUp(hkDown);
            }
        }

        /// <summary>
        /// Peforms hotkeys press
        /// </summary>
        /// <param name="hotKey">List of keys to press</param>
        private void HotKeyDown(List<uint> hotKey)
        {
            // Press keys in correct order (Ctrl, Shift, S)
            for (int i = 0; i < hotKey.Count; i++)
            {
                if (hotKey[i] == (int)MouseInputSimulator.MouseControls.WHEEL_DOWN)
                {
                    mouseInput.SimulateMouseScroll(false);
                }
                else if (hotKey[i] == (int)MouseInputSimulator.MouseControls.WHEEL_UP)
                {
                    mouseInput.SimulateMouseScroll(true);
                }
                else
                {
                    InputSimulator.SimulateKeyDown((VirtualKeyCode)hotKey[i]);
                }
            }
        }

        /// <summary>
        /// Performs hotkeys release
        /// </summary>
        /// <param name="hotKey">List of keys to press</param>
        private void HotKeyUp(List<uint> hotKey)
        {
            // Release keys in correct order (S, Shift, Ctrl)
            for (int i = hotKey.Count - 1; i >= 0; i--)
            {
                if (hotKey[i] == (int)MouseInputSimulator.MouseControls.WHEEL_DOWN)
                {
                    continue;
                }
                else if (hotKey[i] == (int)MouseInputSimulator.MouseControls.WHEEL_UP)
                {
                    continue;
                }
                else
                {
                    InputSimulator.SimulateKeyUp((VirtualKeyCode)hotKey[i]);
                }

            }
        }

        /// <summary>
        /// Messages dispatcher.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void zeemoteListener_NewMessage(object sender, MessageEventArgs e)
        {
            // Analize buttons
            if (e.ZeemoteMessage != null)
            {
                zeemoteKeysParser.AnalyzeKeys(e.ZeemoteMessage);
            }
            else
            {
                // Report message
                textBoxStatus.Text = e.Message;

                if(e.Message == "Connected")
                {
                    notifyIcon.ShowBalloonTip(3000, "ZeeClient", "Connected", ToolTipIcon.Info);
                }
            }
        }

        void zeemoteListener_ErrorOccured(object sender, ErrorEventArgs e)
        {
            textBoxStatus.Text = e.ErrorType;
        }

        void hotKeys_NewMessage(object sender, MessageEventArgs e)
        {
            textBoxStatus.Text = e.Message;
        }

        /// <summary>
        /// Show hotKey setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotKeySetup_Click(object sender, EventArgs e)
        {
            FormKeySetup keySetup;

            if (sender.Equals(buttonA))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonA);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonA = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonB))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonB);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonB = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonC))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonC);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonC = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonD))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonD);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonD = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonLeft))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyLeft);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyLeft = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonRight))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyRight);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyRight = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonUp))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyUp);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyUp = keySetup.HotKeys;
            }
            else if (sender.Equals(buttonDown))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyDown);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyDown = keySetup.HotKeys;
            }
            Properties.Settings.Default.Save();
            LoadButtonsSettings();
        }

        /// <summary>
        /// Releases all hotkeys
        /// <remarks>Used as safe landing while program is closing.</remarks>
        /// </summary>
        private void ReleaseAllKeys()
        {
            HotKeyUp(hkA);
            HotKeyUp(hkB);
            HotKeyUp(hkC);
            HotKeyUp(hkD);
            HotKeyUp(hkLeft);
            HotKeyUp(hkRight);
            HotKeyUp(hkUp);
            HotKeyUp(hkDown);
        }

        /// <summary>
        /// Loads button settings.
        /// </summary>
        private void LoadButtonsSettings()
        {
            hkA = ParseKeySettings(Properties.Settings.Default.ButtonA);
            hkB = ParseKeySettings(Properties.Settings.Default.ButtonB);
            hkC = ParseKeySettings(Properties.Settings.Default.ButtonC);
            hkD = ParseKeySettings(Properties.Settings.Default.ButtonD);
            hkLeft = ParseKeySettings(Properties.Settings.Default.JoyLeft);
            hkRight = ParseKeySettings(Properties.Settings.Default.JoyRight);
            hkUp = ParseKeySettings(Properties.Settings.Default.JoyUp);
            hkDown = ParseKeySettings(Properties.Settings.Default.JoyDown);
        }

        /// <summary>
        /// Parse setting string to keys list
        /// </summary>
        /// <param name="setting">Key setting string</param>
        /// <returns>List of keys in correct order.</returns>
        private List<uint> ParseKeySettings(string setting)
        {
            string[] strKeys = setting.Split(';');
            List<uint> hotKeys = new List<uint>(6);

            for (int i = 0; i < strKeys.Length; i++)
            {
                foreach (VirtualKeyCode keyCode in Enum.GetValues(typeof(VirtualKeyCode)))
                {
                    if (keyCode.ToString() == strKeys[i])
                    {
                        hotKeys.Add((uint)keyCode);
                        break;
                    }
                }
                // Parse mouse inputs
                foreach (MouseInputSimulator.MouseControls mouseInput in Enum.GetValues(typeof(MouseInputSimulator.MouseControls)))
                {
                    if (mouseInput.ToString() == strKeys[i])
                    {
                        hotKeys.Add((uint)mouseInput);
                        break;
                    }
                }
            }

            return hotKeys;
        }

        /// <summary>
        /// Minimize window to tray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClient_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideWindow();
            }
        }

        /// <summary>
        /// Handler for window messages.
        /// <remarks>Use to restore window in single instance scenario.</remarks>
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == SingleInstance.WM_SHOW_MAIN_WND)
            {
                ShowWindow();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Shows window after it was hidden.
        /// Use to restore window from tray or on event from another instance of app.
        /// </summary>
        private void ShowWindow()
        {
            if(WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }

            // Save current TopMost property for featurure
            bool topMost = this.TopMost;
            // Bring window up front
            this.TopMost = true;
            this.TopMost = topMost;
        }

        /// <summary>
        /// Minimizes window to tray.
        /// </summary>
        private void HideWindow()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        /// <summary>
        /// Hanlde program exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseAllKeys();
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();
        }

        /// <summary>
        /// Notify icon click.
        /// Shows application window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Supports click on notify icon to show or hide program window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if(this.WindowState == FormWindowState.Minimized)
                {
                    ShowWindow();
                }
                else
                {
                    HideWindow();
                }
            }
        }
    }
}
