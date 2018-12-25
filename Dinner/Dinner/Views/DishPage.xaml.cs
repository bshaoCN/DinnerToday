using Dinner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dinner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DishPage : ContentPage
	{
		public DishPage ()
		{
			InitializeComponent ();
		}

        private async void OnDishSaved(object sender, EventArgs e)
        {
            var todoItem = (Dish)BindingContext;
            await App.DishDatabase.SaveDishAsync(todoItem);
            await Navigation.PopAsync();
        }
    }
}