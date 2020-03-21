using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace HR.Share.PublicShare
{
    public class GlobalClass
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
            ClimbNet,
            [DescriptionAttribute("团队协作")]
            TeamCooperation,
            [DescriptionAttribute("定制数据")]
            CustomData,
            [DescriptionAttribute("人工服务")]
            CustomerService
        }
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
