using CommunityToolkit.Mvvm.ComponentModel;
using English4s.Presentation.Generic;

namespace English4s.Presentation.ViewModels
{
    public partial class DashBoardViewModel(MainViewModel mainViewModel) : BaseViewModel(mainViewModel)
    {
        [ObservableProperty]
        string? content = "This is from viewmodel";

        public override Task Init()
        {
            try
            {
                _mainViewModel.SetLoadingStatus(true);
            }
            catch (Exception ex) 
            {
                _mainViewModel.PushErrorMessage(ex.Message);
            }
            finally
            {
                _mainViewModel.SetLoadingStatus(false);
            }
            return Task.CompletedTask;
        }
    }
}
