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
    public partial class AssetTransferHistoryForm : ContentPage
    {
        private List<HistoryClass> _historyList;

        public List<HistoryClass> HistoryList
        {
            get { return _historyList; }
            set { _historyList = value; OnPropertyChanged(); }
        }

        public AssetTransferHistoryForm(long ID)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.BindingContext = this;

            _ = this.loadDataAsync(ID);
        }

        GetService getService = new GetService();
        
        private async Task loadDataAsync(long id)
        {
            var result = await getService.getHistoryList(id);
            HistoryList = result;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}