using App1.models;
using App1.services;
using App1.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public List<Temp> AssetGroupList { get; set; }
        public List<Temp> DepartmentList { get; set; }

        private List<AssetList> _assetList;

        public List<AssetList> AssetClassList
        {
            get { return _assetList; }
            set { _assetList = value; OnPropertyChanged(); }
        }

        private int totalAsset;

        private string _assetFromTotal;

        public string AssetFromTotal
        {
            get { return _assetFromTotal; }
            set { _assetFromTotal = value; OnPropertyChanged(); }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                this.TopStackLayout.IsVisible = false;
            }
            else
            {
                this.TopStackLayout.IsVisible = true;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            AssetGroupList = new List<Temp>();
            AssetGroupList.Add(new Temp { ID = 1, Name = "Hydraulic" });
            AssetGroupList.Add(new Temp { ID = 3, Name = "Electrical" });
            AssetGroupList.Add(new Temp { ID = 4, Name = "Mechanical " });

            DepartmentList = new List<Temp>();
            DepartmentList.Add(new Temp { ID = 1, Name = "Exploration" });
            DepartmentList.Add(new Temp { ID = 2, Name = "Production" });
            DepartmentList.Add(new Temp { ID = 3, Name = "Transportation" });
            DepartmentList.Add(new Temp { ID = 4, Name = "R&D" });
            DepartmentList.Add(new Temp { ID = 5, Name = "Distribution" });
            DepartmentList.Add(new Temp { ID = 6, Name = "QHSE" });

            //StartDatePicker.Date = new DateTime(2017, 1, 1);
            //EndDatePicker.Date = DateTime.Now;
            _ = this.loadInitData();

            this.BindingContext = this;
        }

        GetService getService = new GetService();
        private async Task loadInitData()
        {
            AssetClassList = await getService.getAssetList();
            totalAsset = AssetClassList.Count;
            AssetFromTotal = $"{AssetClassList.Count} assets from {totalAsset}";
        }

        private async Task loadAssetDateAsync()
        {
            var assetgroup = (Temp)AssetGroupPicker.SelectedItem;
            var department = (Temp)DepartmentPicker.SelectedItem;

            AssetRequest assetRequest = new AssetRequest
            {
                AssetGroupId = assetgroup.ID,
                DepartmentId = department.ID,
                StartDate = StartDatePicker.Date,
                EndDate = StartDatePicker.Date,
                SearchContent = SearchEditor.Text
            };

            AssetClassList = await getService.getAssetList(assetRequest);
            AssetFromTotal = $"{AssetClassList.Count} assets from {totalAsset}";
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {    
            if (AssetGroupPicker.SelectedItem != null && AssetGroupPicker.SelectedItem != null)
            {
                _ = this.loadAssetDateAsync();
            }
        }

        private void Picker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (EndDatePicker.Date > StartDatePicker.Date)
            {
                _ = this.loadAssetDateAsync();
            }
            else
            {
                DisplayAlert("Alert", "End date must greater than Start Date", "OK");
            }
        }

        private void SearchEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ = this.loadAssetDateAsync();
        }

        private void EditImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void TransferImageButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private void HistoryImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new AssetTransferHistoryForm((long)(sender as ImageButton).CommandParameter));
        }
    }
}
