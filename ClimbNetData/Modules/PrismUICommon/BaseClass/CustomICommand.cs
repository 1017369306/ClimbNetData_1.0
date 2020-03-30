using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Media;

namespace PrismUICommon.BaseClass
{
    public abstract class CustomICommand : BindableBase
    {
        private string _guid = null;
        private ImageSource _iconKey = null;
        private string displayName = null;
        private bool _isEnabled;

        public string Guid { get => _guid; set => _guid = value; }
        public ImageSource IconKey { get => _iconKey; set => _iconKey = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }
        public abstract bool CanExecute();
        public abstract void Execute();
        public abstract void ExecuteGeneric(string parameter);

        private DelegateCommand _executeDelegateCommand;

        //public abstract DelegateCommand ExecuteDelegateCommand { get { return _executeDelegateCommand}; set; }
        //public DelegateCommand ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);
        public DelegateCommand ExecuteDelegateCommand
        {
            get
            {
                if (_executeDelegateCommand == null)
                    _executeDelegateCommand = new DelegateCommand(Execute, CanExecute);
                return _executeDelegateCommand;
            }
            set
            {
                _executeDelegateCommand = value;
            }
        }
        //public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }

        //public DelegateCommand DelegateCommandObservesProperty { get; private set; }

        //public DelegateCommand DelegateCommandObservesCanExecute { get; private set; }

        //public CustomICommand()
        //{
        //    ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);

        //    DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);

        //    DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);

        //    ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => IsEnabled);
        //}

    }
}
