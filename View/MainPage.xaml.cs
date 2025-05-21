using FeawosCoffeeApp.ViewModel;


namespace FeawosCoffeeApp.View;

public partial class MainPage : ContentPage
{
    
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
