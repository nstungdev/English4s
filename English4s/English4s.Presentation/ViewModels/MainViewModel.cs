using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using English4s.Presentation.Generic;
using MaterialDesignThemes.Wpf;

namespace English4s.Presentation.ViewModels
{
    public partial class MainViewModel(Func<Type, BaseViewModel> viewModelFactory) : ObservableObject
    {
        readonly Func<Type, BaseViewModel> _viewModelFactory = viewModelFactory;
        const int SnackBarDuration = 3;

        [ObservableProperty]
        BaseViewModel? _currentView;

        [ObservableProperty]
        bool isLoading = false;

        [ObservableProperty]
        SnackbarMessageQueue infoSnackBarQueue = new(TimeSpan.FromSeconds(SnackBarDuration));

        [ObservableProperty]
        SnackbarMessageQueue errorSnackBarQueue = new(TimeSpan.FromSeconds(SnackBarDuration));

        public void SetLoadingStatus(bool isLoading)
        {
            IsLoading = isLoading;
        }

        public void PushInfoMessage(string msg)
        {
            InfoSnackBarQueue.Enqueue(msg);
        }

        public void PushErrorMessage(string msg)
        {
            ErrorSnackBarQueue.Enqueue(msg);
        }

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
