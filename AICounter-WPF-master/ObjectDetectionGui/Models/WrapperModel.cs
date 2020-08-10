using System.Linq;
using DeepLearning;
using System.Diagnostics;
using ObjectDetectionGui.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows;
using ObjectDetectionGui.Views;

namespace Models
{
    public class WrapperModel: NotifiedModelBase
    {
        #region Fields

        private static WrapperModel m_Instance = null;
        private string m_NetInitilizeElapsedTime;
        private string m_NetHardware;
        private string m_DetectionElapsedTime;
        private bool m_IsDetectionEnable = false;

        #endregion

        #region Initilizing

        private WrapperModel()
        {
            IsDetectionEnable = false;
            Task.Run(() => InitialNetwork());
        }

        private void InitialNetwork()
        {
            IsDetectionEnable = false;
           // var sw = new Stopwatch();
           // sw.Start();
            Wrapper = new DeepLearningWrapper();
            Wrapper.InitilizeDeepLearningNetwork();
            InitilizeHardware();
            //sw.Stop();
           //NetInitilizeElapsedTime = "Network Initilaized in " + sw.Elapsed.TotalMilliseconds.ToString("F2") + " ms";
            IsDetectionEnable = true;
        }

        private void InitilizeHardware()
        {
            switch (Wrapper.DetectionHardware)
            {
                case DeepLearning.Base.DetectionHardwares.CPU:
                    //NetHardware = "Process in CPU";
                    break;
                case DeepLearning.Base.DetectionHardwares.GPU:
                    //NetHardware = "Process in GPU";
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Detection

        public List<DetectedItemInfo> Detect()
        {
            int live_num = 0;
            int dead_num = 0;
            int total;
            double sr;
            string DetectionResult;


            List<DetectedItemInfo> items;
            items = Wrapper.Detect(FilePath).ToList();
            foreach (DetectedItemInfo item in items)
            {
                if (item.Type == "live"){live_num += 1;}
                if (item.Type == "dead"){dead_num += 1;}
             }
            total = live_num + dead_num;

            if (total == 0) { sr = 0; }
            else { sr = ((float)live_num / total) * 100; }
            
            DetectionElapsedTime = "  " + "活细胞: " + live_num + "            死细胞: " + dead_num + "            总数: " + total + "            细胞活力: " + sr.ToString("0.00##") + "%";
            DetectionResult = "活细胞: "  + live_num + "\r\n" + 
                              "死细胞: " + dead_num + "\r\n" + 
                              "总数: " + total + "\r\n" + 
                              "细胞活力: " + sr.ToString("0.00##") + "%" + "\r\n";

            //string fileName

            int start = 0, length = FilePath.Length-4;

            string fileName = FilePath.Substring(start, length); 
            string path = fileName + ".txt";
          
            FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//搜索创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(DetectionResult);
            sw.Close();
            fs1.Close();
            return items;
        }

        #endregion

        #region Properties

        public static WrapperModel Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new WrapperModel();
                return m_Instance;
            }
        }

        public string NetInitilizeElapsedTime
        {
            get { return m_NetInitilizeElapsedTime; }
            set { SetProperty(ref m_NetInitilizeElapsedTime, value);}
        }

        public string NetHardware
        {
            get { return m_NetHardware; }
            set { SetProperty(ref m_NetHardware, value);}
        }

        public string DetectionElapsedTime
        {
            get { return m_DetectionElapsedTime; }
            set { SetProperty(ref m_DetectionElapsedTime, value);}
        }

        public bool IsDetectionEnable
        {
            get { return m_IsDetectionEnable; }
            set { SetProperty(ref m_IsDetectionEnable, value);}
        }

        public DeepLearningWrapper Wrapper { get; private set; }
        public string FilePath { get; set; }

        #endregion
    }
}
