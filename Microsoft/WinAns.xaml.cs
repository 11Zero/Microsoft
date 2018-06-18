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
using System.Windows.Shapes;

namespace Microsoft
{
    /// <summary>
    /// WinAns.xaml 的交互逻辑
    /// </summary>
    public partial class WinAns : Window
    {
        public WinAns()
        {
            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;
            if (name == "田海涛")
                MessageBox.Show("就是这个人", "我确定");
            else
                MessageBox.Show("不可能是这个人","关机吧");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;
            if (name == "田海涛")
            {
                MessageBox.Show("这是实话", "真开心");
                if (MessageBox.Show("这窗口关闭?", "大傻子", MessageBoxButton.OKCancel) == MessageBoxResult.OK)

                {

                    if (MessageBox.Show(name + "是你男朋友?", "大傻子", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        Application.Current.Shutdown();
                    else
                        MessageBox.Show("你再反省一下", "叫你皮");
                }
                else
                    MessageBox.Show("照片很好看", "小辣鸡");
            }
            else
                MessageBox.Show("不可能是这个人，赶紧保存文件吧，该关机啦", "关机吧");
        }
    }
}
