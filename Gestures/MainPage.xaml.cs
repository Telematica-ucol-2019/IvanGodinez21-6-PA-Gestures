using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gestures
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnImageButtonClicked(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;
            await this.Navigation.PushModalAsync(new ImagePage(imageButton));
        }
        private async void OnImageButtonClickedAlternative(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;
            await this.Navigation.PushModalAsync(new ImageSwipePage(imageButton));
        }
    }
}
