using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ZeeClient
{
    /// <summary>
    /// Simulates mouse events
    /// </summary>
    class MouseInputSimulator
    {
        // Win32 API function for sending keys.
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        /// <summary>
        /// Mouse Data to send
        /// </summary>
        struct MouseInput
        {
            public int X; // X coordinate
            public int Y; // Y coordinate
            public int MouseData; // mouse data (mouse wheel)
            public uint DwFlags; // further mouse data (mouse buttons)
            public uint Time; // time of the event
            public IntPtr DwExtraInfo; // extra info
        }

        /// <summary>
        /// Inputs to send
        /// </summary>
        struct Input
        {
            public int Type; // input type (0: mouse)
            public MouseInput Data; // mouse data
        }

        // Mouse constants
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002; // Press left mouse button
        const uint MOUSEEVENTF_LEFTUP = 0x0004; // Release left mouse button
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000; // Whole screen, not just application window
        const uint MOUSEEVENTF_MOVE = 0x0001; // Move mouse
        const uint MOUSEEVENTF_WHEEL = 0x0800; // Mouse Scroll
        const int MOUSE_WHEEL_AMOUNT = 120; // Amount of scroll (default 120 to scroll up, -120 to scroll down)

        public enum MouseControls
        {
            WHEEL_UP = 300,
            WHEEL_DOWN = 301
        }

        /// <summary>
        /// Create mouse message.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private MouseInput CreateMouseInput(int x, int y, int data, uint time, uint flag)
        {
            MouseInput Result = new MouseInput();
            Result.X = x;
            Result.Y = y;
            Result.MouseData = data;
            Result.Time = time;
            Result.DwFlags = flag;
            return Result;
        }

        /// <summary>
        /// Simulates mouse click
        /// </summary>
        public void SimulateMouseClick()
        {
            Input[] MouseEvent = new Input[2];
            MouseEvent[0].Type = 0;
            MouseEvent[0].Data = CreateMouseInput(0, 0, 0, 0, MOUSEEVENTF_LEFTDOWN);

            MouseEvent[1].Type = 0; // INPUT_MOUSE; 
            MouseEvent[1].Data = CreateMouseInput(0, 0, 0, 0, MOUSEEVENTF_LEFTUP);

            SendInput((uint)MouseEvent.Length, MouseEvent, Marshal.SizeOf(MouseEvent[0].GetType()));
        }

        /// <summary>
        /// Performs mouse Scroll
        /// </summary>
        /// <param name="up"></param>
        public void SimulateMouseScroll(bool up)
        {
            Input[] MouseEvent = new Input[1];
            MouseEvent[0].Type = 0; // INPUT_MOUSE; 
            MouseEvent[0].Data = CreateMouseInput(0, 0, up ? MOUSE_WHEEL_AMOUNT : -MOUSE_WHEEL_AMOUNT, 0, MOUSEEVENTF_WHEEL);

            SendInput((uint)MouseEvent.Length, MouseEvent, Marshal.SizeOf(MouseEvent[0].GetType()));
        }

        /// <summary>
        /// Performs mouse move
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SimulateMouseMove(int x, int y)
        {
            Input[] MouseEvent = new Input[1];
            MouseEvent[0].Type = 0;
            MouseEvent[0].Data = CreateMouseInput(x, y, 0, 0, MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE);
            SendInput((uint)MouseEvent.Length, MouseEvent, Marshal.SizeOf(MouseEvent[0].GetType()));
        }
    }
}
