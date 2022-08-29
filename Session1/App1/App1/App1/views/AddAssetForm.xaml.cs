using App1.models;
using App1.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssetForm : ContentPage
    {
        public List<Temp> AssetGroupList { get; set; }
        public List<Temp> DepartmentList { get; set; }
        public List<Temp> LocationList { get; set; }
        public List<Temp> EmployeeList { get; set; }
        public AddAssetForm()
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

            LocationList = new List<Temp>();
            LocationList.Add(new Temp { ID = 1, Name = "Kazan" });
            LocationList.Add(new Temp { ID = 2, Name = "Volka" });
            LocationList.Add(new Temp { ID = 3, Name = "Moscow" });

            EmployeeList = new List<Temp>();
            EmployeeList.Add(new Temp { ID = 1, Name = "Martina Winegarden" });
            EmployeeList.Add(new Temp { ID = 2, Name = "Rashida Brammer" });
            EmployeeList.Add(new Temp { ID = 3, Name = "Mohamed Krall" });
            EmployeeList.Add(new Temp { ID = 4, Name = "Shante Karr" });
            EmployeeList.Add(new Temp { ID = 5, Name = "Rosaura Rames" });
            EmployeeList.Add(new Temp { ID = 6, Name = "Toi Courchesne" });
            EmployeeList.Add(new Temp { ID = 7, Name = "Precious Wismer" });
            EmployeeList.Add(new Temp { ID = 8, Name = "Josefa Otte" });
            EmployeeList.Add(new Temp { ID = 9, Name = "Afton Harrington" });
            EmployeeList.Add(new Temp { ID = 10, Name = "Daphne Morrow" });
            EmployeeList.Add(new Temp { ID = 11, Name = "Dottie Polson" });
            EmployeeList.Add(new Temp { ID = 12, Name = "Alleen Nally" });
            EmployeeList.Add(new Temp { ID = 13, Name = "Hilton Odom" });
            EmployeeList.Add(new Temp { ID = 14, Name = "Shawn Hillebrand" });
            EmployeeList.Add(new Temp { ID = 15, Name = "Lorelei Kettler" });
            EmployeeList.Add(new Temp { ID = 16, Name = "Jalisa Gossage" });
            EmployeeList.Add(new Temp { ID = 17, Name = "Germaine Sim" });
            EmployeeList.Add(new Temp { ID = 18, Name = "Suzanna Wollman" });
            EmployeeList.Add(new Temp { ID = 19, Name = "Jennette Besse" });
            EmployeeList.Add(new Temp { ID = 20, Name = "Margherita Anstine" });
            EmployeeList.Add(new Temp { ID = 21, Name = "Earleen Lambright" });
            EmployeeList.Add(new Temp { ID = 22, Name = "Lyn Valdivia" });
            EmployeeList.Add(new Temp { ID = 23, Name = "Alycia Couey" });
            EmployeeList.Add(new Temp { ID = 24, Name = "Lewis Rousey" });
            EmployeeList.Add(new Temp { ID = 25, Name = "Tanja Profitt" });
            EmployeeList.Add(new Temp { ID = 26, Name = "Cherie Whyte" });
            EmployeeList.Add(new Temp { ID = 27, Name = "Efren Leaf" });
            EmployeeList.Add(new Temp { ID = 28, Name = "Delta Darcangelo" });
            EmployeeList.Add(new Temp { ID = 29, Name = "Jess Bodnar" });
            EmployeeList.Add(new Temp { ID = 30, Name = "Sudie Parkhurst" });

            ExipredDatePicker.Date = DateTime.Today;
            this.BindingContext = this;
        }

        private long? AssetID = null;

        public AddAssetForm(long id)
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

            LocationList = new List<Temp>();
            LocationList.Add(new Temp { ID = 1, Name = "Kazan" });
            LocationList.Add(new Temp { ID = 2, Name = "Volka" });
            LocationList.Add(new Temp { ID = 3, Name = "Moscow" });

            EmployeeList = new List<Temp>();
            EmployeeList.Add(new Temp { ID = 1, Name = "Martina Winegarden" });
            EmployeeList.Add(new Temp { ID = 2, Name = "Rashida Brammer" });
            EmployeeList.Add(new Temp { ID = 3, Name = "Mohamed Krall" });
            EmployeeList.Add(new Temp { ID = 4, Name = "Shante Karr" });
            EmployeeList.Add(new Temp { ID = 5, Name = "Rosaura Rames" });
            EmployeeList.Add(new Temp { ID = 6, Name = "Toi Courchesne" });
            EmployeeList.Add(new Temp { ID = 7, Name = "Precious Wismer" });
            EmployeeList.Add(new Temp { ID = 8, Name = "Josefa Otte" });
            EmployeeList.Add(new Temp { ID = 9, Name = "Afton Harrington" });
            EmployeeList.Add(new Temp { ID = 10, Name = "Daphne Morrow" });
            EmployeeList.Add(new Temp { ID = 11, Name = "Dottie Polson" });
            EmployeeList.Add(new Temp { ID = 12, Name = "Alleen Nally" });
            EmployeeList.Add(new Temp { ID = 13, Name = "Hilton Odom" });
            EmployeeList.Add(new Temp { ID = 14, Name = "Shawn Hillebrand" });
            EmployeeList.Add(new Temp { ID = 15, Name = "Lorelei Kettler" });
            EmployeeList.Add(new Temp { ID = 16, Name = "Jalisa Gossage" });
            EmployeeList.Add(new Temp { ID = 17, Name = "Germaine Sim" });
            EmployeeList.Add(new Temp { ID = 18, Name = "Suzanna Wollman" });
            EmployeeList.Add(new Temp { ID = 19, Name = "Jennette Besse" });
            EmployeeList.Add(new Temp { ID = 20, Name = "Margherita Anstine" });
            EmployeeList.Add(new Temp { ID = 21, Name = "Earleen Lambright" });
            EmployeeList.Add(new Temp { ID = 22, Name = "Lyn Valdivia" });
            EmployeeList.Add(new Temp { ID = 23, Name = "Alycia Couey" });
            EmployeeList.Add(new Temp { ID = 24, Name = "Lewis Rousey" });
            EmployeeList.Add(new Temp { ID = 25, Name = "Tanja Profitt" });
            EmployeeList.Add(new Temp { ID = 26, Name = "Cherie Whyte" });
            EmployeeList.Add(new Temp { ID = 27, Name = "Efren Leaf" });
            EmployeeList.Add(new Temp { ID = 28, Name = "Delta Darcangelo" });
            EmployeeList.Add(new Temp { ID = 29, Name = "Jess Bodnar" });
            EmployeeList.Add(new Temp { ID = 30, Name = "Sudie Parkhurst" });

            this.BindingContext = this;
            AssetID = id;
            _ = getAssetById((long)AssetID);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        GetService getService = new GetService();

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AssetNameEditor.Text) && !string.IsNullOrEmpty(AssetDescEditor.Text) 
                && DepartmentPicker.SelectedItem != null    && LocationPicker.SelectedItem != null 
                && AssetGroupPicker.SelectedItem != null    && EmployeePicker.SelectedItem != null)
            {
                AddAssetRequest addAssetRequest = new AddAssetRequest
                {
                    AssetID = this.AssetID,
                    AssetName = AssetNameEditor.Text,
                    AssetDesc = AssetDescEditor.Text,
                    DepartmentId = ((Temp)DepartmentPicker.SelectedItem).ID,
                    LocationId = ((Temp)LocationPicker.SelectedItem).ID,
                    AssetGroupId = ((Temp)AssetGroupPicker.SelectedItem).ID,
                    EmployeeId = ((Temp)EmployeePicker.SelectedItem).ID,
                    ExpiredDate = ExipredDatePicker.Date
                };
                _ = this.storeAsset(addAssetRequest);
            }
            else
            {
                DisplayAlert("Alert", "All fields are required!!", "Ok");
            }
        }

        private async Task storeAsset(AddAssetRequest addAssetRequest)
        {
            var res = await getService.storeAsset(addAssetRequest);
            if (res == System.Net.HttpStatusCode.OK)
            {
                await DisplayAlert("Alert", "Asset is succussfully stored!", "OK");
                App.Current.MainPage = new NavigationPage();
                _ = App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alert", "Asset failed to store!", "OK");
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        private async Task getAssetById(long id)
        {
            var res = await getService.getAssetById(id);
            
            if (res != null)
            {
                AssetNameEditor.Text = res.AssetName;
                AssetDescEditor.Text = res.Description;
                DepartmentPicker.SelectedItem = DepartmentList.Where(d => d.ID == res.DepartmentID).FirstOrDefault();
                LocationPicker.SelectedItem = LocationList.Where(d => d.ID == res.LocationID).FirstOrDefault();
                AssetGroupPicker.SelectedItem = AssetGroupList.Where(d => d.ID == res.AssetGroupID).FirstOrDefault();
                EmployeePicker.SelectedItem = EmployeeList.Where(d => d.ID == res.EmployeeID).FirstOrDefault();

                if (res.WarrantyDate != null)
                {
                    ExipredDatePicker.Date = (DateTime)res.WarrantyDate;
                }
            }
        }
    }
}