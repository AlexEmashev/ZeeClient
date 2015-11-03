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
                mouseInput.SimulateMouseScroll(false);
                //HotKeyDown(hkA);
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
                    //InputSimulator.SimulateKeyUp((VirtualKeyCode)hotKey[i]);
                }
                textBoxRawData.AppendText(((VirtualKeyCode)hotKey[i]).ToString() + " Pressed" + Environment.NewLine);
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
                    //InputSimulator.SimulateKeyUp((VirtualKeyCode)hotKey[i]);
                }

                textBoxRawData.AppendText(((VirtualKeyCode)hotKey[i]).ToString() + " Up" + Environment.NewLine);
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
                textBoxRawData.AppendText(e.Message + Environment.NewLine);
            }
        }

        void zeemoteListener_ErrorOccured(object sender, ErrorEventArgs e)
        {
            textBoxRawData.AppendText(e.ErrorType + Environment.NewLine);
        }

        void hotKeys_NewMessage(object sender, MessageEventArgs e)
        {
            textBoxRawData.AppendText(e.Message + Environment.NewLine);
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
                textBoxRawData.AppendText(Properties.Settings.Default.ButtonA + Environment.NewLine);
            }
            else if (sender.Equals(buttonB))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonB);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonB = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.ButtonB + Environment.NewLine);
            }
            else if (sender.Equals(buttonC))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonC);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonC = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.ButtonC + Environment.NewLine);
            }
            else if (sender.Equals(buttonD))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.ButtonD);
                keySetup.ShowDialog();
                Properties.Settings.Default.ButtonD = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.ButtonD + Environment.NewLine);
            }
            else if (sender.Equals(buttonLeft))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyLeft);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyLeft = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.JoyLeft + Environment.NewLine);
            }
            else if (sender.Equals(buttonRight))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyRight);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyRight = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.JoyRight + Environment.NewLine);
            }
            else if (sender.Equals(buttonUp))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyUp);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyUp = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.JoyUp + Environment.NewLine);
            }
            else if (sender.Equals(buttonDown))
            {
                keySetup = new FormKeySetup(Properties.Settings.Default.JoyDown);
                keySetup.ShowDialog();
                Properties.Settings.Default.JoyDown = keySetup.HotKeys;
                textBoxRawData.AppendText(Properties.Settings.Default.JoyDown + Environment.NewLine);
            }
            Properties.Settings.Default.Save();
            LoadButtonsSettings();
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
    }
}
