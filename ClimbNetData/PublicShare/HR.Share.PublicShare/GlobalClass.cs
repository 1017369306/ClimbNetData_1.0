using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace HR.Share.PublicShare
{
    public class GlobalClass
    {
        #region 私有对象
        private static string _myRunPath = null;
        private static string _myModulePath = null;
        private static string _showModule = null;
        private static DateTime _nowDateTime;
        private static Dictionary<string, string> _modulesDic = null;
        private static string _infoTitle=null;
        private static string _errorTitle = null;
        private static string _warningTitle = null;
        private static string _questionTitle = null;
        private static ImageSource _infoImage = null;
        private static ImageSource _errorImage = null;
        private static ImageSource _warningImage = null;
        private static ImageSource _questionImage = null;


        #endregion

        #region 公共对象
        public static string ShowModule { get => _showModule; set => _showModule = value; }
        public static string MyModulePath { get => _myModulePath; set => _myModulePath = value; }
        public static DateTime NowDateTime { get => _nowDateTime; set => _nowDateTime = value; }

        public static Dictionary<string, string> ModulesDic { get => _modulesDic; set => _modulesDic = value; }

        public static string MyRunPath
        {
            get { return _myRunPath; }
            set
            {
                if (Directory.Exists(value))
                {
                    _myRunPath = value;
                    MyModulePath = _myRunPath + "Modules";
                    NowDateTime = DateTime.Now;
                }
            }
        }

        public static string InfoTitle
        {
            get
            {
                if (_infoTitle == null)
                    _infoTitle = (string)System.Windows.Application.Current.FindResource("InfoTitle");
                return _infoTitle;
            }
        }

        public static string ErrorTitle
        {
            get
            {
                if (_errorTitle == null)
                    _errorTitle = (string)System.Windows.Application.Current.FindResource("ErrorTitle");
                return _errorTitle;
            }
        }
        public static string WarningTitle
        {
            get
            {
                if (_warningTitle == null)
                    _warningTitle = (string)System.Windows.Application.Current.FindResource("WarningTitle");
                return _warningTitle;
            }
        }
        public static string QuestionTitle
        {
            get
            {
                if (_questionTitle == null)
                    _questionTitle = (string)System.Windows.Application.Current.FindResource("QuestionTitle");
                return _questionTitle;
            }
        }
        public static ImageSource InfoImage
        {
            get
            {
                if (_infoImage == null)
                    _infoImage = ((Image)System.Windows.Application.Current.FindResource("InfoImage")).Source;
                return _infoImage;
            }
        }
        public static ImageSource ErrorImage
        {
            get
            {
                if (_errorImage == null)
                    _errorImage = ((Image)System.Windows.Application.Current.FindResource("ErrorImage")).Source;
                return _errorImage;
            }
        }
        public static ImageSource WarningImage
        {
            get
            {
                if (_warningImage == null)
                    _warningImage = ((Image)System.Windows.Application.Current.FindResource("WarningImage")).Source;
                return _warningImage;
            }
        }
        public static ImageSource QuestionImage
        {
            get
            {
                if (_questionImage == null)
                    _questionImage = ((Image)System.Windows.Application.Current.FindResource("QuestionImage")).Source;
                return _questionImage;
            }
        }
        #endregion

        #region 枚举
        /// <summary>
        /// 菜单名
        /// </summary>
        public enum MenuItems
        {
            [DescriptionAttribute("首页")]
            HomePage,
            [DescriptionAttribute("我的任务")]
            MyTask,
            [DescriptionAttribute("数据抓取")]
            ClimbData,
            [DescriptionAttribute("团队协作")]
            TeamCooperation,
            [DescriptionAttribute("定制数据")]
            CustomData,
            [DescriptionAttribute("人工服务")]
            CustomerService
        }
        #endregion

    }

    [MarkupExtensionReturnType(typeof(object[]))]
    public class EnumValuesExtension : MarkupExtension
    {
        public EnumValuesExtension() { }
        public EnumValuesExtension(Type enumType)
        {
            this.EnumType = enumType;
        }
        [ConstructorArgument("enumType")]
        public Type EnumType { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.EnumType == null)
                throw new ArgumentException("The enum type is not set");
            return Enum.GetValues(this.EnumType);
        }
    }

    [MarkupExtensionReturnType(typeof(string))]
    public class EnumNameExtension : MarkupExtension
    {
        public EnumNameExtension() { }
        public EnumNameExtension(object value)
        {
            //this.EnumType = enumType;
            this.Value = value;
        }
        [ConstructorArgument("enumType")]
        public Type EnumType { get; set; }
        [ConstructorArgument("value")]
        public object Value { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (typeof(GlobalClass.MenuItems) == null)
                throw new ArgumentException("The enum type is not set");
            return Enum.GetName(typeof(GlobalClass.MenuItems), this.Value);
            //Enum.GetName(typeof(GlobalClass.MenuItems), GlobalClass.MenuItems.ClimbNet);
        }
    }
}
