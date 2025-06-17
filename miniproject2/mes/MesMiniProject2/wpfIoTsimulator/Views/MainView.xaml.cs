using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace wpfIoTsimulator.Views
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
        }
        Stopwatch stopwatch = new Stopwatch();
        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            StartHmiAni();
        }

        private void StartHmiAni()
        {
            Product.Fill = new SolidColorBrush(Colors.Gray);

            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(5),
            };
            RotateTransform rt = new RotateTransform();
            GearStart.RenderTransform = rt;
            GearStart.RenderTransformOrigin = new Point(0.5, 0.5);
            GearEnd.RenderTransform = rt;
            GearEnd.RenderTransformOrigin = new Point(0.5, 0.5);
            
            rt.BeginAnimation(RotateTransform.AngleProperty, da);

            DoubleAnimation pa = new DoubleAnimation
            {
                From = 129,
                To = 417,
                Duration = TimeSpan.FromSeconds(5),
            };
            Product.BeginAnimation(Canvas.LeftProperty, pa);
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            StartSensorCheck();
        }

        private void StartSensorCheck()
        {
            // 센서 애니메이션
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
            {
                DoubleAnimation sa = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(1),
                    AutoReverse = true,
                };

                SortingSensor.BeginAnimation(OpacityProperty, sa);
            }));

           

            Thread.Sleep(1000);
            // 랜덤으로 색상을 결정짓는 작업
            Random rand = new Random();
            int result = rand.Next(0, 2); // 
            switch (result)
            {
                case 0:
                    Product.Fill = new SolidColorBrush(Colors.Green); // 양품
                    break;
                case 1:
                    Product.Fill = new SolidColorBrush(Colors.Crimson); // 불량
                    break;
                case 2:
                    Product.Fill = new SolidColorBrush(Colors.Gray); // 선별실패
                    break;
            }

        }
    }
}
