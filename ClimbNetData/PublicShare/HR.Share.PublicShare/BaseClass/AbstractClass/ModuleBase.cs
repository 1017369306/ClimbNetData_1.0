using HR.Share.PublicShare.BaseClass.Interface;
using System;
using System.Drawing;

namespace HR.Share.PublicShare.BaseClass.AbstractClass
{
    public abstract class ModuleBase : IModuleBase
    {
        #region 实现IModuleBase的接口
        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public string Title
        {
            get
            {
                return MainBaseMethod.GetEnumDescription(menuItem);
            }
        }

        public string Caption
        {
            get
            {
                return MainBaseMethod.GetEnumDescription(menuItem);
            }
        }

        //public GlobalClass.MenuItems menuItem
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public Image Icon
        {
            get
            {
                return null;
            }
        }

        public abstract GlobalClass.MenuItems menuItem { get; }

        public abstract void Load();

        #endregion
    }
}
