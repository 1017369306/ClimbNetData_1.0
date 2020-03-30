using HR.Share.Forms;
using System;
using System.Drawing;

namespace HR.Share.PublicShare
{
    public enum ModuleGroupType
    {
        WholeMachine
    }

    /// <summary>
    /// 客户端功能接口定义
    /// </summary>
    public interface IModuleInterface : IDisposable
    {
        Guid Id { get; }
        string Caption { get; }
        Image Icon { get; }
        ModuleGroupType ModuleType { get; }
        BasePanel Content { get; }
    }
}
