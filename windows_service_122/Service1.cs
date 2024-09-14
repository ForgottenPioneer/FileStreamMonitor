using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.ServiceProcess;
//using System.Text;
//using System.Threading.Tasks;

//namespace windows_service_122
//{
//    public partial class FileMonitorService : ServiceBase
//    {
//        private FileSystemWatcher watcher;
//        public FileMonitorService()
//        {
//            InitializeComponent();
//            watcher = new FileSystemWatcher();
//            watcher.Path = @"C:\MonitorDirectory";
//            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
//            watcher.Filter = ".txt";
//            watcher.Created += OnChanged;
//            watcher.Changed += OnChanged;
//            watcher.Deleted += OnChanged;
//        }
//        protected override void OnStart(string[] args)
//        {
//            watcher.EnableRaisingEvents = true;
//            File.AppendAllText(@"C:\logs\log.txt", "Служба запущена." + Environment.NewLine);

//        }
//        protected override void OnStop()
//        {
//            watcher.EnableRaisingEvents = false;
//            File.AppendAllText(@"C:\logs\log.txt", "Служба остановлена." + Environment.NewLine);
//        }
//        private void OnChanged(object sender, FileSystemEventArgs e)
//        {
//            string message = $"{e.ChangeType}: {e.FullPath} at {DateTime.Now}";
//            File.AppendAllText(@"C:\logs\log.txt", message + Environment.NewLine);
//        }
//    }
//}












using System;
using windows_service_122;
using System.IO;
using System.ServiceProcess;

namespace FileMonitorService
{
    public partial class FileMonitorService : ServiceBase
    {
        private FileSystemWatcher _watcher;

        public FileMonitorService()
        {
            InitializeComponent();
            _watcher = new FileSystemWatcher();
            _watcher.Path = @"C:\MonitorDirectory";
            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            _watcher.Filter = ".txt";
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.Changed += OnChanged;
        }

        protected override void OnStart(string[] args)
        {
            _watcher.EnableRaisingEvents = true;
            File.AppendAllText(@"C:\PathToLog\log.txt", "Service started." + Environment.NewLine);
        }

        protected override void OnStop()
        {
            _watcher.EnableRaisingEvents = false;
            File.AppendAllText(@"C:\PathToLog\log.txt", "Service stopped." + Environment.NewLine);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string message = $"{e.ChangeType}: {e.FullPath} at {DateTime.Now}";
            File.AppendAllText(@"C:\PathToLog\log.txt", message + Environment.NewLine);
        }
    }
}
