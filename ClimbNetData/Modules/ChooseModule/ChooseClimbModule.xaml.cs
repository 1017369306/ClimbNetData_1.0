﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
