using CommunityToolkit.Mvvm.ComponentModel;
using English4s.Presentation.Generic;

namespace English4s.Presentation.ViewModels
{
    public partial class DashBoardViewModel : BaseViewModel
    {
        [ObservableProperty]
        string? content = "This is from viewmodel";
    }
}
