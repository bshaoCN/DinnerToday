using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dinner.Models;

namespace Dinner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.DishDatabase.GetDishesAsync();
        }
        private async void OnDishAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DishPage
            {
                BindingContext = new Dish()
            });
        }


        private async void OnRandomDishSelected(object sender, EventArgs e)
        {
            listView.ItemsSource = await App.DishDatabase.GetRandomDishedAsync();
        }

        private async void OnDishesRefreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = await App.DishDatabase.GetDishesAsync();
            listView.IsRefreshing = false;
        }

        private async void OnEdit(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            await Navigation.PushAsync(new DishPage
            {
                BindingContext = (Dish)item.CommandParameter
            });
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            await App.DishDatabase.DeleteDishAsync((Dish)item.CommandParameter);
            listView.ItemsSource = await App.DishDatabase.GetDishesAsync();
        }
    }
}