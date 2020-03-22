using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothTank
{
    class TankController
    {
        public enum COMMAND {
            Forward,
            Reverse,
            Stop,
            Left,
            Right
        }
        private SerialPort BTport;
        public TankController(String comPort, int baudRate) {
            BTport = new SerialPort();
            BTport.BaudRate = baudRate;
            BTport.PortName = comPort;
            BTport.Open();
        }

        public void sendCommand(COMMAND cmd) {
            if (BTport.IsOpen)
            {
                char[] buffer = new char[1];
                switch (cmd)
                {
                    case COMMAND.Stop:
                        buffer[0] = 's';
                        BTport.Write(buffer,0,1);
                        break;
                    case COMMAND.Forward:
                        buffer[0] = 'f';
                        BTport.Write(buffer, 0, 1);
                        break;
                    case COMMAND.Reverse:
                        buffer[0] = 'b';
                        BTport.Write(buffer, 0, 1);
                        break;
                    case COMMAND.Left:
                        buffer[0] = 'l';
                        BTport.Write(buffer, 0, 1);
                        break;
                    case COMMAND.Right:
                        buffer[0] = 'r';
                        BTport.Write(buffer, 0, 1);
                        break;
                }
            }
        
        }

        
    }
}
