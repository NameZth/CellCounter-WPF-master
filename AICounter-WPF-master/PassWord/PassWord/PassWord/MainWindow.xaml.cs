using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace PassWord
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length == 17)
            {

                BinaryWriter bw;
                BinaryReader br;
                string FilePath = @"C:\lisence";
               // string File = @"C:\lisence\lisence";
                string PWord;
               

                if (!(Directory.Exists(FilePath)))
                {
                    Directory.CreateDirectory(FilePath);
                }
               
                //FileStream pw = new FileStream(File, FileMode.Create, FileAccess.Write);//搜索创建写入文件 
                //StreamWriter sw = new StreamWriter(pw);

                // 74-70-FD-79-BF-E3

              
                var mac1 = (textBox.Text[0] + 1) % 2;
                var mac2 = (textBox.Text[1]) % 2;
                var mac3 = (textBox.Text[3]) % 2;
                var mac4 = (textBox.Text[4] + 1) % 2;
                var mac5 = (textBox.Text[6]) % 2;
                var mac6 = (textBox.Text[7] + 1) % 2;
                var mac7 = (textBox.Text[9] + 1) % 2;
                var mac8 = (textBox.Text[10] + 1) % 2;
                var mac9 = (textBox.Text[12]) % 2;
                var mac10 = (textBox.Text[13] + 1) % 2;
                var mac11 = (textBox.Text[15] + 1) % 2;
                var mac12 = (textBox.Text[16]) % 2;


                PWord = mac12.ToString() + mac9.ToString() + mac1.ToString() + mac4.ToString() + mac1.ToString() + mac9.ToString() +
                  mac1.ToString() + mac1.ToString() + mac8.ToString() + mac1.ToString() + mac5.ToString() + mac6.ToString() +
                  mac7.ToString() + mac12.ToString() + mac3.ToString() + mac1.ToString() + mac4.ToString() + mac2.ToString() +
                  mac12.ToString() + mac9.ToString() + mac1.ToString() + mac4.ToString() + mac1.ToString() + mac10.ToString() + mac4.ToString() +
                  mac2.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac4.ToString() +
                  mac2.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac6.ToString() +
                  mac10.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac10.ToString() +
                  mac2.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac2.ToString() +
                  mac9.ToString() +
                  mac11.ToString() +
                  mac4.ToString() +
                  mac4.ToString() +
                  mac2.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac6.ToString() +
                  mac4.ToString() +
                  mac7.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac9.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac3.ToString() +
                  mac12.ToString() +
                  mac8.ToString() +
                  mac6.ToString() +
                  mac4.ToString() +
                  mac4.ToString() +
                  mac4.ToString() +
                  mac2.ToString() +
                  mac9.ToString() +
                  mac11.ToString() +
                  mac10.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac4.ToString() +
                  mac10.ToString() +
                  mac1.ToString() +
                  mac12.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac4.ToString() +
                  mac1.ToString() +
                  mac9.ToString() +
                  mac1.ToString() +
                  mac1.ToString() +
                  mac8.ToString() +
                  mac2.ToString() +
                  mac1.ToString() +
                  mac10.ToString();

                // 74-70-FD-79-BF-E3
                // 80-FA-5B-5B-13-B7

                bw = new BinaryWriter(new FileStream("C:\\lisence\\lisence",
                    FileMode.Create, FileAccess.Write));


               // 写入文件

                bw.Write(PWord
                    );

                bw.Close();


                //sw.Write(

                //PWord


                //    );

                //sw.Close();
                //pw.Close();

                MessageBoxResult result = MessageBox.Show("文件已保存到C盘！", "生成成功",
                                          MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("请输入正确的物理地址！", "无法运行",
                                          MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
