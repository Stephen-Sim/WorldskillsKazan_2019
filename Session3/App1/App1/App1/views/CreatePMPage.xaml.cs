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
    public partial class CreatePMPage : ContentPage
    {
        public List<Temp> AssetList { get; set; }
        public List<Temp> TaskList { get; set; }
        public List<Temp> ModelList { get; set; }
        public List<DayOfWeek> WeekDayList { get; set; }
        public List<int> MonthDayList { get; set; }

        private List<Temp> _selectedAssetList;

        public List<Temp> SelectedAssetList
        {
            get { return _selectedAssetList; }
            set { _selectedAssetList = value; OnPropertyChanged(); }
        }


        public CreatePMPage()
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

            ModelList = new List<Temp>();
            ModelList.Add(new Temp { Id = 1, Name = "Daily" });
            ModelList.Add(new Temp { Id = 2, Name = "Weekly" });
            ModelList.Add(new Temp { Id = 3, Name = "Monthly" });
            ModelList.Add(new Temp { Id = 4, Name = "Every X Kilometer" });

            WeekDayList = new List<DayOfWeek>();
            WeekDayList.Add(DayOfWeek.Monday);
            WeekDayList.Add(DayOfWeek.Tuesday);
            WeekDayList.Add(DayOfWeek.Wednesday);
            WeekDayList.Add(DayOfWeek.Thursday);
            WeekDayList.Add(DayOfWeek.Friday);
            WeekDayList.Add(DayOfWeek.Saturday);
            WeekDayList.Add(DayOfWeek.Sunday);

            MonthDayList = new List<int>();

            for (int i = 1; i <= 31; i++)
            {
                MonthDayList.Add(i);
            }

            SelectedAssetList = new List<Temp>();
            this.RunStackLayout.IsVisible = false;
            this.TimeStackLayout.IsVisible = false;

            this.BindingContext = this;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
        private void removeAsset_Clicked(object sender, EventArgs e)
        {
            var tempList = SelectedAssetList;
            tempList.Remove(tempList.Where(x => x.Id == (int)(sender as Button).CommandParameter).First());
            SelectedAssetList = new List<Temp>(tempList);
        }

        private void TapLabelGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (AssetPicker.SelectedItem != null)
            {
                if(SelectedAssetList.Where(x => x.Id == ((Temp)AssetPicker.SelectedItem).Id).FirstOrDefault() != null)
                {
                    DisplayAlert("Alert", "Asset is already selcted", "Ok");
                    return;
                }

                var tempList = SelectedAssetList;
                tempList.Add((Temp)AssetPicker.SelectedItem);
                SelectedAssetList = new List<Temp>(tempList);
            }
            else
            {
                DisplayAlert("Alert", "Selected Asset Cannot be Null", "Ok");
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedModelId = ((Temp)ModelPicker.SelectedItem).Id;

            if (selectedModelId != 4)
            {
                this.TimeStackLayout.IsVisible = true;
                this.RunStackLayout.IsVisible = false;

                switch (selectedModelId)
                {
                    case 1:
                        DayStackLayout.IsVisible = true;
                        WeekStackLayout.IsVisible = false;
                        MonthStackLayout.IsVisible = false;
                        break;
                    case 2:
                        DayStackLayout.IsVisible = false;
                        WeekStackLayout.IsVisible = true;
                        MonthStackLayout.IsVisible = false;
                        break;
                    case 3:
                        DayStackLayout.IsVisible = false;
                        WeekStackLayout.IsVisible = false;
                        MonthStackLayout.IsVisible = true;
                        break;
                }
            }
            else
            {
                this.RunStackLayout.IsVisible = true;
                this.TimeStackLayout.IsVisible = false;
            }
        }

        private void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            if (TaskPicker.SelectedItem == null || SelectedAssetList.Count == 0 || ModelPicker.SelectedItem == null)
            {
                DisplayAlert("Alert", "All feilds are required!", "Ok");
                return;
            }

            var selectedModelId = ((Temp)ModelPicker.SelectedItem).Id;

            if (selectedModelId == 1 || selectedModelId == 2 || selectedModelId == 3)
            {
                if (StartDatePicker.Date >= EndDatePicker.Date)
                {
                    DisplayAlert("Alert", "End Date must greater than Start Date!", "Ok");
                    return;
                }

                PMTaskRequest pMTaskRequest = new PMTaskRequest();
                pMTaskRequest.TaskId = ((Temp)TaskPicker.SelectedItem).Id;
                pMTaskRequest.AssetId = new List<long>();

                foreach (var asset in SelectedAssetList)
                {
                    pMTaskRequest.AssetId.Add(asset.Id);
                }

                pMTaskRequest.StartDate = StartDatePicker.Date;
                pMTaskRequest.EndDate = EndDatePicker.Date;

                switch (selectedModelId)
                {
                    case 1:
                        pMTaskRequest.DayIntervalToRun = int.Parse(DaystoRunEditor.Text);
                        break;

                    case 2:
                        pMTaskRequest.DayofWeektoRun = (DayOfWeek) DayofWeekPicker.SelectedItem;
                        pMTaskRequest.NumbersofWeekstoRun = int.Parse(WeekstoRunEditor.Text);
                        break;

                    case 3:
                        pMTaskRequest.DayofMonthtoRun = int.Parse(DayofMonthPicker.SelectedItem.ToString());
                        pMTaskRequest.NumberofMonthstoRun = int.Parse(MonthstoRunEditor.Text);
                        break;

                    default:
                        break;
                }

                Console.WriteLine(pMTaskRequest.ToString());
                _ = StorePMTaskAsync(pMTaskRequest);
            }
        }

        GetService getService = new GetService();

        private async Task StorePMTaskAsync(PMTaskRequest pMTaskRequest)
        {
            var result = await getService.StorePMTask(pMTaskRequest);
            
            if (result == System.Net.HttpStatusCode.OK)
            {
                await DisplayAlert("Alert", "PM Tasks are stored!", "Ok");

                App.Current.MainPage = new NavigationPage();
                _ = App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }
    }
}