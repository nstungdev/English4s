using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using English4s.Presentation.Generic;

namespace English4s.Presentation.ViewModels
{
    public partial class MainViewModel(Func<Type, BaseViewModel> viewModelFactory) : ObservableObject
    {
        readonly Func<Type, BaseViewModel> _viewModelFactory = viewModelFactory;

        [ObservableProperty]
        BaseViewModel? _currentView;

        [RelayCommand]
        public Task Navigate(Type viewModelType)
        {
            if (viewModelType.BaseType != typeof(BaseViewModel))
                return Task.CompletedTask;
            var viewModel = _viewModelFactory.Invoke(viewModelType);
            if (viewModel.GetType() == CurrentView?.GetType())
                return Task.CompletedTask;
            CurrentView = viewModel;
            return Task.CompletedTask;
        }
    }
}
