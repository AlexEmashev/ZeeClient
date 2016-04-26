using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;
using System.Timers;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace ZeeClient
{
    /// <summary>
    /// Connect to Zeemote and read messages from the device
    /// </summary>
    class ZeemoteListener
    {
        BackgroundWorker bgWorkerProcessData;

        /// <summary>
        /// Device name.
        /// <remarks>Use it in search metohd.</remarks>
        /// </summary>
        private string deviceName = "Zeemote JS1";
        BluetoothAddress deviceAddress;
        // Zeemote service GUID
        Guid serviceClass = new Guid("8E1F0CF7-508F-4875-B62C-FBB67FD34812");
        /// <summary>
        /// Flag for cancelling an operation.
        /// </summary>
        bool Cancel = false;
        public event MessageEventHandler NewMessage;
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        // Currently not using
        //public event ErrorOccuredEventHandler ErrorOccured;
        //public delegate void ErrorOccuredEventHandler(object sender, ErrorEventArgs e);

        /// <summary>
        /// Constructor
        /// </summary>
        public ZeemoteListener()
        {
            // Creating worker that will be trying to connect to Zeemote.
            bgWorkerProcessData = new BackgroundWorker();
            bgWorkerProcessData.WorkerReportsProgress = true;
            bgWorkerProcessData.WorkerSupportsCancellation = true;
            bgWorkerProcessData.DoWork += new DoWorkEventHandler(bgWorkerProcessData_DoWork);
            bgWorkerProcessData.ProgressChanged += new ProgressChangedEventHandler(bgWorkerProcessData_ProgressChanged);
        }

        /// <summary>
        /// Runs connection initialization
        /// </summary>
        public void Connect()
        {
            bgWorkerProcessData.RunWorkerAsync();
        }

        /// <summary>
        /// Main method for thread, that Establish connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgWorkerProcessData_DoWork(object sender, DoWorkEventArgs e)
        {
            EstablishConnection();
        }

        /// <summary>
        /// Reports about changing of progress of connection with device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgWorkerProcessData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ZeemoteMessage)
            {
                NewMessage(this, new MessageEventArgs((ZeemoteMessage)e.UserState));
            }
            else if (e.UserState is String)
            {
                string message = (string)e.UserState;
                if (!string.IsNullOrEmpty(message) && NewMessage != null)
                    NewMessage(this, new MessageEventArgs(message));
            }
        }

        /// <summary>
        /// Scan for Zeemote
        /// <returns>true if device in range</returns>
        /// </summary>
        private bool ScanForDevice()
        {
            // ToDo: move btClient to the class level
            bgWorkerProcessData.ReportProgress(0, "Searching for the device...");
            BluetoothClient btClient = new BluetoothClient();
            BluetoothDeviceInfo[] devices = btClient.DiscoverDevicesInRange();
            //bgWorkerProcessData.ReportProgress(0, "Search complete");
            //bgWorkerProcessData.ReportProgress(0, "Devices discovered:");

            foreach (BluetoothDeviceInfo device in devices)
            {
                if (device.DeviceName == deviceName)
                {
                    deviceAddress = device.DeviceAddress;
                    bgWorkerProcessData.ReportProgress(0, deviceName + " found");
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Establish connection with Zeemote. 
        /// When connection is established, starts reading of data
        /// </summary>
        private void EstablishConnection()
        {
            try
            {
                do
                {
                    // Scan for device
                    if (ScanForDevice())
                    {
                        ConnectToDevice();
                    }
                } while (!Cancel);
                bgWorkerProcessData.ReportProgress(100);
            }
            catch (Exception ex)
            {
                bgWorkerProcessData.ReportProgress(0, ex.Message + " Reconnecting...");
            }
            finally
            {
                // Can't remember what was it for
                bgWorkerProcessData.ReportProgress(100, "It seems there is no Bluetooth on this device.");
            }
        }

        /// <summary>
        /// Connect to device
        /// </summary>
        private void ConnectToDevice()
        {
            try
            {
                // bgWorkerProcessData.ReportProgress(0, "Creating endboint");
                BluetoothEndPoint endPoint = new BluetoothEndPoint(deviceAddress, serviceClass);
                // bgWorkerProcessData.ReportProgress(0, "Creating bt client");
                using (BluetoothClient btClient = new BluetoothClient())
                {
                    bgWorkerProcessData.ReportProgress(0, "Connecting...");
                    btClient.Connect(endPoint);
                    bgWorkerProcessData.ReportProgress(0, "Connected");
                    // If connected
                    using (Stream peerStream = btClient.GetStream())
                    {
                        // Read and parse data from device.
                        ReadData(peerStream);
                    }
                }
            }
            catch (Exception ex)
            {
                // try to connect again in 2 second.
                bgWorkerProcessData.ReportProgress(0, ex.Message);
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Reads data from deivice's stream
        /// </summary>
        /// <param name="peerStream">Stream with data to read.</param>
        private void ReadData(Stream peerStream)
        {
            byte[] buf = new byte[1024]; ;
            int numberOfBytesRead = 0;
            try
            {
                do
                {
                    numberOfBytesRead = peerStream.Read(buf, 0, buf.Length);
                    if (numberOfBytesRead == 0)
                    {
                        bgWorkerProcessData.ReportProgress(0, "Connection is closed");
                        EstablishConnection();
                        continue;
                    }

                    DispatchBluetoothMessage(buf, numberOfBytesRead);
                } while (peerStream.CanRead);
            }
            catch (Exception ex)
            {
                bgWorkerProcessData.ReportProgress(0, ex.Message);
                bgWorkerProcessData.ReportProgress(0, "Stream is closed.");
            }
        }

        /// <summary>
        /// Dispatch zeemote message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="numberOfBytes"></param>
        public void DispatchBluetoothMessage(byte[] message, int numberOfBytes)
        {
            ZeemoteMessage msg = new ZeemoteMessage();

            if ((numberOfBytes == 8) &&
                (message[0] == 7 && message[1] == 161 && message[2] == 5 && message[3] == 255))
            {
                // Device is connected.
            }
            // Check if message about button
            else if ((numberOfBytes == 9) &&
                (message[0] == 8 && message[1] == 161 && message[2] == 7))
            {
                for (int i = 3; i <= 6; i++)
                {
                    if (message[i] == 0)
                    {
                        msg.ButtonA = true;
                    }
                    else if (message[i] == 1)
                    {
                        msg.ButtonB = true;
                    }
                    else if (message[i] == 2)
                    {
                        msg.ButtonC = true;
                    }
                    else if (message[i] == 3)
                    {
                        msg.ButtonD = true;
                    }
                }

                // Button was touched even if there are no messages about it.
                // That means, button was repeased.
                msg.ButtonsTouched = true;
                msg.Touched = true;
            }
            // Battery charge message
            else if (numberOfBytes == 5)
            {
                try
                {
                    string batteryStatus = "Voltage " + BitConverter.ToUInt16(new byte[] { message[4], message[3]}, 0).ToString();
                    // Currently write battery status to log file, to get the info, when battery dies
                    //SimpleLog.Write(batteryStatus, true);
                }
                catch (Exception exc)
                {
                    //SimpleLog.Write(exc.Message, false);
                }

            }
            // Joystick
            else if ((numberOfBytes == 6) &&
                (message[0] == 5 && message[1] == 161 && message[2] == 8 && message[3] == 0))
            {
                int axysX = 0;
                int axysY = 0;

                if (message[4] >= 128)
                    axysX = message[4] - 255;
                else if (message[4] > 0)
                    axysX = message[4];

                if (message[5] >= 128)
                    axysY = message[5] - 255;
                else
                    axysY = message[5];

                msg.JoystickX = axysX;
                msg.JoystickY = axysY;
            }

            // Send Zeemote message
            if (msg.Touched)
                bgWorkerProcessData.ReportProgress(0, msg);
        }
    }

    /// <summary>
    /// Send Zeemote message
    /// </summary>
    class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Message from listener
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// True if device just connected
        /// </summary>
        public bool ConnectionEstablished { get; set; }
        /// <summary>
        /// Device disconnected
        /// </summary>
        public bool DisconnectOccured { get; set; }
        /// <summary>
        /// Keys message from controller
        /// </summary>
        public ZeemoteMessage ZeemoteMessage { get; set; }
        public MessageEventArgs(string message)
        {
            Message = message;
        }
        public MessageEventArgs(ZeemoteMessage msg)
        {
            ZeemoteMessage = msg;
        }
    }

    class ErrorEventArgs : EventArgs
    {
        public string ErrorType { get; set; }
        public ErrorEventArgs(string errorType)
        {
            ErrorType = errorType;
        }
    }

    /// <summary>
    /// Class of Zeemote message.
    /// Client should analize it, to get current values.
    /// </summary>
    public class ZeemoteMessage
    {
        /// <summary>
        /// Indicates, that controls was used.
        /// </summary>
        public bool Touched { get; set; }
        /// <summary>
        /// Indicates, that button was touched, not Joystick.
        /// When user presses first button, then Joystick. 
        /// There should be the way to know, that buttons were not used in this message.
        /// </summary>
        public bool ButtonsTouched { get; set; }
        private bool btnA = false;
        public bool ButtonA
        {
            get { return btnA; }
            set
            {
                btnA = value;
                Touched = true;
                ButtonsTouched = true;
            }
        }

        private bool btnB = false;
        public bool ButtonB
        {
            get { return btnB; }
            set
            {
                btnB = value;
                Touched = true;
                ButtonsTouched = true;
            }
        }

        private bool btnC = false;
        public bool ButtonC
        {
            get { return btnC; }
            set
            {
                btnC = value;
                Touched = true;
                ButtonsTouched = true;
            }
        }

        private bool btnD = false;
        public bool ButtonD
        {
            get { return btnD; }
            set
            {
                btnD = value;
                Touched = true;
                ButtonsTouched = true;
            }
        }

        private int joystickX = 0;
        public int JoystickX
        {
            get { return joystickX; }
            set
            {
                joystickX = value;
                Touched = true;
            }
        }

        private int joystickY = 0;
        public int JoystickY
        {
            get { return joystickY; }
            set
            {
                joystickY = value;
                Touched = true;
            }
        }
    }
}
