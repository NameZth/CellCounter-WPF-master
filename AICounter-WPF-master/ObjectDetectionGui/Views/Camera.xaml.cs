using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFMediaKit.DirectShow.Controls;

namespace ObjectDetectionGui.Views
{
    /// <summary>
    /// Camera.xaml 的交互逻辑
    /// </summary>
    public partial class Camera : System.Windows.Controls.UserControl
    {
        string fileName = "";
        string Path;

        public Camera()
        {
            InitializeComponent(); 
            cb.ItemsSource = MultimediaUtil.VideoInputNames;
            if (MultimediaUtil.VideoInputNames.Length > 0)
            {
                cb.SelectedIndex = 1;//第0个摄像头为默认摄像头
            }
            else
            {
                System.Windows.MessageBox.Show("电脑没有安装任何可用摄像头");
            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vce.VideoCaptureSource = (string)cb.SelectedItem;
        }

        public void btnCapture_Click(object sender, RoutedEventArgs e)
        {

            // string fileName = Interaction.InputBox("请输入文件名", "命名框");
            //if (fileName == "") {
            //    MessageBoxResult result = System.Windows.MessageBox.Show("请设置路径！", "无法拍照",
            //         MessageBoxButton.OK, MessageBoxImage.Information);
            //}


            //string Path = System.IO.Path.Combine(@"C:\AICounter Files", fileName);
            // 建立目标渲染图像器，高度为前台控件实显高度，此处不能使用.width或.height属性，否则现错误。
            // 为了避免图像抓取出现黑边现象，需要对图象进行重新测量及缩放
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)vce.ActualWidth * 3, (int)vce.ActualHeight * 3, 288, 288, PixelFormats.Default);
            //VideoCaptureElement的Stretch="Fill"
            vce.Measure(vce.RenderSize);
            vce.Arrange(new Rect(vce.RenderSize));
            // 指定图像渲染目标
            bitmap.Render(vce);
            // 建立图像解码器。类型为jpeg
            BitmapEncoder encoder = new JpegBitmapEncoder();
            // 将当前渲染器中渲染位图作为一个位图帧加入解码器，进行解码，取得数据流。
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            // 建立内存流，将得到解码图像流写入内存流。
            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Save(stream);
                byte[] pics = stream.ToArray(); // 将流以文件形式存储于计算机中。
                //string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
               

                if (Directory.Exists(Path))
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("此文件已存在！", "无需创建",
                                       MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Directory.CreateDirectory(Path);
                    
                }

                string fullPath = System.IO.Path.Combine(Path, fileName+".jpg");
                //保存图片
                File.WriteAllBytes(fullPath, pics);
            }   // 预览效果暂停。
            //vce.Pause();
        }

       
        private void btnanew_Click(object sender, RoutedEventArgs e)
        {
            //File.Delete(fullPath.ToString());
            //vce.Play();
            //vce.Close();
            //fileName = Interaction.InputBox("请输入文件名", "命名框");
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择网页保存位置";
            BrowDialog.ShowDialog();
            Path = BrowDialog.SelectedPath;
        }

        /// <summary>
        /// 重拍
        /// </summary>
        /// 
        
    }
}

