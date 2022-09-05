using App1.models;
using App1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWellForm : ContentPage
    {
        public List<Temp> RockList { get; set; }
        public List<Temp> WellTypeList { get; set; }

        private List<RockLayer> addedRockList;

        public List<RockLayer> AddedRockList
        {
            get { return addedRockList; }
            set { addedRockList = value; OnPropertyChanged(); }
        }

        public AddWellForm()
        {
            InitializeComponent();

            RockList = new List<Temp>();
            RockList.Add(new Temp { ID = 1, Name = "Argillite" });
            RockList.Add(new Temp { ID = 2, Name = "Breccia" });
            RockList.Add(new Temp { ID = 3, Name = "Chalk" });
            RockList.Add(new Temp { ID = 4, Name = "Chert" });
            RockList.Add(new Temp { ID = 5, Name = "Coal" });
            RockList.Add(new Temp { ID = 6, Name = "Conglomerate" });
            RockList.Add(new Temp { ID = 7, Name = "Dolomite" });
            RockList.Add(new Temp { ID = 8, Name = "Limestone" });
            RockList.Add(new Temp { ID = 9, Name = "Marl" });
            RockList.Add(new Temp { ID = 10, Name = "Mudstone" });
            RockList.Add(new Temp { ID = 11, Name = "Sandstone" });
            RockList.Add(new Temp { ID = 12, Name = "Shale" });
            RockList.Add(new Temp { ID = 13, Name = "Tufa" });
            RockList.Add(new Temp { ID = 14, Name = "Wackestone" });

            WellTypeList = new List<Temp>();
            WellTypeList.Add(new Temp { ID = 1, Name = "Well" });
            WellTypeList.Add(new Temp { ID = 2, Name = "Section" });

            FromDepthEditor.Text = "0";

            AddedRockList = new List<RockLayer>();

            this.BindingContext = this;
        }

        public AddWellForm(Well well)
        {
            InitializeComponent();

            RockList = new List<Temp>();
            RockList.Add(new Temp { ID = 1, Name = "Argillite" });
            RockList.Add(new Temp { ID = 2, Name = "Breccia" });
            RockList.Add(new Temp { ID = 3, Name = "Chalk" });
            RockList.Add(new Temp { ID = 4, Name = "Chert" });
            RockList.Add(new Temp { ID = 5, Name = "Coal" });
            RockList.Add(new Temp { ID = 6, Name = "Conglomerate" });
            RockList.Add(new Temp { ID = 7, Name = "Dolomite" });
            RockList.Add(new Temp { ID = 8, Name = "Limestone" });
            RockList.Add(new Temp { ID = 9, Name = "Marl" });
            RockList.Add(new Temp { ID = 10, Name = "Mudstone" });
            RockList.Add(new Temp { ID = 11, Name = "Sandstone" });
            RockList.Add(new Temp { ID = 12, Name = "Shale" });
            RockList.Add(new Temp { ID = 13, Name = "Tufa" });
            RockList.Add(new Temp { ID = 14, Name = "Wackestone" });

            WellTypeList = new List<Temp>();
            WellTypeList.Add(new Temp { ID = 1, Name = "Well" });
            WellTypeList.Add(new Temp { ID = 2, Name = "Section" });

            this.BindingContext = this;

            FromDepthEditor.Text = "0";

            AddedRockList = new List<RockLayer>();

            this.WellId = (int) well.ID;
            
            WellNameEditor.Text = well.WellName;
            var items = WellTypeList.Where(x => x.ID == well.WellTypeID).FirstOrDefault();
            WellTypePicker.SelectedItem = WellTypeList.Where(x => x.ID == well.WellTypeID).FirstOrDefault();
            WellCapacityEditor.Text = well.Capacity.ToString();
            GasDepthEditor.Text = well.GasOilDepth.ToString();

            var tempRockList = new List<RockLayer>();

            foreach (var item in well.WellLayers)
            {
                tempRockList.Add(new RockLayer { 
                    RockId = item.RockType.ID,
                    RockName = item.RockType.Name,
                    FromDepth = item.StartPoint,
                    ToDepth = item.EndPoint,
                });
            }

            AddedRockList = new List<RockLayer>(tempRockList.OrderBy(x => x.FromDepth).ToList());

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WellNameEditor.Text) || string.IsNullOrEmpty(GasDepthEditor.Text) || string.IsNullOrEmpty(WellCapacityEditor.Text) || WellTypePicker.SelectedItem == null)
            {
                DisplayAlert("Alert", "The feilds above is required before adding the rock layer.", "Ok");
                return;
            }

            int fromDepth = int.Parse(FromDepthEditor.Text);
            int toDepth = int.Parse(ToDepthEditor.Text);

            int GasDepth = int.Parse(GasDepthEditor.Text);

            if (RockPicker.SelectedItem == null || toDepth <= 0 || fromDepth < 0)
            {
                DisplayAlert("Alert", "All fields are required!", "Ok");
                return;
            }

            if (toDepth - fromDepth < 100)
            {
                DisplayAlert("Alert", "The depth of a layer cannot be less than 100 points", "Ok");
                return;
            }

            if (toDepth > GasDepth)
            {
                DisplayAlert("Alert", "The depth of a layer cannot be greater than gas or oil extraction depth", "Ok");
                return;
            }

            RockLayer rockLayer = new RockLayer
            {
                RockId = ((Temp)RockPicker.SelectedItem).ID,
                RockName = ((Temp)RockPicker.SelectedItem).Name,
                FromDepth = fromDepth,
                ToDepth = toDepth
            };

            var templist = AddedRockList;
            templist.Add(rockLayer);
            AddedRockList = new List<RockLayer>(templist);

            FromDepthEditor.Text = toDepth.ToString();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }


        GetService getService = new GetService();
        private int WellId = 0;

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WellNameEditor.Text) || string.IsNullOrEmpty(GasDepthEditor.Text) || string.IsNullOrEmpty(WellCapacityEditor.Text) || WellTypePicker.SelectedItem == null)
            {
                await DisplayAlert("Alert", "All fields are required!", "Ok");
                return;
            }

            if (addedRockList.Count == 0)
            {
                await DisplayAlert("Alert", "At least one rock layer should be added", "Ok");
                return;
            }

            AddWellRequest addWellRequest = new AddWellRequest();
            addWellRequest.WellID = this.WellId;
            addWellRequest.WellName = WellNameEditor.Text;
            addWellRequest.WellTypeID = ((Temp)WellTypePicker.SelectedItem).ID;
            addWellRequest.GasOilDepth = int.Parse(GasDepthEditor.Text);
            addWellRequest.Capacity = int.Parse(WellCapacityEditor.Text);
            addWellRequest.RockLayers = new List<RockLayer>(addedRockList);

            var res = await getService.StoreWell(addWellRequest);

            if (res == HttpStatusCode.OK)
            {
                await DisplayAlert("Alert", "Well Succesfully Stored!", "Ok");

                App.Current.MainPage = new NavigationPage();
                _ = App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alert", "Somthing Went Wrong!", "Ok");
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var rockLayer = (RockLayer)(sender as ImageButton).CommandParameter;

            var templist = AddedRockList;
            templist.Remove(rockLayer);
            AddedRockList = new List<RockLayer>(templist);

            DisplayAlert("Alert", "Layers has deleted!", "Ok");
        }
    }
}