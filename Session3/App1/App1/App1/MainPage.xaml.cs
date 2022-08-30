using App1.models;
using App1.services;
using App1.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public List<Temp> AssetList { get; set; }
        public List<Temp> TaskList { get; set; }

        private List<PMList> _pmList;

        public List<PMList> PMList
        {
            get { return _pmList; }
            set { _pmList = value; OnPropertyChanged(); }
        }

        public List<PMList> tempPMList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            AssetList = new List<Temp>();
            AssetList.Add(new Temp { Id = 1, Name = "Toyota Hilux FAF321" });
            AssetList.Add(new Temp { Id = 2, Name = "Suction Line 852" });
            AssetList.Add(new Temp { Id = 3, Name = "ZENY 3,5CFM Single-Stage 5 Pa Rotary Vane" });
            AssetList.Add(new Temp { Id = 4, Name = "Volvo FH16" });


            TaskList = new List<Temp>();
            TaskList.Add(new Temp { Id = 1, Name = "Get Tires Rotated and Balanced." });
            TaskList.Add(new Temp { Id = 2, Name = "Check Engine Oil" });
            TaskList.Add(new Temp { Id = 3, Name = "Check  Air Filter" });
            TaskList.Add(new Temp { Id = 4, Name = "Check Battery" });
            TaskList.Add(new Temp { Id = 5, Name = "Inspect for any damage to paint on pump" });
            TaskList.Add(new Temp { Id = 6, Name = "Inspect cord and cord placement" });
            TaskList.Add(new Temp { Id = 7, Name = "Pull each pump and reset" });

            _ = this.loadDataAsync();
            this.BindingContext = this;
        }

        GetService getService = new GetService();

        private async Task loadDataAsync()
        {
            var result = await getService.GetActiveTask(activeDatePicker.Date);
            PMList = new List<PMList>(result);
            tempPMList = PMList;
        }
        private async Task changeTaskStatusAsync(long pmid)
        {
            var result = await getService.ChangeTaskStatus(pmid);

            if (result == HttpStatusCode.OK)
            {
                _ = DisplayAlert("Alert", "Status Successfully Changed", "Ok");
            }

            _ = this.loadDataAsync(); 
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var pm = (PMList)(sender as StackLayout).BindingContext;

            var result = await getService.ChangeTaskStatus(pm.ID);

            if (result == HttpStatusCode.OK)
            {
                _ = DisplayAlert("Alert", "Status Successfully Changed", "Ok");
            }

            _ = this.loadDataAsync();
        }

        private  void activeDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            _ = this.loadDataAsync();
        }

        private void TapGestureRecognizer_TappedFilterLabel(object sender, EventArgs e)
        {
            AssetPicker.SelectedIndex = -1;
            TaskPicker.SelectedIndex = -1;
            _ = this.loadDataAsync();
        }

        private void AssetPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AssetPicker.SelectedIndex != -1)
            {
                PMList = tempPMList;
                var selectedAsset = (Temp) AssetPicker.SelectedItem;
                PMList = PMList.Where(x => x.AssetID == selectedAsset.Id).ToList();
            }
        }

        private void TaskPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TaskPicker.SelectedIndex != -1)
            {
                PMList = tempPMList;
                var selectedTask = (Temp)TaskPicker.SelectedItem;
                PMList = PMList.Where(x => x.AssetID == selectedTask.Id).ToList();
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new CreatePMPage());
        }
    }
}
