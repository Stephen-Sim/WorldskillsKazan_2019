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
        public AssetTransferHistoryForm(long ID)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}