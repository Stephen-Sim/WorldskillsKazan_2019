using App1.models;
using App1.services;
using App1.views;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        GetService getService = new GetService();

        private string wellCapacity = "0 m2";

        public string WellCapacity
        {
            get { return wellCapacity; }
            set { wellCapacity = value; OnPropertyChanged(); }
        }

        private List<Well> wellList;

        public List<Well> WellList
        {
            get { return wellList; }
            set { wellList = value; OnPropertyChanged(); }
        }

        private List<WellLayerRequest> wellLayerList;

        public List<WellLayerRequest> WellLayerList
        {
            get { return wellLayerList; }
            set { wellLayerList = value; OnPropertyChanged(); }
        }


        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            if (CrossConnectivity.Current.IsConnected)
            {
                _ = this.loadDataAsync();
            }

            update();
           
            this.BindingContext = this;
        }

        bool lastConnect = true;

        private async void update()
        {
            await Task.Delay(5000);

            if (CrossConnectivity.Current.IsConnected)
            {
                if (lastConnect != CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("alert", "Wifi Connection is Back!", "ok");
                    _ = this.loadDataAsync();
                }

                EditButton.IsVisible = true;
                AddButton.IsVisible = true;
                lastConnect = true;
            }
            else
            {
                if (lastConnect != CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("alert", "Wifi Connection is Lost!", "ok");
                }

                lastConnect = false;
                EditButton.IsVisible = false;
                AddButton.IsVisible = false;
            }

            update();
        }

        public async Task loadDataAsync()
        {
            var res = await getService.GetWells();
            WellList = new List<Well>(res);
        }

        private async void WellPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WellPicker.SelectedItem != null)
            {
                var SelectedWell = (Well) WellPicker.SelectedItem;
                WellCapacity = $"{SelectedWell.Capacity} m2 ";

                var res = await getService.GetWellLayers(SelectedWell.ID);
                WellLayerList = new List<WellLayerRequest>(res);
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddWellForm());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (WellPicker.SelectedItem != null)
            {
                var SelectedWell = (Well) WellPicker.SelectedItem;
            
                App.Current.MainPage.Navigation.PushAsync(new AddWellForm(SelectedWell));
            }
        }
    }
}
