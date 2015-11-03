using System;
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
        /// Joystick can be buggy, and has dead zone. Here small fix for it.
        /// </summary>
        private int JoystickDeadZone = 15;
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

                    SendNewMessage("A released");
                }
                else if (msg.ButtonA && !curZeemoteKeys.A)
                {
                    curZeemoteKeys.A = msg.ButtonA;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeA));

                    SendNewMessage("A pressed");
                }

                if (!msg.ButtonB && curZeemoteKeys.B)
                {
                    curZeemoteKeys.B = msg.ButtonB;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeB));

                    SendNewMessage("B released");
                }
                else if (msg.ButtonB && !curZeemoteKeys.B)
                {
                    curZeemoteKeys.B = msg.ButtonB;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeB));

                    SendNewMessage("B pressed");
                }

                if (!msg.ButtonC && curZeemoteKeys.C)
                {
                    curZeemoteKeys.C = msg.ButtonC;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeC));

                    SendNewMessage("C released");
                }
                else if (msg.ButtonC && !curZeemoteKeys.C)
                {
                    curZeemoteKeys.C = msg.ButtonC;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeC));

                    SendNewMessage("C pressed");
                }

                if (!msg.ButtonD && curZeemoteKeys.D)
                {
                    curZeemoteKeys.D = msg.ButtonD;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeD));

                    SendNewMessage("D released");
                }
                else if (msg.ButtonD && !curZeemoteKeys.D)
                {
                    curZeemoteKeys.D = msg.ButtonD;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeD));

                    SendNewMessage("D pressed");
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

                    SendNewMessage("Left released");
                }
                else if (direction == 1 && !curZeemoteKeys.JoyLeft)
                {
                    curZeemoteKeys.JoyLeft = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyLeft));

                    SendNewMessage("Left pressed");
                }

                if (direction != 2 && curZeemoteKeys.JoyRight)
                {
                    curZeemoteKeys.JoyRight = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyRight));
                    SendNewMessage("Right released");
                }
                else if (direction == 2 && !curZeemoteKeys.JoyRight)
                {
                    curZeemoteKeys.JoyRight = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyRight));

                    SendNewMessage("Right pressed");
                }

                if (direction != 3 && curZeemoteKeys.JoyUp)
                {
                    curZeemoteKeys.JoyUp = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyUp));
                    SendNewMessage("Up released");
                }
                else if (direction == 3 && !curZeemoteKeys.JoyUp)
                {
                    curZeemoteKeys.JoyUp = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyUp));

                    SendNewMessage("Up pressed");
                }

                if (direction != 4 && curZeemoteKeys.JoyDown)
                {
                    curZeemoteKeys.JoyDown = false;
                    if (KeyUp != null)
                        KeyUp.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyDown));
                    SendNewMessage("Down released");
                }
                else if (direction == 4 && !curZeemoteKeys.JoyDown)
                {
                    curZeemoteKeys.JoyDown = true;
                    if (KeyDown != null)
                        KeyDown.Invoke(this, new ZeemoteKeysArgs(ZeemoteKeys.KeyCodeJoyDown));

                    SendNewMessage("Down pressed");
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
