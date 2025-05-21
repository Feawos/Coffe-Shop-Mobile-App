
using CommunityToolkit.Mvvm.ComponentModel;
using FeawosCoffeeApp.Model;
using FeawosCoffeeApp.Services;
using FeawosCoffeeApp.View;
using FeawosCoffeeApp.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FeawosCoffeeApp.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title = "Feawos";



        public bool IsNotBusy => !IsBusy;


        protected virtual PropertyChangedEventHandler GetPropertyChanged(PropertyChangedEventHandler propertyChanged, PropertyChangedEventHandler propertyChangedEventHandler) => propertyChanged;

        protected virtual void OnPropertyChanged(string propertyName, PropertyChangedEventHandler propertyChanged) => propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
