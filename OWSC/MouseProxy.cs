using System.IO.Ports;
using System.Threading;

namespace OWSC
{
    public class MouseProxy
    {
        private readonly SerialPort _port;
        public MouseProxy()
        {
            var ports = SerialPort.GetPortNames();
            _port = new SerialPort(ports[1], 9600);
            _port.Open();
        }

        public void Press()
        {
            var bytes = new byte[] { 0 };
            _port.Write(bytes, 0, 1);
        }

        public void Release()
        {
            _port.Write(new[] { (byte)0, (byte)0 }, 0, 2);
        }

        public void Close()
        {
            _port.Close();
        }
    }
}