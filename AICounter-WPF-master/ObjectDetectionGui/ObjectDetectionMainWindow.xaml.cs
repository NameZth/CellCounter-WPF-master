using ObjectDetectionGui.Base;
using Models;
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace ObjectDetectionGui
{
    public partial class ObjectDetectionMainWindow : Window
    {
        private PreviewImageModel m_Model;

        public ObjectDetectionMainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            m_Model = PreviewImageModel.Instance;
            previewImageGrid.DataContext = m_Model;

            m_Model.MainImage = previweImage;
            m_Model.MainCanvas = previewCanvas;

            statusBarGrid.DataContext = WrapperModel.Instance;
        }

        private void BrowserView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            //if (WindowState != WindowState.Normal)
            //{
            //    WindowState = WindowState.Normal;
            //}
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
