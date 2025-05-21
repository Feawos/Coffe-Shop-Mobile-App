
using System.ComponentModel;
using FeawosCoffeeApp.Services;
using FeawosCoffeeApp.Model;

namespace FeawosCoffeeApp.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        private readonly FeawosCoffeeAppService feawosCoffeeAppService;
        private Model.MenuItem selectedMenuItem;

        public Model.MenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set
            {
                selectedMenuItem = value;
                OnPropertyChanged(nameof(SelectedMenuItem), GetPropertyChanged(GetPropertyChanged(), GetPropertyChanged(GetPropertyChanged(), GetPropertyChanged(GetPropertyChanged()))));
            }
        }

        private PropertyChangedEventHandler GetPropertyChanged(PropertyChangedEventHandler propertyChangedEventHandler)
        {
            throw new NotImplementedException();
        }

        private PropertyChangedEventHandler GetPropertyChanged()
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DetailsViewModel(int menuItemId, FeawosCoffeeAppService service)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            feawosCoffeeAppService = service;
            SelectedMenuItem = feawosCoffeeAppService.GetMenuItemById(menuItemId);
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}
