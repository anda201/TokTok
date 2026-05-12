using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokTok.ViewModels
{
    [ObservableObject] /*해당 어트리뷰트를 추가해 INotifyPropertyChanged를 사용*/
    public partial class MainViewModel
    {
        [ObservableProperty] 
        private INotifyPropertyChanged _currentViewModel;

        [RelayCommand] /*Commend를 간단하게 호출할 수 있도록 도와주는 어트리뷰트*/
        public void ToLogin() { 
                CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(LoginControlViewModel));
        }
        [RelayCommand] 
        public void ToChangePwd() { 
                CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(ChangePwdControlViewModel));
        }
        [RelayCommand] 
        public void ToSignup() { 
                CurrentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(SignupControlViewModel));
        }
        public MainViewModel() {
                _currentViewModel = (INotifyPropertyChanged)App.Current.Services.GetService(typeof(LoginControlViewModel));
        }
    }
}
