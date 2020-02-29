using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Share.PublicShare
{
    public static class GlobalClass
    {
        private static string _myRunPath = null;
        private static string _myModulePath = null;
        private static string _showModule = null;
        private static DateTime _nowDateTime;

        public static string ShowModule { get => _showModule; set => _showModule = value; }
        public static string MyModulePath { get => _myModulePath; set => _myModulePath = value; }
        public static DateTime NowDateTime { get => _nowDateTime; set => _nowDateTime = value; }

        public static string MyRunPath
        {
            get { return _myRunPath; }
            set
            {
                if (Directory.Exists(value))
                {
                    _myRunPath = value;
                    MyModulePath = _myRunPath + "\\Module";
                    NowDateTime = DateTime.Now;
                }
            }
        }
    }
}
