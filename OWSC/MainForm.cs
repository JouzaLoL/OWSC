using MaterialSkin.Controls;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OWSC
{
    public partial class MainForm : MaterialForm
    {
        private MouseProxy _proxy;
        private Random _rng;
        private Thread _thread;
        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public void SoldierNoSpread()
        {
            while (true)
            {
                if (GetAsyncKeyState(0xA0) < 0)
                {
                    SoldierShoot();
                }
            }
        }

        public void SoldierShoot()
        {
            _proxy.Press();
            Thread.Sleep(_rng.Next(230, 350));
            _proxy.Release();
            Thread.Sleep(_rng.Next(195, 220));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _proxy = new MouseProxy();
            _rng = new Random();

            _thread = new Thread(SoldierNoSpread);
            _thread.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _thread.Abort();
            _proxy.Close();
        }
    }
}
