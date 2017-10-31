using System;

using App8.Models;
using App8.ViewModels;

using Xamarin.Forms;

namespace App8.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            try
            {
                InitializeComponent();

                BindingContext = viewModel = new ItemsViewModel();
            }
            catch (Exception ex)
            {
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void fabBtn_Clicked(object sender, EventArgs e)
        {

        }

        async void Handle_FabClicked(object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync(new CreateUPM());
            //  this.DisplayAlert("Floating Action Button", "You clicked the FAB!", "Awesome!");
        }
    }
}
