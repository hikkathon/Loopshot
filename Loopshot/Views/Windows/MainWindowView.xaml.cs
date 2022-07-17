using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Threading;

namespace Loopshot
{
    /// <summary>
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindowView()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Screenshot);
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }

        void Screenshot(object source, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            string FileName = $"shoot/{guid}.jpeg";

            int screenLeft = (int)SystemParameters.VirtualScreenLeft; // Y
            int screenTop = (int)SystemParameters.VirtualScreenTop; // X
            int screenWidth = (int)SystemParameters.VirtualScreenWidth; // Ширина
            int screenHeight = (int)SystemParameters.VirtualScreenHeight; // Высота

            Bitmap bitmap = new Bitmap(screenWidth, screenHeight);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap.Size);

            bitmap.Save(FileName);

            //ImageSource image = new BitmapImage(new Uri(Environment.CurrentDirectory + $"/{FileName}", UriKind.Absolute));
            //ScanImage.Source = image;
        }
    }
}
