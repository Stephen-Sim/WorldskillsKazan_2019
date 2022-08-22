using App1.models;
using App1.services;
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
        public List<Temp> AssetList { get; set; }
        public Temp SelectedAsset { get; set; }
        public List<Temp> TaskList { get; set; }
        public Temp SelectedTask { get; set; }

        private List<PMList> _pmList;

        public List<PMList> PMList
        {
            get { return _pmList; }
            set { _pmList = value; OnPropertyChanged(); }
        }


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

            this.loadDataAsync();
            this.BindingContext = this;
        }

        GetService getService = new GetService();

        private async Task loadDataAsync()
        {
            var result = await getService.GetActiveTask("");
            PMList = new List<PMList>(result);
        }
    }
}
