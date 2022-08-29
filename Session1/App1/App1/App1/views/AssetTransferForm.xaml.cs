using App1.models;
using App1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetTransferForm : ContentPage
    {
        public List<Temp> DepartmentList { get; set; }
        public List<Temp> LocationList { get; set; }

        private AssetList Asset;
        public AssetTransferForm(AssetList asset)
        {
            InitializeComponent();
            AssetNameLabel.Text = asset.AssetName;
            DepartmentLabel.Text = asset.Department;
            AssetSNLabel.Text = asset.AssetSN;

            DepartmentList = new List<Temp>();
            DepartmentList.Add(new Temp { ID = 1, Name = "Exploration" });
            DepartmentList.Add(new Temp { ID = 2, Name = "Production" });
            DepartmentList.Add(new Temp { ID = 3, Name = "Transportation" });
            DepartmentList.Add(new Temp { ID = 4, Name = "R&D" });
            DepartmentList.Add(new Temp { ID = 5, Name = "Distribution" });
            DepartmentList.Add(new Temp { ID = 6, Name = "QHSE" });

            LocationList = new List<Temp>();
            LocationList.Add(new Temp { ID = 1, Name = "Kazan" });
            LocationList.Add(new Temp { ID = 2, Name = "Volka" });
            LocationList.Add(new Temp { ID = 3, Name = "Moscow" });

            NewAssetSNLabel.Text = $"??/{asset.AssetGroupId.ToString("00")}/????";
            Asset = asset;

            this.BindingContext = this;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        GetService getService = new GetService();
        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (DepartmentPicker.SelectedItem != null && LocationPicker.SelectedItem != null)
            {
                AssetTransferRequest assetTransfer = new AssetTransferRequest
                {
                    AssetID = Asset.AssetID,
                    NewDepartmentId = ((Temp)DepartmentPicker.SelectedItem).ID,
                    NewLocationId = ((Temp)LocationPicker.SelectedItem).ID,
                    AssetGroupId = Asset.AssetGroupId
                };

                _ = this.AssetTransferAsync(assetTransfer);
            }
            else
            {
                DisplayAlert("Alert", "All feilds are required!", "Ok");
            }
        }

        private async Task AssetTransferAsync(AssetTransferRequest assetTransfer)
        {
            var res = await getService.assetTransfer(assetTransfer);

            if (res == HttpStatusCode.OK)
            {
                await DisplayAlert("Alert", "Transfer Request Successfully Made!!!", "Ok");

                App.Current.MainPage = new NavigationPage();
                _ = App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alert", "Request Failed!", "Ok");
            }
        }

    }
}