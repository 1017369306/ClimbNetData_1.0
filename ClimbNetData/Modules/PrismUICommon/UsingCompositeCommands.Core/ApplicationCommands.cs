﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace PrismUICommon.UsingCompositeCommands.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand = new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }
    }
}
