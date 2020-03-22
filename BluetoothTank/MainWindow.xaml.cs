using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BluetoothTank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TankController tc;
        public MainWindow()
        {
            InitializeComponent();
            tc = new TankController("COM5", 9600);
            mainWindow.PreviewKeyDown += Container_KeyDown;
            mainWindow.PreviewKeyUp += Container_KeyUp;
            buttonUp.PreviewMouseDown += ButtonUp_MouseDown;
            buttonDown.PreviewMouseDown += ButtonDown_MouseDown;
            buttonLeft.PreviewMouseDown += ButtonLeft_MouseDown;
            buttonRight.PreviewMouseDown += ButtonRight_MouseDown;

            buttonUp.PreviewMouseUp += MouseUp;
            buttonDown.PreviewMouseUp += MouseUp;
            buttonRight.PreviewMouseUp += MouseUp;
            buttonLeft.PreviewMouseUp += MouseUp;
        }

        private void Container_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    tc.sendCommand(TankController.COMMAND.Forward);
                    break;
                case Key.Down:
                    tc.sendCommand(TankController.COMMAND.Reverse);
                    break;
                case Key.Right:
                    tc.sendCommand(TankController.COMMAND.Right);
                    break;
                case Key.Left:
                    tc.sendCommand(TankController.COMMAND.Left);
                    break;
            }
        }

        private void Container_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Right || e.Key == Key.Left)
                tc.sendCommand(TankController.COMMAND.Stop);
        }

        private void ButtonRight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tc.sendCommand(TankController.COMMAND.Right);
        }

        private void ButtonLeft_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tc.sendCommand(TankController.COMMAND.Left);
        }

        private void ButtonDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tc.sendCommand(TankController.COMMAND.Reverse);
        }

        private void ButtonUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tc.sendCommand(TankController.COMMAND.Forward);
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            tc.sendCommand(TankController.COMMAND.Stop);
        }
    }
}
