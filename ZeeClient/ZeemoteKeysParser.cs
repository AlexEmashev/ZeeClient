﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeeClient
{
    /// <summary>
    /// Parse Zeemote message to actual keys status
    /// </summary>
    class ZeemoteKeysParser
    {
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        /// <summary>
        /// Service message
        /// </summary>
        public event MessageEventHandler NewMessage;

        public delegate void ZeemoteKeyDownHandler(object sender, ZeemoteKeysArgs e);
        /// <summary>
        /// Occurs, when Zeemote key is down
        /// </summary>
        public event ZeemoteKeyDownHandler KeyDown;

        public delegate void ZeemoteKeyUpHandler(object sender, ZeemoteKeysArgs e);
        /// <summary>
        /// Occurs, when Zeemote key is up
        /// </summary>
        public event ZeemoteKeyUpHandler KeyUp;

        /// <summary>
        /// Joystick might be buggy, and has default coordinates other then (0, 0). Here small fix for it.
        /// <remarks>Also, user can set this setting, in order to use Joystick as a buttons 
        /// and lower it's accuracy to exclude incorrect side moves.</remarks>
        /// </summary>
        private int JoystickDeadZone {
            get
            {
                return Properties.Settings.Default.DeadZone;
            }
            set 
            { 
                Properties.Settings.Default.DeadZone = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Current Zeemote keys status
        /// </summary>
        private ZeemoteKeys curZeemoteKeys = new ZeemoteKeys();

        /// <summary>
        /// Analizes hot key message.
        /// Understands what keys have been pressed or released
        /// </summary>
        /// <param name="msg"></param>
        public void AnalyzeKeys(ZeemoteMessage msg)
        {
            // If there are buttons touched in message
            if (msg.ButtonsTouched)
            {
                if (!msg.ButtonA && curZeemoteKeys.A)
                {
                    curZeemoteKeys.A = msg.ButtonA;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeA));
                }
                else if (msg.ButtonA && !curZeemoteKeys.A)
                {
                    curZeemoteKeys.A = msg.ButtonA;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeA));
                }

                if (!msg.ButtonB && curZeemoteKeys.B)
                {
                    curZeemoteKeys.B = msg.ButtonB;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeB));
                }
                else if (msg.ButtonB && !curZeemoteKeys.B)
                {
                    curZeemoteKeys.B = msg.ButtonB;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeB));
                }

                if (!msg.ButtonC && curZeemoteKeys.C)
                {
                    curZeemoteKeys.C = msg.ButtonC;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeC));
                }
                else if (msg.ButtonC && !curZeemoteKeys.C)
                {
                    curZeemoteKeys.C = msg.ButtonC;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeC));
                }

                if (!msg.ButtonD && curZeemoteKeys.D)
                {
                    curZeemoteKeys.D = msg.ButtonD;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeD));
                }
                else if (msg.ButtonD && !curZeemoteKeys.D)
                {
                    curZeemoteKeys.D = msg.ButtonD;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeD));
                }
            }
            else // Joystick was touched
            {
                int direction = FindJoystickDirection(msg);

                // 0 - no; 1 - left; 2 - right; 3 - up; 4 - down.
                if (direction != 1 && curZeemoteKeys.JoyLeft)
                {
                    curZeemoteKeys.JoyLeft = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyLeft));
                }
                else if (direction == 1 && !curZeemoteKeys.JoyLeft)
                {
                    curZeemoteKeys.JoyLeft = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyLeft));
                }

                if (direction != 2 && curZeemoteKeys.JoyRight)
                {
                    curZeemoteKeys.JoyRight = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyRight));
                }
                else if (direction == 2 && !curZeemoteKeys.JoyRight)
                {
                    curZeemoteKeys.JoyRight = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyRight));
                }

                if (direction != 3 && curZeemoteKeys.JoyUp)
                {
                    curZeemoteKeys.JoyUp = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyUp));
                }
                else if (direction == 3 && !curZeemoteKeys.JoyUp)
                {
                    curZeemoteKeys.JoyUp = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyUp));
                }

                if (direction != 4 && curZeemoteKeys.JoyDown)
                {
                    curZeemoteKeys.JoyDown = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyDown));
                }
                else if (direction == 4 && !curZeemoteKeys.JoyDown)
                {
                    curZeemoteKeys.JoyDown = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyDown));
                }
            }
        }

        /// <summary>
        /// Checks current joystick direction, to calculate, which button is pressed.
        /// </summary>
        /// <param name="msg">Current Zeemote message</param>
        /// <returns>
        /// 0 - no direction, 
        /// 1 - left, 
        /// 2 - right, 
        /// 3 - up, 
        /// 4 - down</returns>
        private int FindJoystickDirection(ZeemoteMessage msg)
        {
            // Define which direction is prevailed, to press apropriate button, get dead zone in account
            // No, Left, Right, Up, Down
            int[] directions = new int[5];

            directions[0] = JoystickDeadZone;
            directions[1] = (Math.Abs(msg.JoystickX) > JoystickDeadZone) && msg.JoystickX < 0 ? Math.Abs(msg.JoystickX) : 0;
            directions[2] = (Math.Abs(msg.JoystickX) > JoystickDeadZone) && msg.JoystickX > 0 ? msg.JoystickX : 0;
            directions[3] = (Math.Abs(msg.JoystickY) > JoystickDeadZone) && msg.JoystickY < 0 ? Math.Abs(msg.JoystickY) : 0; ;
            directions[4] = (Math.Abs(msg.JoystickY) > JoystickDeadZone) && msg.JoystickY > 0 ? msg.JoystickY : 0;

            int direction = 0;
            // Define direction
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] > directions[direction])
                {
                    direction = i;
                }
            }

            return direction;
        }

        /// <summary>
        /// Sends tech info for client.
        /// </summary>
        /// <param name="message"></param>
        private void SendNewMessage(string message)
        {
            if (NewMessage != null)
            {
                NewMessage(this, new MessageEventArgs(message));
            }
        }
    }

    /// <summary>
    /// Class containing code of pressed key on Zeemote.
    /// </summary>
    class ZeemoteKeysArgs : EventArgs
    {
        /// <summary>
        /// Code from ZeemoteKeys structure
        /// </summary>
        public int ZeemoteKeyCode { get; set; }

        public ZeemoteKeysArgs(int keyCode)
        {
            ZeemoteKeyCode = keyCode;
        }
    }

    /// <summary>
    /// Key press status.
    /// </summary>
    public struct ZeemoteKeys
    {
        public bool A { get; set; }
        public static int KeyCodeA { get { return 0; } }

        public bool B { get; set; }
        public static int KeyCodeB { get { return 1; } }

        public bool C { get; set; }
        public static int KeyCodeC { get { return 2; } }

        public bool D { get; set; }
        public static int KeyCodeD { get { return 3; } }

        public bool JoyLeft { get; set; }
        public static int KeyCodeJoyLeft { get { return 4; } }

        public bool JoyRight { get; set; }
        public static int KeyCodeJoyRight { get { return 5; } }

        public bool JoyUp { get; set; }
        public static int KeyCodeJoyUp { get { return 6; } }

        public bool JoyDown { get; set; }
        public static int KeyCodeJoyDown { get { return 7; } }

        public int JoyX { get; set; }
        public int JoyY { get; set; }
    }
}
