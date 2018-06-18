using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Microsoft
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void GridDelegate(Grid grid, double _Opacity);//声明委托方法
        private object[] invokeBGData = new object[2];
        WinAns answin = null;
        bool showflag = false;
        ImageBrush im = null;
        //Point ppp = new Point();
        //声明委托参数，[0]位存放委托方法的第一个参数，[1]位存放委托方法的第二个参数

        public MainWindow()
        {
            InitializeComponent();
            //invokeBGData[0] = this;//定义[0]位参数位需要更新的Chart控件
            //invokeBGData[1] = 1;//定义[1]位为Chart中的数据
            invokeBGData[0] = backgrid;
            invokeBGData[1] = 0.0;
            
            Thread thread = new Thread(UpdateGrid);
            thread.IsBackground = true;
            thread.Start();
            answin = new WinAns();
            //backgrid.Background = 
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed )
            {
                //Point down_p = new Point(Cursor.Position.X, Cursor.Position.Y);
                //Point pp = Mouse.GetPosition(e.Source as FrameworkElement);//WPF方法
                //ppp = (e.Source as FrameworkElement).PointToScreen(pp);//WPF方法
                this.DragMove();
                
                //backgrid.Background = im;

                if (answin == null)
                    answin = new WinAns();
                if (showflag)
                {
                    answin.Left = this.Left + this.Width;
                    answin.Top = this.Top;
                    answin.Show();
                    answin.Topmost = true;
                }
            }


        }
        public void GridDelegateMethod(Grid grid, double _Opacity)
        {
            grid.Opacity = _Opacity;
            //_Chart.Series[0].Points.DataBind(this.dataTable.AsEnumerable(), "日期", "数据", "");
        }
        private void UpdateGrid()
        {


            int flag = -1;
            double step = 0.05;
            
            while (true)
            {
                double _Opacity = (double)invokeBGData[1];
                if (_Opacity < 0.1)
                {
                    flag = 1;
                }
                if (_Opacity > 0.95)
                {
                    flag = -1;
                }
                invokeBGData[1] = _Opacity + flag * step;
                backgrid.Dispatcher.BeginInvoke(new GridDelegate(GridDelegateMethod), invokeBGData);
                Thread.Sleep(100);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("你你说你男朋友叫啥？说错了马上关机","当心啊老铁");
            //answin.Owner = this;
            //double top = this.Top;
            answin.Left = this.Left+this.Width;
            answin.Top = this.Top;
            

            answin.Show();
            showflag = true;
            answin.Topmost = true;

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("我不开心了，我想关机", "气人");
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               
            }
        }
    }
}
