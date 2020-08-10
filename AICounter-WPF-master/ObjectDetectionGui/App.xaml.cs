using Key;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ObjectDetectionGui
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string macs;
            string lisence;
            macs = CounterKey.GetMacByNetworkInterface();
            lisence = IsWhat.lisence.Read();
            if (!(macs == lisence))
            {
                MessageBoxResult result = MessageBox.Show("此软件未注册！", "错误提示",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                Shutdown();
            }
            
        }
    }

}
