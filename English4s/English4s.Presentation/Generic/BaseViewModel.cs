using CommunityToolkit.Mvvm.ComponentModel;
using English4s.Presentation.ViewModels;
using MaterialDesignThemes.Wpf;

namespace English4s.Presentation.Generic
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly MainViewModel _mainViewModel;
        protected BaseViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            Task.Factory.StartNew(Init);
        }
        public abstract Task Init();
    }
}
