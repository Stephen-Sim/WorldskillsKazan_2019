using App1.models;
using App1.services;
using App1.views;
using Newtonsoft.Json;
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

            _ = this.loadDataAsync();

            this.BindingContext = this;
        }

        public async Task loadDataAsync()
        {
            var res = await getService.GetWells();
            WellList = new List<Well>(res);
        }

        private async void WellPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedWell = (Well) WellPicker.SelectedItem;
            WellCapacity = $"{SelectedWell.Capacity} m2 ";

            var res = await getService.GetWellLayers(SelectedWell.ID);
            WellLayerList = new List<WellLayerRequest>(res);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new AddWellForm());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (WellPicker.SelectedItem != null)
            {
                var SelectedWell = (Well) WellPicker.SelectedItem;
            
                App.Current.MainPage = new NavigationPage();
                App.Current.MainPage.Navigation.PushAsync(new AddWellForm(SelectedWell));
            }
        }
    }
}
