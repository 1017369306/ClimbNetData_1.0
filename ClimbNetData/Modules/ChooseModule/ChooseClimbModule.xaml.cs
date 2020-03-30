using System.Windows.Controls;

namespace ChooseModule
{
    /// <summary>
    /// ChooseClimbModule.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseClimbModule : UserControl
    {

        #region 属性
        ChooseClimbModuleProvider _provider = null;
        #endregion

        public ChooseClimbModule(ChooseClimbModuleProvider provider)
        {
            InitializeComponent();
            this._provider = provider;
        }
    }
}
