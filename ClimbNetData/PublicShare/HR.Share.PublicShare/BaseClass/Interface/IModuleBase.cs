using System;
using System.Drawing;

namespace HR.Share.PublicShare.BaseClass.Interface
{
    public interface IModuleBase
    {
        /// <summary>
        /// Module的ID
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Module标题
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Module的描述
        /// </summary>
        string Caption { get; }
        /// <summary>
        /// Module的enum
        /// </summary>
        /// <returns></returns>
        GlobalClass.MenuItems menuItem { get; }
        /// <summary>
        /// 此Module加载的load事件
        /// </summary>
        void Load();
        /// <summary>
        /// 图标
        /// </summary>
        Image Icon { get; }
    }

}
